using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    [SerializeField] bool bossCheckpoint = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.savedCheckpoint = transform.position;

            if(bossCheckpoint)
            {   
                PlayerPrefs.SetInt("bossCheck", 1);
                PlayerPrefs.SetFloat("bossX", transform.position.x);
                PlayerPrefs.SetFloat("bossY", transform.position.y);
                
                //set an x and y for the player based on the checkpoint location and make that their spawn point
            }
            else
            {
                PlayerPrefs.SetInt("bossCheck", 0);
            }

            Debug.Log("CheckpointTrigger");
        }
    }
}
