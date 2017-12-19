using System;
using System.Data;
using System.Data.SqlClient;


namespace ConsoleApp1
{
    class Program
    {
          static void Main(string[] args)
        {
            String name;
            Console.WriteLine("Calling test.....");
            Test t = new Test();
            name = Console.ReadLine();
            t.runproc(name);
            Console.Read();
        }

    }
    class Test
    {
        SqlConnection sqlconn =new SqlConnection();
        SqlCommand sqlcomm;

        public void runproc(String name) {
            //  SqlConnection conn = new SqlConnection();
            try {
                sqlconn.ConnectionString =
                    "Data Source=anaplansql.eastus2.cloudapp.azure.com;" +
                    "Initial Catalog=AnaplanDb_v1;" +
                    "User id=AnaplanSQLAdmin;" +
                    "Password=Pass@word123;";
                Console.WriteLine("Got con string");
                sqlconn.Open();
                Console.WriteLine("Opened con");

                //sqlconn = new SqlConnection(ConfigurationManager.AppSettings["Sql_server"]);
                //sqlconn.Open();
                sqlcomm = new SqlCommand();
                sqlcomm.Connection = sqlconn;

                //Here I am definied command type is Stored Procedure. 
                sqlcomm.CommandType = CommandType.StoredProcedure;

                //Here I mentioned the Stored Procedure Name. 
                sqlcomm.CommandText = name;






                //For reading from select op
                SqlDataReader dr = sqlcomm.ExecuteReader(CommandBehavior.CloseConnection);
                if (!dr.Read())

                {
                    Console.WriteLine("Nothing to read");
                }
                else
                {
                    Console.WriteLine("read");
                    /*while (dr.Read())
                    {
                        Console.WriteLine(dr["AccountKey"]);
                    }dr.NextResult();*/
                    Console.WriteLine("Proc done");
                    //if (rowsAffected != 0)
                    Console.WriteLine("Success");
                }




                /*For insert/alter/update statements
                 *using (SqlDataReader dr = sqlcomm.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string treatment = dr[0].ToString();
                    }
                }*/
                //int rowsAffected = sqlcomm.ExecuteNonQuery();

                //else
                //Console.WriteLine("No rows affected");

                sqlcomm.Dispose();
                sqlconn.Close();
                return;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            }

        }
        
    }

    



