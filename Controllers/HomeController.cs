using login.Models;
using login.NewFolder1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace login.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(UserModel user)
        {
            swatiEntities sw =new swatiEntities();
            var res = sw.Logins.Where(m => m.Email == user.Email).FirstOrDefault();
            if (res == null)
            {
                TempData["reqred"] = " Reourd not found";
            }
            else
            {
                if (res.Email == user.Email && res.Password == user.Password)
                {
                    FormsAuthentication.SetAuthCookie(user.Email,false);
                    Session["Email"] = res.Email;
                    Session["Password"] = res.Password;
                    return RedirectToAction("DeshBord");
                }
                else
                {
                    TempData["Password"] = "Envild Password";
                }

            }
            return View();
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            Session["Email"] = null;
            return RedirectToAction("Index");
        }
        public ActionResult show()
        {
            swatiEntities sw = new swatiEntities();
          List<EmpModel> emp = new List<EmpModel>();
            var res = sw.employees.ToList();
            foreach(var item in res)
            {
                emp.Add(new EmpModel 
                {
                    Id=item.Id,
                    Name=item.Name,
                    Email=item.Email,
                    Mob=item.Mob,
                    Department=item.Department,
                    Companey=item.Companey,
                
                });

            }
            return View(emp);
        }
        [HttpGet]
        public ActionResult AddEmp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmp(EmpModel emp)
        {
            swatiEntities sw =new swatiEntities();
            employee e = new employee();
            e.Id = emp.Id;
            e.Name = emp.Name;
            e.Email = emp.Email;
            e.Mob = emp.Mob;
            e.Department = emp.Department;
            e.Companey = emp.Companey;
            if (emp.Id==0)
            {
                sw.employees.Add(e);
                sw.SaveChanges();
            }
            else
            {
                sw.Entry(e).State = System.Data.Entity.EntityState.Modified;
                sw.SaveChanges();
            }
            return RedirectToAction("show");
        }
        public ActionResult Delete(int Id)
        {
            swatiEntities sw = new swatiEntities();
            var Deleteitem= sw.employees.Where(m => m.Id==Id).First();
            sw.employees.Remove(Deleteitem);
            sw.SaveChanges();
            return RedirectToAction("show");
        }
        public ActionResult Edit(int Id)
        {
            swatiEntities sw = new swatiEntities();
            EmpModel emp = new EmpModel();
            var Edititem = sw.employees.Where(y=> y.Id == Id).First();
            emp.Id = Edititem.Id;
            emp.Name = Edititem.Name;
            emp.Email = Edititem.Email;
            emp.Mob = Edititem.Mob;
            emp.Department = Edititem.Department;
            emp.Companey = Edititem.Companey;
            return View("AddEmp",emp);
        }
       public ActionResult DeshBord() 
        {
            return View();
        }
        public ActionResult Sinout()
        {

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
} 