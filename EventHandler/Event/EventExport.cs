namespace EventHandler.Event {
    public class EventExport {
        private EventList Events { get; set; }
        public EventExport(EventList events) {
            Events = events;
        }
    }
}