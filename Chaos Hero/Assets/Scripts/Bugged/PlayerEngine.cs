using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEngine : MonoBehaviour
{
    Rigidbody2D playerRB;
    float xPos;
    float speed = 7f;
    int jumpCounter = 0;
    
    void Start()
    { 
        playerRB = GetComponent<Rigidbody2D>();
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            jumpCounter = 0;
        }

        if (collision.gameObject.tag == "Lava")
        {
            transform.position = new Vector2(-110, -3.0f);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
