using Eval_D2_P2.Service.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Newtonsoft.Json;
using System.Net;

namespace Eval_D2_P2.API.Event
{
    public class EventGetFunction
    {
        private readonly IEventService _eventService;
        public EventGetFunction(IEventService eventService)
        {
            _eventService = eventService;
        }

        [Function("EventGetFunction")]
        public async Task<HttpResponseData> GetAll([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "events")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");

            try
            {
                var allEvents = await this._eventService.GetAll();
                var events = allEvents as Entity.Event[] ?? allEvents.ToArray();
                
                await response.WriteStringAsync(
                JsonConvert.SerializeObject(
                    new
                    {
                        events
                    }));
            }
            catch (Exception e)
            {
                await response.WriteStringAsync(e.Message);
                response.StatusCode = HttpStatusCode.NotFound;
            }

            return response;
        }
    }
}
