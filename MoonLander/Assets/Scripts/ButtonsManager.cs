using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public GameObject PauseButton;
    public GameObject ResumeButton;
    public GameObject BackToMainMenuButton;
    public GameObject LeftAndRightArrowsImage;
    public GameObject UpArrowAndSpace;
    public Text RotateShip;
    public Text ActivatePropulsion;
    void Start()
    {
        PauseButton.SetActive(true);
        ResumeButton.SetActive(false);
        BackToMainMenuButton.SetActive(false);
        LeftAndRightArrowsImage.SetActive(false);
        UpArrowAndSpace.SetActive(false);
        RotateShip.enabled = false;
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
        SceneManager.LoadScene(LevelName);
    }
}
