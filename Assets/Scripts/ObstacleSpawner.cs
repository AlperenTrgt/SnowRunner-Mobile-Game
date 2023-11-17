using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<Transform> obstaclePoints = new List<Transform>();
    public List<Transform> CoinPoints = new List<Transform>();
    [SerializeField] private List<GameObject> obstaclePrefabs;
    [SerializeField] private List<GameObject> CoinPrefabs;


    private void Start()
    {
        var r = new System.Random();
        int o = (int) Math.Ceiling(obstaclePoints.Count / 10.0f);
        int c = (int)Math.Ceiling(CoinPoints.Count / 10.0f);

        HashSet<int> randomValues = new HashSet<int>();
        //For Obstacles
        while (randomValues.Count < o)
        {
            randomValues.Add(r.Next(0, obstaclePoints.Count() - 1));
        }

        foreach (var x in randomValues)
        {
            int randomIndex = r.Next(0, obstaclePrefabs.Count);
            Instantiate(obstaclePrefabs[randomIndex], obstaclePoints[x]);
        }
        //For Coins
        while (randomValues.Count < c)
        {
            randomValues.Add(0);
        }

        foreach (var x in randomValues)
        {
            int randomIndex = r.Next(0);
            Instantiate(CoinPrefabs[randomIndex], CoinPoints[x]);
        }
    }
}
