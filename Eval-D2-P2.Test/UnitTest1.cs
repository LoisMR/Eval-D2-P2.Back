using Eval_D2_P2.Entity;
using Eval_D2_P2.Service.Contracts;

namespace Eval_D2_P2.Test
{
    public class EventTests
    {
        private IEventService _eventService;

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public async Task AddEvent_ShouldReturnCreatedStatusCode()
        {
            // Arrange
            var newEvent = new Event
            {
                Title = "Test Event",
                Description = "Test Event Description",
                Date = DateTime.Now,
                Location = "Test Location"
            };

            // Act
            await _eventService.Add(newEvent);

            // Assert
            //Assert.IsTrue(HttpStatusCode.Created);

        }


        [Test]
        public async Task DeleteEvent_ShouldRemoveEventFromDatabase()
        {
            // Arrange
            var eventId = Guid.NewGuid();

            // Act
            var result = await _eventService.Delete(eventId);

            // Assert
            Assert.IsTrue(result);
        }

        // Ajoutez des tests similaires pour GetAll et Update selon vos besoins

        [Test]
        public async Task UpdateEvent_ShouldUpdateEventInDatabase()
        {
            // Arrange
            var eventId = Guid.NewGuid();

            var updatedEvent = new Event
            {
                Id = eventId,
                Title = "Updated Event",
                Description = "Updated Description",
                Date = DateTime.Now,
                Location = "Updated Location"
            };

            // Act
            var result = await _eventService.Update(updatedEvent, eventId);

            // Assert
            Assert.IsTrue(result);

        }
    }
}
