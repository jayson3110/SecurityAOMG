using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace SecurityInAOMG.Models
{
    public class db
    {
     
       public SqlConnection con = new SqlConnection("data source=JAYSON\\SQLEXPRESS; database=AOMG; integrated security=SSPI; MultipleActiveResultSets=True");

        // DataReader
        public DataSet GetArtistData()
        {

            SqlCommand cmd = new SqlCommand("select * from AOMG_Artist ");

            cmd.Connection = con;
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            con.Close();


            return ds;


        }

        // Normal
        public List<Artist> GetArtistDataNormal()
        {

            SqlCommand cmd = new SqlCommand("select * from AOMG_Artist ");
            var model = new List<Artist>();
            cmd.Connection = con;
            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {

                var artist = new Artist();
                artist.Artist_Name += sdr["Artist_Name"];
                artist.Artist_role += sdr["Artist_role"];
                artist.Artist_contact += sdr["Artist_contact"];
               

                model.Add(artist);





            }
            con.Close();

            return model;

        }

        public List<UserAccount> GetUserAccount()
        {

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
            con.Close();

            return model;

        }

        public List<UseGroup> GetUserGroup()
        {
            con.Open();
            var model = new List<UseGroup>();
            SqlCommand cmd = new SqlCommand("select * from Group_User ");

            cmd.Connection = con;


            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {

                var userGroup = new UseGroup();
                userGroup.Group_user_Id += (int)sdr["Group_user_Id"];
                userGroup.Group_user_Name += sdr["Group_user_Name"];
                userGroup.Editing += sdr["Editing"];
                userGroup.Detail += sdr["Detail"];
                userGroup.Deleting += sdr["Deleting"];

                model.Add(userGroup);


            }
            con.Close();

            return model;


        }







    }




}
