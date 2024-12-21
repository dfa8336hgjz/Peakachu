using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorControl : MonoBehaviour
{
    [SerializeField] ObstacleGenerator LeftGenerator;
    [SerializeField] ObstacleGenerator RightGenerator;
    [SerializeField] PlayerInput player;


    private float normalLeftSpawnTime = 3;
    private float normalRightSpawnTime = 4;
    private float emolgaSpawnTime = 8;
    private GameControl game;

    private void Start()
    {
        game = GameControl.instance;
    }

    void Update()
    {
        if (!game.isGamePaused())
        {
            normalLeftSpawnTime -= Time.deltaTime;
            normalRightSpawnTime -= Time.deltaTime;
            emolgaSpawnTime -= Time.deltaTime;
            if (emolgaSpawnTime < 0)
            {
                emolgaSpawnTime = Random.Range(6, 10);
                if (player.isLeftSide())
                {
                    RightGenerator.spawnEmolga();
                }
                else
                {
                    LeftGenerator.spawnEmolga();
                }
            }

            if (normalLeftSpawnTime < 0)
            {
                normalLeftSpawnTime = Random.Range(3, 8);
                LeftGenerator.spawn();
            }
            if (normalRightSpawnTime < 0)
            {
                normalRightSpawnTime = Random.Range(3, 8);
                RightGenerator.spawn();
            }
        }
    }
}
