using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public static PlayerController Instanciate;
    [HideInInspector] public Vector3 Rotation;
    [HideInInspector] public bool ParticlesController;
    private Rigidbody2D Rb_Player;
    public GameObject ExplotionParticles;
    public float InitialForce;
    public float RotationForce;
    public float PropulsionForce;
    public float InitialRotation;
    public float Fuel;
    public float CombustionFuel;
    public int MaxRotationLanding;
    void Start ()
    {
        Instanciate = this;
        ParticlesController = false;
        Rotation = transform.eulerAngles;
        Rotation.z = InitialRotation;
        Rb_Player = GetComponent<Rigidbody2D>();
        Rb_Player.AddForce(transform.right * InitialForce);

    }


    void Update ()
    {          
        PlayerMovement();
        //  Debug.Log("Horizontal Speed" + Rb_Player.velocity.x);
        //  Debug.Log("Vertical Speed" + Rb_Player.velocity.y);
    
    }

    public void PlayerMovement()
    {
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) && Fuel > 0)
        {
            ParticlesController = true;
            Rb_Player.AddForce(transform.up * Time.deltaTime * PropulsionForce);
            Fuel -= CombustionFuel * Time.deltaTime;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LandCollider")
        {
            if (transform.rotation.eulerAngles.z < MaxRotationLanding || transform.rotation.eulerAngles.z > 360 - MaxRotationLanding)
            {
                Time.timeScale = 0;
            }
            else            
            {            
                Instantiate(ExplotionParticles, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag == "Terrain" || collision.gameObject.tag == "LandTerrain")
        {
            Instantiate(ExplotionParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
