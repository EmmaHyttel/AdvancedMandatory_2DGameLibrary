using GameLibrary.Enums;

namespace GameLibrary.Events
{
    public class CreatureEvent : EventArgs
    {
        public CreatureEventTypes EventType { get; init; }

        public CreatureEvent(CreatureEventTypes eventType)
        {
            EventType = eventType;
        }
    }
}
