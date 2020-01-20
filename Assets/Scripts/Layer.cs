using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer
{
    // type
    public WeaponType type { get; private set; }
    public float durability { get; private set; }
    public int uses { get; private set; }

    public Layer(WeaponType type, float durability, int uses)
    {
        this.type = type;
        if (durability <= 0 || durability > 100)
        {
            throw new ArgumentOutOfRangeException("Layer: Durability must be <0..100]");
        }
        this.durability = durability;
        if (uses <= 0 || uses > 3)
        {
            throw new ArgumentOutOfRangeException("Layer: Uses must be <0..3]");
        }
        this.uses = uses;
    }

    public void SetDurability(float delta)
    {
        if (delta > 100)
        {
            throw new ArgumentOutOfRangeException("Reduction of health for new layer can not exceed 100");
        }
        durability -= delta;
    }

    public void SetLayerBase(WeaponType type, float durability, int uses)
    {
        this.type = type;
        this.durability = durability;
        this.uses = uses;
    }
}
