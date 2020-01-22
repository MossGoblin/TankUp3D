using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventData
{
    public GameObject anchor { get; private set; }
    public string EventMessage {get; private set; }

    public EventData(string eventMessage)
    {
        this.EventMessage = eventMessage;
    }
    public EventData()
    {
    }
}
