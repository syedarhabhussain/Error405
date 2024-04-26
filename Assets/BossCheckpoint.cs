using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCheckpoint : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("bossCheck") == 1)    //gets saved in checkpoint trigger used here
        {
            Debug.Log("deleted from checkpoint");
            Destroy(gameObject);
        } 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
