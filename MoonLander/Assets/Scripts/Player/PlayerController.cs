using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public static PlayerController Instanciate;
    public GameObject ExplotionParticles;
    [HideInInspector] public Vector3 Rotation;
    [HideInInspector] public bool ParticlesController;
    [HideInInspector] public bool EndLevel;
    [HideInInspector] public bool GameOver;     
    public float InitialForce;
    public float RotationForce;
    public float PropulsionForce;
    public float InitialRotation;
    public float GravityScale;
    public int PointsOnLand;
    public int MaxRotationLanding;
    public int MaxLandVelocity;
    public LayerMask Terrains;
    private Rigidbody2D Rb_Player;

    void Start ()
    {
        Instanciate = this;
        ParticlesController = false;
        EndLevel = false;
        GameOver = false;
        Rotation = transform.eulerAngles;
        Rotation.z = InitialRotation;
        Rb_Player = GetComponent<Rigidbody2D>();
        Rb_Player.AddForce(transform.right * InitialForce);
        Rb_Player.gravityScale = GravityScale;
    }


    void Update ()
    {          
        PlayerMovement();
        UpdateSpeed();
        HeighUpdate();     


    }

    public void UpdateSpeed()
    {
        PlayerStats.Instanciate.HorizontalSpeed = (int)(Rb_Player.velocity.x * 100);
        PlayerStats.Instanciate.VerticalSpeed = (int)(Rb_Player.velocity.y * 100);
    }

    public void PlayerMovement()
    {
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) && PlayerStats.Instanciate.Fuel > 0 && !EndLevel && !GameOver)
        {
            ParticlesController = true;
            Rb_Player.AddForce(transform.up * Time.deltaTime * PropulsionForce);
            PlayerStats.Instanciate.Fuel -= PlayerStats.Instanciate.CombustionFuel * Time.deltaTime;
        }
        else
        {
            ParticlesController = false;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow) && !EndLevel && !GameOver)
        {
            Rotation.z += RotationForce * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow) && !EndLevel && !GameOver)
        {
            Rotation.z -= RotationForce * Time.deltaTime;
        }
        transform.eulerAngles = Rotation;
    }

    

    public void HeighUpdate()
    {

        RaycastHit2D HeightRay = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - GetComponent<SpriteRenderer>().bounds.size.y / 2), -Vector2.up , Mathf.Infinity, Terrains);
        if (gameObject != null)
        {
            if (HeightRay.collider.tag == "Terrain")
            {
                PlayerStats.Instanciate.Height = (int)((GetComponent<SpriteRenderer>().bounds.min.y - HeightRay.point.y) * 10);
            }
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - GetComponent<SpriteRenderer>().bounds.size.y / 2), -Vector3.up, Color.green);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LandColliderX1" || collision.gameObject.tag == "LandColliderX2" || collision.gameObject.tag == "LandColliderX3")
        {
            if( (transform.rotation.eulerAngles.z < MaxRotationLanding || transform.rotation.eulerAngles.z > 360 - MaxRotationLanding) && PlayerStats.Instanciate.HorizontalSpeed > -MaxLandVelocity)
            {
                EndLevel = true;
                switch (collision.gameObject.tag)
                {
                    case "LandColliderX1":
                        PlayerStats.Instanciate.Points += PointsOnLand * 1;
                        break;
                    case "LandColliderX2":
                        PlayerStats.Instanciate.Points += PointsOnLand * 2;
                        break;
                    case "LandColliderX3":
                        PlayerStats.Instanciate.Points += PointsOnLand * 3;
                        break;
                }
                Time.timeScale = 0;
            }
            else            
            {            
                Instantiate(ExplotionParticles, transform.position, Quaternion.identity);
                GetComponent<SpriteRenderer>().enabled = false;
                Rb_Player.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                GameOver = true;
            }
        }

        if (collision.gameObject.tag == "Terrain" || collision.gameObject.tag == "LandTerrain")
        {
            Instantiate(ExplotionParticles, transform.position, Quaternion.identity);
            GetComponent<SpriteRenderer>().enabled = false;
            Rb_Player.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            GameOver = true;
        }
    }

}
