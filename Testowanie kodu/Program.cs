using PracaInzynierskaAPI.DataBase.Context;
using PracaInzynierskaAPI.DataBase.Repository.Book_User;
using PracaInzynierskaAPI.Entities.Book_User;
using System;

namespace Testowanie_kodu
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PInzDataBaseContext();

            var bookUserRepo = new Book_UserRepository(context);

            var bookUser = new Book_UserDbModel
            {
                Id = Guid.NewGuid(),
                IsBuildIn = true,
                CreatedAt = DateTime.Now,
                UserId = Guid.NewGuid(),
                BookId = Guid.NewGuid()
            };

            Console.WriteLine(bookUserRepo.Add(bookUser));
        }
    }
}
