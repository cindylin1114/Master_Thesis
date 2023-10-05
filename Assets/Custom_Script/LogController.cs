using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogController : MonoBehaviour
{
    GameManager gameManager;


    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Open_VirtualTour_1()
    {
        Debug.Log("Open VirtualTour_1");
    }

    public void Close_VirtualTour_1()
    {
        Debug.Log("Close VirtualTour_1");
    }

    public void Open_VirtualTour_2()
    {
        Debug.Log("Open VirtualTour_2");
    }

    public void Close_VirtualTour_2()
    {
        Debug.Log("Close VirtualTour_2");
    }

    public void Open_VirtualTour_3()
    {
        Debug.Log("Open VirtualTour_3");
    }

    public void Close_VirtualTour_3()
    {
        Debug.Log("Close VirtualTour_3");
    }

    public void Play_Audio()
    {
        Debug.Log("Play guide audio");
    }

    public void Open_Keyword_1_2()
    {
        Debug.Log("Open Keyword_1_2");
    }

    public void Open_Keyword_1_3()
    {
        Debug.Log("Open Keyword_1_3");
    }

    public void Open_Keyword_1_5()
    {
        Debug.Log("Open Keyword_1_5");
    }

    public void Open_Keyword_2_1()
    {
        Debug.Log("Open Keyword_2_1");
    }

    public void Open_Keyword_2_2()
    {
        Debug.Log("Open Keyword_2_2");
    }

    public void Open_Keyword_2_3()
    {
        Debug.Log("Open Keyword_2_3");
    }

    public void Open_Keyword_3_1()
    {
        Debug.Log("Open Keyword_3_1");
    }

    public void Open_Keyword_3_2()
    {
        Debug.Log("Open Keyword_3_2");
    }

    public void Open_Keyword_3_3()
    {
        Debug.Log("Open Keyword_3_3");
    }

    public void Start_To_Puzzle_1()
    {
        Debug.Log("Start Puzzle_1");
    }

    public void Start_To_Puzzle_2()
    {
        Debug.Log("Start Puzzle_2");
    }

    public void Collect_FinalClue()
    {
        Debug.Log("Collect FinalClue");
    }

    public void Open_Checkpoint_1_2()
    {
        if (gameManager.FinishExam_Book2)
        {
            Debug.Log("Review Checkpoint_1_2");
        } 
        else
        {
            Debug.Log("Challenge Checkpoint_1_2");
        }
    }

    public void Open_Checkpoint_1_3()
    {
        if (gameManager.FinishExam_Book3)
        {
            Debug.Log("Review Checkpoint_1_3");
        }
        else
        {
            Debug.Log("Challenge Checkpoint_1_3");
        }
    }

    public void Open_Checkpoint_1_5()
    {
        if (gameManager.FinishExam_Book5)
        {
            Debug.Log("Review Checkpoint_1_5");
        }
        else
        {
            Debug.Log("Challenge Checkpoint_1_5");
        }
    }

    public void Open_Checkpoint_Area2()
    {
        if (gameManager.FinishExam_Book6 && gameManager.FinishExam_Book7 && gameManager.FinishExam_Book8)
        {
            Debug.Log("Review Checkpoint_Area2");
        }
        else
        {
            Debug.Log("Challenge Checkpoint_Area2");
        }
    }

    public void Open_Checkpoint_3_1()
    {
        if (gameManager.FinishExam_Object1)
        {
            Debug.Log("Review Checkpoint_3_1");
        }
        else
        {
            Debug.Log("Challenge Checkpoint_3_1");
        }
    }

    public void Open_Checkpoint_3_2()
    {
        if (gameManager.FinishExam_Object2)
        {
            Debug.Log("Review Checkpoint_3_2");
        }
        else
        {
            Debug.Log("Challenge Checkpoint_3_2");
        }
    }

    public void Open_Checkpoint_3_3()
    {
        if (gameManager.FinishExam_Object3)
        {
            Debug.Log("Review Checkpoint_3_3");
        }
        else
        {
            Debug.Log("Challenge Checkpoint_3_3");
        }
    }

    public void Open_Checkpoint_Final()
    {
        Debug.Log("Open Checkpoint_Final");
    }

    public void Review_Checkpoint_1_2()
    {
        Debug.Log("Review Checkpoint_1_2");
    }

    public void Review_Checkpoint_1_3()
    {
        Debug.Log("Review Checkpoint_1_3");
    }

    public void Review_Checkpoint_1_5()
    {
        Debug.Log("Review Checkpoint_1_5");
    }

    public void Review_Checkpoint_Area2()
    {
        Debug.Log("Review Checkpoint_Area2");
    }

    public void Review_Checkpoint_3_1()
    {
        Debug.Log("Review Checkpoint_3_1");
    }

    public void Review_Checkpoint_3_2()
    {
        Debug.Log("Review Checkpoint_3_2");
    }

    public void Review_Checkpoint_3_3()
    {
        Debug.Log("Review Checkpoint_3_3");
    }

    public void Adjust_Position()
    {
        Debug.Log("Adjust Position");
    }

    public void Open_TipBank()
    {
        Debug.Log("Open TipBank");
    }

    public void Open_ClueBank()
    {
        Debug.Log("Open ClueBank");
    }

    public void Open_PuzzleBank()
    {
        Debug.Log("Open PuzzleBank");
    }

    public void Open_PictureBank()
    {
        Debug.Log("Open PictureBank");
    }

    public void Open_Keyword()
    {
        Debug.Log("Open Keyword");
    }

    public void Stop_Logging()
    {
        gameManager.ControlLog = true;
    }
}
