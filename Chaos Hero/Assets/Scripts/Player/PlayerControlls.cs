using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerControlls : MonoBehaviour
{
    Rigidbody2D playerRB;
    float xPos;
    float speed = 7f;
    int jumpCounter = 0;
    int badNumber;
    int randomNum;
    void Start()
    {
        //Kills the player if he gets the debuff
        if (PlayerPrefs.GetString("Random Kill") == "True")
        {
            randomNum = Random.Range(1, 21);

            print(randomNum + " Normal Number");

            StartCoroutine(KillPlayer());
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
        xPos = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(xPos, 0, 0);
       
    }
    private void Update()
    {
        if (Input.GetKeyDown("space") && jumpCounter == 0)
        {
            jumpCounter++;
            playerRB.AddForce(new Vector2(0, 370));
        }
        else if (Input.GetKeyDown("space") && (jumpCounter == 1) && (PlayerPrefs.GetString("DJCancel") == "False"))
        {
            jumpCounter++;
            playerRB.AddForce(new Vector2(0, 150));
        }
    }
    public IEnumerator KillPlayer()
    {
        badNumber = Random.Range(1, 21);

        yield return new WaitForSeconds(5);

        if (randomNum == badNumber)
        {
            SceneManager.LoadScene("The Level");
        }

        print(badNumber + " Bad number");

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
            Destroy(collision.gameObject);
        }
    }
}
