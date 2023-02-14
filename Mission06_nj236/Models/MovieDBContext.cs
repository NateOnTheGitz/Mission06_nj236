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
        
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieInfo>().HasData(
                new MovieInfo
                {
                    MovieID = 1,
                    Category = "Animated",
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
                    Category = "Action/Adventure",
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
                    Category = "Drama",
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
