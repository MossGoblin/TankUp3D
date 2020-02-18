using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event // FIXME : WILL BE DEPRECATED; APPARENTLY NOT NEEDED AT THE MOMENT
{
    public EventType eventType { get; private set; }
    public EventData eventData { get; private set; }
    public Event(EventData eventData)
    {
        this.eventData = eventData;
    }
}
