using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecurityInAOMG.Models;
using System.Data.SqlClient;
using System.Data;


namespace SecurityInAOMG.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            List<Artist> model = null;

            db showData = new db();
            DataSet ds = showData.GetArtistData();
          
            if (Session["user"] != null && (int)Session["user"] == 1)
            {
                // int VIPNumber = (int)Session["user"];
                ViewBag.data = ds.Tables[0];
                return View("adminView", model);

            }
            else if(Session["user"] != null && (int)Session["user"] == 2)
            {
                model = ViewBag.data = ds.Tables[0];
                return View("userView", model);
            }
            else
            {
                return View("Index");
            }


        }










    }
}