using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerInput player = PlayerInput.instance;
        if (collision.gameObject.CompareTag("Skill"))
        {
            Destroy(gameObject);
            GameControl.instance.increasePoint(3);
        }
        else if (collision.gameObject.CompareTag("Player") && !GameControl.instance.quickAttackActivated())
        {
            // lose
            GameControl.instance.setLoseScene(true);
            Debug.Log(gameObject.name + " collide with "+collision.gameObject.name+". "+player.getAnimationName());
        }
    }
}
