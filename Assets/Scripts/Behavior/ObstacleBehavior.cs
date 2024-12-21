using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // lose
            GameControl.instance.setLoseScene(true);
            Debug.Log("lose");
        }
        else if (collision.gameObject.CompareTag("Skill"))
        {
            GameControl.instance.increasePoint(3);
            Destroy(gameObject);
        }
    }
}
