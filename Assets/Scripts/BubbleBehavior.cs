using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBehavior : MonoBehaviour
{
    public enum BubbleColor { Red, Blue, Yellow, Orange, Purple, Green}
    public BubbleColor bubbleColor;

    public Vector3 initialPosition;
    public bool isMerged = false;

    private static List<GameObject> mergedBubbles = new List<GameObject>();

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble") && !isMerged && !collision.gameObject.GetComponent<BubbleBehavior>().isMerged)
        {
            BubbleBehavior otherBubble = collision.gameObject.GetComponent<BubbleBehavior>();
            BubbleColor newColor = MergedColor(this.bubbleColor, otherBubble.bubbleColor);

            MergeBubbles(collision.gameObject, newColor);
        }
    }

    //set bubble to original point
    public void Respawn()
    {
        transform.position = initialPosition;
        gameObject.SetActive(true);
        isMerged = false;
    }

    private void MergeBubbles(GameObject otherBubble, BubbleColor newColor)
    {
        //Disable Primary Bubbles
        gameObject.SetActive(false);
        otherBubble.SetActive(false);

        //Merge Bubble
        Vector3 mergedPosition = (transform.position + otherBubble.transform.position)/2;
        GameObject mergedBubble = Instantiate(Resources.Load<GameObject>("MergedBubblePrefab"), mergedPosition, Quaternion.identity);

        //Assign Color
        BubbleBehavior mergedBehavior = mergedBubble.GetComponent<BubbleBehavior>();
        mergedBehavior.bubbleColor = newColor;

        //Change Sprite Based on Color

        //track original bubbles position
        mergedBubbles.Add(gameObject);
        mergedBubbles.Add(otherBubble);

        isMerged = true;
        otherBubble.GetComponent<BubbleBehavior>().isMerged = isMerged = true;
    }

    private BubbleColor MergedColor(BubbleColor color1, BubbleColor color2)
    {
        if(color1 == color2)
        {
            return color1;
        }

        if(color1 == BubbleColor.Red &&  color2 == BubbleColor.Blue)
        {
            return BubbleColor.Purple;
        }
        else if(color1 == BubbleColor.Yellow && color2 == BubbleColor.Blue)
        {
            return BubbleColor.Green;
        }
        else if(color1 == BubbleColor.Red && color2 == BubbleColor.Yellow)
        {
            return BubbleColor.Orange;
        }

        return color1;
    }

    public void PopMergedBubble(GameObject mergedBubble)
    {
        foreach(GameObject bubble in mergedBubbles)
        {
            BubbleBehavior behavior = bubble.GetComponent<BubbleBehavior>();
            behavior.Respawn();
        }

        Destroy(mergedBubble);
        mergedBubbles.Clear();
    }
}
