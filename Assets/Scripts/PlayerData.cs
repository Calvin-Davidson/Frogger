using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public int score = 0;
    public int bestscore = 0;

    public MapGenerator mapgen;
    public GameObject mapgeneratorObject;

    private void Start()
    {
        mapgen = mapgeneratorObject.GetComponent<MapGenerator>();

        UpdateUI();
    }

    public void addScore(int amount)
    {
        score += amount;
        if (score > bestscore)
        {
            bestscore = score;
            mapgen.CreateNewMap();
        }

        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        UpdateUI();
    }

    public void removeScore(int amount)
    {
        score -= amount;
    }

    public void UpdateUI()
    {
        GameObject.Find("HighScoreTekst").GetComponent<TextMeshProUGUI>().text = "HighScore: " + PlayerPrefs.GetInt("HighScore");
        GameObject.Find("ScoreTekst").GetComponent<TextMeshProUGUI>().text = "Score: " + score;
    }
}