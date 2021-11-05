using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // Changes the scene by shifting the index by 1
    }



    public void QuitGame()
    {
        Application.Quit(); // Just quits the game
    }
}
