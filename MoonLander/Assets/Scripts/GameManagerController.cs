using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class GameManagerController : MonoBehaviour {

    public GameObject Player;

    private const int NumberOfArrays = 6;// <------ MAGIC NUMBER, no se como evitarlo profe ¿Alguna idea?
    private GameObject[][] Terrains = new GameObject[NumberOfArrays][]; 

    public GameObject[] LD_RD_Terrain;//<-----------
    public GameObject[] LU_RD_Terrain;//<-----------
    public GameObject[] LD_RU_Terrain;//<-----------  El 6 representa la cantidad de arrays que iran en el jagged array
    public GameObject[] LU_RU_Terrain;//<-----------
    public GameObject[] LU_RU_LandZone;//<----------
    public GameObject[] LD_RD_LandZone;//<----------


    private GameObject[] InstanciateTerrains;
    public int StartHeightTerrain;
    public int MaxHeight;
    public int MinHeight;
    private float cameraH;
    private float cameraW;
    private GameObject AuxTerrain;
    private List<int> IndexArray = new List<int>();
    private bool TerrainCheck;
    void Start()
    {
        Terrains[0] = LD_RD_LandZone;
        Terrains[1] = LD_RD_Terrain;
        Terrains[2] = LD_RU_Terrain;
        Terrains[3] = LU_RU_LandZone;
        Terrains[4] = LU_RU_Terrain;
        Terrains[5] = LU_RD_Terrain;


        cameraH = Camera.main.orthographicSize * 2f;
        cameraW = cameraH * Camera.main.aspect;
       
        Instantiate(Player, new Vector2(-cameraW/2, cameraH/2), Quaternion.identity);

        InstanciateTerrains = new GameObject[(int)cameraW];

        do
        {
            TerrainAsignation();
        } while (!TerrainCheck);
        TerrainGeneration();
    }

    
    void Update ()
    {

    }

    public void TerrainGeneration()
    {
        int counter = 0;

        for (int i = (int)-cameraW/2; i < cameraW/2; i++)
        {

           Instantiate(InstanciateTerrains[counter], new Vector2(i, StartHeightTerrain), Quaternion.identity);

           for (int j = 0; j < Terrains.Length; j++)
           {
               for (int k = 0; k < Terrains[j].Length; k++)
                {
                    if (Terrains[j][k] == InstanciateTerrains[counter])
                    {
                        if (Terrains[j] == LD_RD_LandZone || Terrains[j] == LD_RD_Terrain || Terrains[j] == LU_RD_Terrain)
                        {
                            StartHeightTerrain--;
                        }
                        if (Terrains[j] == LD_RU_Terrain || Terrains[j] == LU_RU_LandZone || Terrains[j] == LU_RU_Terrain)
                        {
                            StartHeightTerrain++;
                        }
                    }
               }
           }

            counter++;

        }

    }

    public void TerrainAsignation()
    {
        int TerrainsRandom = 0;
        int auxHeightTerrain = StartHeightTerrain;
        TerrainCheck = false;

        for (int i = 0; i < NumberOfArrays; i++)
        {
            IndexArray.Add(i);
        }

        for (int i = 0; i < InstanciateTerrains.Length; i++)
        {
            
            TerrainsRandom = IndexArray[Random.Range(0, IndexArray.Count)];

            InstanciateTerrains[i] = Terrains[TerrainsRandom][Random.Range(0, Terrains[TerrainsRandom].Length)];

            IndexArray.Clear();

            switch (TerrainsRandom)
            {
                case 0:                   
                    IndexArray.Add(System.Array.IndexOf(Terrains, LU_RU_Terrain));
                    IndexArray.Add(System.Array.IndexOf(Terrains, LU_RD_Terrain));
                    auxHeightTerrain--;
                    break;
                case 1:
                    IndexArray.Add(System.Array.IndexOf(Terrains, LU_RU_LandZone));
                    IndexArray.Add(System.Array.IndexOf(Terrains, LU_RU_Terrain));
                    IndexArray.Add(System.Array.IndexOf(Terrains, LU_RD_Terrain));
                    auxHeightTerrain--;
                    break;
                case 2:
                    IndexArray.Add(System.Array.IndexOf(Terrains, LD_RD_LandZone));
                    IndexArray.Add(System.Array.IndexOf(Terrains, LD_RD_Terrain));
                    if (auxHeightTerrain < MaxHeight)
                        IndexArray.Add(System.Array.IndexOf(Terrains, LD_RU_Terrain));
                    auxHeightTerrain++;
                    break;
                case 3:
                    IndexArray.Add(System.Array.IndexOf(Terrains, LD_RD_Terrain));
                    IndexArray.Add(System.Array.IndexOf(Terrains, LD_RU_Terrain));
                    auxHeightTerrain++;
                    break;
                case 4:
                    IndexArray.Add(System.Array.IndexOf(Terrains, LD_RD_LandZone));
                    IndexArray.Add(System.Array.IndexOf(Terrains, LD_RD_Terrain));
                    IndexArray.Add(System.Array.IndexOf(Terrains, LD_RU_Terrain));
                    auxHeightTerrain++;
                    break;
                case 5:
                    IndexArray.Add(System.Array.IndexOf(Terrains, LU_RU_LandZone));
                    IndexArray.Add(System.Array.IndexOf(Terrains, LU_RU_Terrain));
                    if (auxHeightTerrain > MinHeight)
                        IndexArray.Add(System.Array.IndexOf(Terrains, LU_RD_Terrain));
                    auxHeightTerrain--;
                    break;
            }
            IndexArray.Sort();
        }

        for (int i = 0; i < InstanciateTerrains.Length; i++)
        {
            for (int j = 0; i < LD_RD_LandZone.Length; i++)
            {
                if (InstanciateTerrains[i]== LD_RD_LandZone[j])
                {
                    TerrainCheck = true;
                }
            }
            for (int j = 0; i < LU_RU_LandZone.Length; i++)
            {
                if (InstanciateTerrains[i] == LU_RU_LandZone[j])
                {
                    TerrainCheck = true;
                }
            }
        }
    }
}
