using Microsoft.AspNetCore.Mvc;
using Inventory.ArqLimpia.BL.Interfaces;
using Inventory.ArqLimpia.BL.DTOs;

namespace Inventory.Web.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductBL _productBL;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IProductBL productBL,IWebHostEnvironment webHostEnvironment)
        {
            _productBL = productBL;
             _webHostEnvironment = webHostEnvironment;

        }
        // GET: ProductController
        public async Task<IActionResult> Index(FindProductsOutputDTOs Pproducts)
        {
            var list = await _productBL.Find(Pproducts);
            return View(list);
        }


        // GET: ProductController/Details/5
        public  async  Task < ActionResult> Details(int Id)
        {
            FindByIdDTOs findById = new FindByIdDTOs()
            {
            Id = Id
           };
            FindOneProductsOutputDTOs Pproduct = await _productBL.FindOne(findById);
            return View(Pproduct);
        }


        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.ErrorMenssge = "";
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        public async Task <ActionResult> Create (ImageInputDTO pProducts)
        {
            try
            {
                string fileName = null;

                CreateProductsInputDTOs product = new CreateProductsInputDTOs(){
                    ProductName = pProducts.ProductName,
                    Description = pProducts.Description,
                    Price = pProducts.Price,
                    Stock = pProducts.Stock
                };

                if(pProducts.ImageUrl != null){
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(pProducts.ImageUrl.FileName);
                    string filePath = Path.Combine(uploadsFolder, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                    await pProducts.ImageUrl.CopyToAsync(fileStream);
                    }
                    product.ImageUrl = fileName;;
                  
                }
                
                
                CreateProductsOutputDTOs result = await _productBL.CreateProduct(product);
                if (result != null) 
                return RedirectToAction(nameof(Index));
                else
                {
                    ViewBag.ErrorMessage = "No se pudo agregar el registro";
                    return View(pProducts);
                }
            }
            catch(Exception ex)
            {
                 ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
        //CONTINUACION 

        // GET: ProductController/Edit/5/Update 
        public async Task< ActionResult> Edit(int Id)
        {
            FindByIdDTOs findById = new FindByIdDTOs()
            {
            Id = Id
           };
            FindOneProductsOutputDTOs Pproduct = await _productBL.FindOne(findById);
            UpdateProductsInputDTOs product = new UpdateProductsInputDTOs(){
                ProductId = Pproduct.Id,
                ProductName = Pproduct.ProductName,
                Price = Pproduct.Price,
                Stock = Pproduct.Stock
            };
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int Id,UpdateProductsInputDTOs product )
        {
            try
            {
                UpdateProductsOutputDTOs editProduct = await _productBL.Update(product);
                if(editProduct != null){
                return RedirectToAction(nameof(Index));
                }else{
                    ViewBag.ErrorMessage = "Product not updated";
                    return View(product);
                }
            }
            catch (Exception )
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public async Task<ActionResult> Delete(int Id)
        {
            FindByIdDTOs IdProduct = new FindByIdDTOs(){
                Id = Id
            };
            FindOneProductsOutputDTOs product = await _productBL.FindOne(IdProduct);
            DeleteProductsInputDTOs pProduct = new DeleteProductsInputDTOs(){
                IdProduct = product.Id
            };
            return View(pProduct);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int Id, FindByIdDTOs Product)
        {
            try
            {
                DeleteProductsInputDTOs product = new DeleteProductsInputDTOs(){
                    IdProduct = Id
                };
                DeleteProductsOutputDTOs pProduct = await _productBL.Delete(product);
                if(pProduct.IsDeleted ==true){
                  return RedirectToAction(nameof(Index));
                }else{
                    ViewBag.ErrorMessage = "Not eliminated product";
                    return View(Product);
                }
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
    }
}
