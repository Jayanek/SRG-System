using MySql.Data.MySqlClient;
using SRG_SYSTEM.Models;

namespace SRG_SYSTEM.Services
{
    public class MapperService
    {
        private readonly MySqlDataReader _reader;
        private Customer _customer;

        public MapperService(MySqlDataReader reader)
        {
            _customer = new Customer();
            _reader = reader;
            MapCustomer();
        }

        private void MapCustomer()
        {
            _customer.CustomerId = Convert.ToInt32(_reader["CustomerId"]);
            _customer.StoreId = Convert.ToInt32(_reader["StoreId"]);
            _customer.FirstName = _reader["CustomerFirstName"].ToString();
            _customer.LastName = _reader["CustomerLastName"].ToString();
            _customer.Email = _reader["CustomerEmail"].ToString();
            _customer.AddressId = Convert.ToInt32(_reader["CustomerAddressId"]);
            _customer.Active = Convert.ToBoolean(Convert.ToInt16(_reader["CustomerActive"]));
            _customer.CreateDate = (DateTime)_reader["CustomerCreateDate"];
            _customer.LastUpdate = (DateTime)_reader["CustomerLastUpdate"];

            _customer.Address = new AddressMapHelper(_reader, "Customer").MapAddress();
            _customer.Store = MapStore();


        }

        private Store MapStore()
        {
            Store StoreObj = new Store();
            StoreObj.StoreId = Convert.ToInt32(_reader["StoreId"]);
            StoreObj.ManagerStaffId = Convert.ToInt32(_reader["StoreStaffId"]);
            StoreObj.LastUpdate = (DateTime)_reader["StoreLastUpdate"];
            StoreObj.AddressId = Convert.ToInt32(_reader["StoreAddressId"]);
            StoreObj.Address = new AddressMapHelper(_reader, "Store").MapAddress();
            StoreObj.ManagerStaff = MapStaff();
            return StoreObj;
        }

        private Staff MapStaff()
        {

            Staff StaffObj = new Staff();
            StaffObj.StaffId = Convert.ToInt32(_reader["StoreStaffId"]);
            StaffObj.FirstName = _reader["StaffFirstName"].ToString();
            StaffObj.LastName = _reader["StaffLastName"].ToString();
            StaffObj.AddressId = Convert.ToInt32(_reader["StaffAddressId"]);
            StaffObj.Email = _reader["StaffEmail"].ToString();
            StaffObj.Picture = _reader["StaffPicture"].ToString();
            StaffObj.Active = Convert.ToBoolean(Convert.ToInt16(_reader["StaffActive"]));
            StaffObj.Username = _reader["StaffUserName"].ToString();
            StaffObj.Password = _reader["StaffPassword"].ToString();
            StaffObj.LastUpdate = (DateTime)_reader["StaffLastUpdate"];
            StaffObj.Address = new AddressMapHelper(_reader, "Staff").MapAddress();
            return StaffObj;
        }

        public Customer GetCustomer()
        {
            return _customer;
        }
    }
}
