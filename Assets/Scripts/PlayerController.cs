using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // refs
    [SerializeField] GameMaster master;
    [SerializeField] GameObject fullTurret;
    [SerializeField] GameObject rocket;
    // models
    [SerializeField] private GameObject[] models;
    [SerializeField] private bool state = true;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            state = !state;
            rocket.SetActive(state);
        }
    }
}
