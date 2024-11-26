using GithubActionsDemoApp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas
{
    public class TestBase
    {
        protected ApplicationDbContext BuildContext(string nombreDB)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(nombreDB).Options;

            var dbContext = new ApplicationDbContext(options);
            return dbContext;
        }
    }
}
