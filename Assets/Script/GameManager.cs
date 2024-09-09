using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject mainMenuUI; // Referensi ke panel UI Main Menu
    [SerializeField] public GameObject winPanel;
    public static GameManager instance;
    public GameObject gameOverPanel;

    void Awake()
    {
        // Pause game saat dimulai
        Time.timeScale = 0f;

        // Tampilkan UI Main Menu
        mainMenuUI.SetActive(true);

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

    // BLM BISA NGILANGIN UI MAIN MENU, MASA HRS MENCET START DLU
    public void RestartGame()
    {
        // Muat ulang scene saat ini
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Menyembunyikan UI Main Menu
        mainMenuUI.SetActive(false);

        // Mengembalikan waktu ke normal
        Time.timeScale = 1f;
    }

    public void ReturnToMainMenu()
    {
        // Mengembalikan waktu ke normal
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Debug.Log("Game is exiting...");
        Application.Quit(); // Fungsi untuk menutup aplikasi
    }

    public void StartGame()
    {
        // Menyembunyikan UI Main Menu
        mainMenuUI.SetActive(false);

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
