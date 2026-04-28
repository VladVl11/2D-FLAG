using System.Collections;
using System.Collections.Generic;
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
    void mapGenerator()
    {
        
        float spawnPos = 0;
        GameObject LastPrefab = null;
        for (int i = 0; i < mapSize; i++)
        {
            
            GameObject prefab = MapPrefabs[Random.Range(0, MapPrefabs.Length)];
            if (prefab != LastPrefab)
            {
                LastPrefab = prefab;
                Instantiate(prefab, new Vector3(spawnPos, mapY, 0), Quaternion.identity);
                float length = prefab.GetComponent<PresetLength>().length;
                spawnPos += length;
                GameObject duplicatePrefabCheck = prefab;
            }
            else
            {
                i--;
                continue;
            }

            
        }
        Debug.Log("Map Generated");
        GameObject newPlayer = Instantiate(PlayerCharacter, PlayerSpawn, Quaternion.identity);
        Camera.player = newPlayer.transform;
    }
        

    void Start()
    {
        mapGenerator();
    }

    
}
