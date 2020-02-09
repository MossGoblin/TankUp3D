using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // refs
    [SerializeField] GameMaster master;
    [SerializeField] public Tank tank;

    public void AddLayer(Layer layerType)
    {
        tank.tankData.AddLayer(layerType);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
