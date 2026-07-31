using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Template_Integration.Conection;
using Template_Integration.Models;

namespace Template_Integration.Controllers
{
    public class AdminController: Controller
    {
        private readonly IWebHostEnvironment _env;
        private App _Db;

        public AdminController(IWebHostEnvironment env, App context)
        {
            _env = env;
            _Db = context;
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Customers()
        {
            return View(_Db.RegisterForm.ToList());
        }
         public IActionResult Delete(int Id)
        {
         var DeleteData = _Db.RegisterForm.Find(Id);
            _Db.RegisterForm.Remove(DeleteData);
            _Db.SaveChanges();
            return RedirectToAction("Customers");
        }
        
        [HttpPost]
        public IActionResult UpdateCustomer([FromBody] Register model)
        {
            var user = _Db.RegisterForm.FirstOrDefault(x => x.Id == model.Id);

            if (user == null)
            {
                return Json(new { success = false });
            }

            user.Name = model.Name;
            user.Email = model.Email;
            user.Password = model.Password;
            user.Role = model.Role;

            _Db.SaveChanges();

            return Json(new { success = true });
        }
        public IActionResult AddProducts()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProducts(Product model)
        {
            if (model.ProductImageFile != null)
            {
                string folderPath = Path.Combine(_env.WebRootPath, "images");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string fileName = Path.GetFileName(model.ProductImageFile.FileName);
                string filePath = Path.Combine(folderPath, fileName);

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    model.ProductImageFile.CopyTo(fs);
                }

                // Save file name in database
                model.ProductImage = fileName;
            }

            _Db.AddProducts.Add(model);
            _Db.SaveChanges();
            ModelState.Clear();
            ViewBag.Message = "Product Added Successfully!";

            return View();

        }
        public IActionResult ProductList()
        {
            var products = _Db.AddProducts.ToList();
            return View(products);
        }

    }

}
