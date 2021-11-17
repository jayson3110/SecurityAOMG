using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecurityInAOMG.Models;
using System.Data.SqlClient;

namespace SecurityInAOMG.Controllers
{
    public class GroupController : Controller
    {
        SqlConnection con = new SqlConnection("data source=JAYSON\\SQLEXPRESS; database=AOMG; integrated security=SSPI");
        // GET: Group
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                List<UserAccount> model = GetGroupUser();
                return View(model);
            }else
            {
                return Redirect("https://localhost:44357/");
            }
           
        }

        public ActionResult Edit(int id)
        {
            List<UserAccount> userList = GetGroupUser();
            var getId = userList.Single(m => m.userId == id);
            return View(getId);
        }

        [HttpPost]
        public ActionResult Edit(UserAccount user, int id)
        {
            
            SqlCommand cmd = new SqlCommand();
            List<UserAccount> userList = GetGroupUser();
            var getId = userList.Single(m => m.userId == id);
            try
            {
                con.Open();
                cmd.CommandText = "update Users set username='" + user.username + "', password = '" + user.password + "', roles ='" + user.roles + "' where userID='" + getId + "' ";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
            finally
            {
                con.Close();
            }



            /*cmd.Parameters.AddWithValue("@username", user.username);
            cmd.Parameters.AddWithValue("@password", user.password);
            cmd.Parameters.AddWithValue("@roles", user.roles);
            cmd.Parameters.AddWithValue("@userId", user.userId);*/





            //con.Close();
            
         
            return View();

        }



        public List<UserAccount> GetGroupUser() {

            con.Open();
            var model = new List<UserAccount>();
            SqlCommand cmd = new SqlCommand("select * from Users ");

            cmd.Connection = con;
         

            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {

                var userAccount = new UserAccount();
                userAccount.userId += (int)sdr["userId"];
                userAccount.username += sdr["username"];
                userAccount.password += sdr["password"];
                userAccount.roles += sdr["roles"];

                model.Add(userAccount);



            }

            return model;

        }
    }
}