using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookList.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using bookList.repositories.interfaces;

namespace bookList.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController: ControllerBase{
        private  IBookRepository _repo;
        public BooksController(IBookRepository repo){
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>>GetValues(){
            var allBooks= _repo.Get();
            return Ok(allBooks);
        }

        [Route("api/books/{bookId}")]
        [HttpGet]
        public ActionResult<Book> getSingleBook(int bookId){
            var book= _repo.singleGet(bookId);
            return Ok(book);
        }

    }
}