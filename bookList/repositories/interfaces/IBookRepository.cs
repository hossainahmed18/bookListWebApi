using bookList.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookList.repositories.interfaces
{
    public interface IBookRepository
    {
        public ActionResult<IEnumerable<Book>> Get();

        ActionResult<Book> singleGet(int id);

        public void Post(Book book);

        public void Update(Book book);

        public void Delete(int id);


    }
}