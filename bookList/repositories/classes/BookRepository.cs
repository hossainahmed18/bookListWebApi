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

        ActionResult<Book> singleGet(int id){
            return _mainContext.books.FirstOrDefault(b=>b.BookId==id);
        }


        public async void Post(Book book){
            if(book){

            }

        }
    }
}