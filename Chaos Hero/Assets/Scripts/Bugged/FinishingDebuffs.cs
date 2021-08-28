using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishingDebuffs : MonoBehaviour
{
    int debuffChosen; //Num representor of a certain debuff
    //static List<int> debuffsHaving = new List<int>(); //List of debuffs player currently has

    void Start()
    {
        //PlayerPrefs.SetString("BadPlatforms", "False"); //index 2
        debuffChosen = Random.Range(1, 4);

        while (!DontDestroy.debuffsHaving.Contains(debuffChosen))
        {
            debuffChosen = Random.Range(1, 4);

            print(debuffChosen);   
        }
        DontDestroy.debuffsHaving.Add(debuffChosen);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {     
         SceneManager.LoadScene("The Level");
     
        switch (debuffChosen)
        {
            case 1:
                PlayerPrefs.SetString("DJCancel", "True");
                print("Double Jump Canceled!");
                break;

            case 2:
                PlayerPrefs.SetString("Bad Platform", "True");
                print("Bad Platforms!");
                break;

            case 3:
                PlayerPrefs.SetString("Flip Map", "True");
                print("Flipping Map");
                break;
        }
    }

}
