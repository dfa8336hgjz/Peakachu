using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class highScore : MonoBehaviour
{
    private TextMeshProUGUI textmesh;
    void Start()
    {
        textmesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        int currentScore = PlayerPrefs.GetInt("highScore");
        textmesh.text = "Highest score: " + ((currentScore > GameControl.instance.getTotalPoint())? currentScore.ToString() : GameControl.instance.getTotalPoint().ToString());
    }
}
