using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public GameObject PauseButton = null;
    public GameObject ResumeButton = null;
    public GameObject BackToMainMenuButton = null;
    public GameObject LeftAndRightArrowsImage = null;
    public GameObject UpArrowAndSpace = null;
    public Text RotateShip = null;
    public Text ActivatePropulsion = null;
    void Start()
    {
        if(PauseButton != null)
            PauseButton.SetActive(true);
        if (ResumeButton != null)
            ResumeButton.SetActive(false);
        if(BackToMainMenuButton != null)
            BackToMainMenuButton.SetActive(false);
        if(LeftAndRightArrowsImage != null)
            LeftAndRightArrowsImage.SetActive(false);
        if(UpArrowAndSpace != null)
            UpArrowAndSpace.SetActive(false);
        if(RotateShip != null)
            RotateShip.enabled = false;
        if(ActivatePropulsion != null)
            ActivatePropulsion.enabled = false;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        PauseButton.SetActive(false);
        ResumeButton.SetActive(true);
        BackToMainMenuButton.SetActive(true);
        LeftAndRightArrowsImage.SetActive(true);
        UpArrowAndSpace.SetActive(true);
        RotateShip.enabled = true;
        ActivatePropulsion.enabled = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PauseButton.SetActive(true);
        ResumeButton.SetActive(false);
        BackToMainMenuButton.SetActive(false);
        LeftAndRightArrowsImage.SetActive(false);
        UpArrowAndSpace.SetActive(false);
        RotateShip.enabled = false;
        ActivatePropulsion.enabled = false;
    }

    public void Test()
    {
        Debug.Log("TEST");
    }

    public void Change_Scense(string LevelName)
    {
        Time.timeScale = 1;
        if (LoadingScenes.Instanciate != null)
        {
            LoadingScenes.Instanciate.Level = 1;
        }
        SceneManager.LoadScene(LevelName);
    }
}
