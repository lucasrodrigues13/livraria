using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Domain.Interface;
using Core.Model;
using Core.Repository.MongoDB;
using MongoDB.Driver;

namespace Book.Domain.Service
{
    public class BookService : IBookService
    {
        private readonly IMongoDbRepository _bookRepository;
        public BookService(IMongoDbRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public bool Insert(BookModel book)
        {
            var entity =_bookRepository.AddOne(book);

            return entity.Success;
        }

        public List<BookModel> Get()
        {
            var entities = _bookRepository.GetAll<BookModel>();
           
            return entities.Entities.OrderBy(a => a.Name).ToList();
        }

        public BookModel Get(string id)
        {
            var filter = Builders<BookModel>.Filter.Where(a => a.Id == id);
            return _bookRepository.GetOne<BookModel>(filter).Entity;
        }

        public BookModel Update(BookModel book)
        {
            var filter = Builders<BookModel>.Filter.Where(a => a.Id == book.Id);
            var update = Builders<BookModel>.Update.Set(b => b.Authors[0].Name, book.Authors[0].Name)
                                                    .Set(b => b.Authors[0].BirthDate, book.Authors[0].BirthDate)
                                                    .Set(b => b.Authors[0].BirthDate, book.Authors[0].BirthDate)
                                                    .Set(b => b.Description, book.Description)
                                                    .Set(b => b.Edition, book.Edition)
                                                    .Set(b => b.Id, book.Id)
                                                    .Set(b => b.ISBN, book.ISBN)
                                                    .Set(b => b.Name, book.Name)
                                                    .Set(b => b.Publisher.Address, book.Publisher.Address)
                                                    .Set(b => b.Publisher.Name, book.Publisher.Name)
                                                    .Set(b => b.Publisher.ZipCode, book.Publisher.ZipCode);


            var entity = _bookRepository.UpdateOne(book.Id, update);

            return entity.Entity;
        }

        public bool Delete(string id)
        {
            return _bookRepository.DeleteOne<BookModel>(id).Result.Success;
        }
    }
}
