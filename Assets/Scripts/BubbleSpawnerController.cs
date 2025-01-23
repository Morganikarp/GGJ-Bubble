using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawnerController : MonoBehaviour
{
    public GameObject bubblePrefab;
    GameObject myBubble;

    bool spawnTrigger;

    void Start()
    {
        spawnTrigger = false;
        myBubble = Instantiate(bubblePrefab);
        myBubble.transform.position = transform.position;
    }

    void Update()
    {
        if (myBubble == null)
        {
            spawnTrigger = true;
            myBubble = bubblePrefab;
        }

        if (spawnTrigger)
        {
            spawnTrigger = false;
            StartCoroutine("spawnDelay");
        }
    }

    IEnumerator spawnDelay()
    {
        yield return new WaitForSeconds(3f);
        spawnBubble();
    }

    void spawnBubble()
    {
        Instantiate(myBubble);
        myBubble.transform.position = transform.position;
    }
}
