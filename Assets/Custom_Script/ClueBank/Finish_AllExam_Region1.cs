using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish_AllExam_Region1 : MonoBehaviour
{
    [HeaderAttribute("Book1_Exam Answer")]
    public List<GameObject> Book1_Answer;

    [HeaderAttribute("Book2_Exam Answer")]
    public List<GameObject> Book2_Answer;

    [HeaderAttribute("Book3_Exam Answer")]
    public List<GameObject> Book3_Answer;

    [HeaderAttribute("Book4_Exam Answer")]
    public List<GameObject> Book4_Answer;

    [HeaderAttribute("Book5_Exam Answer")]
    public List<GameObject> Book5_Answer;

    [HeaderAttribute("Book_Exam CheckBoard")]
    public List<GameObject> CheckBoard;

    [HeaderAttribute("Book_Exam Quick Button")]
    public List<GameObject> QuickFinish;

    [HeaderAttribute("Book_Exam Quick Button Description")]
    public List<GameObject> QuickFinish_Des;

    [HeaderAttribute("Screen Location")]
    public GameObject Region_Hint;
    public GameObject Clue_Bank;
    public GameObject Puzzle_Bank;
    public GameObject Start_To_Puzzle;
    public List<GameObject> CheckPoint;

    private float timer_1;
    private float timer_2;
    private float timer_3;
    private float timer_4;
    private float timer_5;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Start()
    {
        timer_1 = 0;
        timer_2 = 0;
        timer_3 = 0;
        timer_4 = 0;
        timer_5 = 0;
    }


    public void Update()
    {
        if ((gameManager.FinishExam_Book1 || gameManager.FinishExam_Book2 || gameManager.FinishExam_Book3 || gameManager.FinishExam_Book4 || gameManager.FinishExam_Book5))
        {
            if (gameManager.ClueNum_Book1 == 0)
            {
                QuickFinish[0].SetActive(true);
            } 
            else
            {
                QuickFinish[0].SetActive(false);
            }

            if (gameManager.ClueNum_Book2 == 0)
            {
                QuickFinish[1].SetActive(true);
            }
            else
            {
                QuickFinish[1].SetActive(false);
            }

            if (gameManager.ClueNum_Book3 == 0)
            {
                QuickFinish[2].SetActive(true);
            }
            else
            {
                QuickFinish[2].SetActive(false);
            }

            if (gameManager.ClueNum_Book4 == 0)
            {
                QuickFinish[3].SetActive(true);
            }
            else
            {
                QuickFinish[3].SetActive(false);
            }

            if (gameManager.ClueNum_Book5 == 0)
            {
                QuickFinish[4].SetActive(true);
            }
            else
            {
                QuickFinish[4].SetActive(false);
            }
        }



        if (QuickFinish_Des[0].activeSelf)
        {
            timer_1 += Time.deltaTime;

            if (timer_1 >= 3.0f)
            {
                QuickFinish_Des[0].SetActive(false);
            }
        }
        else
        {
            timer_1 = 0;
        }

        if (QuickFinish_Des[1].activeSelf)
        {
            timer_2 += Time.deltaTime;

            if (timer_2 >= 3.0f)
            {
                QuickFinish_Des[1].SetActive(false);
            }
        }
        else
        {
            timer_2 = 0;
        }

        if (QuickFinish_Des[2].activeSelf)
        {
            timer_3 += Time.deltaTime;

            if (timer_3 >= 3.0f)
            {
                QuickFinish_Des[2].SetActive(false);
            }
        }
        else
        {
            timer_3 = 0;
        }

        if (QuickFinish_Des[3].activeSelf)
        {
            timer_4 += Time.deltaTime;

            if (timer_4 >= 3.0f)
            {
                QuickFinish_Des[3].SetActive(false);
            }
        }
        else
        {
            timer_4 = 0;
        }

        if (QuickFinish_Des[4].activeSelf)
        {
            timer_5 += Time.deltaTime;

            if (timer_5 >= 3.0f)
            {
                QuickFinish_Des[4].SetActive(false);
            }
        }
        else
        {
            timer_5 = 0;
        }
    }


    public void QuickFinish_Book1()
    {
        gameManager.ClueNum_Book1 = 6;

        foreach (GameObject i in Book1_Answer) {
            i.SetActive(true);
        }

        gameManager.Book1_Question1 = true;
        gameManager.Book1_Question2 = true;
        gameManager.Book1_Question3 = true;
        gameManager.Book1_Question4 = true;
        gameManager.Book1_Question5 = true;
        gameManager.Book1_Question6 = true;

        CheckBoard[0].SetActive(false);

        QuickFinish_Des[0].SetActive(true);
    }

    public void QuickFinish_Book2()
    {
        gameManager.ClueNum_Book2 = 6;

        foreach (GameObject i in Book2_Answer)
        {
            i.SetActive(true);
        }

        gameManager.Book2_Question1 = true;
        gameManager.Book2_Question2 = true;
        gameManager.Book2_Question3 = true;
        gameManager.Book2_Question4 = true;
        gameManager.Book2_Question5 = true;
        gameManager.Book2_Question6 = true;

        CheckBoard[1].SetActive(false);

        QuickFinish_Des[1].SetActive(true);
    }

    public void QuickFinish_Book3()
    {
        gameManager.ClueNum_Book3 = 6;

        foreach (GameObject i in Book3_Answer)
        {
            i.SetActive(true);
        }

        gameManager.Book3_Question1 = true;
        gameManager.Book3_Question2 = true;
        gameManager.Book3_Question3 = true;
        gameManager.Book3_Question4 = true;
        gameManager.Book3_Question5 = true;
        gameManager.Book3_Question6 = true;

        CheckBoard[2].SetActive(false);

        QuickFinish_Des[2].SetActive(true);
    }

    public void QuickFinish_Book4()
    {
        gameManager.ClueNum_Book4 = 6;

        foreach (GameObject i in Book4_Answer)
        {
            i.SetActive(true);
        }

        gameManager.Book4_Question1 = true;
        gameManager.Book4_Question2 = true;
        gameManager.Book4_Question3 = true;
        gameManager.Book4_Question4 = true;
        gameManager.Book4_Question5 = true;
        gameManager.Book4_Question6 = true;

        CheckBoard[3].SetActive(false);

        QuickFinish_Des[3].SetActive(true);
    }

    public void QuickFinish_Book5()
    {
        gameManager.ClueNum_Book5 = 4;

        foreach (GameObject i in Book5_Answer)
        {
            i.SetActive(true);
        }

        gameManager.Book5_Question1 = true;
        gameManager.Book5_Question2 = true;
        gameManager.Book5_Question3 = true;
        gameManager.Book5_Question4 = true;

        CheckBoard[4].SetActive(false);

        QuickFinish_Des[4].SetActive(true);
    }

    public void AutoCollectPuzzle()
    {
        gameManager.check_flag_1 = true;
        gameManager.check_flag_2 = true;
        gameManager.check_flag_3 = true;
        gameManager.check_flag_4 = true;
        gameManager.check_flag_5 = true;
    }

    public void Relocation()
    {
        Region_Hint.transform.localPosition = new Vector3(0.902f, -0.196f, 0.014f);

        Region_Hint.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);


        Clue_Bank.transform.localPosition = new Vector3(0.886f, -0.785f, 0.01f);

        Clue_Bank.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);


        foreach (GameObject i in CheckPoint) 
        {
            i.transform.localPosition = new Vector3(1.97f, -0.781f, -0.005f);

            i.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        }


        Puzzle_Bank.transform.localPosition = new Vector3(0.855f, 0.303f, 0.0f);

        Puzzle_Bank.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);


        Start_To_Puzzle.transform.localPosition = new Vector3(0.045f, 0.0f, 0.0f);

        Start_To_Puzzle.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    }
}
