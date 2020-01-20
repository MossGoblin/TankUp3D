using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        layerStack = new Stack<Layer>();
        layerStack.Push(Factory.CreateRandomLayer());
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
    public int[] GetStateCollection()
    {
        int numberOfWeaponTypes = Enum.GetNames(typeof(WeaponType)).Length;
        int[] stateArray = new int[numberOfWeaponTypes]; // number of weapon types
        foreach (Layer layer in layerStack)
        {
            stateArray[(int)layer.type]++;
        }
        return stateArray;
    }

    public void AddLayer(Layer newLayer)
    {
        layerStack.Push(newLayer);
    }

    public Layer RemoveLayer()
    {
        return layerStack.Pop();
    }

}
