using Eval_D2_P2.Service.Contracts;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;

namespace Eval_D2_P2.API.Event
{
    public class EventPostFunction
    {
        private readonly IEventService _eventService;

        public EventPostFunction(IEventService eventService)
        {
            _eventService = eventService;
        }

        [Function("EventPostFunction")]
        public async Task<HttpResponseData> Add([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "events")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.Created);
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");

            try
            {
                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var newEvent = JsonConvert.DeserializeObject<Entity.Event>(requestBody);

                if (newEvent != null)
                {
                    await this._eventService.Add(newEvent);
                }
            }
            catch (JsonException e)
            {
                await response.WriteStringAsync($"Invalid JSON : {e.Message}");
                response.StatusCode = HttpStatusCode.BadRequest;
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
