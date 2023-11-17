using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject[] PathPrefabs;
    public Transform playerTransform;
    private float spawnZ = 0.0f;
    private float tileLength = 10f;
    private int amnTilesOnScreen = 12;
    private List<GameObject> activeTiles = new List<GameObject>();



    private void Start()
    {
        for (int i = 0; i < amnTilesOnScreen; i++)
        {
            if (i == 0)
            {
                SpawnTile(i);
                SpawnTile(i);
            }
            else
            {
                SpawnTile(1);
            }

        }
    }
    private void Update()
    {
        if (playerTransform.position.z - 15 > spawnZ - (amnTilesOnScreen * tileLength))
        {
            SpawnTile(1);
            DeleteTile();
        }
    }
    private void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(PathPrefabs[tileIndex], transform.forward * spawnZ, transform.rotation);
        activeTiles.Add(go);
        spawnZ += tileLength;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
