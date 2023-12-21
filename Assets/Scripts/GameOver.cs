using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        audioSource.Play();
    }
    public void RestartGame()
    {

        SceneManager.LoadScene("Show");
    }
    public void MainMenu()
    {

        SceneManager.LoadScene("MainMenu");
    }
}
