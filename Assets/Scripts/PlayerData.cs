using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int score = 0;
    public int bestscore = 0;

    public int bestscoreEver = 0;

    public MapGenerator mapgen;
    public GameObject mapgeneratorObject;

    private void Start()
    {
        mapgen = mapgeneratorObject.GetComponent<MapGenerator>();
    }

    public void addScore(int amount)
    {
        score += amount;
        if (score > bestscore)
        {
            bestscore = score;
            mapgen.CreateNewMap();
        }
    }

    public void removeScore(int amount)
    {
        score -= amount;
    }
}