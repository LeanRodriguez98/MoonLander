using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour {

    public GameObject Player;

    
    void Start()
    {
        Instantiate(Player, new Vector2(0, 0), Quaternion.identity);
    }

    
    void Update ()
    {
	}
}
