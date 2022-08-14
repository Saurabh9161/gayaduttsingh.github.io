using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gayaduttsingh.Models;

namespace gayaduttsingh.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        gdsdatabaseEntities db = new gdsdatabaseEntities();
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Events()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactUs(ContactTbl ct)
        {
            ct.cdt = DateTime.Now.ToString();
            db.ContactTbls.Add(ct);
            db.SaveChanges();
            Response.Write("<script>alert('Thanks for contact')</script>");
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult register(register reg,Login lg)
        {
            HttpPostedFileBase file = Request.Files["profile"];
            if (file != null)
            {
                //for file uploading here
                reg.profile = file.FileName;
                file.SaveAs(Server.MapPath("../Content/profiles/"+file.FileName));
                //registration code here
                reg.regdt = DateTime.Now.ToString();
                db.registers.Add(reg);
                db.SaveChanges();
                
                //code for sending mail
                EmailSender es = new EmailSender();
                es.SendTo = reg.email;
                es.Subject = "gayaduttsingh Portal";
                es.MessageBody = "Hello" + reg.fname + "Thanks ! for register on my portal . Your email id " + reg.email + " and password is " + reg.passwd;
                if (es.SenderEmail() == true)
                {
                    Response.Write("<script>alert('Your Registration completed succesfully')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Your Registration not completed ')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Plz select your Profile')</script>");
            }
           return View();
        }
        public ActionResult Teachers()
        {
            return View();
        }
        public ActionResult Location()
        {
            return View();
        }
        public ActionResult Saurabh()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Feedback()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Feedback(Feedback ft)
        {
            ft.fdt = DateTime.Now.ToString();
            db.Feedbacks.Add(ft);
            db.SaveChanges();
            Response.Write("<script>alert('Thanks for feedback')</script>");
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string uid,string passwd)
        {
            Login lg = db.Logins.SingleOrDefault(x => x.userid == uid && x.passwd == passwd);
            if (lg!=null)
            {
                //goto admin zone

                Response.Write("<script>alert('Welcome Admin Zone');window.location.href='/AdminZone/Index'</script>");
                //set session value
                Session["aid"] = lg.userid;
            }
            else
            {
                Response.Write("<script>alert('Invalid UserId or Password')</script>");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Enquiry()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Enquiry(Enquiry et)
        {
           et.edt=DateTime.Now.ToString();
           db.Enquiries.Add(et);
           db.SaveChanges();
           Response.Write("<script>alert('Thanks for enquiry')</script>");
           return View();
        }
        

    }
}
