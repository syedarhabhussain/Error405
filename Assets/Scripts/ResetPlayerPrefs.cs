using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPrefs : MonoBehaviour
{
    public void ResetPrefs()
    {
        PlayerPrefs.DeleteKey("Health");
        PlayerPrefs.DeleteKey("Arrow");
        PlayerPrefs.DeleteKey("Ability");
    }

}
