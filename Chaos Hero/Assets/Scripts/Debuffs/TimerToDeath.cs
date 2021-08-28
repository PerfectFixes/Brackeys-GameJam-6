using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerToDeath : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay;
    public Text countdownText;
    private void Start()
    {
        if(PlayerPrefs.GetString("Timer On") == "False")
        {
            countdownText.gameObject.SetActive(false);
        }
        else if(PlayerPrefs.GetString("Timer On") == "True")
        {  
            StartCoroutine(CountdownToStart());
        }
        
    }
    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSeconds(1);

            countdownTime--;
        }
        countdownDisplay.text = "Now";
        
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("The Level");

        yield return new WaitForSeconds(1);

       

    }
}
