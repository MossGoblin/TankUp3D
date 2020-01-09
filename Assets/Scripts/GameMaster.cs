using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    //refs
    [SerializeField] public PlayerController player;
    [SerializeField] public GridMaster gridMaster;
    [SerializeField] public CameraControl cameraMaster;
    [SerializeField] public MouseController mouseMaster;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       HandleInput(); 
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Layer newGunLayer = new Layer(WeaponType.Gun, 100, 3);
            player.AddLayer(newGunLayer);
            DumpStack();

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Layer newRocketLayer = new Layer(WeaponType.Rocket, 100, 3);
            player.AddLayer(newRocketLayer);
            DumpStack();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Layer newRaygunLayer = new Layer(WeaponType.Raygun, 100, 3);
            player.AddLayer(newRaygunLayer);
            DumpStack();
        }
    }
    private void DumpStack()
    {
        Debug.Log("Stack size = " + player.tank.tankData.GetStackSize() + " / Last: " + player.tank.tankData.GetTopType().ToString());
    }
}
