using System.Collections;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour
{

    public TimerController timerCont;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            LeadboardData.leaderboardStats.Add(timerCont.mainTimer);

            SceneManager.LoadScene(0);

            //if (LeadboardData.leaderboardStats.Length == LeadboardData.leaderboardStats.
            //Array.Sort(LeadboardData.leaderboardStats);

            //LeadboardData.leaderboardStats.Append(timerCont.mainTimer);
        }
    }
}
