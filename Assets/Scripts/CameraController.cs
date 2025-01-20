using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float camSpeed;
    public float vertOffset;
    public float maxHeight;
    public float minHeight;

    GameObject Player;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        CamMove();
    }

    void CamMove()
    {
        float camTarget = Player.transform.position.y + vertOffset;

        if (camTarget <= minHeight)
        {
            camTarget = minHeight;
        }

        else if (camTarget >= maxHeight)
        {
            camTarget = maxHeight;
        }

        transform.position = new Vector3(0, Mathf.Lerp(transform.position.y, camTarget, Time.deltaTime * camSpeed), -10f);
    }
}
