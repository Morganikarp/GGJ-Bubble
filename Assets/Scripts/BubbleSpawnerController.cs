using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawnerController : MonoBehaviour
{
    public GameObject bubblePrefab;
    public GameObject myBubble;

    public bool spawnTrigger;

    void Start()
    {
        spawnTrigger = false;
        SpawnBubble();
    }

    void Update()
    {
        if (spawnTrigger)
        {
            spawnTrigger = false;
            StartCoroutine("spawnDelay");
        }
    }

    IEnumerator spawnDelay()
    {
        yield return new WaitForSeconds(3f);
        SpawnBubble();
    }

    void SpawnBubble()
    {
        myBubble = Instantiate(bubblePrefab);
        myBubble.GetComponent<BubbleLaunch>().BubbleSpawner = this;
        myBubble.transform.position = transform.position;
    }
}
