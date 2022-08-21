using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace shop.Controllers
{
    public class AdminController : Controller
    {
        public  IActionResult GetAllUserDetails()
        {
            using(shopcontext db=new shopcontext())
            {
                /*return db.users != null ?
              View(await db.users.ToListAsync()) :
              Problem("Entity set 'DatabaseContext.UserAccounts'  is null.");*/
                if(db.users!=null)
                {
                    var users = db.users.ToList();
                    return View(users);
                }
            }
            return View();
        }

        public async Task<IActionResult> DeleteUser(int? id) 
        {
            using (shopcontext db = new shopcontext())
            {
                if (id == null)
                {
                    return NotFound();
                }
                var result = await db.users.FirstAsync(users => users.id == id);
                if (result == null)
                {
                    return NotFound();
                }
                return View(result);
            }
            //return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(int id)
        {
            using (shopcontext db = new shopcontext())
            {
                if (id==null)
                {
                    return NotFound();
                }
                var user=db.users.FirstOrDefault(x => x.id==id);
                if(user!=null)
                {
                    db.users.Remove(user);
                }
                await db.SaveChangesAsync();
                return RedirectToAction("GetAllUserDetails", "Admin");
            }
        }


    }
}
