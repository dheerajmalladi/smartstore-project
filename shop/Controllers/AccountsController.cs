using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop.Models;

namespace shop.Controllers
{
    public class AccountsController : Controller
    {
        //private readonly shopContext _context;

        //public AccountsController(shopContext context)
        //{
        //    _context = context;
        //}
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            using(shopcontext db=new shopcontext())
            {
                var result = db.users.Where(x => x.emailid == login.emailid && x.password == login.password).ToList();
                if (result.Count() > 0)
                {
                    HttpContext.Session.SetInt32("id",result[0].id);
                    HttpContext.Session.SetInt32("roll", result[0].user_category);
                    return RedirectToAction("welcome", "Home");
                }
                else
                {
                    TempData["LoginStatus"] = "Fail";
                }
            }
            return View();
        }
        public IActionResult signup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult signup(users user)
        {
            using(shopcontext db=new shopcontext())
            {
                db.users.Add(user);
                if(db.SaveChanges()>0)
                {
                    return RedirectToAction("Login","Accounts");
                }
                else
                {
                    TempData["signupStatus"] = "fail";
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Accounts");
            return View();
        }
        
        public async Task<IActionResult> MyDetails(int? id)
        {
            using (shopcontext db = new shopcontext())
            {
                if (id == null)
                {
                    return NotFound();
                }
                var result = await db.users.FirstOrDefaultAsync(x=>x.id==id);
                if(result==null)
                {
                    return NotFound();
                }
                else
                {
                    return View(result);
                }
            }
        }

        public async Task<IActionResult> EditDetails(int? id)
        {

            using(shopcontext db=new shopcontext())
            {
                if(id==null)
                {
                    return NotFound();
                }
                var result = await db.users.FirstAsync(users=>users.id==id);
                if (result == null)
                {
                    return NotFound();
                }
                return View(result);
            }
            //return View();
        }

       [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDetails([Bind("id,fname,lname,dob,gender,phno,emailid,password,user_category")]users user)
        {
            var id = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            using (shopcontext db=new shopcontext())
            {
                if (id == null)
                {
                    return NotFound();
                }
                db.Update(user);
                await db.SaveChangesAsync();
                return RedirectToAction("MyDetails", "Accounts", new {@id=id});
            }
            
        }
    }
}
