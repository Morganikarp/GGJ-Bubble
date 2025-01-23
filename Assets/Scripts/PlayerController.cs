using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator ani;

    PlayerFloorCheck flCheck;
    ParticleSystem afterImgPartSys;
    GameObject blowerRange;
    ParticleSystem pushPartSys;
    ParticleSystem pullPartSys;

    public float walkMod;
    public float jumpMod;

    public bool jumpBuffer;

    public bool enableAfterImg;

    public List<GameObject> blowableBubbles;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

        flCheck = transform.GetChild(0).GetComponent<PlayerFloorCheck>();
        afterImgPartSys = transform.GetChild(1).GetComponent<ParticleSystem>();
        blowerRange = transform.GetChild(2).gameObject;
        pushPartSys = blowerRange.transform.GetChild(0).GetComponent<ParticleSystem>();
        pullPartSys = blowerRange.transform.GetChild(1).GetComponent<ParticleSystem>();

        enableAfterImg = false;

        blowableBubbles = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Blower();

        if (enableAfterImg)
        {
            enableAfterImg = false;
            afterImgPartSys.Play();
        }
    }

    void Move()
    {
        float ContrVal = Input.GetAxisRaw("Horizontal") * walkMod;

        if (ContrVal != 0) { ani.SetBool("walking", true); }
        else { ani.SetBool("walking", false); }

        if (ContrVal != 0)
        {
            ani.SetBool("walking", true);
            rb.velocity = new Vector2(ContrVal, rb.velocity.y);

            float a = ContrVal < 0 ? -1 : 1;
            transform.localScale = new Vector2(a , transform.localScale.y);
        }

        else
        {
            ani.SetBool("walking", false);
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

    void Blower()
    {
        float adjustmentAngle = transform.localScale.x < 0 ? 90 : -90;

        Vector3 vectorToTarget = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = -Mathf.Atan2(vectorToTarget.x, vectorToTarget.y) * Mathf.Rad2Deg + adjustmentAngle;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        blowerRange.transform.rotation = q;
        pushPartSys.transform.rotation = q;
        pullPartSys.transform.rotation = q;

        if (transform.localScale.x < 0)
        {
            pushPartSys.transform.eulerAngles += new Vector3(0, 0, 180);
            pullPartSys.transform.eulerAngles += new Vector3(0, 0, 180);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            for (int i = 0; i < blowableBubbles.Count; i++)
            {
                Rigidbody2D bubbleRB = blowableBubbles[i].GetComponent<Rigidbody2D>();
                Vector2 distVect = (blowableBubbles[i].transform.position - transform.position).normalized;
                bubbleRB.AddForce(distVect * 0.05f, ForceMode2D.Impulse);
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) { pushPartSys.Play(); }
        if (Input.GetKeyUp(KeyCode.Mouse0)) { pushPartSys.Stop(); }

        else if (Input.GetKey(KeyCode.Mouse1))
        {
            pushPartSys.Stop();
            for (int i = 0; i < blowableBubbles.Count; i++)
            {
                Rigidbody2D bubbleRB = blowableBubbles[i].GetComponent<Rigidbody2D>();
                Vector2 distVect = (transform.position - blowableBubbles[i].transform.position).normalized;
                bubbleRB.AddForce(distVect * 0.05f, ForceMode2D.Impulse);
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1)) { pullPartSys.Play(); }
        if (Input.GetKeyUp(KeyCode.Mouse1)) { pullPartSys.Stop(); }
    }
}
