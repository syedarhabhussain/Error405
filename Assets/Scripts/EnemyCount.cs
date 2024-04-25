using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{
    public TMP_Text enemyCounterText;
    public GameObject enemyFloor;
    public GameObject portal;

    public int count;

    // Start is called before the first frame update
    void Start()
    {
        enemyCounterText.text = "Enemies Left:" + count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        count = enemyFloor.transform.childCount;
        enemyCounterText.text = "Enemies Left:" + count.ToString();

        if (count == 0)
        {
            portal.SetActive(true);
        }
    }
}
