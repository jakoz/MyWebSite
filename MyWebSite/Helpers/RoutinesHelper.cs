using Microsoft.AspNet.Identity;
using MyWebSite.Controllers;
using MyWebSite.Models;
using MyWebSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebSite.Helpers
{
    public class RoutinesHelper
    {
        protected UserManager<ApplicationUser> UserManager { get; set; }
        public ApplicationDbContext _context;

        public RoutinesHelper()
        {
            _context = new ApplicationDbContext();
        }

       
        
    }
}