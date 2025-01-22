using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerFloorCheck flCheck;
    ParticleSystem partSys; 

    public float walkMod;
    public float jumpMod;

    public bool jumpBuffer;

    public bool enableAfterImg;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        flCheck = transform.GetChild(0).GetComponent<PlayerFloorCheck>();
        partSys = transform.GetChild(1).GetComponent<ParticleSystem>();

        enableAfterImg = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();

        if (enableAfterImg)
        {
            enableAfterImg = false;
            partSys.Play();
        }
    }

    void Move()
    {
        float ContrVal = Input.GetAxisRaw("Horizontal") * walkMod;

        if (ContrVal != 0)
        {
            rb.velocity = new Vector2(ContrVal, rb.velocity.y);
        }

        else
        {
            rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, Time.deltaTime / 0.05f), rb.velocity.y);
        }
    }

    void Jump()
    {

        if (jumpBuffer && flCheck.touchingFloor)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, jumpMod), ForceMode2D.Impulse);
            jumpBuffer = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!flCheck.touchingFloor)
            {
                jumpBuffer = true;
                StartCoroutine("JumpBufferDelay");
            }

            else if (flCheck.touchingFloor)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(new Vector2(0, jumpMod), ForceMode2D.Impulse);
                jumpBuffer = false;
            }

        }
    }

    IEnumerator JumpBufferDelay()
    {
        yield return new WaitForSeconds(0.15f);
        jumpBuffer = false;
    }
}
