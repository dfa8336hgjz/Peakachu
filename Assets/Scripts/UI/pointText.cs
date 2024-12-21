using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class pointText : MonoBehaviour
{
    private TextMeshProUGUI textmesh;
    private void Start()
    {
        textmesh = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textmesh.text = "Point: " + GameControl.instance.getTotalPoint();
    }
}
