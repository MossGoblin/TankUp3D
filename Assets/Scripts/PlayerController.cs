using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // refs
    [SerializeField] GameMaster master;
    [SerializeField] Tank tank;
    [SerializeField] public GameObject tankChasis;
    [SerializeField] public GameObject tankTurretGun;
    [SerializeField] public GameObject tankTurretRocket;
    [SerializeField] public GameObject tankTurretRayGun;
    [SerializeField] public GameObject tankRocket;
    // models
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Layer newGunLayer = new Layer(WeaponType.Gun, 100, 3);
            tank.tankData.AddLayer(newGunLayer);
            DumpStack();

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Layer newRocketLayer = new Layer(WeaponType.Rocket, 100, 3);
            tank.tankData.AddLayer(newRocketLayer);
            DumpStack();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Layer newRaygunLayer = new Layer(WeaponType.Raygun, 100, 3);
            tank.tankData.AddLayer(newRaygunLayer);
            DumpStack();
        }
    }
    private void DumpStack()
    {
        Debug.Log("Stack size = " + tank.tankData.GetStackSize() + " / Last: " + tank.tankData.GetTopType().ToString());
    }}
