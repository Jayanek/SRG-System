using MySql.Data.MySqlClient;
using SRG_SYSTEM.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRG_SYSTEM.DataAccess
{
    public  class AdoDbAccess<T>
    {
        private readonly string _cs;

        public AdoDbAccess(string cs,MapperService)
        {
            _cs = cs;
        }

        public List<T> GetItemListSP(AdoInputParams[] parameters,string sp)
        {

            var itemList = new List<T>();

            //using var con = new MySqlConnection(cs);
            //con.Open();
            using (var connection = new MySqlConnection(_cs))
            {
                MySqlCommand cmd = new MySqlCommand(sp, connection)
                {

                    CommandType = CommandType.StoredProcedure
                };

                if(parameters.Length > 0)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.Add(new MySqlParameter
                        {
                            ParameterName = param.Name,
                            MySqlDbType = param.Type=="I"?MySqlDbType.Int32:MySqlDbType.String,
                            Value = param.Value,
                            Direction = ParameterDirection.Input
                        });
                    }
                    
                }
                

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
