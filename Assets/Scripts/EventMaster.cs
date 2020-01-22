using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventMaster : MonoBehaviour
{
    public static EventMaster Instance {get; private set; }
    public delegate void EventListener(EventData eventData);
    public Dictionary<EventType, HashSet<EventListener>> eventCollection;

    private void Awake()
    {
        // setup Instance
        // check for conflicting Instances
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        eventCollection = new Dictionary<EventType, HashSet<EventListener>>();
    }

    public void RegisterListener(EventType eventType, EventListener eventListener)
    {
        if (!eventCollection.ContainsKey(eventType))
        {
            eventCollection.Add(eventType, new HashSet<EventListener>());
        }
        eventCollection[eventType].Add(eventListener);
    }
    
    public void UnRegisterListener(EventListener eventListener)
    {
        foreach (var set in eventCollection)
        {
            if (set.Value.Contains(eventListener))
            {
                set.Value.Remove(eventListener);
            }
        }
    }
    public void FireEvent(EventType eventType, EventData eventData)
    {
        if (eventCollection.ContainsKey(eventType))
        {
            foreach (EventListener listener in eventCollection[eventType])
            {
                listener(eventData);
            }
        }
    }
}
