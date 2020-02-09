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
    public Vector3 originalScale;
    public float currentScaleFactor;
    public int sizeFactor;
    public float damageFactor;
    public float speedFactor;
    public float accuracyFactor;
    public float rotationSpeedFactor;


    void Awake()
    {
    }

    void Start()
    {
        // init data
        originalScale = this.transform.localScale;
        currentScaleFactor = 1;
        tankData = new TankData();
        player = GetComponentInParent<PlayerController>();
        // Debug.Log("Got player: " + player.ToString());
        turret = player.GetComponentInChildren<Turret>();
        CalculateFactors();
        turret.currentTurret = currentWeapon;
        // Debug.Log("Got turret");
    }

    void Update()
    {
        CalculateFactors();
        UpdateVisualModel();
    }

    private void CalculateFactors()
    {
        // private float sizeFactor; -- stack size
        sizeFactor = tankData.GetStackSize();
        // private float damageFactor; - number of layers same as the top layer
        damageFactor = tankData.GetTypeCount(tankData.GetTopType());
        // public float speedFactor; - balance
        int[] tankStateCollection = tankData.GetStateCollection();
        speedFactor = ToolBox.GetDisbalance(tankStateCollection);
        // private float accuracyFactor; - size factor
        accuracyFactor = tankData.GetStackSize();
        // private float rotationSpeedFactor; - balance
        rotationSpeedFactor = ToolBox.GetDisbalance(tankStateCollection);


        currentWeapon = tankData.GetTopType();
    }

    private void UpdateVisualModel()
    {
        UpdateSize(sizeFactor);
        UpdateTurret();
    }


    private void UpdateSize(int sizeFactor)
    {
        if (currentScaleFactor != sizeFactor)
        {
            float sigmoidFactor = ToolBox.Sigmoid(sizeFactor);
            float newScaleX = originalScale.x * sigmoidFactor;
            float newScaleY = originalScale.y * sigmoidFactor;
            float newScaleZ = originalScale.z * sigmoidFactor;
            Vector3 newScale = new Vector3(newScaleX, newScaleY, newScaleZ);
            player.transform.localScale = newScale;
            // Debug.Log($"Scale: {sizeFactor} - {sigmoidFactor}");
            currentScaleFactor = sizeFactor;
        }
    }
    private void UpdateTurret()
    {
        if (currentWeapon != turret.currentTurret)
        {
            turret.SwitchTurret(currentWeapon);
        }
    }

}
