using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Shopify.Models;

namespace Shopify.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ShopifyContext _context;
        private readonly IWebHostEnvironment _environment;


        public HomeController(ShopifyContext context, IWebHostEnvironment environment)
        {
            
            _context = context;
            _environment = environment;
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(ProductModel product, List<IFormFile> ImageFiles)
        {
            if (ImageFiles != null && ImageFiles.Count > 0)
            {
                var uploadFolder = @"E:\Shopify Images";
                Directory.CreateDirectory(uploadFolder);

                foreach (var file in ImageFiles)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    var filePath = Path.Combine(uploadFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    product.Images.Add(new ImageModel
                    {
                        ImagePath = uniqueFileName
                    });
                }
            }

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Create");
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
    }
}
