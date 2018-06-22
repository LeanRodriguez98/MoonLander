using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour {

    public GameObject Player;
    private GameObject[][] Terrains = new GameObject[5][];

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
    private int[] AuxArrayTerrains;
    
    void Start()
    {
        
        /*for (int i = 0; i < LD_RD_Terrain.Length; i++)
        {
            Terrains[0][i] = LD_RD_Terrain[i];
        }*/


        Terrains[0] = LD_RD_Terrain;
        Terrains[1] = LU_RD_Terrain;
        Terrains[2] = LD_RU_Terrain;
        Terrains[3] = LU_RU_Terrain;
        Terrains[4] = LU_RU_LandZone;
        cameraH = Camera.main.orthographicSize * 2f;
        cameraW = cameraH * Camera.main.aspect;
       
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
            if (i%2 == 0)
            {
                Instantiate(AuxTerrain, new Vector2(i, StartHeightTerrain), Quaternion.identity);
            }
            else
            {
                Instantiate(LD_RD_Terrain[0], new Vector2(i, StartHeightTerrain + 1), Quaternion.identity);

            }
        }

    }

    public void TerrainAsignation()
    {
        int TerrainsRandom = 0;

        if (AuxTerrain == null)
        {
            //TerrainsRandom = Random.Range()
        }
        switch (TerrainsRandom)
        {
            case 0:
                break;
            case 1:
                break;
        }
    }
}
