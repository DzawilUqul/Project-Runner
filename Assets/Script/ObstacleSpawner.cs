using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    [SerializeField] private float spawnTime;
    [SerializeField] private Transform spawnLocation;
    private float timer;
    private bool collidedFinish = false;

    void Update()
    {
        if (collidedFinish)
        {
            return;  // Jika sudah bertabrakan, hentikan spawning
        }

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
        float spawnX = spawnLocation.transform.position.x;
        float spawnZ = spawnLocation.transform.position.z;

        // Tentukan posisi y sesuai dengan obstacle yang dipilih
        float spawnY = 0f; // Default posisi y
        if (index == 0) spawnY = 0f;   // Obstacle1: y = 1
        else if (index == 1) spawnY = 0f; // Obstacle2: y = 2
        else if (index == 2) spawnY = 0f;

        // Atur posisi obstacle
        obstacle.transform.position = new Vector3(spawnX, spawnY, spawnZ);
    }

    // Panggil ini dari OnTriggerEnter di FinishSpawner
    public void OnPlayerCollidedWithFinish()
    {
        collidedFinish = true;  // Set flag menjadi true
        Debug.Log("Player collided with FinishSpawner.");
    }
}
