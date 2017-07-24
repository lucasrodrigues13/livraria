using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Domain.Interface
{
    public interface IBookService
    {
        bool Insert(BookModel book);
        List<BookModel> Get();

        BookModel Get(string id);
        BookModel Update(BookModel book);
        bool Delete(string id);
    }
}
