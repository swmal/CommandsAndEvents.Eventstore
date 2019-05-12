# CommandsAndEvents.Eventstore

Adds support for publishing domain events to [Eventstore](https://eventstore.org/)

Just add this nuget package from a CommandsAndEvents project and events will be published
on the stream based on the Aggregate root and the event name.

## Configuration
The stream provider reads the eventstore url from an environment variable named COMMANDS_EVENTS_EVENTSTORE_URL.
If this variable is not present, default value "tcp://admin:changeit@localhost:1113" will be used.
