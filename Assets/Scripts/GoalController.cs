using System.Collections;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour
{
    public PlayerController pCont;
    public Animator sceneTransAni;
    public TimerController timerCont;

    private void Start()
    {
        StartCoroutine("sceneStart");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            LeadboardData.leaderboardStats.Add(timerCont.mainTimer);

            StartCoroutine("sceneTrans");
        }
    }

    IEnumerator sceneStart()
    {
        sceneTransAni.SetTrigger("SceneBegin");
        yield return new WaitForSeconds(0.8f);
        pCont.gameOn = true;
        timerCont.gameOn = true;
    }

    IEnumerator sceneTrans()
    {
        sceneTransAni.SetTrigger("SceneEnd");
        pCont.gameOn = false;
        timerCont.gameOn = false;
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(0);
    }
}
