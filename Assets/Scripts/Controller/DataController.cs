using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highestScore;
    void Start()
    {
        if (PlayerPrefs.GetInt("highScore") == 0)
        {
            highestScore.text = "";
        }
        else
        {
            highestScore.text = "Highest Score: " + PlayerPrefs.GetInt("highScore").ToString();
        }
    }
}
