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
        SqlConnection con = new db().con;
        SqlCommand cmd1 = new SqlCommand();
        SqlCommand cmd2 = new SqlCommand();
        SqlCommand cmd3 = new SqlCommand();
        SqlDataReader dr;
        SqlDataReader dr2;
        SqlDataReader dr3;
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



            cmd1.Connection = con;
            cmd2.Connection = con;
            cmd3.Connection = con;

            con.Open();

            cmd1.CommandText = "select * from Users where username= @uid and password=@pwd  and roles=@roles ";
            cmd1.Parameters.AddWithValue("@uid", uid);
            cmd1.Parameters.AddWithValue("@pwd", pwd);
            cmd1.Parameters.AddWithValue("@roles", "admin");


            cmd2.CommandText = "select * from Users where username= @uid and password=@pwd  and roles=@roles ";
            cmd2.Parameters.AddWithValue("@uid", uid);
            cmd2.Parameters.AddWithValue("@pwd", pwd);
            cmd2.Parameters.AddWithValue("@roles", "user");

            cmd3.CommandText = "select * from Users where username= @uid and password=@pwd  and roles=@roles ";
            cmd3.Parameters.AddWithValue("@uid", uid);
            cmd3.Parameters.AddWithValue("@pwd", pwd);
            cmd3.Parameters.AddWithValue("@roles", "editor");





            dr = cmd1.ExecuteReader();
            dr2 = cmd2.ExecuteReader();
            dr3 = cmd3.ExecuteReader();


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
            else if (dr2.Read())
            {
                Session["user"] = 2;
                Session.Timeout = 5;

                jr.Data = new
                {
                    status = "OK"
                };


            }

            else if (dr3.Read())
            {
                Session["user"] = 3;
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