using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AssignClue_Object3_2 : MonoBehaviour // 透過點擊蒐集關鍵字至線索庫中(附加在 keyword_area1_1 - keyword_area1_1_Content - keyword_area1_1_Button)
{
    public int TargetNum; // 指定關鍵字蒐集數量上限

    public GameObject Reminder; // 關鍵字蒐集完成的提醒視窗

    private float timer; // (提醒視窗關閉)計時器

    [HeaderAttribute("Orginal Clue")] // 初始關鍵字：存放在書籍區(展版、簡述)中的所有關鍵字
    public List<GameObject> Orginal_Clue;

    [HeaderAttribute("Collected Clue")] // 存放於線索庫中的關鍵字(初始狀態為隱藏)
    public List<GameObject> Collected_Clue;

    [HeaderAttribute("Clue Transform")] // Book_Transform - Object1_Transform 線索庫中關鍵字放置的實際初始位置
    public List<Transform> Clue_Trans;


    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (Reminder.activeSelf) // 如果提醒視窗已經出現
        {
            timer += Time.deltaTime; // 開始計時

            if (timer >= 3.0f) // 等待3秒後
            {
                Reminder.SetActive(false); // 提醒視窗自動關閉
            }
        }
        else
        {
            timer = 0; // 計時器歸零
        } 
    }


    public void Keyword1_check() // 關鍵字蒐集功能(屬於個別關鍵字)
    {
        if (gameManager.ClueNum_Object2 < TargetNum) // 如果當前蒐集數量小於蒐集數量上限
        {
            gameManager.Object2_Keyword1 = true; // 該關鍵字的蒐集狀態 : true

            Orginal_Clue[0].SetActive(false); // 隱藏書籍區中的關鍵字

            Collected_Clue[0].SetActive(true); // 顯示線索庫中的關鍵字

            Collected_Clue[0].transform.position = Clue_Trans[gameManager.ClueNum_Object2].position; // 該關鍵字分配至指定的線索庫位置

            gameManager.ClueNum_Object2++; // 關鍵字蒐集數量 + 1
        } 
        else
        {
            Debug.Log("Object2_Clue is enough!"); // 關鍵字數量已達上限

            Reminder.SetActive(true); // 顯示提醒視窗
        }
    }

    public void Keyword2_check()
    {
        if (gameManager.ClueNum_Object2 < TargetNum)
        {
            gameManager.Object2_Keyword2 = true;

            Orginal_Clue[1].SetActive(false);

            Collected_Clue[1].SetActive(true);

            Collected_Clue[1].transform.position = Clue_Trans[gameManager.ClueNum_Object2].position;

            gameManager.ClueNum_Object2++;
        }
        else
        {
            Debug.Log("Object2_Clue is enough!");

            Reminder.SetActive(true);
        }
    }

    public void Keyword3_check()
    {
        if (gameManager.ClueNum_Object2 < TargetNum)
        {
            gameManager.Object2_Keyword3 = true;

            Orginal_Clue[2].SetActive(false);

            Collected_Clue[2].SetActive(true);

            Collected_Clue[2].transform.position = Clue_Trans[gameManager.ClueNum_Object2].position;

            gameManager.ClueNum_Object2++;
        }
        else
        {
            Debug.Log("Object2_Clue is enough!");

            Reminder.SetActive(true);
        }
    }

    public void Keyword4_check()
    {
        if (gameManager.ClueNum_Object2 < TargetNum)
        {
            gameManager.Object2_Keyword4 = true;

            Orginal_Clue[3].SetActive(false);

            Collected_Clue[3].SetActive(true);

            Collected_Clue[3].transform.position = Clue_Trans[gameManager.ClueNum_Object2].position;

            gameManager.ClueNum_Object2++;
        }
        else
        {
            Debug.Log("Object2_Clue is enough!");

            Reminder.SetActive(true);
        }
    }

    public void Keyword5_check()
    {
        if (gameManager.ClueNum_Object2 < TargetNum)
        {
            gameManager.Object2_Keyword5 = true;

            Orginal_Clue[4].SetActive(false);

            Collected_Clue[4].SetActive(true);

            Collected_Clue[4].transform.position = Clue_Trans[gameManager.ClueNum_Object2].position;

            gameManager.ClueNum_Object2++;
        }
        else
        {
            Debug.Log("Object2_Clue is enough!");

            Reminder.SetActive(true);
        }
    }

    public void Keyword6_check()
    {
        if (gameManager.ClueNum_Object2 < TargetNum)
        {
            gameManager.Object2_Keyword6 = true;

            Orginal_Clue[5].SetActive(false);

            Collected_Clue[5].SetActive(true);

            Collected_Clue[5].transform.position = Clue_Trans[gameManager.ClueNum_Object2].position;

            gameManager.ClueNum_Object2++;
        }
        else
        {
            Debug.Log("Object2_Clue is enough!");

            Reminder.SetActive(true);
        }
    }
}
