using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
            PlayerPrefs.SetFloat("HighScore", score);
            PlayerPrefs.Save();
            mapgen.CreateNewMap();
        }
        UpdateUI();
    }

    public void removeScore(int amount)
    {
        score -= amount;
    }

    public void UpdateUI()
    {
        GameObject.Find("HighScoreTekst").GetComponent<TextMeshProUGUI>().text = "HighScore: " + PlayerPrefs.GetFloat("HighScore");
        GameObject.Find("ScoreTekst").GetComponent<TextMeshProUGUI>().text = "Score: " + score;
    }
}