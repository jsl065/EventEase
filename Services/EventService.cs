using EventEase.Models;

namespace EventEase.Services
{
    public class EventService
    {
        private readonly SessionStorageService _sessionStorageService;

        public EventService(SessionStorageService sessionStorageService)
        {
            _sessionStorageService = sessionStorageService;
        }

        public async Task<List<Event>> GetEvents()
        {
            var events = await _sessionStorageService.GetItemAsync<List<Event>>("events");
            if (events == null)
            {
                // Initial dummy data which is normally retrieved from a DB.
                events =
                [
                    new Event { Id = 1 , Name = "First event", Location = "Amsterdam", Date = new DateOnly(2000, 1, 1), AvailableSpots = 10},
                    new Event { Id = 2, Name = "Second event", Location = "Rotterdam", Date = new DateOnly(2010, 1, 1), AvailableSpots = 0}
                ];
            }
            return events;
        }

        public async Task<bool> RegisterForEvent(Registration registration)
        {
            var events = await GetEvents();
            var eventItem = events.FirstOrDefault(e => e.Id == registration.EventId);

            if (eventItem == null)
            {
                // TODO should probably throw an error
                return false;
            }

            if (eventItem.AvailableSpots == 0)
            {
                return false;
            }

            eventItem.AvailableSpots--;

            await _sessionStorageService.SaveItemAsync("events", events);
            return true;
        }
    }
}