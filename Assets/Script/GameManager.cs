using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject gameOverPanel;

    public void GameOver()
    {
        gameOverPanel.SetActive(true);

        // Menghentikan waktu jika diperlukan
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        // Muat ulang scene saat ini
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Mengembalikan waktu ke normal
        Time.timeScale = 1f;
    }

    public void ReturnToMainMenu()
    {
        // Mengembalikan waktu ke normal
        Time.timeScale = 0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ExitGame()
    {
        Debug.Log("Game is exiting...");
        Application.Quit(); // Fungsi untuk menutup aplikasi
    }

    public void StartGame()
    {
        // Melanjutkan game
        Time.timeScale = 1f;

        // Menyembunyikan Win Panel
        winPanel.SetActive(false);
    }

    public void WinGame()
    {
        // Menghentikan game
        Time.timeScale = 0f;

        // Menampilkan Win Panel
        winPanel.SetActive(true);
    }
}
