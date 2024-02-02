using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class CloseOnClick : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject levelsMenu;
    [SerializeField] public float delayTime;
    
    public void OpenMenuCloseOptions()
    {
        StartCoroutine(Delay(delayTime));
    }

    IEnumerator Delay(float delayTime)
    {
        // Wait
        yield return new WaitForSeconds(delayTime);

        // Close Options and Load Main Menu
        optionsMenu.SetActive(false);
        levelsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
