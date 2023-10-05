using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro; // TextMeshPro

public class ReturnAndPairClue_Object3_2 : MonoBehaviour // 用來將置於線索庫的「關鍵字」配對到對應的測驗題目；將關鍵字放回初始位置(歸位至展品區) (附加在 Clue_bank - Clue_Bank_Content - keyword_area1_1_Collection)
{
    public GameObject CheckPoint; // 展品測驗畫面

    public GameObject Exam_Button; // 提示庫中的「挑戰」按鈕

    public GameObject CheckBoard; // 展品測驗完成的提示視窗

    public GameObject CheckPoint_Final;

    public GameObject ReselectClueButton;

    public GameObject FinalKeyword_2;

    [SerializeField] private TextMeshProUGUI ObjectTitle; // 線索庫中的展品名稱 (讓 private type variable 顯示在 Inspector)

    [SerializeField] private TextMesh ExamButton_Label; // 挑戰按鈕字樣

    public Image ObjectImage; // 提示庫中的「展品」圖樣位置

    private string ObjectName = "愛國史家陳援庵先生";

    [SerializeField] private Sprite ObjectSprite; // 配對展品封面

    [SerializeField] private Sprite UnknownSprite; // 未解鎖圖片

    [SerializeField] private Sprite CompleteSprite; // 完成配對展品封面

    public float snapDistance; // 吸取距離(系統偵測關鍵字要距離回答區域多少距離之內才會判斷對錯；以「公尺」為單位)

    [HeaderAttribute("Collected Clue")] // 存在於線索庫中的關鍵字
    public List<GameObject> Collected_Clue;

    [HeaderAttribute("Orginal Clue")] // 存在於展品區畫面中的關鍵字
    public List<GameObject> Orginal_Clue;

    [HeaderAttribute("Clue Transform")] // 於線索庫中關鍵字置放的位置
    public List<Transform> Clue_Trans;

    [HeaderAttribute("Clue FrontPlate")] // 線索庫中的關鍵字「背板」
    public List<GameObject> Clue_Frontplate;

    public GameObject Final_Clue_Frontplate;

    [HeaderAttribute("Clue Color")] // 關鍵字「背板」的顏色
    public List<Material> Return_Color;

    public Material Return_Color_Final;

    [HeaderAttribute("Return Transform_Object")] // 用以記錄關鍵字復原的位置
    public List<Transform> Return_Trans;

    [HeaderAttribute("Object Detection Area")] // 展品區中的偵測回答區域
    public List<GameObject> Detect_Area;

    [HeaderAttribute("Answer Clue")] // 展品區中的測驗答案
    public List<GameObject> Answer_Clue;

    [HeaderAttribute("Audio Setting")] // 音效設置(配對成功和失敗的音效)
    private AudioSource audioSource;
    public AudioClip sound_Success;
    public AudioClip sound_Fail;

    public AudioClip sound_Complete;

    public bool review_flag = false;

    [Range(0.0f, 1.0f)] // toggle bar
    public float successVolume;
    [Range(0.0f, 1.0f)]
    public float failVolume;

    public static int step = 0; // 關鍵字答題進度

    public static int limitNum = 3; // 指定數量為3個(3個填答區域)

    private Vector3 Return_Rotat = new Vector3(0.0f, 0.0f, 0.0f);
    
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Collected_Clue.Count-1; i++)
        {
            if (!CheckPoint.activeSelf) // 如果展品測驗畫面沒有出現
            {
                Collected_Clue[i].GetComponent<ObjectManipulator>().enabled = false; // 禁用 Collected_Clue GameObject 的操作互動
            }
            else
            {
                Collected_Clue[i].GetComponent<ObjectManipulator>().enabled = true;
            }
        }

        if (!CheckPoint_Final.activeSelf)
        {
            FinalKeyword_2.GetComponent<ObjectManipulator>().enabled = false;
        }
        else
        {
            FinalKeyword_2.GetComponent<ObjectManipulator>().enabled = true;
        }


        for (int i = 0; i < Collected_Clue.Count; i++)
        {
            if (Collected_Clue[i].activeSelf)
            {
                if (Return_Trans[i].localPosition == new Vector3(0, 0, 0)) // 如果關鍵字復原位置還沒有被設置
                {
                    Return_Trans[i].position = Collected_Clue[i].transform.position; // 將該關鍵字目前出現在線索庫中的位置分派給它
                }
            }
            else
            {
                Clue_Frontplate[i].GetComponent<MeshRenderer>().material = Return_Color[1]; // 回復成關鍵字背板原本的顏色
            }
        }

        if (FinalKeyword_2.activeSelf)
        {
            Final_Clue_Frontplate.GetComponent<MeshRenderer>().material = Return_Color_Final;
        }


        if (gameManager.ClueNum_Object2 > 0 && !gameManager.FinishExam_Object2) // 有關鍵字在線索庫中才會有「重選線索」功能
        {
            ReselectClueButton.SetActive(true);
        }
        else
        {
            ReselectClueButton.SetActive(false);
        }

        if (gameManager.ClueNum_Object2 >= limitNum) // 如果關鍵字蒐集數量達到指定要求(目前設定需要蒐集"限制數量"關鍵字)
        {
            ObjectTitle.text = ObjectName + "(完成)"; // 更動展品標題

            ObjectTitle.color = Color.green; // 字體顏色變為綠色

            ObjectImage.sprite = ObjectSprite; // 於提示庫中顯示配對展品封面

            gameManager.ClueComplete_Object2 = true; // 記錄該書的線索已經蒐集完畢
        } 
        else
        {
            ObjectTitle.text = ObjectName + "(" + gameManager.ClueNum_Object2 + "/" + limitNum + ")"; // 顯示關鍵字蒐集進度

            ObjectTitle.color = Color.black;

            ObjectImage.sprite = UnknownSprite;

            gameManager.ClueComplete_Object2 = false;

            CheckPoint.SetActive(false); // 未達成蒐集數量，展品測驗畫面不會開啟
        }

        if (gameManager.ClueComplete_Object2)
        {
            Exam_Button.GetComponent<Interactable>().IsEnabled = true; // 提示庫中的「挑戰」按鈕 啟用互動
        }
        else
        {
            Exam_Button.GetComponent<Interactable>().IsEnabled = false;
        }

        if (gameManager.Object2_Question1 && gameManager.Object2_Question2 && gameManager.Object2_Question3) // 如果在CheckPoint視窗中，展品測驗中的問題全部回答正確後
        {
            gameManager.FinishExam_Object2 = true;

            ObjectImage.sprite = CompleteSprite; // 提示庫中的展品封面變更為「完成配對展品封面」

            ExamButton_Label.text = "複習"; // 挑戰測驗已經完成

            if (!review_flag)
            {
                audioSource.PlayOneShot(sound_Complete);

                review_flag = true;
            }

            if (!gameManager.check_flag_10)
            {
                CheckBoard.SetActive(true);
            }
        }
    }

    public void ReselectClue() // 「關鍵字歸位」按鈕
    {
        Debug.Log("Reselect the Clue from Object1");

        foreach (GameObject i in Clue_Frontplate)
        {
            i.GetComponent<MeshRenderer>().material = Return_Color[0]; // 關鍵字背板顏色變動(用以判別該狀態為可以歸位)
        }

        foreach (GameObject j in Collected_Clue)
        {
            if (j.activeSelf)
            {
                j.GetComponent<Interactable>().IsEnabled = true; // 關鍵字可以被點擊歸位
            }
        }
    }

    public void LockClue() // 「鎖定關鍵字按鈕」
    {
        foreach (GameObject i in Clue_Frontplate)
        {
            i.GetComponent<MeshRenderer>().material = Return_Color[1]; // 回復為關鍵字背板的原始顏色
        }

        foreach (GameObject j in Collected_Clue)
        {
            if (j.activeSelf)
            {
                j.GetComponent<Interactable>().IsEnabled = false; // 禁用關鍵字「點擊」互動
            }
        }
    }


    public void Keyword1_return() // 關鍵字歸位 功能 (for每一個關鍵字)
    {
        Debug.Log("Return Object2_Keyword1");

        if (gameManager.ClueNum_Object2 > 0) // 如果未達指定關鍵字蒐集數量
        {
            gameManager.Object2_Keyword1 = false; // 該關鍵字的蒐集狀態 : false

            Collected_Clue[0].SetActive(false); // 隱藏線索庫中的關鍵字

            Orginal_Clue[0].SetActive(true); // 顯示展品區中的關鍵字(原本蒐集後已經變為隱藏狀態)

            gameManager.ClueNum_Object2--; // 關鍵字蒐集數量 - 1

            Clue_Trans[gameManager.ClueNum_Object2].position = Collected_Clue[0].transform.position;

            Return_Trans[0].localPosition = new Vector3(0, 0, 0); // (線索庫)關鍵字復原的位置歸零
        }
    }

    public void Keyword2_return()
    {
        Debug.Log("Return Object2_Keyword2");

        if (gameManager.ClueNum_Object2 > 0)
        {
            gameManager.Object2_Keyword2 = false;

            Collected_Clue[1].SetActive(false);

            Orginal_Clue[1].SetActive(true);

            gameManager.ClueNum_Object2--;
            
            Clue_Trans[gameManager.ClueNum_Object2].position = Collected_Clue[1].transform.position;

            Return_Trans[1].localPosition = new Vector3(0, 0, 0);
        }
    }

    public void Keyword3_return()
    {
        Debug.Log("Return Object2_Keyword3");

        if (gameManager.ClueNum_Object2 > 0)
        {
            gameManager.Object2_Keyword3 = false;

            Collected_Clue[2].SetActive(false);

            Orginal_Clue[2].SetActive(true);

            gameManager.ClueNum_Object2--;

            Clue_Trans[gameManager.ClueNum_Object2].position = Collected_Clue[2].transform.position;

            Return_Trans[2].localPosition = new Vector3(0, 0, 0);
        }
    }

    public void Keyword4_return()
    {
        Debug.Log("Return Object2_Keyword4");

        if (gameManager.ClueNum_Object2 > 0)
        {
            gameManager.Object2_Keyword4 = false;

            Collected_Clue[3].SetActive(false);

            Orginal_Clue[3].SetActive(true);

            gameManager.ClueNum_Object2--;

            Clue_Trans[gameManager.ClueNum_Object2].position = Collected_Clue[3].transform.position;

            Return_Trans[3].localPosition = new Vector3(0, 0, 0);
        }
    }

    public void Keyword5_return()
    {
        Debug.Log("Return Object2_Keyword5");

        if (gameManager.ClueNum_Object2 > 0)
        {
            gameManager.Object2_Keyword5 = false;

            Collected_Clue[4].SetActive(false);

            Orginal_Clue[4].SetActive(true);

            gameManager.ClueNum_Object2--;

            Clue_Trans[gameManager.ClueNum_Object2].position = Collected_Clue[4].transform.position;

            Return_Trans[4].localPosition = new Vector3(0, 0, 0);
        }
    }

    public void Keyword6_return()
    {
        Debug.Log("Return Object2_Keyword6");

        if (gameManager.ClueNum_Object2 > 0)
        {
            gameManager.Object2_Keyword6 = false;

            Collected_Clue[5].SetActive(false);

            Orginal_Clue[5].SetActive(true);

            gameManager.ClueNum_Object2--;

            Clue_Trans[gameManager.ClueNum_Object2].position = Collected_Clue[5].transform.position;

            Return_Trans[5].localPosition = new Vector3(0, 0, 0);
        }
    }

    // 愛國史家陳援庵先生 第一個關鍵字(預設錯誤)
    public void ClueDetermine_1() // follow with Clue_list
    {
        if (CheckPoint.activeSelf == true)
        { // pair the answer
            if (Vector3.Distance(Collected_Clue[0].transform.position, Return_Trans[0].position) > 0.01f)
            {
                Debug.Log("Not the request keyword(Object2_Keyword1)");
                Collected_Clue[0].transform.position = Return_Trans[0].position;

                Collected_Clue[0].transform.localEulerAngles = Return_Rotat;

                audioSource.volume = failVolume;
                audioSource.PlayOneShot(sound_Fail);
            }
        }
    }


    // 愛國史家陳援庵先生 第二個關鍵字(預設錯誤)
    public void ClueDetermine_2() // follow with Clue_list
    {
        if (CheckPoint.activeSelf == true)
        { // pair the answer
            if (Vector3.Distance(Collected_Clue[1].transform.position, Return_Trans[1].position) > 0.01f)
            {
                Debug.Log("Not the request keyword(Object2_Keyword2)");
                Collected_Clue[1].transform.position = Return_Trans[1].position;

                Collected_Clue[1].transform.localEulerAngles = Return_Rotat;

                audioSource.volume = failVolume;
                audioSource.PlayOneShot(sound_Fail);
            }
        }
    }


    // 愛國史家陳援庵先生 第三個關鍵字(預設錯誤)
    public void ClueDetermine_3() // follow with Clue_list
    {
        if (CheckPoint.activeSelf == true)
        { // pair the answer
            if (Vector3.Distance(Collected_Clue[2].transform.position, Return_Trans[2].position) > 0.01f)
            {
                Debug.Log("Not the request keyword(Object2_Keyword3)");
                Collected_Clue[2].transform.position = Return_Trans[2].position;

                Collected_Clue[2].transform.localEulerAngles = Return_Rotat;

                audioSource.volume = failVolume;
                audioSource.PlayOneShot(sound_Fail);
            }
        }
    }


    // 愛國史家陳援庵先生 第四個關鍵字；第一個正確的關鍵字
    public void ClueDetermine_4() // follow with Clue_list
    {
        if (CheckPoint.activeSelf == true)
        { // pair the answer
            if (Vector3.Distance(Collected_Clue[3].transform.position, Detect_Area[0].transform.position) < snapDistance)
            {
                SnapToCorrectPos_4(); // Clue_1 is paired correctly
                audioSource.volume = successVolume;
                audioSource.PlayOneShot(sound_Success);
            }
            else if (Vector3.Distance(Collected_Clue[3].transform.position, Detect_Area[0].transform.position) >= snapDistance)
            {
                ResetThePos_4();
                audioSource.volume = failVolume;
                audioSource.PlayOneShot(sound_Fail);
            }
        }
    }

    void SnapToCorrectPos_4() // 回答正確
    {
        Debug.Log("Object2_Question1 is correct");

        Collected_Clue[3].SetActive(false);

        Answer_Clue[0].SetActive(true);

        Detect_Area[1].SetActive(false);

        gameManager.Object2_Question1 = true;

        if (step < limitNum)
        {
            step++;
        }
        if (step == limitNum)
        {
            Debug.Log("Finish Object2_Exam!");

            gameManager.FinishExam_Object2 = true;
        }
    }

    void ResetThePos_4() // 回答錯誤
    {
        Debug.Log("Object2_Question1 is wrong");

        Collected_Clue[3].transform.position = Return_Trans[3].position;

        Collected_Clue[3].transform.localEulerAngles = Return_Rotat;
    }


    // 愛國史家陳援庵先生 第五個關鍵字；第二個正確的關鍵字
    public void ClueDetermine_5() // follow with Clue_list
    {
        if (CheckPoint.activeSelf == true)
        { // pair the answer
            if (Vector3.Distance(Collected_Clue[4].transform.position, Detect_Area[0].transform.position) < snapDistance)
            {
                SnapToCorrectPos_5(); // Clue_1 is paired correctly
                audioSource.volume = successVolume;
                audioSource.PlayOneShot(sound_Success);
            }
            else if (Vector3.Distance(Collected_Clue[4].transform.position, Detect_Area[0].transform.position) >= snapDistance)
            {
                ResetThePos_5();
                audioSource.volume = failVolume;
                audioSource.PlayOneShot(sound_Fail);
            }
        }
    }

    void SnapToCorrectPos_5() // 回答正確
    {
        Debug.Log("Object2_Question2 is correct");

        Collected_Clue[4].SetActive(false);

        Answer_Clue[1].SetActive(true);

        Detect_Area[2].SetActive(false);

        gameManager.Object2_Question2 = true;

        if (step < limitNum)
        {
            step++;
        }
        if (step == limitNum)
        {
            Debug.Log("Finish Object2_Exam!");

            gameManager.FinishExam_Object2 = true;
        }
    }

    void ResetThePos_5() // 回答錯誤
    {
        Debug.Log("Object2_Question2 is wrong");

        Collected_Clue[4].transform.position = Return_Trans[4].position;

        Collected_Clue[4].transform.localEulerAngles = Return_Rotat;
    }


    // 愛國史家陳援庵先生 第六個關鍵字；第三個正確的關鍵字
    public void ClueDetermine_6() // follow with Clue_list
    {
        if (CheckPoint.activeSelf == true)
        { // pair the answer
            if (Vector3.Distance(Collected_Clue[5].transform.position, Detect_Area[0].transform.position) < snapDistance)
            {
                SnapToCorrectPos_6(); // Clue_1 is paired correctly
                audioSource.volume = successVolume;
                audioSource.PlayOneShot(sound_Success);
            }
            else if (Vector3.Distance(Collected_Clue[5].transform.position, Detect_Area[0].transform.position) >= snapDistance)
            {
                ResetThePos_6();
                audioSource.volume = failVolume;
                audioSource.PlayOneShot(sound_Fail);
            }
        }
    }

    void SnapToCorrectPos_6() // 回答正確
    {
        Debug.Log("Object2_Question3 is correct");

        Collected_Clue[5].SetActive(false);

        Answer_Clue[2].SetActive(true);

        Detect_Area[3].SetActive(false);

        gameManager.Object2_Question3 = true;

        if (step < limitNum)
        {
            step++;
        }
        if (step == limitNum)
        {
            Debug.Log("Finish Object2_Exam!");

            gameManager.FinishExam_Object2 = true;
        }
    }

    void ResetThePos_6() // 回答錯誤
    {
        Debug.Log("Object2_Question3 is wrong");

        Collected_Clue[5].transform.position = Return_Trans[5].position;

        Collected_Clue[5].transform.localEulerAngles = Return_Rotat;
    }


    public void CheckWindow()
    {
        gameManager.check_flag_10 = true;
    }
}
