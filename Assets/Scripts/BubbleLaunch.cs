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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Afterimage activate
            collision.gameObject.GetComponent<PlayerController>().enableAfterImg = true;

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