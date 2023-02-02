using MySql.Data.MySqlClient;
using SRG_SYSTEM.Models;
using SRG_SYSTEM.Services;
using System.Data;
using System.Diagnostics.Metrics;
using System.Reflection.PortableExecutable;

namespace SRG_SYSTEM.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetCountryList()
        {


            string cs = @"server=localhost;user id=root;password={};database=sakila";
            var customers = new List<Customer>();

            //using var con = new MySqlConnection(cs);
            //con.Open();
            using (var connection = new MySqlConnection(cs))
            {
                MySqlCommand cmd = new MySqlCommand("spGetCustomerDetails", connection)
                {

                    CommandType = CommandType.StoredProcedure
                };
                MySqlParameter lastPage = new MySqlParameter
                {
                    ParameterName = "@lastPage", 
                    MySqlDbType = MySqlDbType.Int32,
                    Value = 600, 
                    Direction = ParameterDirection.Input 
                };
                //Add the parameter to the Parameters property of SqlCommand object
                cmd.Parameters.Add(lastPage);

                //Open the Connection
                connection.Open();

                MySqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    MapperService mapper = new MapperService(sdr);

                    var mappedCustomer = mapper.GetCustomer();
                    customers.Add(mappedCustomer);
                    
                }
                
               
            }

            Console.WriteLine("");
            return customers;


        }
    }
}
