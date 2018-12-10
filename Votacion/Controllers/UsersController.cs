
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Votacion.Models;

namespace Votacion.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private DemocracyContext db = new DemocracyContext();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (UserView userView)
        {
            if (!ModelState.IsValid)
            {
                return View(userView);
            }
            string path = string.Empty;
            string pic = string.Empty;
            if(userView.Photo != null)
            {
                pic = Path.GetFileName(userView.Photo.FileName);
                path = Path.Combine(Server.MapPath("~/Content/Photos"), pic);
                userView.Photo.SaveAs(path);
                using (MemoryStream ms = new MemoryStream())
                {
                    userView.Photo.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                } 
            }
            {
                var user = new User
                {
                    Adress = userView.Adress,
                    FristName = userView.FristName,
                    Grade = userView.Grade,
                    Group = userView.Group,
                    LastName = userView.LastName,
                    Phone = userView.Phone,
                    Photo = pic == string.Empty ? string.Empty:string.Format("~/Content/Photos/{0}",pic),
                    UserName = userView.UserName
                };

                db.Users.Add(user);
                try
                {

                db.SaveChanges();
                    this.CreateASPUser(userView);
                }
                catch(Exception ex)
                {
                    if(ex.InnerException != null && 
                        ex.InnerException.InnerException != null && 
                        ex.InnerException.Message.Contains("UserNameIndex"))
                    {
                        ViewBag.Error = "El correo esta en uso, use otro correo";
                    }
                    else
                    {
                        ViewBag.Error = ex.Message;
                    }
                    return View(userView);
                }
                return RedirectToAction("Index");
            }
           
        }

        private void CreateASPUser(UserView userView)
        {// Manejo de Usuarios 
              var userContext = new ApplicationDbContext();
              var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
              var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(userContext));
            // Crea Roles de Usuario
            string roleName = "User";

            //Verificando la  vista de los roles existentes
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }

            //Creando los usuarios en ASP.Net
            var userASP = new ApplicationUser
            {
                UserName = userView.UserName,
                Email = userView.UserName,
                PhoneNumber = userView.Phone,

            };
            userManager.Create(userASP, userASP.UserName);

            //
            userASP = userManager.FindByName(userView.UserName);
            userManager.AddToRole(userASP.Id, "User");
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.Users.Find(id);
            if (user == null)
            { 
                return HttpNotFound();
            }
            var userView = new UserView
            {
                Adress = user.Adress,
                FristName = user.FristName,
                Grade = user.Grade,
                Group = user.Group,
                LastName = user.LastName,
                Phone = user.Phone,
                UserId = user.UserId,
                UserName = user.UserName, 
            };
            return View(userView);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserView userView)
        {
            if (!ModelState.IsValid)
            {
                return View(userView);
            }
 //cargar imagen
            string path = string.Empty;
            string pic = string.Empty;
            if (userView.Photo != null)
            {

                pic = Path.GetFileName(userView.Photo.FileName);
                path = Path.Combine(Server.MapPath("~/Content/Photos"), pic);
                userView.Photo.SaveAs(path);
                using (MemoryStream ms = new MemoryStream())
                {
                    userView.Photo.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
            }
                var user = db.Users.Find(userView.UserId);

                user.Adress = userView.Adress;
                user.FristName = userView.FristName;
                user.Grade = userView.Grade;
                user.Group = userView.Group;
                user.LastName = userView.LastName;
                user.Phone = userView.Phone;
            

            if (!string.IsNullOrEmpty(pic))
            {
                user.Photo = string.Format("~/Content/Photos/{0}", pic);

            }
            
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        
            

            // GET: Users/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
        

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
