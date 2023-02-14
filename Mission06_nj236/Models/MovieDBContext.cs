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
    }
}
