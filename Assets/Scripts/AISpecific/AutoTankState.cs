using System.Collections.Generic;
using UnityEngine;

public class AutoTankState : MonoBehaviour
{
     // create and hold a context
     private Context context;

     [SerializeField] private Tank tank;
     private Sensor sensor;

    // Should ALL properties of the sensor should be controlled from HERE ??
     // sensor pulse timing
     private float sensorTiming = 0f;
     [SerializeField]
     [Range(0, 10f)]
     private float sensorPingTime = 2f;

     private void Awake() 
     {
         sensor = this.gameObject.GetComponent<Sensor>();
         tank = this.gameObject.GetComponentInChildren<Tank>();
         context = new Context(sensor.objectsInRange, tank);
         Debug.Log("Context fPrint: " + context.fPrint);
     }

     private void FixedUpdate() 
     {
        if (sensorTiming <= sensorPingTime)
        {
            sensorTiming += Time.deltaTime;
        }
        else
        {
            List<GameObject> objectsInRange = sensor.Ping();
            context.Update(objectsInRange);
            Debug.Log("Sensor Ping! : " + context.fPrint);
            sensorTiming = 0;
        }
     }
}
