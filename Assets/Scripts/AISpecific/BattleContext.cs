using UnityEngine;
using System;
using System.Collections.Generic;

public class ContextAnalyzer
{
    public int fPrint { get; private set; }
    public SensorPackage sensorPackage;
    public Tank contextOwner { get; private set; }
    public List<GameObject> agentsList {get; private set;}
    public List<GameObject> assetList { get; private set; }
    public int ownSize { get; private set; }

    public ContextAnalyzer(List<GameObject> targetList, Tank owner)
    {
        this.contextOwner = owner;
        this.ownSize = owner.tankData.GetStackSize();
        agentsList = new List<GameObject>();
        assetList = new List<GameObject>();
        SortActorsAndAssets(targetList);
        fPrint = CreateFingerPrint();
        sensorPackage = CreateSensorPackage(); // for struct comparison use struct1.Equals(struct2);
    }

    private int CreateFingerPrint()
    {
        // TODO : HERE - create context fingerprint
        // 1. how should we construct the fingerprint ??
        // 2. what should we include in the fingerprint ??
        
        /*
         2. list of variables:
         -. number of agents - int
         -. total size of agents - int
         -. size of largest agent - int
         -. presence of layers - bool
         -. presence of upgrades - bool
        */

        // Let's try a simple int fingerprint // FIXME : Not sure this fPrint is the best way forward
        fPrint += 
            agentsList.Count * 10000 +
            GetTotalSize(agentsList) * 1000 +
            GetMaxSize(agentsList) * 100 +
            LayersPresence(assetList) * 10 +
            UpgradesPresence(assetList);
        
        return fPrint;
    }

    private SensorPackage CreateSensorPackage()
    {
        SensorPackage package = new SensorPackage();
        package.NumberOfAgents = agentsList.Count;
        package.TotalSizeOfAgents = GetTotalSize(agentsList);
        package.MaxSizeOfAgents = GetMaxSize(agentsList);
        package.LayersInRange = LayersPresence(assetList) == 1 ? true : false;
        package.UpgradesInRange = UpgradesPresence(assetList) == 1 ? true : false;

        return package;
    }

    private int UpgradesPresence(List<GameObject> assetList)
    {
        int result = 0;
        foreach (var asset in assetList)
        {
            if (asset.GetComponent<AssetData>().assetType == AssetType.Upgrade)
            {
                result = 1;
                break;
            }
        }
        return result;
    }

    private int LayersPresence(List<GameObject> assetList)
    {
        int result = 0;
        foreach (var asset in assetList)
        {
            if (asset.GetComponent<AssetData>().assetType == AssetType.Layer)
            {
                result = 1;
                break;
            }
        }
        return result;
    }

    private int GetMaxSize(List<GameObject> agentsList)
    {
        int result = 0;
        foreach (var agent in agentsList)
        {
            result = Mathf.Max(result, agent.GetComponent<Tank>().tankData.GetStackSize());
        }
        return result;
    }

    private int GetTotalSize(List<GameObject> agentsList)
    {
        int result = 0;
        foreach (var agent in agentsList)
        {
            result += agent.gameObject.GetComponent<Tank>().tankData.GetStackSize();
        }
        return result;
    }

    private void SortActorsAndAssets(List<GameObject> targetList)
    {
        foreach (GameObject target in targetList)
        {
            if (target.gameObject.layer == 9) // if the target is a combatant
            {
                agentsList.Add(target);
            }
            else if (target.gameObject.layer == 10) // if the target is a pickup
            {
                assetList.Add(target);
            }
        }
    }
}