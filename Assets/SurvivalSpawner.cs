using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    need a timer to know when to spawn and a series of stages to go through
    so at stage 1 its easy and ass you add stages more variants/enemy types get added

*/

public class SurvivalSpawner : MonoBehaviour
{
    [SerializeField] float currentTime;
    [SerializeField] float timeTillSpawn;
    [SerializeField] float maxTimer;
    [SerializeField] float timeChange;
    [SerializeField] int timesSpawned = 0;  // once this hits a certain number change what enemy and counter its using
    [SerializeField] int difficultyTier = 0;
    [SerializeField] int difficultyChange;  //what number should the difficulty go up on
    [SerializeField] int startingDifficultyTier = 0;    //what difficulty tier should the spawner start
    [SerializeField] bool miniBossSpawn;


    public List<GameObject> mobs;

    // Start is called before the first frame update
    void Start()
    {
        //spawn enemies (give them inf range) then set the timer
        if(!miniBossSpawn && startingDifficultyTier == 0)
        {
            SpawnMobs();
            timesSpawned = 1;
            currentTime = timeTillSpawn;
        }
        else
        {
            currentTime = timeTillSpawn;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if(difficultyTier >= startingDifficultyTier)
        {
            if(currentTime <= 0.0f)
            {
                SpawnMobs();
                timesSpawned += 1;
                currentTime = timeTillSpawn;


                if((timesSpawned % difficultyChange) == 0)
                {
                    difficultyTier += 1;
                }


                if(difficultyChange > 1)
                {
                    if((difficultyTier % 3) == 0 && difficultyTier != 0)
                    {
                        difficultyChange -= 1;
                    }
                }


                if(timeTillSpawn < maxTimer && difficultyTier % 2 == 0 && difficultyTier != 0)
                    timeTillSpawn += timeChange;
            }
        }
        else
        {
            if(currentTime <= 0.0f)
            {
                timesSpawned += 1;
                currentTime = timeTillSpawn;


                if((timesSpawned % difficultyChange) == 0)
                {
                    difficultyTier += 1;
                    

                }


                if(difficultyChange > 1)
                {
                    if((difficultyTier % 3) == 0 && difficultyTier != 0)
                    {
                        difficultyChange -= 1;
                    }
                }


                if(timeTillSpawn < maxTimer && difficultyTier % 2 == 0 && difficultyTier != 0)
                    timeTillSpawn += timeChange;
            }
        }
    }

    void SpawnMobs()
    {
        if(difficultyTier < mobs.Count)
        {
            
            if(difficultyTier == 0)
            {
                GameObject mob = Instantiate(mobs[Random.Range(0, difficultyTier)], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                mob.GetComponent<BasicEnemy>().detectRange = 100;
            }
            
            else if(difficultyTier > 0)
            {
                GameObject mob = Instantiate(mobs[Random.Range(0, difficultyTier)], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                if(mob.GetComponent<BasicEnemy>() != null)
                    mob.GetComponent<BasicEnemy>().detectRange = 100;
                if(mob.GetComponent<RangedEnemy>() != null)
                    mob.GetComponent<RangedEnemy>().detectRange = 100;
                if(mob.GetComponent<ChargingSlime>() != null)
                    mob.GetComponent<ChargingSlime>().detectRange = 100;
                if(mob.GetComponent<ElectroBirdEnemy>() != null)
                    mob.GetComponent<ElectroBirdEnemy>().detectRange = 100;
                if(mob.GetComponent<LightningBirdEnemy>() != null)
                    mob.GetComponent<LightningBirdEnemy>().detectRange = 100;
                if(mob.GetComponent<CloudsquatchEnemy>() != null)
                    mob.GetComponent<CloudsquatchEnemy>().detectRange = 100;
            }
        }
        else if(difficultyTier >= mobs.Count)
        {
            GameObject mob = Instantiate(mobs[Random.Range(0, mobs.Count-1)], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            if(mob.GetComponent<BasicEnemy>() != null)
                mob.GetComponent<BasicEnemy>().detectRange = 100;
            if(mob.GetComponent<RangedEnemy>() != null)
                mob.GetComponent<RangedEnemy>().detectRange = 100;
            if(mob.GetComponent<ChargingSlime>() != null)
                mob.GetComponent<ChargingSlime>().detectRange = 100;
            if(mob.GetComponent<ElectroBirdEnemy>() != null)
                mob.GetComponent<ElectroBirdEnemy>().detectRange = 100;
            if(mob.GetComponent<LightningBirdEnemy>() != null)
                mob.GetComponent<LightningBirdEnemy>().detectRange = 100;
            if(mob.GetComponent<CloudsquatchEnemy>() != null)
                mob.GetComponent<CloudsquatchEnemy>().detectRange = 100;
            
            
        }
    }
}
