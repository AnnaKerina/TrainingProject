using System;
using System.Web.Mvc;
using Blog.Store.Entity;
using Models;

namespace Routing.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private IDatabaseContext _dbContext;

        public HomeController(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Index()
        {
            var user = new User
            {
                Name = "Ivan",
                DateCreated = DateTime.Now,
                Age = 10,
                Surname = "Ivanov",
                Summary = "ssss"
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return View();
        }

        public ActionResult SecondPage()
        {
            return View();
        }

        public ActionResult ThirdPage()
        {
            return View();
        }

    }
}
