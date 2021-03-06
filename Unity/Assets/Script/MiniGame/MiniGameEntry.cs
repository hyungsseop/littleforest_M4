using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGameEntry : MonoBehaviour
{
// 미니게임 초기화해주는 스크립트

    public GameObject MinigameObject;
    int doorcount = 0;   

    void Start()
    {
        if (doorcount == 2) // 하루에 미니게임 두번만
        {
            MinigameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void FixedUpdate()
    {
        int t = DateTime.Now.Hour;
        if (t == 5) // 새벽 다섯시에 초기화
        {
            MinigameObject.GetComponent<BoxCollider>().enabled = true;
            doorcount = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount == 1)
            {
                Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                BoxCollider2D coll = MinigameObject.GetComponent<BoxCollider2D>();

                if (coll.OverlapPoint(mp))
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        StaticVal.scenenumber = 6;
                        SceneManager.LoadScene(StaticVal.scenenumber);
                        doorcount++;

                    }
                }
            }
        }

        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                BoxCollider2D coll = MinigameObject.GetComponent<BoxCollider2D>();

                if (coll.OverlapPoint(mp))
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        StaticVal.scenenumber = 6;
                        SceneManager.LoadScene(StaticVal.scenenumber);
                        doorcount++;
                    }
                }

            }
        }
    }
}
