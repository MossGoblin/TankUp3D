using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    //refs
    [SerializeField] public PlayerController player;
    [SerializeField] public GridMaster gridMaster;
    [SerializeField] public CameraControl cameraMaster;
    [SerializeField] public InputController inputMaster;

    void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        gridMaster = GameObject.FindObjectOfType<GridMaster>();
        cameraMaster = GameObject.FindObjectOfType<CameraControl>();
        inputMaster = GameObject.FindObjectOfType<InputController>();
    }

}
