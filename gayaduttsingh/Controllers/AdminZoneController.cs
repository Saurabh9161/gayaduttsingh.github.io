using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gayaduttsingh.Models;

namespace gayaduttsingh.Controllers
{
    public class AdminZoneController : Controller
    {
        //
        // GET: /AdminZone/
        gdsdatabaseEntities db = new gdsdatabaseEntities();

        public ActionResult Index()
        {
            if (Session["aid"] != null)
            {

            }
            else
            {
                Response.Write("<script>alert('First Login');window.location.href='/Home/Login'</script>");  
            }
            return View();
        }
        public ActionResult Logout()
        {

            Session.Abandon();
            Response.Write("<script>window.location.href='/Home/Login'</script>");
            return View();
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            if (Session["aid"] != null)
            {

            }
            else
            {
                Response.Write("<script>alert('First Login');window.location.href='/Home/Login'</script>");
            }
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(string npass, string cpass)
        {
            if (npass == cpass)
            {
                string uid = Session["aid"].ToString();
                Login lg = db.Logins.SingleOrDefault(x => x.userid == uid);
                if (lg != null)
                {
                    lg.passwd = npass;
                    db.SaveChanges();
                    Response.Write("<script>alert('Password changed successfully');window.location.href='/Home/Login'</script>");
                }
                else
                {
                    Response.Write("<script>alert('Your Password is not changed')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Plz confirm Password')</script>");
            }
            return View();
        }
        public ActionResult Contact()
        {
            List<ContactTbl> Lst = null;
            if (Session["aid"] != null)
            {
                Lst = db.ContactTbls.ToList();
            }
            else
            {
                Response.Write("<script>alert('First Login');window.location.href='/Home/Login'</script>");
            }
            return View(Lst);
        }
        public ActionResult Register()
        {
            List<register> Lst = null;
            if (Session["aid"] != null)
            {
                Lst = db.registers.ToList();
            }
            else
            {
                Response.Write("<script>alert('First Login');window.location.href='/Home/Login'</script>");
            }
            return View(Lst);
        }
        public ActionResult Admission()
        {
            List<Enquiry> Lst = null;
            if (Session["aid"] != null)
            {
                Lst = db.Enquiries.ToList();
            }
            else
            {
                Response.Write("<script>alert('First Login');window.location.href='/Home/Login'</script>");
            }
            return View(Lst);
        }
        public ActionResult Feedback()
        {
            List<Feedback> Lst = null;
            if (Session["aid"] != null)
            {
                Lst = db.Feedbacks.ToList();
            }
            else
            {
                Response.Write("<script>alert('First Login');window.location.href='/Home/Login'</script>");
            }
            return View(Lst);
        }
        public IView List { get; set; }
    }
}
