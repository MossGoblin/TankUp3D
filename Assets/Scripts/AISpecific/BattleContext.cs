using UnityEngine;
using System;
using System.Collections.Generic;

public class BattleContext
{
    public int fingerprint { get; private set; }
    public Tank contextOwner { get; private set; }
    public List<GameObject> actorsList {get; private set;}
    public List<GameObject> assetList { get; private set; }
    public int ownSize { get; private set; }

    public BattleContext(List<GameObject> targetList, Tank owner)
    {
        this.contextOwner = owner;
        this.ownSize = owner.tankData.GetStackSize();
        actorsList = new List<GameObject>();
        assetList = new List<GameObject>();
        SortActorsAndAssets(targetList);
        fingerprint = CreateFingerPrint();
    }

    private int CreateFingerPrint()
    {
        // TODO : HERE - create context fingerprint
        throw new NotImplementedException();
    }

    private void SortActorsAndAssets(List<GameObject> targetList)
    {
        foreach (GameObject target in targetList)
        {
            if (target.gameObject.layer == 9) // if the target is a combatant
            {
                actorsList.Add(target);
            }
            else if (target.gameObject.layer == 10) // if the target is a pickup
            {
                assetList.Add(target);
            }
        }
    }
}