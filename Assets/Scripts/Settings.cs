using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public void movesettings()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    }

    public void resume()
    {

    }

    public void playagain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

        public void quit()
    {

    }
}
