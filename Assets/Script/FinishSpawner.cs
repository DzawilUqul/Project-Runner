using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishSpawner : MonoBehaviour
{
    // Referensi ke GameManager atau script ObstacleSpawner
    private ObstacleSpawner obstacleSpawner;

    void Start()
    {
        // Cari referensi ke GameManager atau script ObstacleSpawner
        obstacleSpawner = FindObjectOfType<ObstacleSpawner>();  // Bisa juga melalui inspector jika lebih baik
    }

    // Mendeteksi tabrakan dengan Player
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Pastikan Player diberi tag "Player"
        {
            obstacleSpawner.OnPlayerCollidedWithFinish();  // Panggil fungsi di GameManager untuk menghentikan spawning
        }
    }
}
