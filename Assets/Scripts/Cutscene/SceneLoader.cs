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
        SceneManager.LoadScene("Start Menu", LoadSceneMode.Single);
    }
}
