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

        public ActionResult<Book> singleGet(int id);

        public Task Post(Book book);

        public Task Update(int id, Book book);

        public Task Delete(int? id);


    }
}