using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMaster : MonoBehaviour
{
    // refs
    [SerializeField] Tank playerTank;

    // selfrefs
    [SerializeField] TextMeshProUGUI topLayerText;
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        WeaponType playerTopLayer = playerTank.tankData.GetTopType();
        topLayerText.text = playerTopLayer.ToString();
    }
}
