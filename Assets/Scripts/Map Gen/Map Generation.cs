using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;
using UnityEngine;


public class MapGeneration : MonoBehaviour
{
    public GameObject[] MapPrefabs; // Array of map prefabs
    public int mapSize; // Size of the map (width)
    public float mapY; // Y position for the map prefabs
    public GameObject PlayerCharacter; //The Player Character
    public Vector3 PlayerSpawn; //The Player Spawn Point
    public CameraMovement Camera; //The Camera that will follow the player
    public GameObject[] GameObjectCamera;
    public GameObject StartPreset;
    public GameObject FinishPreset;
    private Transform currentExit;
    void mapGenerator()
    {
        
        
        GameObject LastPrefab = null;
        Instantiate(StartPreset, new Vector3(0, mapY, 0), Quaternion.identity);
        
        for (int i = 0; i < mapSize; i++)
        {
            
            GameObject prefab = MapPrefabs[Random.Range(0, MapPrefabs.Length)];
            if (prefab != LastPrefab)
            {
                LastPrefab = prefab;
                Instantiate(prefab, new Vector3(0, mapY, 0), Quaternion.identity);
                Vector3 entryOffset = prefab.GetComponent<PresetLength>().entrypoint.position - prefab.transform.position;
                currentExit = prefab.GetComponent<PresetLength>().exitpoint;
                Vector3 vector3 = currentExit.position + entryOffset;
                prefab.transform.position = vector3;
                GameObject duplicatePrefabCheck = prefab;
            }
            else
            {
                i--;
                continue;
            }
            if (i == mapSize)
            {
                Instantiate(FinishPreset, new Vector3(0, mapY, 0), Quaternion.identity);
            }


        }
        
        GameObject newPlayer = Instantiate(PlayerCharacter, PlayerSpawn, Quaternion.identity);
        Camera.player = newPlayer.transform;
    }
        

    void Start()
    {
        mapGenerator();
    }

    
}
