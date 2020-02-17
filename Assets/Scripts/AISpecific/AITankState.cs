using UnityEngine;

public class AITankState : MonoBehaviour
{
     // create and hold a context
     private Context context;
     [SerializeField] private Tank tank;
     private AISensor sensor;

     private void Awake() 
     {
         sensor = this.gameObject.GetComponent<AISensor>();
         tank = this.gameObject.GetComponentInChildren<Tank>();
         context = new Context(sensor.objectsInRange, tank);
         Debug.Log("Context fPrint: " + context.fPrint);
     }
}
