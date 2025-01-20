using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerFloorCheck flCheck;

    public float walkMod;
    public float jumpMod;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        flCheck = transform.GetChild(0).GetComponent<PlayerFloorCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
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
        if (Input.GetKeyDown(KeyCode.Space) && flCheck.touchingFloor)
        {
            rb.AddForce(new Vector2(0, jumpMod), ForceMode2D.Impulse);
        }
    }
}
