using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour

{
    public static PoolManager instance;

    public static PoolManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("PoolManager");
                go.AddComponent<PoolManager>();
            }
            return instance;
        }
    }
    public Dictionary<Type, Dictionary<IProduct, bool>> pools;

    void Awake()
    {
        // setup Instance
        // check for conflicting Instances
        if (instance != null && instance != this) // FIXME : IS THIS NEEDED ??
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        
        pools = new Dictionary<Type, Dictionary<IProduct, bool>>();
    }
}
