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
        
        rend = GetComponentInChildren<SpriteRenderer>();
        //rend.enabled = true;
    }   

    // Update is called once per frame      
    void Update()
    {
        UpdateArray();
        if(GameObject.FindGameObjectWithTag("Canvas").GetComponent<EnemyCount>() != null)
        {
            if(GameObject.FindGameObjectWithTag("Canvas").GetComponent<EnemyCount>().count <= 0) // if enemy count = 0
            {
                rend.enabled = false;
            }
            else
            {
                transform.right = (GetClosestEnemy(enemyTransform).position - this.transform.position).normalized;
                rend.enabled = true;
            }
        }
        else
        {
            if(GameObject.FindGameObjectWithTag("Canvas").GetComponent<IslandsCounter>().count <= 0 || allEnemies.Length == 0) // for slime abyss level bc it has a diff enemy count script
            {
                rend.enabled = false;
            }
            else
            {
                transform.right = (GetClosestEnemy(enemyTransform).position - this.transform.position).normalized;
                rend.enabled = true;
            }
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
