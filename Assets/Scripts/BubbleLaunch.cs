using UnityEngine;

public class BubbleLaunch : MonoBehaviour
{
    public BubbleBehavior BubbleBehavior;

    private Vector3 launchDirection;
    private float launchForce;
    private float horizontalLaunchPower = 50f;
    private float verticalLaunchPower = 50f;
    private float diagonalLaunchPower = 50f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRigidBody = collision.gameObject.GetComponent<Rigidbody2D>();


            BubbleThing(BubbleBehavior.bubbleColor);
            playerRigidBody.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);

            //Pop Bubble
            //Trigger bubble Respawn
            if (BubbleBehavior.isMerged == true)
            {
                BubbleBehavior.PopMergedBubble(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
                BubbleBehavior.Respawn();
            }
        }
    }

    private void BubbleThing(BubbleBehavior.BubbleColor bubbleColor)
    {
        switch (bubbleColor)
        {
            case BubbleBehavior.BubbleColor.Red:
                launchDirection = new Vector3(-1, 0, 0);
                launchForce = horizontalLaunchPower;
                break;
            case BubbleBehavior.BubbleColor.Blue:
                launchDirection = new Vector3(1, 0, 0);
                launchForce = horizontalLaunchPower;
                break;
            case BubbleBehavior.BubbleColor.Yellow:
                launchDirection = new Vector3(0, 1, 0);
                launchForce = verticalLaunchPower;
                break;
            case BubbleBehavior.BubbleColor.Green:
                launchDirection = new Vector3(1, 1, 0);
                launchForce = diagonalLaunchPower;
                break;
            case BubbleBehavior.BubbleColor.Purple:
                launchDirection = new Vector3(0, -1, 0);
                launchForce = verticalLaunchPower;
                break;
            case BubbleBehavior.BubbleColor.Orange:
                launchDirection = new Vector3(-1, 1, 0);
                launchForce = diagonalLaunchPower;
                break;
            default:
                Debug.Log("help");
                break;
        }

    }
}