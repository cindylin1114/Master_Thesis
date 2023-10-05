using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.UI;

public class Finish_AllExam_Region3 : MonoBehaviour
{
    [HeaderAttribute("Object1 Origin Keyword")]
    public List<GameObject> Object1_Keyword;

    [HeaderAttribute("Object2 Origin Keyword")]
    public List<GameObject> Object2_Keyword;

    [HeaderAttribute("Object3 Origin Keyword")]
    public List<GameObject> Object3_Keyword;

    [HeaderAttribute("Object1 Clue Keyword")]
    public List<GameObject> Object1_Clue;

    [HeaderAttribute("Object2 Clue Keyword")]
    public List<GameObject> Object2_Clue;

    [HeaderAttribute("Object3 Clue Keyword")]
    public List<GameObject> Object3_Clue;

    [HeaderAttribute("Object1_Exam Answer")]
    public List<GameObject> Object1_Answer;

    [HeaderAttribute("Object2_Exam Answer")]
    public List<GameObject> Object2_Answer;

    [HeaderAttribute("Object3_Exam Answer")]
    public List<GameObject> Object3_Answer;

    [HeaderAttribute("Object_Exam CheckBoard")]
    public List<GameObject> CheckBoard;

    [HeaderAttribute("Screen Location")]
    public GameObject Region_Hint;
    public GameObject Clue_Bank;
    public GameObject Picture_Bank;
    public List<GameObject> CheckPoint;


    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void QuickFinish_Object1()
    {
        foreach (GameObject i in Object1_Keyword)
        {
            i.SetActive(true);

            i.GetComponent<Interactable>().IsEnabled = false;
        }

        foreach (GameObject i in Object1_Clue)
        {
            i.SetActive(false);
        }

        gameManager.ClueNum_Object1 = 3;

        foreach (GameObject i in Object1_Answer) {
            i.SetActive(true);
        }

        gameManager.Object1_Question1 = true;
        gameManager.Object1_Question2 = true;
        gameManager.Object1_Question3 = true;

        CheckBoard[0].SetActive(false);
    }

    public void QuickFinish_Object2()
    {
        foreach (GameObject i in Object2_Keyword)
        {
            i.SetActive(true);

            i.GetComponent<Interactable>().IsEnabled = false;
        }

        foreach (GameObject i in Object2_Clue)
        {
            i.SetActive(false);
        }

        gameManager.ClueNum_Object2 = 3;

        foreach (GameObject i in Object2_Answer)
        {
            i.SetActive(true);
        }

        gameManager.Object2_Question1 = true;
        gameManager.Object2_Question2 = true;
        gameManager.Object2_Question3 = true;

        CheckBoard[1].SetActive(false);
    }

    public void QuickFinish_Object3()
    {
        foreach (GameObject i in Object3_Keyword)
        {
            i.SetActive(true);

            i.GetComponent<Interactable>().IsEnabled = false;
        }

        foreach (GameObject i in Object3_Clue)
        {
            i.SetActive(false);
        }

        gameManager.ClueNum_Object3 = 4;

        foreach (GameObject i in Object3_Answer)
        {
            i.SetActive(true);
        }

        gameManager.Object3_Question1 = true;
        gameManager.Object3_Question2 = true;
        gameManager.Object3_Question3 = true;
        gameManager.Object3_Question4 = true;

        CheckBoard[2].SetActive(false);
    }


    public void AutoCollectPuzzle()
    {
        gameManager.check_flag_9 = true;
        gameManager.check_flag_10 = true;
        gameManager.check_flag_11 = true;
    }

    public void Relocation()
    {
        Region_Hint.transform.localPosition = new Vector3(-1.044f, -0.721f, 0.019f);

        Region_Hint.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);


        Clue_Bank.transform.localPosition = new Vector3(-1.064f, -1.289f, 0.015f);

        Clue_Bank.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);


        foreach (GameObject i in CheckPoint)
        {
            i.transform.localPosition = new Vector3(-0.055f, -1.252f, 0.0f);

            i.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        }


        Picture_Bank.transform.localPosition = new Vector3(-1.255f, -1.282f, -0.015f);

        Picture_Bank.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    }
}
