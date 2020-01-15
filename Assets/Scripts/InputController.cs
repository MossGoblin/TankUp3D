using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    // refs
    [SerializeField]
    private GameMaster master;
    [SerializeField] private Camera camera;
    public RaycastHit mouseHit;

    void Awake() 
    {
        mouseHit = GetRayHitMouse();
    }
    void Update()
    {
       mouseHit = GetRayHitMouse();
       HandleInput();
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

    private void HandleInput()
    {
        // Escape for QUIT
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // 1-3 for Custom Layers
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Layer newGunLayer = new Layer(WeaponType.Gun, 100, 3);
            master.player.AddLayer(newGunLayer);
            DumpStack();

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Layer newRocketLayer = new Layer(WeaponType.Rocket, 100, 3);
            master.player.AddLayer(newRocketLayer);
            DumpStack();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Layer newRaygunLayer = new Layer(WeaponType.Raygun, 100, 3);
            master.player.AddLayer(newRaygunLayer);
            DumpStack();
        }

        // NumPad - for removing layers
        if (Input.GetKeyDown(KeyCode.KeypadMinus) && master.player.tank.tankData.GetStackSize() > 1)
        {
            master.player.tank.tankData.RemoveLayer();
            DumpStack();
        }
    }
    private void DumpStack()
    {
        Debug.Log($"Stack size = {master.player.tank.tankData.GetStackSize()} / Top: {master.player.tank.tankData.GetTopType().ToString()}");
        Debug.Log($"Balance: {master.player.tank.speedFactor}");
    }
}
