using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    // refs
    [SerializeField]
    private GameMaster master;
    [SerializeField] private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public RaycastHit GetRayHitMouse()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit mousePositionHit;
        if(Physics.Raycast(ray, out mousePositionHit))
        {
            return mousePositionHit;
        }
        return mousePositionHit;

    }
}
