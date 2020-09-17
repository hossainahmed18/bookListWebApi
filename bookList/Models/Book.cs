using System;
using System.ComponentModel.DataAnnotations;

namespace bookList.Models
{
    public class Book
    {

        public int BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public string publisherName {get; set;}
        

    }
}