using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using StarterAssets;

public class Pause : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject panel;
    public AudioSource audioSource;
    public ThirdPersonController thirdPersonController;
    [SerializeField] GameObject player;
    public AudioSource gameMusic;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        thirdPersonController = player.GetComponent<ThirdPersonController>();

    }
    public void pauseGame()
    {
        gameMusic.Pause();
        isPaused = true;
        thirdPersonController.LockCameraPosition = true;
        panel.SetActive(true);
        Time.timeScale = 0;
        audioSource.Play();

    }
    public void resumeGame()
    {
        gameMusic.Play();
        panel.SetActive(false);
        thirdPersonController.LockCameraPosition = false;
        Time.timeScale = 1;
        isPaused = false;
        audioSource.Pause();

    }
    public void restartGame()
    {
        SceneManager.LoadScene("Show");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                pauseGame();
            }
            else
            {
                resumeGame();
            }
        }
    }
}
