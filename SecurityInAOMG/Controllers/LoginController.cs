using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using SecurityInAOMG.Models;

namespace SeurityASP.NET.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection con = new SqlConnection("data source=JAYSON\\SQLEXPRESS; database=AOMG; integrated security=SSPI; MultipleActiveResultSets=true");
        SqlCommand cmd1 = new SqlCommand();
        SqlCommand cmd2 = new SqlCommand();
        SqlDataReader dr;
        SqlDataReader dr2;
        // GET: Login
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                Response.Redirect("https://www.google.com.vn/imghp?hl=vi");

            }

            return View();
        }

        public JsonResult CheckLogin(FormCollection Collection)
        {
            string uid = Collection["uid"];
            string pwd = Collection["password"];


            con.Open();
            cmd1.Connection = con;
            cmd2.Connection = con;
            cmd1.CommandText = "select * from Users where username='"+uid+"' and password='"+pwd+ "' and roles='admin' ";
            cmd2.CommandText = "select * from Users where username='" + uid + "' and password='" + pwd + "' and roles='user' ";

            dr = cmd1.ExecuteReader();
            dr2 = cmd2.ExecuteReader();


            JsonResult jr = new JsonResult();

            if (dr.Read())
            {
              
                    Session["user"] = 1;
                    Session.Timeout = 5;

                    jr.Data = new
                    {
                        status = "OK"
                    };
                con.Close();
                
            }
           else if (dr2.Read() )
            {
                Session["user"] = 2;
                Session.Timeout = 5;

                jr.Data = new
                {
                    status = "OK"
                };


            } 
            else
            {
                jr.Data = new
                {
                    status = "False"
                };
            }

            return Json(jr, JsonRequestBehavior.AllowGet);


        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Index");
        }





    }
}