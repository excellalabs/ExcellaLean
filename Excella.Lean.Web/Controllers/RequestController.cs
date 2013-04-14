namespace Excella.Lean.Web.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;

    using Excella.Lean.Core.Models.Events;

    public class RequestController : ApiController
    {

        public RequestController()
        {
            
        }

        // POST ~/api/Request/RequestReservation
        [HttpPost]
        public async Task<ReservationResult> RequestCalc(ReservationRequest request)
        {
            var result = await 
            return result;
        }

    }
}
