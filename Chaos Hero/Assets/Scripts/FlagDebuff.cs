using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
            debuffs.Clear();

            debuffListLoadCount = PlayerPrefs.GetInt("debuffsCount");
            if (debuffListLoadCount == 0)
            {
                print("YOU WON GAME OVER BITCH!!!");
            }
            else
            {
                for (int i = 0; i < debuffListLoadCount; i++)
                {
                    debuffs.Add(PlayerPrefs.GetString("debuffs" + i));
                }


                isTouching = true;
                debuffChosen = Random.Range(0, debuffListLoadCount);
                print($"Debuff chosen is {debuffs[debuffChosen]}");
                /////////////////////////

                switch (debuffs[debuffChosen])
                {
                    case "Bad Platform":
                        PlayerPrefs.SetString("Bad Platform", "True");
                        break;

                    case "Flip Map":
                        PlayerPrefs.SetString("Flip Map", "True");
                        break;

                    case "Raising Lava":
                        PlayerPrefs.SetString("Raising Lava", "True");
                        break;

                    case "DJCancel":
                        PlayerPrefs.SetString("DJCancel", "True");
                        break;

                    case "Invert Controls":
                        PlayerPrefs.SetString("Invert Controls", "True");
                        break;

                    case "Timer On":
                        PlayerPrefs.SetString("Timer On", "True");
                        break;

                    case "Random Kill":
                        PlayerPrefs.SetString("Random Kill", "True");
                        break;
                }





                ///////////////////////
                if (debuffs.Count != 0)
                {
                    debuffs.Remove(debuffs[debuffChosen]);
                }
                print($"List has {debuffs.Count} items after collisiion ");


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

                print($"List has {debuffs.Count} items after scene load ");
            }
        }
    }

}