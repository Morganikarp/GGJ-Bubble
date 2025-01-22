using System.Collections;
using System.Collections.Generic;

using System.Xml.Serialization;
using UnityEngine;

public class BubbleLaunch : MonoBehaviour
{
    private Dictionary<Color, (Vector3 direction, float force)> colorLaunchProperties;
    private float launchPower = 50f;
    // Start is called before the first frame update
    void Start()
    {
        colorLaunchProperties = new Dictionary<Color, (Vector3 direction, float force)>
       {
           { Color.red, (new Vector3(-1, 0, 0), launchPower)},
           { new Color(1f,0.92f, 0.016f), (new Vector3(0, 1, 0), launchPower)},
           { new Color(0f, 0f, 1f), (new Vector3(1, 0, 0), launchPower)},
           { Color.green, (new Vector3(1f, 1f, 0),launchPower)},
           { new Color (0.5f, 0, 0.5f), (new Vector3(0, -1, 0), launchPower)}, //purple
           { new Color (1f, 0.647f, 0), (new Vector3(-1f, 1f, 0), launchPower)} //oramge
       };

        Vector3 RespawnPosition = gameObject.transform.position;

using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;
using static BubbleBehavior;

public class BubbleLaunch : MonoBehaviour
{

    BubbleMerge BubbleMerge;

    private Dictionary<Color, (Vector3 direction, float force)> colorLaunchProperties;





    public BubbleBehavior BubbleBehavior;

    private Vector3 launchDirection;
    private float launchForce;
    private float horizontalLaunchPower = 50f;
    private float verticalLaunchPower = 50f;
    private float diagonalLaunchPower = 50f;


    // Start is called before the first frame update





    private float verticalLaunchPower = 50f;
    private float horizontalLaunchPower = 1000f;
    private float diagonalLaunchPower = 100f;








    void Start()
    {

        colorLaunchProperties = new Dictionary<Color, (Vector3 direction, float force)>
       {



           { Color.red, (Vector3.left, 10f)},
           { Color.yellow, (Vector3.up, 10f)},
           { Color.blue, (Vector3.right, 10f)},
           { Color.green, (new Vector3(1f, 1f, 0),10f)},
           { new Color (0.5f, 0, 0.5f), (Vector3.down, 10f)}, //purple
           { new Color (1f, 0.647f, 0), (new Vector3(-1f, 1f, 0), 10f)} //oramge
       };

        Vector3 RespawnPosition = gameObject.transform.position;    

           { Color.red, (new Vector3(-1f, 0, 0), horizontalLaunchPower)},
           { new Color(1, 0.92f, 0.016f), (new Vector3(0, 1f, 0), verticalLaunchPower)},
           { Color.blue, (new Vector3(1f, 0, 0), horizontalLaunchPower)},
           { Color.green, (new Vector3(1f, 1f, 0),diagonalLaunchPower)},
           { new Color (0.5f, 0, 0.5f), (new Vector3(0, -1f, 0), verticalLaunchPower)}, //purple
           { new Color (1f, 0.647f, 0), (new Vector3(-1f, 1f, 0), diagonalLaunchPower)} //oramge
       };


           { Color.red, (new Vector3(-1f, 0, 0), horizontalLaunchPower)},
           { new Color(1, 0.92f, 0.016f), (new Vector3(0, 1f, 0), verticalLaunchPower)},
           { Color.blue, (new Vector3(1f, 0, 0), horizontalLaunchPower)},
           { Color.green, (new Vector3(1f, 1f, 0),diagonalLaunchPower)},
           { new Color (0.5f, 0, 0.5f), (new Vector3(0, -1f, 0), verticalLaunchPower)}, //purple
           { new Color (1f, 0.647f, 0), (new Vector3(-1f, 1f, 0), diagonalLaunchPower)} //oramge
       };



           { Color.red, (new Vector3(-1f, 0, 0), horizontalLaunchPower)},
           { new Color(1, 0.92f, 0.016f), (new Vector3(0, 1f, 0), verticalLaunchPower)},
           { Color.blue, (new Vector3(1f, 0, 0), horizontalLaunchPower)},
           { Color.green, (new Vector3(1f, 1f, 0),diagonalLaunchPower)},
           { new Color (0.5f, 0, 0.5f), (new Vector3(0, -1f, 0), verticalLaunchPower)}, //purple
           { new Color (1f, 0.647f, 0), (new Vector3(-1f, 1f, 0), diagonalLaunchPower)} //oramge
       };


        BubbleMerge = GetComponent<BubbleMerge>();

        Vector3 RespawnPosition = gameObject.transform.position;





    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            // Afterimage activate
            collision.gameObject.GetComponent<PlayerController>().enableAfterImg = true;

            Rigidbody2D playerRigidBody = collision.gameObject.GetComponent<Rigidbody2D>();

            Rigidbody2D playerRigidBody = collision.gameObject.GetComponent<Rigidbody2D>();


            SpriteRenderer bubbleRenderer = GetComponent<SpriteRenderer>();
            Color bubbleColor = bubbleRenderer.color;

            if (colorLaunchProperties.TryGetValue(bubbleColor, out var launchProperties))
            {
                Vector3 launchDirection = launchProperties.direction;

                float launchForce = launchProperties.force;

                playerRigidBody.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);

                //Pop Bubble
                Destroy(gameObject);
            }

            //Trigger bubble Respawn
        }
    }
}

                float launchForce;





                if (BubbleMerge.hasMerged == false)
                {
                    launchForce = launchProperties.force;
                }
                else
                {
                    launchForce = launchProperties.force * 2;
                }


                if (BubbleMerge.hasMerged == false)
                {
                    launchForce = launchProperties.force;
                }
                else
                {
                    launchForce = launchProperties.force * 2;
                }


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

