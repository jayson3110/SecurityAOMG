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
     
       public SqlConnection con = new SqlConnection("data source=JAYSON\\SQLEXPRESS; database=AOMG; integrated security=SSPI");

        
        public DataSet GetArtistData()
        {

            SqlCommand cmd = new SqlCommand("select * from AOMG_Artist ");

            cmd.Connection = con;
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            return ds;


        }

        public List<UserAccount> GetGroupUser()
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

    }
}