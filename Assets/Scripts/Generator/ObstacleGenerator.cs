using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    public Side side;

    public void spawn()
    {
        int i = Random.Range(0, obstacles.Length - 1);
        GameObject obstacle = Instantiate(obstacles[i], transform.position, Quaternion.identity);
        obstacle.transform.localScale = new Vector3(obstacle.transform.localScale.x * getTransformDirection(), obstacle.transform.localScale.y, obstacle.transform.localScale.z);
    }

    public void spawnEmolga()
    {
        GameObject obstacle = Instantiate(obstacles[2], transform.position, Quaternion.identity);
        obstacle.transform.localScale = new Vector3(obstacle.transform.localScale.x * getTransformDirection(), obstacle.transform.localScale.y, obstacle.transform.localScale.z);
    }

    private int getTransformDirection()
    {
        if (side == Side.Left)
        {
            return -1;
        }
        else return 1;
    }
}
