using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMerge : MonoBehaviour
{
    private bool hasMerged = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble") && !hasMerged)
        {
            hasMerged = true;
            Transform otherBubble = collision.transform;

            //add to size
            float newSize = Mathf.Pow(transform.localScale.x * transform.localScale.x + otherBubble.localScale.x * otherBubble.localScale.x, 0.5f);;

            //Change scale of only larger bubble
            Transform largerBubble = transform.localScale.x > otherBubble.localScale.x ? transform : otherBubble;
            largerBubble.localScale = new Vector3 (newSize, newSize, newSize);

            //Destroy smaller bubble
            Destroy(largerBubble == transform ? otherBubble.gameObject : gameObject);
        }
    }
}
