using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using UpdatedLogReg.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using UpdatedDojoDatchi.Models;

namespace UpdatedLogReg.Controllers
{
    public class LogRegController : Controller
{
    private MonsterContext dbContext;

    // here we can "inject" our context service into the constructor
    public LogRegController(MonsterContext context)
    {
        dbContext = context;
    }

//this is the login register page
    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        System.Console.WriteLine("****************Main Page");
        return View();
    }
    [HttpGet]
    [Route("register")]
    public IActionResult Register()
    {
        System.Console.WriteLine("****************Register");
        return View();
    }

    [HttpGet]
    [Route("login")]
    public IActionResult Login()
    {
        System.Console.WriteLine("****************login");
        return View();
    }

//this is what happens when you register
    [HttpPost("doesregister")]
    public IActionResult DoesRegister(UserObject user)
    {
        System.Console.WriteLine("****************Does Register");
        // Check initial ModelState
        if(ModelState.IsValid)
        {
            // If a User exists with provided email
            if(dbContext.Users.Any(u => u.Email == user.Email))
            {
                System.Console.WriteLine("****************Email in use");
                // Manually add a ModelState error to the Email field, with provided error message
                ModelState.AddModelError("Email", "Email already in use!");
                // You may consider returning to the View at this point
                return View("Index", user);
            }
            else
            {
                System.Console.WriteLine("****************Creating User");
                // Initializing a PasswordHasher object, providing our User class as its
                PasswordHasher<UserObject> Hasher = new PasswordHasher<UserObject>();
                user.Password = Hasher.HashPassword(user, user.Password);
                
                //Save your user object to the database
                dbContext.Add(user);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("userid", user.UserId);

                //create monster
                MonsterObject myMonster = new MonsterObject();
                myMonster.UserId = user.UserId;
                dbContext.Add(myMonster);
                dbContext.SaveChanges();

                return Redirect("/monster"); //This doesn't exist yet
            }
        }
        // other code
        else
        {
            System.Console.WriteLine("****************User Not Created");
            return View("Index", user);
        }
    }

    //this is what happens when you login
    [HttpPost("doeslogin")]
    public IActionResult DoesLogin(LoginUser userSubmission)
    {
        System.Console.WriteLine("****************Logging in");
        if(ModelState.IsValid)
        {
            // If inital ModelState is valid, query for a user with provided email
            var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.email);
            // If no user exists with provided email
            if(userInDb == null)
            {
                System.Console.WriteLine("****************No email");
                // Add an error to ModelState and return to View!
                ModelState.AddModelError("Email", "Yeah, I've never seen this email before.");
                return View("Index");
            }
            
            // Initialize hasher object
            var hasher = new PasswordHasher<LoginUser>();
            
            // varify provided password against hash stored in db
            var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.password);
            
            // result can be compared to 0 for failure
            if(result == 0)
            {
                System.Console.WriteLine("****************Wrong Password");
                // handle failure (this should be similar to how "existing email" is handled)
                ModelState.AddModelError("Email", "How did you forget your password?");
                return View("Index");
            }
            System.Console.WriteLine("****************Successfully logged in");
            var user = dbContext.Users.SingleOrDefault(u => u.Email == userSubmission.email);
            HttpContext.Session.SetInt32("userid", user.UserId);
            return Redirect("/success"); //This doesn't exist yet
        }
        else
        {
            System.Console.WriteLine("****************not logged in");
            return View ("Index");
        }
    }

    [HttpGet]
    [Route("success")]
    public IActionResult Success()
    {
        System.Console.WriteLine("****************Success!");
        if (HttpContext.Session.GetInt32("userid") != null)
        {
            System.Console.WriteLine("****************Actual success!");
            int? index = HttpContext.Session.GetInt32("userid");
            MonsterObject userMonster = dbContext.Monsters
                                .Where(m => m.UserId == index)
                                .FirstOrDefault();
            userMonster.img = "~/images/baseimg.gif";
            userMonster.Reaction = "It's a good thing you didn't forget about your monster!";
            dbContext.SaveChanges();
            return Redirect("/monster");
        }
        else
        {
            System.Console.WriteLine("****************Secret failure");
            return Redirect("/");
        }
    }

    [HttpGet]
    [Route("logout")]
    public IActionResult Logout()
    {
        System.Console.WriteLine("****************Logged out");
        HttpContext.Session.Clear();
        return Redirect("/");
    }
}
}