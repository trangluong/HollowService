using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HollowService.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HollowService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //DbContextOptions options;
            //string dbName = "TestDatabase.db";
            //if (File.Exists(dbName))
            //{
            //    File.Delete(dbName);
            //}
            //using (var dbContext = new MyDBContext(options))
            //{
            //    Ensure database is created
            //    dbContext.Database.EnsureCreated();
            //    if (!dbContext.Employees.Any())
            //    {
            //        dbContext.Employees.AddRange(new Employee[]
            //            {
            //                 new Employee{ Id=1, FirstName="Trang", LastName="Luong", Title="Senior consultant" },
            //                 new Employee{ Id=2, FirstName="Bao", LastName="Ngo", Title="Senior architect"  },
            //                 new Employee{ Id=3, FirstName="Nghia", LastName="Le", Title="Consultant"  },
            //                   new Employee{ Id=4, FirstName="Quan", LastName="Ngueyn", Title="Consultant"  }
            //            });
            //        dbContext.SaveChanges();
            //    }
            //}
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
