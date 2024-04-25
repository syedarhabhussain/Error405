using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    I want to make the pointer appear when there are 15 or less enemies on the map and I want it to point towards the closest enemy to the player


    maybe something like detect closest on layer enemy
*/


/*
    currently need to find a way to get a list/array of all enemy positions and find the closest and then point the arrow to that one
    and I need it to change if that enemy dies or gets farther
*/

public class EnemyPointer : MonoBehaviour
{
    SpriteRenderer rend;
    public GameObject[] allEnemies;
    public GameObject nearestEnemy;

    // Start is called before the first frame update
    void Start()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        rend = GetComponentInChildren<SpriteRenderer>();
        rend.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        //GetClosestEnemy(enemyFloor.transform);
        //transform.right = ( GetClosestEnemy(allEnemies) - this.transform.position).normalized;
    }


    Transform GetClosestEnemy (Transform[] enemies)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach(Transform potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
     
        return bestTarget;
    }
}
