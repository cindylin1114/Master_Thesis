using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.UI;

public class Finish_AllExam_Region2 : MonoBehaviour
{
    [HeaderAttribute("Book6 Origin Keyword")]
    public List<GameObject> Book6_Keyword;

    [HeaderAttribute("Book7 Origin Keyword")]
    public List<GameObject> Book7_Keyword;

    [HeaderAttribute("Book8 Origin Keyword")]
    public List<GameObject> Book8_Keyword;

    [HeaderAttribute("Book6 Clue Keyword")]
    public List<GameObject> Book6_Clue;

    [HeaderAttribute("Book7 Clue Keyword")]
    public List<GameObject> Book7_Clue;

    [HeaderAttribute("Book8 Clue Keyword")]
    public List<GameObject> Book8_Clue;

    [HeaderAttribute("Book6_Exam Answer")]
    public List<GameObject> Book6_Answer;

    [HeaderAttribute("Book7_Exam Answer")]
    public List<GameObject> Book7_Answer;

    [HeaderAttribute("Book8_Exam Answer")]
    public List<GameObject> Book8_Answer;

    [HeaderAttribute("Book_Exam CheckBoard")]
    public List<GameObject> CheckBoard;

    [HeaderAttribute("Screen Location")]
    public GameObject Region_Hint;
    public GameObject Clue_Bank;
    public GameObject Puzzle_Bank;
    public GameObject Start_To_Puzzle;
    public GameObject CheckPoint;


    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void QuickFinish_Book6()
    {
        foreach (GameObject i in Book6_Keyword)
        {
            i.SetActive(true);

            i.GetComponent<Interactable>().IsEnabled = false;
        }

        foreach (GameObject i in Book6_Clue)
        {
            i.SetActive(false);
        }

        gameManager.ClueNum_Book6 = 3;

        foreach (GameObject i in Book6_Answer) {
            i.SetActive(true);
        }

        gameManager.Book6_Question1 = true;
        gameManager.Book6_Question2 = true;
        gameManager.Book6_Question3 = true;

        gameManager.FinishExam_Book6 = true;

        CheckBoard[0].SetActive(false);
    }

    public void QuickFinish_Book7()
    {
        foreach (GameObject i in Book7_Keyword)
        {
            i.SetActive(true);

            i.GetComponent<Interactable>().IsEnabled = false;
        }

        foreach (GameObject i in Book7_Clue)
        {
            i.SetActive(false);
        }

        gameManager.ClueNum_Book7 = 2;

        foreach (GameObject i in Book7_Answer)
        {
            i.SetActive(true);
        }

        gameManager.Book7_Question1 = true;
        gameManager.Book7_Question2 = true;

        gameManager.FinishExam_Book7 = true;

        CheckBoard[1].SetActive(false);
    }

    public void QuickFinish_Book8()
    {
        foreach (GameObject i in Book8_Keyword)
        {
            i.SetActive(true);

            i.GetComponent<Interactable>().IsEnabled = false;
        }

        foreach (GameObject i in Book8_Clue)
        {
            i.SetActive(false);
        }

        gameManager.ClueNum_Book8 = 3;

        foreach (GameObject i in Book8_Answer)
        {
            i.SetActive(true);
        }

        gameManager.Book8_Question1 = true;
        gameManager.Book8_Question2 = true;
        gameManager.Book8_Question3 = true;

        gameManager.FinishExam_Book8 = true;

        CheckBoard[2].SetActive(false);
    }


    public void AutoCollectPuzzle()
    {
        gameManager.check_flag_6 = true;
        gameManager.check_flag_7 = true;
        gameManager.check_flag_8 = true;

        gameManager.check_flag_12 = true;
    }

    public void Relocation()
    {
        Region_Hint.transform.localPosition = new Vector3(0.902f, -0.196f, 0.014f);

        Region_Hint.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);


        Clue_Bank.transform.localPosition = new Vector3(0.901f, -0.783f, 0.01f);

        Clue_Bank.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);


        CheckPoint.transform.localPosition = new Vector3(1.993f, -0.748f, -0.005f);

        CheckPoint.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);


        Puzzle_Bank.transform.localPosition = new Vector3(0.761f, 0.299f, 0.0f);

        Puzzle_Bank.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);


        Start_To_Puzzle.transform.localPosition = new Vector3(-0.079f, -0.199f, 0.0f);

        Start_To_Puzzle.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    }
}
