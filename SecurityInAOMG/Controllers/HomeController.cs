using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecurityInAOMG.Models;
using System.Data.SqlClient;



namespace SecurityInAOMG.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection("data source=JAYSON\\SQLEXPRESS; database=AOMG; integrated security=SSPI");

        public ActionResult Index()
        {

            List<Artist> model = null;

          
            if (Session["user"] != null && (int)Session["user"] == 1)
            {
                // int VIPNumber = (int)Session["user"];
                model = GetArtistData();
                return View("adminView", model);

            }
            else if(Session["user"] != null && (int)Session["user"] == 2)
            {
                model = GetArtistData();
                return View("userView", model);
            }
            else
            {
                return View("Index");
            }




        }










        public List<Artist> GetArtistData()
        {
            var model = new List<Artist>();
            SqlCommand cmd = new SqlCommand("select * from AOMG_Artist ");

            cmd.Connection = con;
            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {

                var artist = new Artist();
                artist.Artist_Name += sdr["Artist_Name"];
                artist.Artist_role += sdr["Artist_role"];
                artist.Artist_contact += sdr["Artist_contact"].ToString();

                model.Add(artist);



            }

            return model;

        }








    }
}