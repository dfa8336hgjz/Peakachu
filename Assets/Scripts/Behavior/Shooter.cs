using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Shooter : ObstacleBehavior
{
    [SerializeField] GameObject bullet;
    [SerializeField] int bulletCount;
    private Rigidbody2D shooterBody;
    private int mode;
    private int direction;

    private void Start()
    {
        mode = Random.Range(-1, 2);
        shooterBody = GetComponent<Rigidbody2D>();
        direction = PlayerInput.instance.getTransformDirection();
        if (mode == 0) bulletCount *= 5;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            StartCoroutine(ShootBullets());
        }
    }

    private IEnumerator ShootBullets()
    {
        while (bulletCount > 0)
        {
            bulletCount--;
            StartCoroutine("shoot");
            yield return new WaitForSeconds(.1f);
        }
    }

    private IEnumerator shoot()
    {
        if (mode != 1)
        {
            Vector3 position = new Vector3(direction * 0.5f * mode + transform.position.x, 
                0.07f + transform.position.y, 0);
            Quaternion rotation = Quaternion.identity;
            Instantiate(bullet, position, rotation);
            yield return new WaitForSeconds(1f);
        }
        else
        {
            bulletCount = 0;
            shooterBody.velocity = new Vector2(6f * direction, -5f);
        }
    }
}
