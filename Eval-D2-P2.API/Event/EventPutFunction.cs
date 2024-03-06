using Eval_D2_P2.Service.Contracts;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Newtonsoft.Json;
using System.Net;

namespace Eval_D2_P2.API.Event
{
    public class EventPutFunction
    {
        private readonly IEventService _eventService;

        public EventPutFunction(IEventService eventService)
        {
            _eventService = eventService;
        }

        [Function("EventPutFunction")]
        public async Task<HttpResponseData> Update([HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "events/{id}")] 
        HttpRequestData req,
        Guid id)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");

            try
            {
                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var newEvent = JsonConvert.DeserializeObject<Entity.Event>(requestBody);

                if (newEvent != null)
                {
                    var result = await this._eventService.Update(newEvent, id);

                    if (!result)
                    {
                        response.StatusCode = HttpStatusCode.BadRequest;
                    }
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
