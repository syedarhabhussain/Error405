using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    public GameObject canvas;

    private bool isPaused;

    void Update()
    {
        LoadMainMenu();
    }

    public void LoadMainMenu()
    {
        isPaused = canvas.activeSelf;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = isPaused ? 1 : 0;
            canvas.SetActive(!isPaused);
            GameObject warningPanel = canvas.transform.Find("Warning Panel").gameObject;
            GameObject settingsPanel = canvas.transform.Find("Settings Panel").gameObject;

            warningPanel.SetActive(false);
            settingsPanel.SetActive(false);
        }
    }

    public void CloseMenuOnClick()
    {
        canvas.SetActive(false);
        Time.timeScale = 1;
    }
}
