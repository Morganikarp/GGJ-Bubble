using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFloorCheck : MonoBehaviour
{

    public bool touchingFloor;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Floor")
        {
            touchingFloor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Floor")
        {
            touchingFloor = false;
        }
    }
}
