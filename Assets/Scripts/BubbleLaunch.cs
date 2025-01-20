using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BubbleLaunch : MonoBehaviour
{
    private Dictionary<Color, (Vector3 direction, float force)> colorLaunchProperties;

    // Start is called before the first frame update
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRigidBody = collision.gameObject.GetComponent<Rigidbody2D>();
            SpriteRenderer bubbleRenderer = GetComponent<SpriteRenderer>();
            Color bubbleColor = bubbleRenderer.color;

            if (colorLaunchProperties.TryGetValue(bubbleColor, out var launchProperties))
            {
                Vector3 launchDirection = launchProperties.direction;
                float launchForce = launchProperties.force;

                playerRigidBody.velocity = launchDirection * launchForce;
            }

            //Pop Bubble
            Destroy(gameObject);

            //Trigger bubble Respawn
        }
    }
}
