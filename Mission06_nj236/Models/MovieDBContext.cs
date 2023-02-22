using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_nj236.Models
{
    public class MovieDBContext : DbContext
    {
        //My super cool constructor
        public MovieDBContext (DbContextOptions<MovieDBContext> options) : base (options)
        {
            //Not using the contructor for anything fancy right now

        }

        public DbSet<MovieInfo> MovieInfos { get; set; }
        
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryID = 2, CategoryName = "Comedy" },
                new Category { CategoryID = 3, CategoryName = "Drama" },
                new Category { CategoryID = 4, CategoryName = "Family" },
                new Category { CategoryID = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryID = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryID = 7, CategoryName = "Television" },
                new Category { CategoryID = 8, CategoryName = "VHS" }
                );

            mb.Entity<MovieInfo>().HasData(
                new MovieInfo
                {
                    MovieID = 1,
                    CategoryID = 4,
                    Title = "The Iron Giant",
                    Year = "1999",
                    Director = "Brad Bird",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = "Prepare to cry"
                },
                new MovieInfo
                {
                    MovieID = 2,
                    CategoryID = 1,
                    Title = "TENET",
                    Year = "2020",
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "Inversion"
                },
                new MovieInfo
                {
                    MovieID = 3,
                    CategoryID = 3,
                    Title = "12 Angry Men",
                    Year = "1957",
                    Director = "Sidney Lumet",
                    Rating = "G",
                    Edited = false,
                    LentTo = "Nate J",
                    Notes = ""
                }
            );
        }
    }
}
