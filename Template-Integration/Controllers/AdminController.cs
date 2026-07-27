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
            if (ModelState.IsValid)
            {
                if (model.ProductImageFile != null)
                {
                    string folder = Path.Combine(_env.WebRootPath, "images", "products");

                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    string fileName = Guid.NewGuid().ToString() +
                                      Path.GetExtension(model.ProductImageFile.FileName);

                    string filePath = Path.Combine(folder, fileName);

                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ProductImageFile.CopyTo(stream);
                    }

                    model.ProductImage = "/images/products/" + fileName;
                }

                _Db.AddProducts.Add(model);

                _Db.SaveChanges();

                TempData["Success"] = "Product Added Successfully";

                return RedirectToAction("ProductList");

            }

            return View();
        }
        public IActionResult ProductList()
        {
            var products = _Db.AddProducts.ToList();
            return View(products);
        }

    }

}
