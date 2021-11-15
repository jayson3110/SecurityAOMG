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
        SqlConnection con = new SqlConnection("data source=JAYSON\\SQLEXPRESS; database=AOMG; integrated security=SSPI; MultipleActiveResultSets=true");
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


    }
}