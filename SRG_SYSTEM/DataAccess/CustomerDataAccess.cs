using MySql.Data.MySqlClient;
using SRG_SYSTEM.Models;
using SRG_SYSTEM.Services;
using System.Data;

namespace SRG_SYSTEM.DataAccess
{
    public class CustomerDataAccess : ICustomerDataAccess
    {
        private readonly IConfiguration _configuration;

        public CustomerDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Customer> AccessCustomerDetails(int lastPageId)
        {


            string cs = _configuration["MySQLConnection"];
            var customers = new List<Customer>();

            using var con = new MySqlConnection(cs);
            con.Open();
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
                    Value = lastPageId,
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


            return customers;


        }
    }
}
