using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DebuffNotif : MonoBehaviour
{
    private Animator textAnimation;
   
    [Header("Texts")]
    
    public Text doubleJumpText;
    public Text badPlatformText;
    public Text timerOnText;
    public Text raisinLavaText;
    public Text invertControlsText;
    public Text flipCameraText;
    public Text rainingMeteoresText;
    public Text randomKill;

    [Header("SFX")]
    public AudioSource audioManager;
    public AudioClip doubleJumpSFX;
    public AudioClip badPlatformSFX;
    public AudioClip timerOnSFX;
    public AudioClip raisingLavaSFX;
    public AudioClip invertControlSFX;
    public AudioClip flipMapSFX;
    public AudioClip rainingMeteoresSFX;
    public AudioClip randomKillSFX;
    public AudioClip diedRandomlySFX;

    void Start()
    {
        textAnimation = GetComponent<Animator>();
        if(PlayerPrefs.GetString("RandomDeath") == "True")
        {
            audioManager.PlayOneShot(diedRandomlySFX);

            PlayerPrefs.SetString("RandomDeath", "False");
        }

        if ((PlayerPrefs.GetString("DJCancel") == "True") && PlayerPrefs.GetString("DJCancelText") == "True")
        {
            audioManager.PlayOneShot(doubleJumpSFX);
            doubleJumpText.gameObject.SetActive(true);
            PlayerPrefs.SetString("DJCancelText", "False");
            textAnimation.SetBool("TextDown", true);
        }
        else
        {
            doubleJumpText.gameObject.SetActive(false);
        }
        if ((PlayerPrefs.GetString("Bad Platform") == "True") && PlayerPrefs.GetString("Bad Platform Text") == "True")
        {
            audioManager.PlayOneShot(badPlatformSFX);
            badPlatformText.gameObject.SetActive(true);
            PlayerPrefs.SetString("Bad Platform Text", "False");
            textAnimation.SetBool("TextDown", true);
        }
        else
        {
            badPlatformText.gameObject.SetActive(false);
        }
        if ((PlayerPrefs.GetString("Timer On") == "True") && PlayerPrefs.GetString("Timer On Text") == "True")
        {
            audioManager.PlayOneShot(timerOnSFX);
            timerOnText.gameObject.SetActive(true);
            PlayerPrefs.SetString("Timer On Text", "False");
            textAnimation.SetBool("TextDown", true);
        }
        else
        {
            timerOnText.gameObject.SetActive(false);
        }
        if ((PlayerPrefs.GetString("Raising Lava") == "True") && PlayerPrefs.GetString("Raising Lava Text") == "True")
        {
            audioManager.PlayOneShot(raisingLavaSFX);
            raisinLavaText.gameObject.SetActive(true);
            PlayerPrefs.SetString("Raising Lava Text", "False");
            textAnimation.SetBool("TextDown", true);
        }
        else
        {
            raisinLavaText.gameObject.SetActive(false);
        }
        if ((PlayerPrefs.GetString("Invert Controls") == "True") && PlayerPrefs.GetString("Invert Controls Text") == "True")
        {
            audioManager.PlayOneShot(invertControlSFX);
            invertControlsText.gameObject.SetActive(true);
            PlayerPrefs.SetString("Invert Controls Text", "False");
            textAnimation.SetBool("TextDown", true);
        }
        else
        {
            invertControlsText.gameObject.SetActive(false);
        }
        if ((PlayerPrefs.GetString("Flip Map") == "True") && PlayerPrefs.GetString("Flip Map Text") == "True")
        {
            audioManager.PlayOneShot(flipMapSFX);
            flipCameraText.gameObject.SetActive(true);
            PlayerPrefs.SetString("Flip Map Text", "False");
            textAnimation.SetBool("TextDown", true);
        }
        else
        {
            flipCameraText.gameObject.SetActive(false);
        }
        if ((PlayerPrefs.GetString("Raining Meteores") == "True") && PlayerPrefs.GetString("Raining Meteores Text") == "True")
        {
            audioManager.PlayOneShot(rainingMeteoresSFX);
            rainingMeteoresText.gameObject.SetActive(true);
            PlayerPrefs.SetString("Raining Meteores Text", "False");
            textAnimation.SetBool("TextDown", true);
        }
        else
        {
            rainingMeteoresText.gameObject.SetActive(false);
        }
        if ((PlayerPrefs.GetString("Random Kill") == "True") && PlayerPrefs.GetString("Random Kill Text") == "True")
        {
            audioManager.PlayOneShot(randomKillSFX);
            randomKill.gameObject.SetActive(true);
            PlayerPrefs.SetString("Random Kill Text", "False");
            textAnimation.SetBool("TextDown", true);
        }
        else
        {
            randomKill.gameObject.SetActive(false);
        }

    }
}