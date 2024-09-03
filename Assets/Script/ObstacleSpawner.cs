using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public float spawnTime = 2f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            SpawnObstacle();
            timer = 0;
        }
    }

    void SpawnObstacle()
    {
        int index = Random.Range(0, obstacles.Length);
        GameObject obstacle = Instantiate(obstacles[index]);

        // Tentukan posisi x dan z obstacle berdasarkan posisi spawner (misalnya di depan Dino)
        float spawnX = transform.position.x;
        float spawnZ = transform.position.z;

        // Tentukan posisi y sesuai dengan obstacle yang dipilih
        float spawnY = 1f; // Default posisi y
        if (index == 0) spawnY = 0.5f;   // Obstacle1: y = 1
        else if (index == 1) spawnY = 2.5f; // Obstacle2: y = 2

        // Atur posisi obstacle
        obstacle.transform.position = new Vector3(spawnX, spawnY, spawnZ);
    }
}
