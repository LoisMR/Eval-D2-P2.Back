using Azure;
using Eval_D2_P2.Service.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Newtonsoft.Json;
using System.Net;

namespace Eval_D2_P2.API.Event
{
    public class EventDeleteFunction
    {
        private readonly IEventService _eventService;
        public EventDeleteFunction(IEventService eventService)
        {
            _eventService = eventService;
        }

        [Function("EventDeleteFunction")]
        public async Task<HttpResponseData> DeleteEvent([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "events/{id}")]
        HttpRequestData req,
        Guid id)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");

            try
            {
                var result = await this._eventService.Delete(id);

                if (!result)
                {
                    await response.WriteStringAsync($"Event id not found : {id}");
                    response.StatusCode = HttpStatusCode.NotFound;
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
