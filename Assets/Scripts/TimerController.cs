using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    TextMeshProUGUI TMPro;

    public bool gameOn;

    public float mainTimer;
    int secTimer;
    int minTimer;

    // Start is called before the first frame update
    void Start()
    {
        TMPro = GetComponent<TextMeshProUGUI>();

        gameOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOn)
        {
            mainTimer += Time.deltaTime;

            minTimer = Mathf.FloorToInt(mainTimer / 60);
            secTimer = Mathf.FloorToInt(mainTimer - (minTimer * 60));

            if (minTimer == 0)
            {
                TMPro.text = secTimer.ToString();
            }

            else
            {
                if (secTimer <= 9)
                {
                    TMPro.text = minTimer.ToString() + " : 0" + secTimer.ToString();
                }

                else
                {
                    TMPro.text = minTimer.ToString() + " : " + secTimer.ToString();
                }
            }
        }
    }
}
