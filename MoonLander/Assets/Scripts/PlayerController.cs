using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public static PlayerController Instanciate;
    [HideInInspector] public Vector3 Rotation;
    [HideInInspector] public bool ParticlesController;
    private Rigidbody2D Rb_Player;
    public float RotationForce;
    public float PropulsionForce;
        public LayerMask rayCastLayer;

    void Start ()
    {
        Instanciate = this;
        ParticlesController = false;
        Rotation = Vector3.zero;
        Rb_Player = GetComponent<Rigidbody2D>();
    }
	

	void Update ()
    {          
        PlayerMovement();
    }

    public void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            ParticlesController = true;
            Rb_Player.AddForce(transform.up * Time.deltaTime * PropulsionForce);          
        }
        else
        {
            ParticlesController = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Rotation.z += RotationForce * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Rotation.z -= RotationForce * Time.deltaTime;
        }
        transform.eulerAngles = Rotation;
    }
}
