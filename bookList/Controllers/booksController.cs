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

        [HttpGet("{id}")]
        public ActionResult<Book> getSingleBook(int id){
            var book= _repo.singleGet(id);
            return Ok(book);
        }

       
        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(Book book){
            if(book == null){
                return NotFound("Getting null for student");
            }
            await _repo.Post(book);
            return Ok("Book Added");
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(int id,Book book){
            if(book == null){
                return NotFound("Getting null for student");
            }
             await _repo.Update(id,book);
            return Ok("Book Updated");
        }

       [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int? id){
            if(id == null){
                return NotFound("Getting null for student");
            }
            await _repo.Delete(id);
            return Ok("Book Deleted");
        }

        

    }
}