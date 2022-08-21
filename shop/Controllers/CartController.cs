using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shop;
using shop.Models;

namespace shop.Controllers
{
    public class CartController : Controller
    {
        private readonly shopcontext _context;

        public CartController(shopcontext context)
        {
            _context = context;
        }

        // GET: Cart
        public async Task<IActionResult> Index(int? id)
        {
            var final_amount = 0;
            var final_quantity = 0;
            if (id == null || _context.carts == null)
            {
                return NotFound();
            }
            var carts = await _context.carts.FromSqlRaw("select *  from carts where  id = '" + id + "'  ").ToListAsync();
            foreach (var cart in carts)
            {
                final_amount += cart.totalprice;
                final_quantity += cart.quantity;

            }
            TempData["finalamount"] = final_amount;
            TempData["finalquantity"] = final_quantity;
            return View(carts);
        }

        // GET: Cart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.carts == null)
            {
                return NotFound();
            }

            var cart = await _context.carts
                .FirstOrDefaultAsync(m => m.cartid == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: Cart/Create
        [HttpGet]
        public async Task<IActionResult> Create(int? p_id)
        {
            if (p_id == null || _context.products == null)
            {
                return NotFound();
            }

            var products = await _context.products.FindAsync(p_id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        // POST: Cart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int p_id,string p_name,string p_image_url,int p_quantity,int p_price)
        {
            Cart cart = new Cart();
            cart.p_id =p_id;
            cart.p_name = p_name;
            cart.p_price = p_price;
            cart.p_image_url = p_image_url;
            cart.quantity = p_quantity;
            cart.totalprice = p_quantity * p_price;
            cart.id = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            _context.Add(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction("Create","Cart",new {@p_id=p_id});
        }

        // GET: Cart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.carts == null)
            {
                return NotFound();
            }

            var cart = await _context.carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            return View(cart);
        }

        // POST: Cart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cartid,id,p_id,p_name,p_image_url,quantity,p_price,totalprice")] Cart cart)
        {
            if (id != cart.cartid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.cartid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cart);
        }

        // GET: Cart/Delete/5
        
        public async Task<IActionResult> Delete(int? id)
        {
            int? userid= HttpContext.Session.GetInt32("id");
            if (_context.carts == null)
            {
                return Problem("Entity set 'shopcontext.carts'  is null.");
            }
            var cart = await _context.carts.FindAsync(id);
            if (cart != null)
            {
                _context.carts.Remove(cart);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Cart", new {@id=userid});
        }

        // POST: Cart/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.carts == null)
        //    {
        //        return Problem("Entity set 'shopcontext.carts'  is null.");
        //    }
        //    var cart = await _context.carts.FindAsync(id);
        //    if (cart != null)
        //    {
        //        _context.carts.Remove(cart);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool CartExists(int id)
        {
          return (_context.carts?.Any(e => e.cartid == id)).GetValueOrDefault();
        }
    }
}
