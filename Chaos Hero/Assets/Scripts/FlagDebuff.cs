using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FlagDebuff : MonoBehaviour
{
    bool isTouching = false;
    int debuffChosen;
    int debuffListLoadCount;

    List<string> debuffs = new List<string>();
    void Start()
    {

        isTouching = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && !isTouching)
        {
            debuffListLoadCount = PlayerPrefs.GetInt("debuffsCount");
            debuffs.Clear();
            if (debuffListLoadCount == 0)
            {
                SceneManager.LoadScene("You Won");
            }
            else
            {
                for (int i = 0; i < debuffListLoadCount; i++)
                {
                    debuffs.Add(PlayerPrefs.GetString("debuffs" + i));
                }


                isTouching = true;
                debuffChosen = Random.Range(0, debuffListLoadCount);
                //print($"Debuff chosen is {debuffs[debuffChosen]}");
                /////////////////////////

                switch (debuffs[debuffChosen])
                {
                    case "Bad Platform":
                        PlayerPrefs.SetString("Bad Platform", "True");
                        PlayerPrefs.SetString("Bad Platform Text", "True");
                        //Bad Platforms SFX
                        break;

                    case "Flip Map":
                        PlayerPrefs.SetString("Flip Map", "True");
                        PlayerPrefs.SetString("Flip Map Text", "True");
                        //Flipping The Map SFX
                        break;

                    case "Raising Lava":
                        PlayerPrefs.SetString("Raising Lava", "True");
                        PlayerPrefs.SetString("Raising Lava Text", "True");
                        //Raising Lava SFX
                        break;

                    case "DJCancel":
                        PlayerPrefs.SetString("DJCancel", "True");
                        PlayerPrefs.SetString("DJCancelText", "True");
                        //audioManager.PlayOneShot(debuffgainsSFX);
                        //One Jump SFX
                        break;

                    case "Invert Controls":
                        //Inverting Controls SFX
                        PlayerPrefs.SetString("Invert Controls", "True");
                        PlayerPrefs.SetString("Invert Controls Text", "True");
                        break;

                    case "Timer On":
                        //Timer On SFX
                        PlayerPrefs.SetString("Timer On", "True");
                        PlayerPrefs.SetString("Timer On Text", "True");
                        break;

                    case "Random Kill":
                        //Random Death SFX
                        PlayerPrefs.SetString("Random Kill", "True");
                        PlayerPrefs.SetString("Random Kill Text", "True");
                        break;

                    case "Raining Meteores":
                        PlayerPrefs.SetString("Raining Meteores", "True");
                        PlayerPrefs.SetString("Raining Meteores Text", "True");
                        //Raining Meteores SFX
                        break;
                }
               

                ///////////////////////
                if (debuffs.Count != 0)
                {
                    debuffs.Remove(debuffs[debuffChosen]);
                }
               //print($"List has {debuffs.Count} items after collisiion ");


                for (int i = 0; i < PlayerPrefs.GetInt("debuffsCount"); i++)
                {
                    PlayerPrefs.DeleteKey("debuffs" + i);
                }


                //saving the new updated list after removal of chosen debuffs.
                for (int i = 0; i < debuffs.Count; i++)
                {
                    PlayerPrefs.SetString("debuffs" + i, debuffs[i]);
                }
                PlayerPrefs.SetInt("debuffsCount", debuffs.Count);

                SceneManager.LoadScene("The Level");
                //Invoke(nameof(LoadScene),1);

               //print($"List has {debuffs.Count} items after scene load ");
            }
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("The Level");
    }
}