using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNext()
    {
        OnEnable();
    }

    void OnEnable()
    {
        PlayerPrefs.SetInt("bossCheck", 0);
        SceneManager.LoadScene("Start Menu", LoadSceneMode.Single);
    }
}
