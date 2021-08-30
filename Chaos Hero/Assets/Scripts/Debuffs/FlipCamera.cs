using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCamera : MonoBehaviour
{
    public Transform playerPosition;
    public GameObject meteorPrefab;
    private float respawnTime = 1.2f;
    void Start()
    {
        if (PlayerPrefs.GetString("Flip Map") == "True")
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (PlayerPrefs.GetString("Raining Meteores") == "True")
        {
            StartCoroutine(meteorWave());

        }
    }

    private void spawnMeteors()
    {
        GameObject meteor = Instantiate(meteorPrefab) as GameObject;
        meteor.transform.position = new Vector2(Random.Range(playerPosition.position.x - 10, playerPosition.position.x + 20), playerPosition.position.y + 10);
        //print($"Spawned new meteor at cordinates x={meteor.transform.position.x} y={meteor.transform.position.y}");
    }
    IEnumerator meteorWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnMeteors();
        }
    }
}
