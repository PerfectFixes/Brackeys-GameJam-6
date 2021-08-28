using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    List<string> debuffs = new List<string>() { "Bad Platform", "Raising Lava", "DJCancel", "Invert Controls", "Flip Map", "Timer On", "Random Kill" };
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


        //Saving the original debuff list to a PlayerPrefs
        for (int i = 0; i < debuffs.Count; i++)
        {
            PlayerPrefs.SetString("debuffs" + i, debuffs[i]);
        }

        //Saving the debuff list count to a PlayerPrefs
        PlayerPrefs.SetInt("debuffsCount", debuffs.Count);


        //Loading the level
        SceneManager.LoadScene("The Level");
    }
    public void QuitGame()
    {
        //Quit
        Application.Quit();
    }
}