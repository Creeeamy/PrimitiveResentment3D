using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool paused;
    PauseAction action;

    private void Awake()
    {
        action = new PauseAction();  
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void Start()
    {
        paused = false;
        action.Pause.PauseGame.performed += _ => DeterminePause();
    }

    private void DeterminePause()
    {
        if (paused)
        {
            ResumeGame();
        } else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
