using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    public GameObject ResumeButton;
    public GameObject BackToMainMenuButton;
    public GameObject LeftAndRightArrowsImage;
    public GameObject UpArrowAndSpace;

    public void Pause()
    {
        Time.timeScale = 0;
        ResumeButton.SetActive(true);
        BackToMainMenuButton.SetActive(true);
        LeftAndRightArrowsImage.SetActive(true);
        UpArrowAndSpace.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        ResumeButton.SetActive(false);
        BackToMainMenuButton.SetActive(false);
        LeftAndRightArrowsImage.SetActive(false);
        UpArrowAndSpace.SetActive(false);
    }

    public void Test()
    {
        Debug.Log("TEST");
    }

}
