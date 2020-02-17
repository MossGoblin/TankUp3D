using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    //refs
    [SerializeField] public PlayerController player;
    [SerializeField] public TerrainMaster gridMaster;
    [SerializeField] public CameraControl cameraMaster;
    [SerializeField] public InputController inputMaster;
    [SerializeField] public PoolManager poolMaster;

    void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        gridMaster = GameObject.FindObjectOfType<TerrainMaster>();
        cameraMaster = GameObject.FindObjectOfType<CameraControl>();
        inputMaster = GameObject.FindObjectOfType<InputController>();
        poolMaster = GameObject.FindObjectOfType<PoolManager>();
    }

}
