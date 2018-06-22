using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreens : MonoBehaviour
{
    public float Fade = 10;
    public float wait = 2;
    public string NextSceneName;

    public RawImage[] SplashImages;
    private float Alpha;
    private Color CurrentColor;
    private bool FadeOut;
    private float time;
    private int CurrentImage;
    // Use this for initialization
    void Start()
    {
        time = 0;
        Alpha = 0;
        CurrentColor.b = 255;
        CurrentColor.g = 255;
        CurrentColor.r = 255;
        CurrentColor.a = 0;
        FadeOut = false;
        CurrentImage = 0;
        for (int i = 0; i < SplashImages.Length; i++)
        {
            SplashImages[i].color = CurrentColor;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!FadeOut && Alpha < 1)
        {
            Alpha += Time.deltaTime / Fade;

            CurrentColor.a = Alpha;
            SplashImages[CurrentImage].color = CurrentColor;
        }
        else
        {
            time += Time.deltaTime;
            if (time >= wait)
            {
                FadeOut = true;
                Alpha -= Time.deltaTime / Fade;
                CurrentColor.a = Alpha;
                SplashImages[CurrentImage].color = CurrentColor;
                if (Alpha <= 0)
                {
                    CurrentImage++;
                    time = 0;
                    FadeOut = false;
                }
            }
        }
        
        if (CurrentImage == SplashImages.Length)
        {
            SceneManager.LoadScene(NextSceneName);
        }

    }
}
