using Microsoft.AspNetCore.Mvc;
using SRG_SYSTEM.DataAccess;
using SRG_SYSTEM.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SRG_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;
        private readonly IPageCosmosService _cosmosService;

        public CustomerController(ICustomerRepository repository, IPageCosmosService cosmosService)
        {
            _repository = repository;
            _cosmosService = cosmosService;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //try to get last item from the db
            var lastPageDb = await _cosmosService.GetPageTracker();
            var lastID = lastPageDb != null ? lastPageDb.LastPageNo : 0;

            //get customer list
            var customerList = _repository.GetCustomerList(lastID);
            var customerListLastId = customerList.LastOrDefault() == null ? 0 : customerList.LastOrDefault().CustomerId;
            var customerListCount = customerList.Count();


            var pgt = new PageTracker() { Id = "1", LastPageNo = customerListLastId };
            if (lastPageDb == null)
            {

                await _cosmosService.AddPageTracker(pgt);
            }
            else
            {
                if (customerListCount < 500)
                {
                    pgt.LastPageNo = 0;
                }

                await _cosmosService.UpdatePageTracker(pgt);
            }



            return Ok(customerList);
        }

    }
}
