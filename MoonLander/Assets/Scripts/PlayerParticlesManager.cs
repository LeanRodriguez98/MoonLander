using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticlesManager : MonoBehaviour
{
    public PlayerController _PlayerController;
    private ParticleSystem particles;


    void Start()
    {
        _PlayerController = PlayerController.Instanciate;
        particles = GetComponent<ParticleSystem>();
    }


    void Update()
    {
        if (_PlayerController.ParticlesController == true)
        {
            particles.Play();
        }
        else
        {
            particles.Stop();
        }


    }
}
