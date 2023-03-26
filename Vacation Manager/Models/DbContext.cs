using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Vacation_Manager.Data;

namespace Vacation_Manager.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }
    }
}
