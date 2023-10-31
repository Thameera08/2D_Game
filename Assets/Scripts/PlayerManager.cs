using System;
using System.Net.Mime;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject pauseMenuScreen;
    public AudioSource backgroundMusic;
    public AudioSource soundEffect;
    private float defaultVolume;


    public static Vector2 lastCheckPointPos = new Vector2(-3,0);

    int characterIndex;

  private void Start()
    {
        defaultVolume = backgroundMusic.volume;
    }
    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        
    }

    public void Mute()
    {
   
        backgroundMusic.mute = true;
        soundEffect.mute = true;
    }

    public void Sound()
    {
  
        backgroundMusic.mute = false;
        soundEffect.mute = false;
        
    }
}