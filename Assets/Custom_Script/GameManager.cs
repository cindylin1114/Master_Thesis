using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // singleton(single instance)

    static GameManager instance;

    public Vector3 Pos;

    public Vector3 Rot;

    public bool audio_flag;

    public bool finish_flag_1;

    public bool finish_flag_2;

    public bool AutoClose;

    public bool ControlWindows;

    public bool ControlLog;

    [HeaderAttribute("The Region you choose")]
    public bool chooseregion_1;
    public bool chooseregion_2;
    public bool chooseregion_3;

    [HeaderAttribute("Book_Keyword Collection")]
    public bool Book1_Keyword1;
    public bool Book1_Keyword2;
    public bool Book1_Keyword3;
    public bool Book1_Keyword4;
    public bool Book1_Keyword5;
    public bool Book1_Keyword6;
    public bool Book1_Keyword7;
    public bool Book1_Keyword8;
    public bool Book1_Keyword9;
    public bool Book1_Keyword10;

    public bool Book2_Keyword1;
    public bool Book2_Keyword2;
    public bool Book2_Keyword3;
    public bool Book2_Keyword4;
    public bool Book2_Keyword5;
    public bool Book2_Keyword6;
    public bool Book2_Keyword7;
    public bool Book2_Keyword8;
    public bool Book2_Keyword9;
    public bool Book2_Keyword10;

    public bool Book3_Keyword1;
    public bool Book3_Keyword2;
    public bool Book3_Keyword3;
    public bool Book3_Keyword4;
    public bool Book3_Keyword5;
    public bool Book3_Keyword6;
    public bool Book3_Keyword7;
    public bool Book3_Keyword8;
    public bool Book3_Keyword9;
    public bool Book3_Keyword10;

    public bool Book4_Keyword1;
    public bool Book4_Keyword2;
    public bool Book4_Keyword3;
    public bool Book4_Keyword4;
    public bool Book4_Keyword5;
    public bool Book4_Keyword6;
    public bool Book4_Keyword7;
    public bool Book4_Keyword8;
    public bool Book4_Keyword9;
    public bool Book4_Keyword10;

    public bool Book5_Keyword1;
    public bool Book5_Keyword2;
    public bool Book5_Keyword3;
    public bool Book5_Keyword4;
    public bool Book5_Keyword5;
    public bool Book5_Keyword6;
    public bool Book5_Keyword7;
    public bool Book5_Keyword8;

    public bool Book6_Keyword1;
    public bool Book6_Keyword2;
    public bool Book6_Keyword3;
    public bool Book6_Keyword4;
    public bool Book6_Keyword5;

    public bool Book7_Keyword1;
    public bool Book7_Keyword2;
    public bool Book7_Keyword3;
    public bool Book7_Keyword4;
    public bool Book7_Keyword5;
    public bool Book7_Keyword6;

    public bool Book8_Keyword1;
    public bool Book8_Keyword2;
    public bool Book8_Keyword3;
    public bool Book8_Keyword4;
    public bool Book8_Keyword5;

    [HeaderAttribute("Object_Keyword Collection")]
    public bool Object1_Keyword1;
    public bool Object1_Keyword2;
    public bool Object1_Keyword3;
    public bool Object1_Keyword4;

    public bool Object2_Keyword1;
    public bool Object2_Keyword2;
    public bool Object2_Keyword3;
    public bool Object2_Keyword4;
    public bool Object2_Keyword5;
    public bool Object2_Keyword6;

    public bool Object3_Keyword1;
    public bool Object3_Keyword2;
    public bool Object3_Keyword3;

    [HeaderAttribute("Current Book_Keyword Collection")]
    public int ClueNum_Book1;
    public int ClueNum_Book2;
    public int ClueNum_Book3;
    public int ClueNum_Book4;
    public int ClueNum_Book5;
    public int ClueNum_Book6;
    public int ClueNum_Book7;
    public int ClueNum_Book8;

    [HeaderAttribute("Current Object_Keyword Collection")]
    public int ClueNum_Object1;
    public int ClueNum_Object2;
    public int ClueNum_Object3;

    [HeaderAttribute("Each Question")]
    public bool Book1_Question1;
    public bool Book1_Question2;
    public bool Book1_Question3;
    public bool Book1_Question4;
    public bool Book1_Question5;
    public bool Book1_Question6;

    public bool Book2_Question1;
    public bool Book2_Question2;
    public bool Book2_Question3;
    public bool Book2_Question4;
    public bool Book2_Question5;
    public bool Book2_Question6;

    public bool Book3_Question1;
    public bool Book3_Question2;
    public bool Book3_Question3;
    public bool Book3_Question4;
    public bool Book3_Question5;
    public bool Book3_Question6;

    public bool Book4_Question1;
    public bool Book4_Question2;
    public bool Book4_Question3;
    public bool Book4_Question4;
    public bool Book4_Question5;
    public bool Book4_Question6;

    public bool Book5_Question1;
    public bool Book5_Question2;
    public bool Book5_Question3;
    public bool Book5_Question4;

    public bool Book6_Question1;
    public bool Book6_Question2;
    public bool Book6_Question3;

    public bool Book7_Question1;
    public bool Book7_Question2;

    public bool Book8_Question1;
    public bool Book8_Question2;
    public bool Book8_Question3;

    public bool Object1_Question1;
    public bool Object1_Question2;
    public bool Object1_Question3;

    public bool Object2_Question1;
    public bool Object2_Question2;
    public bool Object2_Question3;

    public bool Object3_Question1;
    public bool Object3_Question2;
    public bool Object3_Question3;
    public bool Object3_Question4;

    [HeaderAttribute("Keyword Collection Progress")]
    public bool ClueComplete_Book1;
    public bool ClueComplete_Book2;
    public bool ClueComplete_Book3;
    public bool ClueComplete_Book4;
    public bool ClueComplete_Book5;
    public bool ClueComplete_Book6;
    public bool ClueComplete_Book7;
    public bool ClueComplete_Book8;

    public bool ClueComplete_Object1;
    public bool ClueComplete_Object2;
    public bool ClueComplete_Object3;

    [HeaderAttribute("Region_Exam Progress")]
    public bool FinishExam_Book1;
    public bool FinishExam_Book2;
    public bool FinishExam_Book3;
    public bool FinishExam_Book4;
    public bool FinishExam_Book5;
    public bool FinishExam_Book6;
    public bool FinishExam_Book7;
    public bool FinishExam_Book8;

    public bool FinishExam_Region_2;

    public bool FinishExam_Object1;
    public bool FinishExam_Object2;
    public bool FinishExam_Object3;

    [HeaderAttribute("Control Exam_CheckBoard not show again")]
    public bool check_flag_1;
    public bool check_flag_2;
    public bool check_flag_3;
    public bool check_flag_4;
    public bool check_flag_5;

    public bool check_flag_6;
    public bool check_flag_7;
    public bool check_flag_8;

    public bool check_flag_12; // Checkboard_Toal in Region_2

    public bool check_flag_9;
    public bool check_flag_10;
    public bool check_flag_11;

    [HeaderAttribute("Puzzle Collection Progress")] // update
    public bool CollectPuzzle_1_1;
    public bool CollectPuzzle_1_2;
    public bool CollectPuzzle_1_3;
    public bool CollectPuzzle_1_4;
    public bool CollectPuzzle_1_5;

    public bool CollectPuzzle_2_1;
    public bool CollectPuzzle_2_2;
    public bool CollectPuzzle_2_3;

    public int PuzzleProgress_1;
    public int PuzzleProgress_2;

    [HeaderAttribute("Puzzle Object Complete")]
    public bool RegionReward_1;
    public bool RegionReward_2;

    [HeaderAttribute("Region_Complete Progress")]
    public bool Complete_Region_1;
    public bool Complete_Region_2;
    public bool Complete_Region_3;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != instance)
        {
            Destroy(gameObject);
        }

        Pos = new Vector3(0.066f, 0.05f, 0.5f);

        Rot = new Vector3(0.0f, 0.0f, 0.0f);
    }

    void Start()
    {
        ControlWindows = false;

        ControlLog = false;

        audio_flag = false;

        finish_flag_1 = false;
        finish_flag_2 = false;

        chooseregion_1 = false;
        chooseregion_2 = false;
        chooseregion_3 = false;


        Book1_Keyword1 = false;
        Book1_Keyword2 = false;
        Book1_Keyword3 = false;
        Book1_Keyword4 = false;
        Book1_Keyword5 = false;
        Book1_Keyword6 = false;
        Book1_Keyword7 = false;
        Book1_Keyword8 = false;
        Book1_Keyword9 = false;
        Book1_Keyword10 = false;

        Book2_Keyword1 = false;
        Book2_Keyword2 = false;
        Book2_Keyword3 = false;
        Book2_Keyword4 = false;
        Book2_Keyword5 = false;
        Book2_Keyword6 = false;
        Book2_Keyword7 = false;
        Book2_Keyword8 = false;
        Book2_Keyword9 = false;
        Book2_Keyword10 = false;

        Book3_Keyword1 = false;
        Book3_Keyword2 = false;
        Book3_Keyword3 = false;
        Book3_Keyword4 = false;
        Book3_Keyword5 = false;
        Book3_Keyword6 = false;
        Book3_Keyword7 = false;
        Book3_Keyword8 = false;
        Book3_Keyword9 = false;
        Book3_Keyword10 = false;

        Book4_Keyword1 = false;
        Book4_Keyword2 = false;
        Book4_Keyword3 = false;
        Book4_Keyword4 = false;
        Book4_Keyword5 = false;
        Book4_Keyword6 = false;
        Book4_Keyword7 = false;
        Book4_Keyword8 = false;
        Book4_Keyword9 = false;
        Book4_Keyword10 = false;

        Book5_Keyword1 = false;
        Book5_Keyword2 = false;
        Book5_Keyword3 = false;
        Book5_Keyword4 = false;
        Book5_Keyword5 = false;
        Book5_Keyword6 = false;
        Book5_Keyword7 = false;
        Book5_Keyword8 = false;

        Book6_Keyword1 = false;
        Book6_Keyword2 = false;
        Book6_Keyword3 = false;
        Book6_Keyword4 = false;
        Book6_Keyword5 = false;

        Book7_Keyword1 = false;
        Book7_Keyword2 = false;
        Book7_Keyword3 = false;
        Book7_Keyword4 = false;
        Book7_Keyword5 = false;
        Book7_Keyword6 = false;

        Book8_Keyword1 = false;
        Book8_Keyword2 = false;
        Book8_Keyword3 = false;
        Book8_Keyword4 = false;
        Book8_Keyword5 = false;

        Object1_Keyword1 = false;
        Object1_Keyword2 = false;
        Object1_Keyword3 = false;
        Object1_Keyword4 = false;

        Object2_Keyword1 = false;
        Object2_Keyword2 = false;
        Object2_Keyword3 = false;
        Object2_Keyword4 = false;
        Object2_Keyword5 = false;
        Object2_Keyword6 = false;

        Object3_Keyword1 = false;
        Object3_Keyword2 = false;
        Object3_Keyword3 = false;

        Book1_Question1 = false;
        Book1_Question2 = false;
        Book1_Question3 = false;
        Book1_Question4 = false;
        Book1_Question5 = false;
        Book1_Question6 = false;

        Book2_Question1 = false;
        Book2_Question2 = false;
        Book2_Question3 = false;
        Book2_Question4 = false;
        Book2_Question5 = false;
        Book2_Question6 = false;

        Book3_Question1 = false;
        Book3_Question2 = false;
        Book3_Question3 = false;
        Book3_Question4 = false;
        Book3_Question5 = false;
        Book3_Question6 = false;

        Book4_Question1 = false;
        Book4_Question2 = false;
        Book4_Question3 = false;
        Book4_Question4 = false;
        Book4_Question5 = false;
        Book4_Question6 = false;

        Book5_Question1 = false;
        Book5_Question2 = false;
        Book5_Question3 = false;
        Book5_Question4 = false;

        Book6_Question1 = false;
        Book6_Question2 = false;
        Book6_Question3 = false;

        Book7_Question1 = false;
        Book7_Question2 = false;

        Book8_Question1 = false;
        Book8_Question2 = false;
        Book8_Question3 = false;

        Object1_Question1 = false;
        Object1_Question2 = false;
        Object1_Question3 = false;

        Object2_Question1 = false;
        Object2_Question2 = false;
        Object2_Question3 = false;

        Object3_Question1 = false;
        Object3_Question2 = false;
        Object3_Question3 = false;
        Object3_Question4 = false;


        ClueNum_Book1 = 0;
        ClueNum_Book2 = 0;
        ClueNum_Book3 = 0;
        ClueNum_Book4 = 0;
        ClueNum_Book5 = 0;
        ClueNum_Book6 = 0;
        ClueNum_Book7 = 0;
        ClueNum_Book8 = 0;

        ClueNum_Object1 = 0;
        ClueNum_Object2 = 0;
        ClueNum_Object3 = 0;


        ClueComplete_Book1 = false;
        ClueComplete_Book2 = false;
        ClueComplete_Book3 = false;
        ClueComplete_Book4 = false;
        ClueComplete_Book5 = false;
        ClueComplete_Book6 = false;
        ClueComplete_Book7 = false;
        ClueComplete_Book8 = false;

        ClueComplete_Object1 = false;
        ClueComplete_Object2 = false;
        ClueComplete_Object3 = false;


        FinishExam_Book1 = false;
        FinishExam_Book2 = false;
        FinishExam_Book3 = false;
        FinishExam_Book4 = false;
        FinishExam_Book5 = false;
        FinishExam_Book6 = false;
        FinishExam_Book7 = false;
        FinishExam_Book8 = false;

        FinishExam_Region_2 = false;

        FinishExam_Object1 = false;
        FinishExam_Object2 = false;
        FinishExam_Object3 = false;


        check_flag_1 = false;
        check_flag_2 = false;
        check_flag_3 = false;
        check_flag_4 = false;
        check_flag_5 = false;
        check_flag_6 = false;
        check_flag_7 = false;
        check_flag_8 = false;
        check_flag_9 = false;
        check_flag_10 = false;
        check_flag_11 = false;
        check_flag_12 = false;


        CollectPuzzle_1_1 = false;
        CollectPuzzle_1_2 = false;
        CollectPuzzle_1_3 = false;
        CollectPuzzle_1_4 = false;
        CollectPuzzle_1_5 = false;

        CollectPuzzle_2_1 = false;
        CollectPuzzle_2_2 = false;
        CollectPuzzle_2_3 = false;


        PuzzleProgress_1 = 0;
        PuzzleProgress_2 = 0;


        RegionReward_1 = false;
        RegionReward_2 = false;


        Complete_Region_1 = false;
        Complete_Region_2 = false;
        Complete_Region_3 = false;
    }
}
