using UnityEngine;
public class CubeTank : MonoBehaviour
{
    Tank tank;
    
    private void Awake() 
    {
        tank = new Tank();
    }
}