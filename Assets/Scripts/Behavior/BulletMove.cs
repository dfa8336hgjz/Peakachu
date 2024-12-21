using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : ObstacleBehavior
{
    public float speed = 1f;
    private int direction = 0;
    private void Start()
    {
        direction = (transform.position.x > 0)? -1 : 1;
    }

    void Update()
    {
        transform.position += new Vector3(direction, -1f, 0) * Time.deltaTime * speed;
    }
}
