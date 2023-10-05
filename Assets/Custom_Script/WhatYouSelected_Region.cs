using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro; // TextMeshPro

public class WhatYouSelected_Region : MonoBehaviour
{
    public GameObject Region_1;

    public GameObject Region_2;

    public GameObject Region_3;

    [SerializeField] private TextMeshPro Region_1_Text;

    [SerializeField] private TextMeshPro Region_2_Text;

    private string Complete_Region_1 = "方豪所藏台灣文獻(完成)";

    private string Complete_Region_2 = "方豪與天主教(完成)";

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (gameManager.Complete_Region_1)
        {
            Region_1.GetComponent<Interactable>().IsEnabled = false;

            Region_1_Text.text = Complete_Region_1;
        }

        if (gameManager.Complete_Region_2)
        {
            Region_2.GetComponent<Interactable>().IsEnabled = false;

            Region_2_Text.text = Complete_Region_2;
        }


        if (gameManager.Complete_Region_1 && gameManager.Complete_Region_2)
        {
            Region_3.GetComponent<Interactable>().IsEnabled = true;
        }
    }

    public void ChooseRegion_1()
    {
        gameManager.chooseregion_1 = true;
    }

    public void ChooseRegion_2()
    {
        gameManager.chooseregion_2 = true;
    }

    public void ChooseRegion_3()
    {
        gameManager.chooseregion_3 = true;
    }


    public void CheckYouSelect_Region_1()
    {
        if (!gameManager.Complete_Region_2)
        {
            if (!gameManager.Complete_Region_2)
            {
                Region_2.GetComponent<Interactable>().IsEnabled = true;
            }
        }
    }

    public void CheckYouSelect_Region_2()
    {
        if (!gameManager.Complete_Region_1)
        {
            if (!gameManager.Complete_Region_2)
            {
                Region_1.GetComponent<Interactable>().IsEnabled = true;
            }
        }
    }
}
