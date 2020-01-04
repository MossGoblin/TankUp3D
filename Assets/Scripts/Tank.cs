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

    // modifiers
    private float sizeFactor;
    private float damageFactor;
    public float speedFactor;
    private float accuracyFactor;
    private float rotationSpeedFactor;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
        // Debug.Log("Got player: " + player.ToString());
        // init data
        tankData = new TankData();

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
        switch (currentWeapon)
        {
            case WeaponType.Gun:
            {
                player.tankTurretGun.SetActive(true);
                player.tankTurretRocket.SetActive(false);
                player.tankTurretRayGun.SetActive(false);
                player.tankRocket.SetActive(false);
            }
            break;
            case WeaponType.Rocket:
            {
                player.tankTurretGun.SetActive(false);
                player.tankTurretRocket.SetActive(true);
                player.tankTurretRayGun.SetActive(false);
                player.tankRocket.SetActive(true);
            }
            break;
            case WeaponType.Raygun:
            {
                player.tankTurretGun.SetActive(false);
                player.tankTurretRocket.SetActive(false);
                player.tankTurretRayGun.SetActive(true);
                player.tankRocket.SetActive(false);
            }
            break;
            default:
                throw new ArgumentOutOfRangeException("Tank: Trying to update visuals by a non-existing weapon type");
        }
    }
}
