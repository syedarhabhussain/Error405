using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public List<Loot> lootList = new List<Loot>();
    public float dropForce = 300f;
   
    List<Loot> GetDroppedItems()
    {
        List<Loot> possibleItems = new List<Loot>();
        List<Loot> possibleUpgrades = new List<Loot>();
        foreach (Loot item in lootList)
        {
            if(!item.isUpgrade && Random.Range(1, 101) <= item.dropChance)
            {
                possibleItems.Add(item);
            }
            if(item.isUpgrade && Random.Range(1, 101) <= item.dropChance)
            {
                possibleUpgrades.Add(item);
            }
        }

        while(possibleUpgrades.Count > 1)
        {
            possibleUpgrades.RemoveAt(Random.Range(0,possibleUpgrades.Count));
        }

        if(possibleUpgrades.Count > 0)
            possibleItems.Add(possibleUpgrades[0]);
        
        return possibleItems;
    }

    public void InstantiateLoot(Vector3 spawnPos)
    {
        List<Loot> droppedItems = GetDroppedItems();
        if(droppedItems != null)
        {
            foreach(Loot item in droppedItems)
            {
                //Create the loot item(s)
                GameObject lootGameObject = Instantiate(item.lootPrefab, spawnPos, Quaternion.identity);
                //Make the item move a bit when spawning
                Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);
            }
        }
    }

}
