using System;
using System.Collections.Generic; //these are using directives
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceControlWithDatabase
{
    class StudentDB
    {
        public static void DeleteStudent(int id)
        {
            SqlConnection con = new SqlConnection("connection string here. . ."); //create Sql connection

            SqlCommand delCmd = new SqlCommand(); //create a delete command object

            delCmd.Connection = con;

            delCmd.CommandText = "DELETE QUERY";

            try
            {
                //open the connection
                con.Open();

                //execute the command
                int rows= delCmd.ExecuteNonQuery();
            }
            catch //we should catch specific exceptions!
            {
                //empty catch is typically not a good idea

            }
            finally
            {
                con.Dispose(); //this calls Close(); internally 
            }

            //SAME AS ABOVE WITH  CATCH REMOVED ***************
            try
            {
                con.Open();
                //continue code here. . . 
            }

            finally
            {
                con.Dispose();
            }
            //using statement
            //Generates a try/finally block
            //Inside the finally, Dispose() is called
            using(var con2 = new SqlConnection())
            {
                con2.Open();
                //other DB code here. . .

                // if exception occurs, we can handle this 
                //in the forms

                //Dispose() is automatically called at the end
            }
        }

    }
}
