using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour

{
    public static PoolManager Instance { get; private set; }
    public Dictionary<Type, Dictionary<IProduct, bool>> pools;

    void Awake()
    {
        // setup Instance
        // check for conflicting Instances
        if (Instance != null && Instance != this) // FIXME : IS THIS NEEDED ??
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        pools = new Dictionary<Type, Dictionary<IProduct, bool>>();
    }
}
