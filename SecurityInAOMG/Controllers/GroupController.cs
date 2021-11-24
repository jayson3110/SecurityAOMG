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
       
        SqlConnection con = new db().con;
        
        // GET: Group
       
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                List<UserAccount> model = new db().GetUserAccount();
                return View(model);
            }else
            {
                return Redirect("https://localhost:44357/");
            }
           
        }

        public ActionResult Edit(int id)
        {
            List<UserAccount> userList = new db().GetUserAccount();
            var getId = userList.Single(m => m.userId == id);
         
            return View(getId);
        }

        [HttpPost]
        public ActionResult Edit(UserAccount user, int id)
        {
            
            SqlCommand cmd = new SqlCommand();


            List<UserAccount> userList = new db().GetUserAccount();
            var getId = userList.Single(m => m.userId == id);
            
            con.Open();

            try
            {

                cmd.CommandText = "update Users set password='" + user.password + "' , roles='" + user.roles + "' where userID= " + getId.userId + "";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();

            }
           
            return View();

        }
       
    }
}