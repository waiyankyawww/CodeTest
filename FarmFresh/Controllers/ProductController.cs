using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmFresh.DAL;
using Microsoft.AspNetCore.Authorization;
using FarmFresh.Models.Repository;
using FarmFresh.Models;

namespace FarmFresh.Controllers
{

    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository<Product> _dataRepository;
        public ProductController(IProductRepository<Product> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Product
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Product> products = _dataRepository.GetAll();
            return Ok(products);
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        //[HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product product = _dataRepository.Get(id);
            if (product == null)
            {
                return NotFound("The product record couldn't be found.");
            }
            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("product is null.");
            }
            _dataRepository.Add(product);
            return CreatedAtRoute(
                  "Get",
                  new { Id = product.ID },
                  product);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("product is null.");
            }
            Product productToUpdate = _dataRepository.Get(id);
            if (productToUpdate == null)
            {
                return NotFound("The product record couldn't be found.");
            }
            _dataRepository.Update(productToUpdate, product);
            return NoContent();
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product = _dataRepository.Get(id);
            if (product == null)
            {
                return NotFound("The product record couldn't be found.");
            }
            _dataRepository.Delete(product);
            return NoContent();
        }
    }


    // [Authorize] // Authentication required
    //public class ProductController : Controller
    //{
    //    private readonly FarmFreshContext _context;

    //    public ProductController(FarmFreshContext context)
    //    {
    //        _context = context;
    //    }

    //    // GET: Product
    //    public async Task<IActionResult> Index()
    //    {
    //        List<Product> products = new List<Product>();
    //        return _context.Products != null
    //            ? View(await _context.Products.ToListAsync())
    //            : Problem("Enitity set is null.");
    //    }

    //    // GET: Product/Details/5
    //    public async Task<IActionResult> Details(Guid? id)
    //    {
    //        if (id == null || _context.Products == null)
    //        {
    //            return NotFound();
    //        }

    //        var product = await _context.Products.FirstOrDefaultAsync(m => m.ID == id);
    //        if (product == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(product);
    //    }

    //    // GET: Product/Create
    //    public IActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: Product/Create
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create(
    //        [Bind(
    //            "ID,ProductName,ProductPhoto,ProductType,PackingType,OnSale,ShopByStore,CreatedDate"
    //        )]
    //            Product product
    //    )
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _context.Add(product);
    //            await _context.SaveChangesAsync();
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(product);
    //    }

    //    // GET: Product/Edit/5
    //    public async Task<IActionResult> Edit(Guid? id)
    //    {
    //        if (id == null || _context.Products == null)
    //        {
    //            return NotFound();
    //        }

    //        var product = await _context.Products.FindAsync(id);
    //        if (product == null)
    //        {
    //            return NotFound();
    //        }
    //        return View(product);
    //    }

    //    // POST: Product/Edit/5
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(
    //        Guid id,
    //        [Bind(
    //            "ID,ProductName,ProductPhoto,ProductType,PackingType,OnSale,ShopByStore,CreatedDate"
    //        )]
    //            Product product
    //    )
    //    {
    //        if (id != product.ID)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                _context.Update(product);
    //                await _context.SaveChangesAsync();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!ProductExists(product.ID))
    //                {
    //                    return NotFound();
    //                }
    //                else
    //                {
    //                    throw;
    //                }
    //            }
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(product);
    //    }

    //    // GET: Product/Delete/5
    //    public async Task<IActionResult> Delete(Guid? id)
    //    {
    //        if (id == null || _context.Products == null)
    //        {
    //            return NotFound();
    //        }

    //        var product = await _context.Products.FirstOrDefaultAsync(m => m.ID == id);
    //        if (product == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(product);
    //    }

    //    // POST: Product/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(Guid id)
    //    {
    //        if (_context.Products == null)
    //        {
    //            return Problem("Entity set 'FarmFreshContext.Products'  is null.");
    //        }
    //        var product = await _context.Products.FindAsync(id);
    //        if (product != null)
    //        {
    //            _context.Products.Remove(product);
    //        }

    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool ProductExists(Guid id)
    //    {
    //        return (_context.Products?.Any(e => e.ID == id)).GetValueOrDefault();
    //    }
    //}
}
