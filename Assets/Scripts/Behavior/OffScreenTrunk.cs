using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreenTrunk : MonoBehaviour
{
    void Update()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPosition.y + 1000 < 0)
        {
            Destroy(gameObject);
        }
    }
}
