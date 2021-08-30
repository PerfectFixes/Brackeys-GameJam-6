using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoresDebuff : MonoBehaviour
{

    float rotationSpeed;

    void Start()
    {
        rotationSpeed = Random.Range(50f, 100f) * Time.deltaTime;
        Destroy(gameObject, 10);
    }


    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }
}
