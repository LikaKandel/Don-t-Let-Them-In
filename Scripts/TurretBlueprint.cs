using UnityEngine;
using System.Collections;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;
    public int upgradeCost;
    public GameObject upgradedPrefab;
    

    public int GetSellAmount()
    {
        return cost / 2;
    }
    public int GetUpgradeAmount()
    {
        return cost / 2;
    }
}
