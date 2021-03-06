using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using SecurityInAOMG.Models;

namespace SecurityInAOMG.Controllers
{
    public class ResgisterController : Controller
    {
        // GET: Resgister
        SqlConnection con = new db().con;
        SqlCommand cmd = new SqlCommand();
     
        
        public ActionResult Resgister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Resgister(UserAccount user)
        {

            con.Open();
            cmd.CommandText = "insert into Users  values(@userId,@username, @password, 'user') ";

            if (Session["user"] == null)
            {
                cmd.Parameters.AddWithValue("@userId", user.userId);
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@password", user.password);
               
                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                con.Close();

            }
            return View();

        }

        public ActionResult ResgisterForAdmin()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ResgisterForAdmin(UserAccount user)
        {

            con.Open();
            cmd.CommandText = "insert into Users  values(@userId,@username, @password, 'admin') ";

            //if (Session["user"] == null)
            //{
            cmd.Parameters.AddWithValue("@userId", user.userId);
            cmd.Parameters.AddWithValue("@username", user.username);
            cmd.Parameters.AddWithValue("@password", user.password);


            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            con.Close();

            //}
            return View();

        }

    }
}