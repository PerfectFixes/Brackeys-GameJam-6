using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCamera : MonoBehaviour
{

    void Start()
    {
        if (PlayerPrefs.GetString("Flip Map") == "True")
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }
}
