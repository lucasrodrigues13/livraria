using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core.Model;
using Book.Domain.Interface;
using System.Web.Http.Cors;

namespace Livraria.Api.Controllers
{
    [EnableCors(origins: "http://localhost:49943", methods: "GET, POST, PUT, DELETE", headers: "*")]
    public class BookController : ApiController
    {
        private IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpPost]
        public void Post([FromBody] BookModel book)
        {
            _bookService.Insert(book);
        }

        [HttpGet]
        public List<BookModel> Get()
        {
            return _bookService.Get();
        }

        [HttpGet]
        public BookModel Get(string id)
        {
            return _bookService.Get(id);
        }

        [HttpPut]
        public BookModel Put([FromBody]BookModel book)
        {
            return _bookService.Update(book);
        }

        [HttpDelete]
        public bool Delete(string id)
        {
            return _bookService.Delete(id);
        }

    }
}
