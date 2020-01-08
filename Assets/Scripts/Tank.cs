using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    // refs
    PlayerController player;
    // Data
    public TankData tankData;
    private WeaponType currentWeapon;
    private Turret turret;

    // modifiers
    private float sizeFactor;
    private float damageFactor;
    public float speedFactor;
    private float accuracyFactor;
    private float rotationSpeedFactor;


    void Awake()
    {
        tankData = new TankData();
        player = GetComponentInParent<PlayerController>();
        // Debug.Log("Got player: " + player.ToString());
        turret = player.GetComponentInChildren<Turret>();
        CalculateFactors();
        turret.currentTurret = currentWeapon;
        Debug.Log("Got turret");
    }

    void Start()
    {
        // init data
    }

    // Update is called once per frame
    void Update()
    {
        CalculateFactors();
        UpdateVisualModel();
    }

    private void CalculateFactors()
    {
    // private float sizeFactor;
    // private float damageFactor;
    // public float speedFactor;
    // private float accuracyFactor;
    // private float rotationSpeedFactor;
        currentWeapon = tankData.GetTopType();
        sizeFactor = tankData.GetStackSize();
        damageFactor = tankData.GetTypeCount(currentWeapon);

    }

    private void UpdateVisualModel()
    {
        if (currentWeapon != turret.currentTurret)
        {
            turret.SwitchTurret(currentWeapon);
        }
    }
}
