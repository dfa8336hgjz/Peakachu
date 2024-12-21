using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkCreateTrigger : MonoBehaviour
{
    public GameObject Trunk;
    private bool isGenerated = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isGenerated)
        {
            GameObject trunk = Instantiate(Trunk, new Vector3(0f, 12f, 0f), Quaternion.identity);
            trunk.name = "Trunk";
            isGenerated = true;
        }
    }
}
