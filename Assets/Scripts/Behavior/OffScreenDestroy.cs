using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreenDestroy : MonoBehaviour
{
    void Update()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        // Check if the object is outside the screen bounds
        if (screenPosition.x < 0 || screenPosition.x > Screen.width ||
            screenPosition.y < 0)
        {
            Destroy(gameObject);
        }
    }
}
