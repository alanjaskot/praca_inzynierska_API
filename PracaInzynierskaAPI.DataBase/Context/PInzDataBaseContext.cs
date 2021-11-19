using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using NLog;
using PracaInzynierskaAPI.Core.Base;
using PracaInzynierskaAPI.DataBase.EntitiesConfig.Author;
using PracaInzynierskaAPI.DataBase.EntitiesConfig.Book;
using PracaInzynierskaAPI.DataBase.EntitiesConfig.Book_Author;
using PracaInzynierskaAPI.DataBase.EntitiesConfig.Book_User;
using PracaInzynierskaAPI.DataBase.EntitiesConfig.Category;
using PracaInzynierskaAPI.DataBase.EntitiesConfig.Comment;
using PracaInzynierskaAPI.DataBase.EntitiesConfig.Language;
using PracaInzynierskaAPI.DataBase.EntitiesConfig.Publisher;
using PracaInzynierskaAPI.DataBase.EntitiesConfig.User;
using PracaInzynierskaAPI.DataBase.EntitiesConfig.UserPermission;
using PracaInzynierskaAPI.Entities.Author;
using PracaInzynierskaAPI.Entities.Book;
using PracaInzynierskaAPI.Entities.Book_Author;
using PracaInzynierskaAPI.Entities.Book_User;
using PracaInzynierskaAPI.Entities.Category;
using PracaInzynierskaAPI.Entities.Comment;
using PracaInzynierskaAPI.Entities.ImageCover;
using PracaInzynierskaAPI.Entities.Language;
using PracaInzynierskaAPI.Entities.NLog;
using PracaInzynierskaAPI.Entities.Publisher;
using PracaInzynierskaAPI.Entities.User;
using PracaInzynierskaAPI.Entities.UserPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.Context
{
    public class PInzDataBaseContext: DbContext, IPInzDataBaseContext
    {
        private readonly ILogger _logger;
        private IDbContextTransaction _transaction;

        public DbSet<AuthorDbModel> Authors { get; set; }
        public DbSet<BookDbModel> Books { get; set; }
        public DbSet<Book_AuthorDbModel> Book_Authors { get; set; }
        public DbSet<Book_UserDbModel> User_Books { get; set; }
        public DbSet<CategoryDbModel> Categories { get; set; }
        public DbSet<ImageCoverDbModel> ImageCovers { get; set; }
        public DbSet<LanguageDbModel> Languages { get; set; }
        public DbSet<PublisherDbModel> Publishers { get; set; }
        public DbSet<CommentDbModel> Comments { get; set; }
        public DbSet<UserDbModel> Users { get; set; }
        public DbSet<UserPermissionDbModel> UserPermissions { get; set; }
        public DbSet<NLogDbModel> NLogs { get; set; }

        public PInzDataBaseContext(DbContextOptions options): base(options)
        {
            var _logger = LogManager.GetCurrentClassLogger();
        }

        public PInzDataBaseContext()
        {
        }

        #region Config

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql("Host=localhost; Port=1511;Database=p_inz;Username=postgres; Password=admin");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AuthorModelEntityConfiguration());
            builder.ApplyConfiguration(new BookModelEntityConfiguration());
            builder.ApplyConfiguration(new Book_AuthorModelEntityConfiguration());
            builder.ApplyConfiguration(new Book_UserModelEntityConfiguration());
            builder.ApplyConfiguration(new CategoryModelEntityConfiguration());
            builder.ApplyConfiguration(new CommentModelEntityConfiguration());
            builder.ApplyConfiguration(new LanguageModelEntityConfiguration());
            builder.ApplyConfiguration(new PublisherModelEntityConfiguration());
            builder.ApplyConfiguration(new UserModelEntityConfiguration());
            builder.ApplyConfiguration(new UserPermissionModelEntityConfiguration());
        }

#endregion

        #region Saves

        private Tuple<bool, Exception> SaveChangesTest()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;

            try
            {
                base.SaveChanges();
            }
            catch (Exception err)
            {
                _logger.Error(err, "SaveChangesTest");
                return new Tuple<bool, Exception>(false, err);
            }
            finally
            {
                ChangeTracker.AutoDetectChangesEnabled = true;
            }

            return new Tuple<bool, Exception>(true, null); ;
        }

        public override int SaveChanges()
        {
            //_logger.Info("SaveChanges");

            try
            {
                AddTimeStamp();

                var saveChangesTestResult = SaveChangesTest();

                if (saveChangesTestResult.Item1)
                {
                    return base.SaveChanges();
                }
                else
                {
                    ChangeTracker
                        .Entries()
                        .Where(p => p.State == EntityState.Added || p.State == EntityState.Modified || p.State == EntityState.Deleted)
                        .ToList()
                        .ForEach(x => x.State = EntityState.Detached);

                    _logger.Info("SaveChangesTest");

                    throw new Exception(saveChangesTestResult.Item2.Message, saveChangesTestResult.Item2);
                }
            }
            catch (Exception err)
            {
                _logger.Error(err, "SaveChanges");
                throw;
            }
        }

        public override ChangeTracker ChangeTracker
        {
            get
            {
                return base.ChangeTracker;
            }
        }

        private void AddTimeStamp()
        {
            var createdEntities = new List<ICreated>();
            var lastModifiedEntities = new List<ILastModified>();
            var deletedEntities = new List<IDeleted>();

            foreach (var entry in ChangeTracker.Entries())
            {
                var isAdded = entry.State == EntityState.Added;
                var isModified = entry.State == EntityState.Modified;
                var isDeleted = entry.State == EntityState.Deleted;

                if (isAdded && entry.Entity is ICreated addedEntity)
                {
                    createdEntities.Add(addedEntity);
                }

                if ((isModified || isAdded) && entry.Entity is ILastModified modifiedEntity)
                {
                    lastModifiedEntities.Add(modifiedEntity);
                }

                foreach (var item in createdEntities)
                {
                    if (item.CreatedAt == default(DateTime))
                        item.CreatedAt = DateTime.Now;
                }
                foreach (var item in lastModifiedEntities)
                {
                    item.LastModifiedAt = DateTime.Now;
                }
                foreach (var item in deletedEntities)
                {
                    if ((isDeleted) && entry.Entity is IDeleted deletedEntity)
                    {
                        if ((entry.Entity as IEntity).IsBuildIn)
                        {
                            _logger.Warn($"Próba usunięcia wbudowanego rekordu {(entry.Entity as IEntity).Id} ");
                            entry.State = EntityState.Unchanged;
                        }
                        else if ((bool)deletedEntity.IsDeleted)
                        {
                            deletedEntities.Add(deletedEntity);
                            entry.State = EntityState.Unchanged;
                        }
                    }
                }

            }
        }
        #endregion

        #region Transactions

        public void BeginTransaction()
        {
            try
            {
                if (_transaction == null)
                    _transaction = Database.BeginTransaction();
            }
            catch (Exception err)
            {
                _logger.Error(err, "AppDbContext.BeginTransaction");
            }
        }

        public void CommitTransaction()
        {
            try
            {
                if (_transaction != null)
                {
                    _transaction.Commit();
                    _transaction.Dispose();
                    _transaction = null;
                }
            }
            catch (Exception err)
            {
                _logger.Error(err, "AppDbContext.CommitTransaction");
            }
        }

        public void RollBackTransaction()
        {
            try
            {
                if (_transaction != null)
                {
                    _transaction.Rollback();
                    _transaction.Dispose();
                    _transaction = null;
                }
            }
            catch (Exception err)
            {
                _logger.Error(err, "AppDbContext.RollbackTransaction");
            }
        }

        #endregion
    }
}
