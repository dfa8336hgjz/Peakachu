using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehavior : MonoBehaviour
{
    [SerializeField] private float speedFactor = 1f;
    void Update()
    {
        transform.position += new Vector3(0, -2, 0) * Time.deltaTime * speedFactor * GameControl.instance.gameSpeed;
    }
}
