using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;
using static BubbleBehavior;

public class BubbleLaunch : MonoBehaviour
{
<<<<<<< Updated upstream
    BubbleMerge BubbleMerge;

    private Dictionary<Color, (Vector3 direction, float force)> colorLaunchProperties;

<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
    public BubbleBehavior BubbleBehavior;

    private Vector3 launchDirection;
    private float launchForce;
    private float horizontalLaunchPower = 50f;
    private float verticalLaunchPower = 50f;
    private float diagonalLaunchPower = 50f;

>>>>>>> Stashed changes
    // Start is called before the first frame update
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    private float verticalLaunchPower = 50f;
    private float horizontalLaunchPower = 1000f;
    private float diagonalLaunchPower = 100f;

<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    void Start()
    {
<<<<<<< Updated upstream
        colorLaunchProperties = new Dictionary<Color, (Vector3 direction, float force)>
       {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
           { Color.red, (Vector3.left, 10f)},
           { Color.yellow, (Vector3.up, 10f)},
           { Color.blue, (Vector3.right, 10f)},
           { Color.green, (new Vector3(1f, 1f, 0),10f)},
           { new Color (0.5f, 0, 0.5f), (Vector3.down, 10f)}, //purple
           { new Color (1f, 0.647f, 0), (new Vector3(-1f, 1f, 0), 10f)} //oramge
       };

        Vector3 RespawnPosition = gameObject.transform.position;    
=======
           { Color.red, (new Vector3(-1f, 0, 0), horizontalLaunchPower)},
           { new Color(1, 0.92f, 0.016f), (new Vector3(0, 1f, 0), verticalLaunchPower)},
           { Color.blue, (new Vector3(1f, 0, 0), horizontalLaunchPower)},
           { Color.green, (new Vector3(1f, 1f, 0),diagonalLaunchPower)},
           { new Color (0.5f, 0, 0.5f), (new Vector3(0, -1f, 0), verticalLaunchPower)}, //purple
           { new Color (1f, 0.647f, 0), (new Vector3(-1f, 1f, 0), diagonalLaunchPower)} //oramge
       };

=======
           { Color.red, (new Vector3(-1f, 0, 0), horizontalLaunchPower)},
           { new Color(1, 0.92f, 0.016f), (new Vector3(0, 1f, 0), verticalLaunchPower)},
           { Color.blue, (new Vector3(1f, 0, 0), horizontalLaunchPower)},
           { Color.green, (new Vector3(1f, 1f, 0),diagonalLaunchPower)},
           { new Color (0.5f, 0, 0.5f), (new Vector3(0, -1f, 0), verticalLaunchPower)}, //purple
           { new Color (1f, 0.647f, 0), (new Vector3(-1f, 1f, 0), diagonalLaunchPower)} //oramge
       };

>>>>>>> Stashed changes
=======
           { Color.red, (new Vector3(-1f, 0, 0), horizontalLaunchPower)},
           { new Color(1, 0.92f, 0.016f), (new Vector3(0, 1f, 0), verticalLaunchPower)},
           { Color.blue, (new Vector3(1f, 0, 0), horizontalLaunchPower)},
           { Color.green, (new Vector3(1f, 1f, 0),diagonalLaunchPower)},
           { new Color (0.5f, 0, 0.5f), (new Vector3(0, -1f, 0), verticalLaunchPower)}, //purple
           { new Color (1f, 0.647f, 0), (new Vector3(-1f, 1f, 0), diagonalLaunchPower)} //oramge
       };

>>>>>>> Stashed changes
        BubbleMerge = GetComponent<BubbleMerge>();

        Vector3 RespawnPosition = gameObject.transform.position;
>>>>>>> Stashed changes
=======

>>>>>>> Stashed changes
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRigidBody = collision.gameObject.GetComponent<Rigidbody2D>();
<<<<<<< Updated upstream
            SpriteRenderer bubbleRenderer = GetComponent<SpriteRenderer>();
            Color bubbleColor = bubbleRenderer.color;

            if (colorLaunchProperties.TryGetValue(bubbleColor, out var launchProperties))
            {
                Vector3 launchDirection = launchProperties.direction;
                float launchForce;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======

                if (BubbleMerge.hasMerged == false)
                {
                    launchForce = launchProperties.force;
                }
                else
                {
                    launchForce = launchProperties.force * 2;
                }
>>>>>>> Stashed changes

                if (BubbleMerge.hasMerged == false)
                {
                    launchForce = launchProperties.force;
                }
                else
                {
                    launchForce = launchProperties.force * 2;
                }
>>>>>>> Stashed changes

                if (BubbleMerge.hasMerged == false)
                {
                    launchForce = launchProperties.force;
                }
                else
                {
                    launchForce = launchProperties.force * 2;
                }

                playerRigidBody.velocity = launchDirection * launchForce;
            }

            //Pop Bubble
            Destroy(gameObject);

=======
            BubbleThing(BubbleBehavior.bubbleColor);
            playerRigidBody.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);

            //Pop Bubble
>>>>>>> Stashed changes
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
