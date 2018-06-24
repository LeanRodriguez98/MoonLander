using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public static PlayerController Instanciate;
    [HideInInspector] public Vector3 Rotation;
    [HideInInspector] public bool ParticlesController;
    [HideInInspector] public bool EndLevel;

    private Rigidbody2D Rb_Player;
    public GameObject ExplotionParticles;
    public int MaxLandVelocity;
    public float InitialForce;
    public float RotationForce;
    public float PropulsionForce;
    public float InitialRotation;
    public float Fuel;
    public float CombustionFuel;
    public int MaxRotationLanding;
    public float HorizontalSpeed;
    public float VerticalSpeed;
    void Start ()
    {
        Instanciate = this;
        ParticlesController = false;
        EndLevel = false;
        Rotation = transform.eulerAngles;
        Rotation.z = InitialRotation;
        Rb_Player = GetComponent<Rigidbody2D>();
        Rb_Player.AddForce(transform.right * InitialForce);

    }


    void Update ()
    {          
        PlayerMovement();
        HorizontalSpeed = (int)(Rb_Player.velocity.x * 100);
        VerticalSpeed = (int)(Rb_Player.velocity.y * 100);

        if (EndLevel)
            ChangeLevel();
    }

    public void PlayerMovement()
    {
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) && Fuel > 0 && !EndLevel)
        {
            ParticlesController = true;
            Rb_Player.AddForce(transform.up * Time.deltaTime * PropulsionForce);
            Fuel -= CombustionFuel * Time.deltaTime;
        }
        else
        {
            ParticlesController = false;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow) && !EndLevel)
        {
            Rotation.z += RotationForce * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow) && !EndLevel)
        {
            Rotation.z -= RotationForce * Time.deltaTime;
        }
        transform.eulerAngles = Rotation;
    }

    public void ChangeLevel()
    {
        SceneManager.LoadScene("LoadingScenes");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LandCollider")
        {
            if( (transform.rotation.eulerAngles.z < MaxRotationLanding || transform.rotation.eulerAngles.z > 360 - MaxRotationLanding) && HorizontalSpeed > -MaxLandVelocity)
            {
                EndLevel = true;
                Rb_Player.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
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
