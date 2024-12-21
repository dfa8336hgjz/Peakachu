using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class currentScoreUI : MonoBehaviour
{
    private TextMeshProUGUI textmesh;
    void Start()
    {
        textmesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textmesh.text = "Your score: "+GameControl.instance.getTotalPoint().ToString();
    }
}
