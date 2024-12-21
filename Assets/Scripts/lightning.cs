using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightning : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D boxCollider2D;

    private void Update()
    {
        PlayerInput player = PlayerInput.instance;
        spriteRenderer.enabled = player.getAnimationName().Contains("Pikachu_Jump");
        boxCollider2D.enabled = player.getAnimationName().Contains("Pikachu_Jump");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);
            GameControl.instance.increasePoint(3);
        }
    }
}
