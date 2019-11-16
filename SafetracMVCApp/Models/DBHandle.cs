using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SafetracMVCApp.Models
{
    public class DBHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["UserConn"].ToString();
            con = new SqlConnection(constring);
        }
        // **************** ADD NEW USER *********************
        public bool AddUser(UserModel model)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewUser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
            cmd.Parameters.AddWithValue("@LastName", model.LastName);
            cmd.Parameters.AddWithValue("@Password", model.Password);
            cmd.Parameters.AddWithValue("@EmailAddress", model.Email);
            cmd.Parameters.AddWithValue("@DateCreated", SqlDbType.DateTime2);
            cmd.Parameters.AddWithValue("@DateModified", SqlDbType.DateTime2);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        // ********** VIEW USER DETAILS ********************
        public  List<UserModel> GetUser()
        {
            connection();
            List<UserModel> userlist = new List<UserModel>();

            SqlCommand cmd = new SqlCommand("GetUserDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                userlist.Add(
                    new UserModel
                    {
                       
                        FirstName = Convert.ToString(dr["first_name"]),
                        LastName = Convert.ToString(dr["last_name"]),
                        Email = Convert.ToString(dr["email_address"]),
                        DateCreated = Convert.ToDateTime(dr["date_created"]),
                     
                    });
            }

           
            return userlist;
        }


    }
}