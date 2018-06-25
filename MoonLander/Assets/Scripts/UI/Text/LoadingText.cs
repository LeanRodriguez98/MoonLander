using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoadingText : MonoBehaviour {
    public Text Loading;

	void Update () {
        Loading.text = LoadingScenes.Instanciate.LoadingText;
	}
}
