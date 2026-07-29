using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Template_Integration.Conection;
using Template_Integration.Models;
namespace Template_Integration.Controllers
{
    public class IndexController(App _Db) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About() => View();
        public IActionResult Pharmacy() => View();
        public IActionResult Grocery() => View();
        public IActionResult Product()
        {
            var data = _Db.AddProducts.ToList();
            return View(data);
            
        }
        public IActionResult ProductDetails() => View();
        public IActionResult Wishlist() => View();
        public IActionResult Cart() => View();
        public IActionResult Checkout() => View();
        public IActionResult Store() => View();
        public IActionResult Portfolio() => View();
        public IActionResult PortfolioDetails() => View();
        public IActionResult Faq() => View();
        public IActionResult ComingSoon() => View();
        public IActionResult Error() => View();
        public IActionResult Blog() => View();
        public IActionResult BlogGrid() => View();
        public IActionResult BlogDetails() => View();
        public IActionResult Contact() => View();
        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(Contact c)
        {
            if (!ModelState.IsValid)
                return View(c);
            _Db.ContactForm.Add(c);
            _Db.SaveChanges();
            ModelState.Clear();
            return View();
        }
        public IActionResult Login() => View();
        [HttpPost]
        
        public IActionResult Login(Register R)
        {
           

            var user = _Db.RegisterForm.FirstOrDefault(x =>
                x.Email == R.Email);
            if (user != null && user.Password == R.Password && user.Role == "Owner")
            {
                HttpContext.Session.SetString("Sessionid", user.Id.ToString());
                HttpContext.Session.SetString("Sessionname", user.Name);

                return RedirectToAction("Dashboard");
            }
            else if (user != null && user.Password == R.Password && user.Role == "User")
            {
                HttpContext.Session.SetString("Sessionid", user.Id.ToString());
                HttpContext.Session.SetString("Sessionname", user.Name);

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login");
            }

            
        }
        public IActionResult Register() => View();
        [HttpPost]
        public IActionResult Register(Register R)
        {
            if(R.Password != R.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Passwords do not match.");
                return View(R);
            }
            if (!ModelState.IsValid)
                return View(R);
            var emailExists = _Db.RegisterForm.Any(x => x.Email == R.Email);

            if (emailExists)
            {
                ModelState.AddModelError("Email", "Email already registered.");
                return View(R);
            }
            _Db.RegisterForm.Add(R);
            _Db.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        public IActionResult ReturnPolicy() => View();
        public IActionResult PrivacyPolicy() => View();
    }
}
