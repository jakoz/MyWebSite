using Microsoft.AspNet.Identity;
using MyWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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