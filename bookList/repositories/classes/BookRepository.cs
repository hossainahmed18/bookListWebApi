using bookList.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using bookList.Models;
using bookList.repositories.interfaces;

namespace bookList.repositories.classes
{
    public class BookRepository : IBookRepository{
        private MainContext _mainContext; 

        public BookRepository (MainContext mainContext){
           _mainContext = mainContext;
        }

    
        public ActionResult<IEnumerable<Book>> Get(){
            var book = _mainContext.books.ToList();
            return book;
        }

        public ActionResult<Book> singleGet(int id){
            return _mainContext.books.FirstOrDefault(b=>b.BookId==id);
        }


        public async Task Post(Book book){
            if(book == null){
                throw new ArgumentNullException(nameof(Book));
            }
            await _mainContext.books.AddAsync(book);
            await _mainContext.SaveChangesAsync();

        }

        public async Task Update(int id,Book book){
            if(book == null){
                throw new ArgumentNullException(nameof(Book));
            }
            Book existingBook= _mainContext.books.FirstOrDefault(b=>b.BookId==id);

            if(existingBook==null){
                throw new ArgumentNullException(nameof(existingBook));
            }
            existingBook.BookName = book.BookName;
            existingBook.AuthorName = book.AuthorName;
            existingBook.publisherName = book.publisherName;

            _mainContext.Attach(existingBook).State= Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _mainContext.SaveChangesAsync();

        }

        public async Task Delete(int? id){
            if(id == null){
                throw new ArgumentNullException(nameof(Book));
            }
            Book existingBook= _mainContext.books.FirstOrDefault(b=>b.BookId==id);

            if(existingBook==null){
                throw new ArgumentNullException(nameof(existingBook));
            }
            _mainContext.books.Remove(existingBook);
            await _mainContext.SaveChangesAsync();
        }


    }
}