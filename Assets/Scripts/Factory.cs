using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Factory
{
    private static Dictionary<Layer, bool> layerPool;
            //     Layer newGunLayer = new Layer(WeaponType.Gun, 100, 3);
            // master.player.AddLayer(newGunLayer);
            // DumpStack();

    static Factory()
    {
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
        // set up the new layer
        
        return newLayer;
    }

}
