using System;
using System.Collections.Generic;
using System.Text;
using CommandsAndEvents.Events;
using EventStore.ClientAPI;

namespace CommandsAndEvents.EventStore
{
    /// <summary>
    /// A <see cref="EventStreamProvider"/> for Eventstore
    /// </summary>
    public class EventstoreStreamProvider : EventStreamProvider
    {
        /// <summary>
        /// Publish an event on a stream.
        /// </summary>
        /// <param name="eventId">Id of the event</param>
        /// <param name="stream">Name of the stream</param>
        /// <param name="eventName">Name of the event type</param>
        /// <param name="data">Event data</param>
        public override void Publish(Guid eventId, string stream, string eventName, byte[] data)
        {
            var connection = EventStoreStreamConnection.GetConnection();
            var eventData = new EventData(eventId, eventName, true, data, null);
            connection.AppendToStreamAsync(stream, ExpectedVersion.Any, eventData).Wait();
        }
    }
}