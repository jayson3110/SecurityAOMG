using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecurityInAOMG.Models;
using System.Data.SqlClient;
using System.Data;
using System.Dynamic;

namespace SecurityInAOMG.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

          

            db showData = new db();
            DataSet ds = showData.GetArtistData();
          
            if (Session["user"] != null && (int)Session["user"] == 1)
            {
                // int VIPNumber = (int)Session["user"];
                ViewBag.data = ds.Tables[0];
                return View("adminView");

            }
            else if(Session["user"] != null && (int)Session["user"] == 2)
            {
                ViewBag.data = ds.Tables[0];
                return View("userView");
            }
            else if (Session["user"] !=null && (int)Session["user"] == 3)
            {

                db data = new db();
                dynamic mymodel = new ExpandoObject();
                mymodel.RolesGroup = data.GetUserGroup();
                mymodel.ArtistData = data.GetArtistDataNormal();

                return View("editorView", mymodel);
            }

          
            else
            {
                return View("Index");
            }


        }










    }
}