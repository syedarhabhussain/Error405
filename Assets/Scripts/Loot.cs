using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Loot : ScriptableObject
{
    public string lootName;
    public int dropChance;
    public GameObject lootPrefab;
    public bool isUpgrade;

    public Loot(string lootName, int dropChance, GameObject lootPrefab, bool isUpgrade)
    {
        this.lootName = lootName;
        this.dropChance = dropChance;
        this.lootPrefab = lootPrefab;
        this.isUpgrade = isUpgrade;
    }

}
