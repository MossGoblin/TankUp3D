using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Factory : MonoBehaviour
{
    // set up Instance
    public static Factory Instance {get; private set; }
    private static Dictionary<Layer, bool> layerPool;

    void Awake()
    {
        // setup Instance
        // check for conflicting Instances
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        
        layerPool = new Dictionary<Layer, bool>();
    }

    public static Layer CreateLayer(WeaponType type)
    {
        Layer newLayer;
        // check for inacive layers
        if (layerPool.Count > 0 && layerPool.ContainsValue(false))
        {
            // find a deactivated layer
            newLayer = layerPool.FirstOrDefault(l => l.Value == false).Key;
            // set it up
            newLayer.SetLayerBase(type, 100, 3);
            // activate it
            layerPool[newLayer] = true;
        }
        else
        {
            newLayer = new Layer(type, 100, 3);
            layerPool.Add(newLayer, true);
        }
        // Fire Event
        EventMaster.Instance.FireEvent(EventType.LayerCreated, new EventData($"Factory: new layer {newLayer.type.ToString()}"));
        return newLayer;
    }

    public static void DeactivateLayer(Layer layer)
    {
        if (!layerPool.ContainsKey(layer))
        {
            throw new KeyNotFoundException("The removed layer was NOT registered with the factory!");
        }
        else
        {
            layerPool[layer] = false;
        }
    }

    public static Layer CreateRandomLayer()
    {
        Layer newLayer;

        int randomTypeIndex = UnityEngine.Random.Range(0, 3);
        Array types = Enum.GetValues(typeof(WeaponType));
        WeaponType randomType = (WeaponType)types.GetValue(randomTypeIndex);

        // check for inacive layers
        if (layerPool.Count > 0 && layerPool.ContainsValue(false))
        {
            // find a deactivated layer
            newLayer = layerPool.FirstOrDefault(l => l.Value == false).Key;
            // set it up
            newLayer.SetLayerBase(randomType, 100, 3);
            // activate it
            layerPool[newLayer] = true;
        }
        else
        {
            newLayer = new Layer(randomType, 100, 3);
            layerPool.Add(newLayer, true);
        }
        // Fire Event
        EventMaster.Instance.FireEvent(EventType.LayerCreated, new EventData($"Factory: new RND layer {newLayer.type.ToString()}"));
        return newLayer;
    }

}
