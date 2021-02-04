using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private IProductService _productService;

        public ProductsController(IProductService productAppService)
        {
            _productService = productAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _productService.GetProducts();
            return View(result);
        }

        [HttpGet()]
        public IActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//Validação de Falsificação entre sites CSRF
        public IActionResult Create([Bind("Id,Name,Description,Price")] ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);

                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var productVM = await _productService.GetById(id);

            if(productVM == null) return NotFound();

            return View(productVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//Validação de Falsificação entre sites CSRF
        public IActionResult Edit([Bind("Id,Name,Description,Price")] ProductViewModel productVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _productService.Update(productVm);
                }
                catch (Exception)
                {
                    throw;
                }


                return RedirectToAction(nameof(Index));
            }

            return View(productVm);
        }

        [HttpGet()]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var productVM = await _productService.GetById(id);

            if (productVM == null) return NotFound();

            return View(productVM);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var productVM = await _productService.GetById(id);

            if (productVM == null) return NotFound();

            return View(productVM);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _productService.Remove(id);

            return RedirectToAction("Index");
        }
    }
}
