using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] tankTurretModels;
    [SerializeField] private GameObject tankRocket;
    public WeaponType currentTurret;

    private void Awake()
    {
        player = GetComponentInParent<PlayerController>().gameObject;
        tankRocket.SetActive(false);
    }
    private void Start() 
    {
        SwitchTurret(currentTurret);
    }

    public void SwitchTurret(WeaponType currentWeapon)
    {
        int typeNumber = (int)currentWeapon;
        foreach (var turret in tankTurretModels)
        {
            turret.SetActive(false);
        }
        tankTurretModels[typeNumber].SetActive(true);
        if (typeNumber == 1)
        {
            tankRocket.SetActive(true);
        }
        else
        {
            tankRocket.SetActive(false);
        }
        currentTurret = currentWeapon;
    }
}
