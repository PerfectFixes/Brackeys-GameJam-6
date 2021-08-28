using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public void ChangeScene()
    {
        //Load the level as you left it
        SceneManager.LoadScene("The Level");
    }
    public void NewGame()
    {
        //Resetting all of the playerprefs to start a frash new game
        PlayerPrefs.SetString("DJCancel", "False");
        PlayerPrefs.SetString("Bad Platform", "False");
        PlayerPrefs.SetString("Adding Enemies", "False");
        PlayerPrefs.SetString("Better Enemies", "False");
        PlayerPrefs.SetString("Raining meteores", "False");
        PlayerPrefs.SetString("Timer On", "False");
        PlayerPrefs.SetString("Raising Lava", "False");
        PlayerPrefs.SetString("Invert Controls", "False");
        PlayerPrefs.SetString("Flip Map", "False");
        PlayerPrefs.SetString("Random Kill", "False");

        //Loading the level
        SceneManager.LoadScene("The Level");
    }
    public void QuitGame()
    {
        //Quit
        Application.Quit();
    }
}
