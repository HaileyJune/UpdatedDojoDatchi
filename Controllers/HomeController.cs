using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UpdatedDojoDatchi.Models;
using UpdatedLogReg.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace UpdatedDojoDatchi.Controllers
{
    public class HomeController : Controller
    {
        private MonsterContext dbContext;
        public HomeController(MonsterContext context)
    {
        dbContext = context;
    }
        // GET: /monster/
        [HttpGet]
        [Route("monster")]
        public IActionResult Monster()
        {
            int? index = HttpContext.Session.GetInt32("userid");
            MonsterObject userMonster = dbContext.Monsters
                                .Where(m => m.UserId == index)
                                .FirstOrDefault();
            return View(userMonster);
        }

        [HttpGet]
        [Route("monster/feed")]
        public IActionResult Feed()
        {
            int? index = HttpContext.Session.GetInt32("userid");
            MonsterObject userMonster = dbContext.Monsters
                                .Where(m => m.UserId == index)
                                .FirstOrDefault();
            userMonster.Feed();
            dbContext.SaveChanges();
            return Redirect("/monster");
        }

        [HttpGet]
        [Route("monster/play")]
        public IActionResult Play()
        {
            int? index = HttpContext.Session.GetInt32("userid");
            MonsterObject userMonster = dbContext.Monsters
                                .Where(m => m.UserId == index)
                                .FirstOrDefault();
            userMonster.Play();
            dbContext.SaveChanges();
            return Redirect("/monster");
        }

        [HttpGet]
        [Route("monster/work")]
        public IActionResult Work()
        {
            int? index = HttpContext.Session.GetInt32("userid");
            MonsterObject userMonster = dbContext.Monsters
                                .Where(m => m.UserId == index)
                                .FirstOrDefault();
            userMonster.Work();
            dbContext.SaveChanges();
            return Redirect("/monster");
        }

        [HttpGet]
        [Route("monster/sleep")]
        public IActionResult Sleep()
        {
            int? index = HttpContext.Session.GetInt32("userid");
            MonsterObject userMonster = dbContext.Monsters
                                .Where(m => m.UserId == index)
                                .FirstOrDefault();
            userMonster.Sleep();
            dbContext.SaveChanges();
            return Redirect("/monster");
        }
        
        [HttpGet]
        [Route("monster/reset")]
        public IActionResult Reset()
        {
            int? index = HttpContext.Session.GetInt32("userid");
            MonsterObject userMonster = dbContext.Monsters
                                .Where(m => m.UserId == index)
                                .FirstOrDefault();
            userMonster.reset();
            dbContext.SaveChanges();
            return Redirect("/monster");
        }
    }
}
