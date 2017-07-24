using System;
using System.Collections.Generic;
using Book.Domain.Interface;
using Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;

namespace Livraria.Api.Tests
{
    [TestClass]
    public class BookTest
    {
        private IBookService _bookService;
        public BookTest()
        {
            var container = new Container();

            InitializeContainer(container);

            container.Verify();

            _bookService = container.GetInstance<IBookService>();
        }

        private void InitializeContainer(Container container)
        {
            Book.Infra.IoC.BootStrapper.RegisterNoScope(container);
        }

        [TestMethod]
        public void InsertBook()
        {
            var inserted = _bookService.Insert(new BookModel()
            {
                Name = "Suma Teológica UPDATED",
                Edition = 52,
                ISBN = 12345678,
                Description = "Suma teológica de São Tomás de Aquino",
                Authors = new List<AuthorModel>()
                {
                    new AuthorModel()
                    {
                        Name = "São Tomás de Aquino",
                        BirthDate = new DateTime(1225, 3, 7)
                    }
                },
                Publisher = new PublisherModel()
                {
                    Name = "Loyola",
                    Address = "Rua Mil Oitocentos e Vinte e Dois, 341 - Ipiranga, São Paulo",
                    ZipCode = "04216-000"
                }

            });

            Assert.IsTrue(inserted);
        }

        [TestMethod]
        public void UpdateBook()
        {
            var book = new BookModel()
            {
                Id = "5971764d2d5f4c0b30b5b027",
                Name = "Suma Teológica EDITADO4",
                Edition = 52,
                ISBN = 12345678,
                Description = "Suma teológica de São Tomás de Aquino UPDATED",
                Authors = new List<AuthorModel>()
                {
                    new AuthorModel()
                    {
                        Name = "São Tomás de Aquino",
                        BirthDate = new DateTime(1225, 3, 7)
                    }
                },
                Publisher = new PublisherModel()
                {
                    Name = "Loyola",
                    Address = "Rua Mil Oitocentos e Vinte e Dois, 341 - Ipiranga, São Paulo",
                    ZipCode = "04216-000"
                }

            };

            _bookService.Update(book);

            //Assert.IsTrue();
        }
        
        [TestMethod]
        public void DeleteBook()
        {
            var id = "597161622d5f4c1e6c66a4c4";

            var deleted = _bookService.Delete(id);

            Assert.IsTrue(deleted);
        }
    }
}
