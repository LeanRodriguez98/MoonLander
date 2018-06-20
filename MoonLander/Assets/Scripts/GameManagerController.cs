using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour {

    public GameObject Player;
    //private GameObject[][] Terrains;
    public GameObject[] LD_RD_Terrain;
    public GameObject[] LU_RD_Terrain;
    public GameObject[] LD_RU_Terrain;
    public GameObject[] LU_RU_Terrain;
    public GameObject[] LU_RU_LandZone;
    public int StartHeightTerrain;
    public int MaxHeight;
    public int MinHeight;
    private float cameraH;
    private float cameraW;
    private GameObject AuxTerrain;
    
    void Start()
    {
        
        /*for (int i = 0; i < LD_RD_Terrain.Length; i++)
        {
            Terrains[0][i] = LD_RD_Terrain[i];
        }
        
        Terrains[1] = LU_RD_Terrain;
        Terrains[2] = LD_RU_Terrain;
        Terrains[3] = LU_RU_Terrain;
        Terrains[4] = LU_RU_LandZone;*/
        cameraH = Camera.main.orthographicSize * 2f;
        cameraW = cameraH * Camera.main.aspect;
        //Instantiate(Player, new Vector2(0, 5), Quaternion.identity);
        Instantiate(Player, new Vector2(-cameraW/2, cameraH/2), Quaternion.identity);
        
        TerrainGeneration();
    }

    
    void Update ()
    {
        

    }

    public void TerrainGeneration()
    {
        AuxTerrain = LU_RU_LandZone[0];

        for (int i = (int)-cameraW/2; i < cameraW/2; i++)
        {
            //TerrainAsignation();
            Instantiate(AuxTerrain, new Vector2(i, StartHeightTerrain), Quaternion.identity);
        }

    }

    public void TerrainAsignation()
    {
        int TerrainsRandom;

        if (AuxTerrain == null)
        {
            //AuxTerrain = Terrains[TerrainsRandom = Random.Range(0, Terrains.Length + 1)][Random.Range(0,Terrains[TerrainsRandom].Length)];
        }
    }
}
