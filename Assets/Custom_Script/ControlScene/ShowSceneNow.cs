using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers; // "SolverHandler" namespace
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro; // TextMeshPro

public class ShowSceneNow : MonoBehaviour
{
    public Transform hololensCamera;

    public GameObject handmenu;

    public GameObject target;

    [HeaderAttribute("Control Windows")]
    public GameObject Region_Hints;

    public GameObject Clue_Bank;

    public GameObject Puzzle_Bank;

    [HeaderAttribute("Control Windows_Type")]
    [SerializeField] private TextMeshPro AdjustPosition_type;

    [SerializeField] private TextMeshPro Region_Hints_type;

    [SerializeField] private TextMeshPro Clue_Bank_type;

    [SerializeField] private TextMeshPro Puzzle_Bank_type;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (gameManager.ControlWindows)
        {
            AdjustPosition_type.text = "跟隨手部\n  調整中...";
        }
        else
        {
            AdjustPosition_type.text = "調整畫面";
        }

        if (Region_Hints.activeSelf)
        {
            Region_Hints_type.color = Color.green;
        } else
        {
            Region_Hints_type.color = Color.white;
        }

        if (Clue_Bank.activeSelf)
        {
            Clue_Bank_type.color = Color.green;
        } else
        {
            Clue_Bank_type.color = Color.white;
        }

        if (Puzzle_Bank.activeSelf)
        {
            Puzzle_Bank_type.color = Color.green;
        } else
        {
            Puzzle_Bank_type.color = Color.white;
        }
    }

    public void ShowScene()
    {
        target.transform.position = new Vector3(handmenu.transform.position.x, handmenu.transform.position.y + 0.2f, handmenu.transform.position.z);
    }

    public void FollowScene()
    {
        if (!gameManager.ControlWindows)
        {
            gameManager.ControlWindows = true;

            target.GetComponent<SolverHandler>().enabled = true;
        }
        else
        {
            gameManager.ControlWindows = false;

            target.GetComponent<SolverHandler>().enabled = false;
        }
    }
}
