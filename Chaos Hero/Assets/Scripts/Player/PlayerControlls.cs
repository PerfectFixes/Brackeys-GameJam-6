using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerControlls : MonoBehaviour
{
    Rigidbody2D playerRB;
    float xPos;
    float speed = 7f;
    int jumpCounter = 0;
    int badNumber;
    int randomNum;

    [Header("RNG Text")]
    public Text luckyNumText;
    public Text killNumText;
    public Text luckyNumParent;
    public Text killNumParent;

    [Header("SFX")]
    public AudioSource audioManager;
    public AudioClip firstJump;
    public AudioClip secondJump;

    void Start()
    {
        
        //Kills the player if he gets the debuff
        if (PlayerPrefs.GetString("Random Kill") == "True")
        {
            randomNum = Random.Range(1, 21);

            luckyNumText.text = randomNum.ToString();

            StartCoroutine(KillPlayer());
        }
        else
        {
            luckyNumParent.gameObject.SetActive(false);
            killNumParent.gameObject.SetActive(false);
        }

        playerRB = GetComponent<Rigidbody2D>();
        if(PlayerPrefs.GetString("Invert Controls") == "True")
        {
            speed = -7;
            if(PlayerPrefs.GetString("Flip Map") == "True")
            {
                speed = 7;
            }
        }
        else if (PlayerPrefs.GetString("Flip Map") == "True")
        {
            speed = -7;
        }

    }
    private void FixedUpdate()
    {
        xPos = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;

        transform.Translate(xPos, 0, 0);
       
    }
    private void Update()
    {
        if (Input.GetKeyDown("space") && jumpCounter == 0)
        {
            audioManager.PlayOneShot(firstJump);
            jumpCounter++;
            playerRB.AddForce(new Vector2(0, 370));
        }
        else if (Input.GetKeyDown("space") && (jumpCounter == 1) && (PlayerPrefs.GetString("DJCancel") == "False"))
        {
            audioManager.PlayOneShot(secondJump);
            jumpCounter++;
            playerRB.AddForce(new Vector2(0, 150));
        }
    }
    public IEnumerator KillPlayer()
    {
        badNumber = Random.Range(1, 21);

        killNumText.text = badNumber.ToString();

        if (randomNum == badNumber)
        {
            //Bad Lucky SFX
            PlayerPrefs.SetString("RandomDeath", "True");
            SceneManager.LoadScene("The Level");
        }


        yield return new WaitForSeconds(5);

        
        StartCoroutine(KillPlayer());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            jumpCounter = 0;
        }
        if (collision.gameObject.tag == "Lava")
        {
            SceneManager.LoadScene("The Level");
        }
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("The Level");
        }
    }
}
