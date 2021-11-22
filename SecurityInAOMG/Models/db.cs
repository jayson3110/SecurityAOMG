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
                userGroup.Roles1 += sdr["Roles1"];
                userGroup.Roles2 += sdr["Roles2"];
                userGroup.Roles3 += sdr["Roles3"];

                model.Add(userGroup);


            }
            con.Close();

            return model;


        }



    }
}