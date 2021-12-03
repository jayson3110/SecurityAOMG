    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecurityInAOMG.Models;
using System.Data.SqlClient;

namespace SecurityInAOMG.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        SqlConnection con = new db().con;

        // GET: Group

        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                List<UseGroup> model = new db().GetUserGroup();
                return View(model);
            }
            else
            {
                return Redirect("https://localhost:44357/");
            }

        }

        public ActionResult Edit(int id)
        {
            List<UseGroup> userGroup = new db().GetUserGroup();
            var getId = userGroup.Single(m => m.Group_user_Id == id);

        

            return View(getId);
        }

        [HttpPost]
       public ActionResult Edit(UseGroup useGroup, int id)
        {

            SqlCommand cmd = new SqlCommand();


            List<UseGroup> userGroup = new db().GetUserGroup();
            var getId = userGroup.Single(m => m.Group_user_Id == id);

           

            con.Open();
          

            switch (useGroup.CheckedEdit)
            {
                case true:
                   

                        cmd.CommandText = "update Group_User set Editing='" + useGroup.Editing + "'  where Group_user_Id= " + getId.Group_user_Id + "";

                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                
                        
                    
                       break;
                case false:
                   
                        cmd.CommandText = "update Group_User set Editing='Null'  where Group_user_Id= " + getId.Group_user_Id + "";

                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                  
                      break;

            }

            switch (useGroup.CheckedDetail)
            {
                case true:

                        cmd.CommandText = "update Group_User set  Detail='" + useGroup.Detail + "'  where Group_user_Id= " + getId.Group_user_Id + "";

                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                   
                       

                    
                    break;
                case false:
                   
                        cmd.CommandText = "update Group_User set Detail='Null'    where Group_user_Id= " + getId.Group_user_Id + "";

                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                    
                   

                    

                    break;

            }

            switch (useGroup.CheckedDelete)
            {
                case true:
                   
                        cmd.CommandText = "update Group_User set  Deleting='" + useGroup.Deleting + "'  where Group_user_Id= " + getId.Group_user_Id + "";

                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                  
                    

                   
                    break;
                case false:
                    

                        cmd.CommandText = "update Group_User set Deleting='Null'  where Group_user_Id= " + getId.Group_user_Id + "";

                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                  
              

                    
                    break;

            }

            con.Close();



            return View();

        } 


    }
}