using bookList.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace bookList.Context
{
    public class MainContext: DbContext{
        public MainContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Book>books{set;get;}

    }
}