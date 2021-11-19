using PracaInzynierska.Application.DTO.Author;
using PracaInzynierskaAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.Services.Author
{
    public interface IAuthorService
    {
        public ResponseModel<List<AuthorDTO>> GetAllAuthors();
        public ResponseModel<List<AuthorDTO>> GetAuthorsToApprove();
        public ResponseModel<List<AuthorDTO>> FindAuthorsByName(List<string> list);
        public ResponseModel<List<AuthorDTO>> GetAuthorsByIds(List<Guid> list);
        public ResponseModel<AuthorDTO> GetAuthorById(Guid id);
        public ResponseModel<Guid> AddAuthor(AuthorDTO author);
        public ResponseModel<bool> ApproveAuthor(AuthorDTO author);
        public ResponseModel<Guid> UpdateAuthor(AuthorDTO author);
        public ResponseModel<List<Guid>> SoftDeleteAuthors(List<AuthorDTO> authors);
        public ResponseModel<Guid> DeleteAuthor(Guid id);
    }
}
