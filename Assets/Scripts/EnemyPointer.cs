using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPointer : MonoBehaviour
{
    SpriteRenderer rend;
    public GameObject[] allEnemies;
    public GameObject nearestEnemy;
    public Transform[] enemyTransform;

    // Start is called before the first frame update
    void Start()
    {
        UpdateArray();
        rend = GetComponentInChildren<SpriteRenderer>();
        //rend.enabled = true;
    }   

    // Update is called once per frame      
    void Update()
    {
        transform.right = (GetClosestEnemy(enemyTransform).position - this.transform.position).normalized;
        
        if(GameObject.FindGameObjectWithTag("Canvas").GetComponent<EnemyCount>().count <= 0) // if enemy count = 0
        {
            rend.enabled = false;
        }
        else
        {
            rend.enabled = true;
        }
        
    }


    Transform GetClosestEnemy (Transform[] enemies)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach(Transform potentialTarget in enemies)
        {
            if(potentialTarget != null)
            {
                Vector3 directionToTarget = potentialTarget.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if(dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = potentialTarget;
                }
            }
        }
     
        return bestTarget;
    }

    public void UpdateArray()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyTransform = new Transform[allEnemies.Length];
        for(int i = 0; i < allEnemies.Length; i++)
        {
            enemyTransform[i] = allEnemies[i].transform;
        }
    }
}
