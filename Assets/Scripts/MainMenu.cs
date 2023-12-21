using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] UIVirtualButton play;
    private void Start()
    {
        audioSource.Play();
    }
    public void StartGame()
    {

        SceneManager.LoadScene("Show");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TeamCredit()
    {
        
    }



}



