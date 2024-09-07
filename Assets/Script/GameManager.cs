using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameOverPanel;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        // Menghentikan waktu jika diperlukan
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        // Mengembalikan waktu ke normal
        Time.timeScale = 1f;
        // Muat ulang scene saat ini
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        // Mengembalikan waktu ke normal
        Time.timeScale = 1f;
        // Muat scene main menu, pastikan Anda telah menambahkannya ke Build Settings
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Debug.Log("Game is exiting..."); // Ini hanya untuk memastikan bahwa fungsi dipanggil saat testing di editor
        Application.Quit(); // Fungsi untuk menutup aplikasi
    }

    public void StartGame()
    {
        // Muat scene permainan, pastikan scene permainan ada di Build Settings
        SceneManager.LoadScene("MainScene");
    }
}
