using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankData
{
    // stack
    public Stack<Layer> layerStack { get; private set; }


    public TankData(Layer initLayer)
    {
        layerStack = new Stack<Layer>();
        layerStack.Push(initLayer);
    }

    public TankData()
    {
        int randomTypeIndex = UnityEngine.Random.Range(0, 3);
        Array types = Enum.GetValues(typeof(WeaponType));
        WeaponType randomType = (WeaponType)types.GetValue(randomTypeIndex);
        Layer randomLayer = new Layer(randomType, 100, 3);
        layerStack = new Stack<Layer>();
        layerStack.Push(randomLayer);
    }

    public int GetStackSize()
    {
        return layerStack.Count;
    }

    public WeaponType GetTopType()
    {
        return layerStack.Peek().type;
    }

    public int GetTypeCount(WeaponType type)
    {
        int result = 0;
        foreach (Layer layer in layerStack)
        {
            if (layer.type == type)
            {
                result++;
            }
        }
        return result;
    }

    public void AddLayer(Layer newLayer)
    {
        layerStack.Push(newLayer);
    }
}
