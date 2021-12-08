using AutoMapper;
using PracaInzynierska.Application.DTO.Author;
using PracaInzynierska.Application.DTO.Book;
using PracaInzynierska.Application.DTO.Book_Author;
using PracaInzynierska.Application.DTO.Book_User;
using PracaInzynierska.Application.DTO.Category;
using PracaInzynierska.Application.DTO.Comment;
using PracaInzynierska.Application.DTO.Language;
using PracaInzynierska.Application.DTO.Publisher;
using PracaInzynierska.Application.DTO.User;
using PracaInzynierska.Application.DTO.UserPermission;
using PracaInzynierskaAPI.Entities.Author;
using PracaInzynierskaAPI.Entities.Book;
using PracaInzynierskaAPI.Entities.Book_Author;
using PracaInzynierskaAPI.Entities.Book_User;
using PracaInzynierskaAPI.Entities.Category;
using PracaInzynierskaAPI.Entities.Comment;
using PracaInzynierskaAPI.Entities.Language;
using PracaInzynierskaAPI.Entities.Publisher;
using PracaInzynierskaAPI.Entities.User;
using PracaInzynierskaAPI.Entities.UserPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.Mapper
{
    public static class AutoMapperConfig
    {
        public static IMapper InitMap() => new MapperConfiguration(config =>
        {
            config.CreateMap<AuthorDbModel, AuthorDTO>();
            config.CreateMap<AuthorDTO, AuthorDbModel>();

            config.CreateMap<BookDbModel, BookDTO>();
            config.CreateMap<BookDTO, BookDbModel>();

            config.CreateMap<Book_AuthorDbModel, Book_AuthorDTO>();
            config.CreateMap<Book_AuthorDTO, Book_AuthorDbModel>();

            config.CreateMap<Book_UserDbModel, Book_UserDTO>();
            config.CreateMap<Book_UserDTO, Book_UserDbModel>();

            config.CreateMap <CategoryDbModel, CategoryDTO>();
            config.CreateMap<CategoryDTO, CategoryDbModel>();

            config.CreateMap<CommentDbModel, CommentDTO>();
            config.CreateMap<CommentDTO, CommentDbModel>();

            config.CreateMap<LanguageDbModel, LanguageDTO>();
            config.CreateMap<LanguageDTO, LanguageDbModel>();

            config.CreateMap<PublisherDbModel, PublisherDTO>();
            config.CreateMap<PublisherDTO, PublisherDbModel>();

            config.CreateMap<UserDbModel, UserDTO>();
            config.CreateMap<UserDTO, UserDbModel>();
            config.CreateMap<UserDbModel, UserInfoDTO>();

            config.CreateMap<UserPermissionDbModel, UserPermissionDTO>();
            config.CreateMap<UserPermissionDTO, UserPermissionDbModel>();

            config.CreateMap<RegisterUser, UserDTO>();
        }).CreateMapper();
    }
}
