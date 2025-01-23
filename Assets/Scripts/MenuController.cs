using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Animator sceneTransAni;
    private void Start()
    {
        sceneTransAni.SetTrigger("SceneBegin");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("sceneTrans");
        }
    }

    IEnumerator sceneTrans()
    {
        sceneTransAni.SetTrigger("SceneEnd");
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(1);
    }
}
