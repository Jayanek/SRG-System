using MySql.Data.MySqlClient;
using SRG_SYSTEM.Models;
using System.Text;

namespace SRG_SYSTEM.Services
{
    public class AddressMapHelper
    {
        private readonly MySqlDataReader _reader;
        private readonly string _prefix;

        public AddressMapHelper(MySqlDataReader reader, string prefix)
        {
            _reader = reader;
            _prefix = prefix;
        }
        public Address MapAddress()
        {
            Address AddressObj = new Address();
            AddressObj.AddressId = Convert.ToInt32(_reader[$"{_prefix}AddressId"]);
            AddressObj.Address1 = _reader[$"{_prefix}Address"].ToString();
            AddressObj.Address2 = _reader[$"{_prefix}Address2"].ToString();
            AddressObj.District = _reader[$"{_prefix}District"].ToString();
            AddressObj.CityId = Convert.ToInt32(_reader[$"{_prefix}CityId"]);
            AddressObj.PostalCode = _reader[$"{_prefix}PostalCode"].ToString();
            AddressObj.Phone = _reader[$"{_prefix}Phone"].ToString();
            AddressObj.Location = Encoding.ASCII.GetString((Byte[])(_reader[$"{_prefix}Location"]));
            AddressObj.LastUpdate = (DateTime)_reader[$"{_prefix}LastUpdate"];
            AddressObj.City = MapAddressCity();
            return AddressObj;
        }

        private City MapAddressCity()
        {

            City CityObj = new City();
            CityObj.CityId = Convert.ToInt32(_reader[$"{_prefix}CityId"]);
            CityObj.City1 = _reader[$"{_prefix}City"].ToString();
            CityObj.CountryId = Convert.ToInt32(_reader[$"{_prefix}CountryId"]);
            CityObj.Country = MapAddressCityCountry();

            return CityObj;
        }

        private Country MapAddressCityCountry()
        {

            Country CountryObj = new Country();
            CountryObj.CountryId = Convert.ToInt32(_reader[$"{_prefix}CountryId"]);
            CountryObj.Country1 = _reader[$"{_prefix}Country"].ToString();

            return CountryObj;
        }
    }
}
