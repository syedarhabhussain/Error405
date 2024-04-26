using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public void Setup()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        PlayerPrefs.DeleteKey("Health");
        PlayerPrefs.DeleteKey("Arrow");
        PlayerPrefs.DeleteKey("Ability");
        PlayerPrefs.SetInt("bossCheck", 0);
        SceneManager.LoadScene(2);
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Debug.Log(SceneManage.GetActiveScene());
    }
}
