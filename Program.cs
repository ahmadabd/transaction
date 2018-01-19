using System;
using System.Data.SqlClient;

namespace transaction
{
    class Program
    {
        
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=bank;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            //SqlTransaction transaction;
            //transaction = con.BeginTransaction("SampleTransaction");

            Console.Write("Enter id:");
            int id = Int32.Parse(Console.ReadLine());

            Console.Write("Enter val:");
            int val = Int32.Parse(Console.ReadLine());

            cmd.CommandText = "begin transaction update account with (rowlock) set account.balance = account.balance + '" + val+"' where account.account_number = '"+id+"'";
            cmd.ExecuteNonQuery();

            Console.Write("Enter 1 for commit:");
            int commit = Int32.Parse(Console.ReadLine());

            if(commit == 1)
            {
                cmd.CommandText = "commit";
                cmd.ExecuteNonQuery();
            }

            con.Close();
        }
    }
}
