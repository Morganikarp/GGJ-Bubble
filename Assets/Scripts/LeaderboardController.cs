using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderboardController : MonoBehaviour
{

    TextMeshProUGUI TMPro;

    void Start()
    {
        TMPro = GetComponent<TextMeshProUGUI>();

        TMPro.text = "Leaderboard:\n";

        LeadboardData.leaderboardStats.Sort();
        List<float> times = LeadboardData.leaderboardStats;

        for (int i = 0; i < times.Count; i++)
        {
            float secs = times[i] - (60 * Mathf.FloorToInt(times[i] / 60));

            if (secs < 10)
            {
                TMPro.text += i+1 + "). " + Mathf.FloorToInt(times[i] / 60) + ":0" + secs.ToString("0.000") + "\n";
            }

            else
            {
                TMPro.text += i+1 + "). " + Mathf.FloorToInt(times[i] / 60) + ":" + secs.ToString("0.000") + "\n";
            }
        }

    }


    void Update()
    {
        
    }
}
