﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebSite.Models
{
    public class TypeOfActivity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public TypeOfActivity()
        {

        }
        public TypeOfActivity(string name)
        {
            this.Name = name;
        }
    }
}