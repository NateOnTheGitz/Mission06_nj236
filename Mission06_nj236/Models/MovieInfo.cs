﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_nj236.Models
{
    public class MovieInfo
    {
        [Key]
        [Required]
        public int MovieID { get; set; }

        //Build Foreign Key Relationship
        [Required]
        public int CategoryID { get; set; }
        public Category Category { get; set; }


        [Required]
        public string Title { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        public string Notes { get; set; }
    }
}
