using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 2f;

    public void PlayGame()
    {
        PlayerPrefs.SetInt("bossCheck", 0);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void PlayFloorOne()
    {
        PlayerPrefs.SetInt("bossCheck", 0);
        StartCoroutine(LoadLevel(2));
    }

    public void PlayFloorTwo()
    {
        PlayerPrefs.SetInt("bossCheck", 0);
        StartCoroutine(LoadLevel(3));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Play animation
        transition.SetTrigger("Start");

        // Wait
        yield return new WaitForSeconds(transitionTime);

        // Load scene
        SceneManager.LoadSceneAsync(levelIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
