using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float direction;
    [SerializeField] private float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float newZ = transform.position.z + speed*direction*Time.deltaTime;
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, newZ);
        transform.position = newPosition;
    }
}
