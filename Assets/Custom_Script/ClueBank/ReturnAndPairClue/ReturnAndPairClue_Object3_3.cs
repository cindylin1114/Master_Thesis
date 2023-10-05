using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro; // TextMeshPro

public class ReturnAndPairClue_Object3_3 : MonoBehaviour // 用來將置於線索庫的「關鍵字」配對到對應的測驗題目；將關鍵字放回初始位置(歸位至展品區) (附加在 Clue_bank - Clue_Bank_Content - keyword_area1_1_Collection)
{
    public GameObject CheckPoint; // 展品測驗畫面

    public GameObject Exam_Button; // 提示庫中的「挑戰」按鈕

    public GameObject CheckBoard; // 展品測驗完成的提示視窗

    public GameObject ReselectClueButton;

    [SerializeField] private TextMeshProUGUI ObjectTitle; // 線索庫中的展品名稱 (讓 private type variable 顯示在 Inspector)

    [SerializeField] private TextMesh ExamButton_Label; // 挑戰按鈕字樣

    public Image ObjectImage; // 提示庫中的「展品」圖樣位置

    private string ObjectName = "方豪六十自定稿";

    [SerializeField] private Sprite ObjectSprite; // 配對展品封面

    [SerializeField] private Sprite UnknownSprite; // 未解鎖圖片

    [SerializeField] private Sprite CompleteSprite; // 完成配對展品封面

    public float snapDistance; // 吸取距離(系統偵測關鍵字要距離回答區域多少距離之內才會判斷對錯；以「公尺」為單位)

    [HeaderAttribute("Collected Clue")] // 存在於線索庫中的關鍵字
    public List<GameObject> Collected_Clue;

    [HeaderAttribute("Collected Final_Clue")] // 存在於線索庫中的最終關鍵字
    public List<GameObject> Collected_Final_Clue;

    [HeaderAttribute("Orginal Clue")] // 存在於展品區畫面中的關鍵字
    public List<GameObject> Orginal_Clue;

    [HeaderAttribute("Clue Transform")] // 於線索庫中關鍵字置放的位置
    public List<Transform> Clue_Trans;

    [HeaderAttribute("Clue FrontPlate")] // 線索庫中的關鍵字「背板」
    public List<GameObject> Clue_Frontplate;

    [HeaderAttribute("Clue Color")] // 關鍵字「背板」的顏色
    public List<Material> Return_Color;

    [HeaderAttribute("Return Transform_Object")] // 用以記錄關鍵字復原的位置
    public List<Transform> Return_Trans;

    [HeaderAttribute("Return Transform_Object_Final")] // 用以記錄關鍵字復原的位置
    public List<Transform> Return_Trans_Final;

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

    public static int limitNum = 2; // 指定數量為2個(4個填答區域)

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
        foreach (GameObject i in Collected_Clue)
        {
            if (!CheckPoint.activeSelf) // 如果展品測驗畫面沒有出現
            {
                i.GetComponent<ObjectManipulator>().enabled = false; // 禁用 Collected_Clue GameObject 的操作互動
            } 
            else
            {
                i.GetComponent<ObjectManipulator>().enabled = true;
            }
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

        for (int i = 0; i < Collected_Final_Clue.Count; i++)
        {
            if (Collected_Final_Clue[i].activeSelf)
            {
                if (Return_Trans_Final[i].localPosition == new Vector3(0, 0, 0)) // 如果關鍵字復原位置還沒有被設置
                {
                    Return_Trans_Final[i].position = Collected_Final_Clue[i].transform.position; // 將該關鍵字目前出現在線索庫中的位置分派給它
                }
            }
        }

        if (gameManager.ClueNum_Object3 > 0 && !gameManager.FinishExam_Object3) // 有關鍵字在線索庫中才會有「重選線索」功能
        {
            ReselectClueButton.SetActive(true);
        }
        else
        {
            ReselectClueButton.SetActive(false);
        }


        if (gameManager.ClueNum_Object3 >= limitNum) // 如果關鍵字蒐集數量達到指定要求(目前設定需要蒐集"限制數量"關鍵字)
        {
            ObjectTitle.text = ObjectName + "(完成)"; // 更動展品標題

            ObjectTitle.color = Color.green; // 字體顏色變為綠色

            ObjectImage.sprite = ObjectSprite; // 於提示庫中顯示配對展品封面

            gameManager.ClueComplete_Object3 = true; // 記錄該書的線索已經蒐集完畢
        } 
        else
        {
            ObjectTitle.text = ObjectName + "(" + gameManager.ClueNum_Object3 + "/" + limitNum + ")"; // 顯示關鍵字蒐集進度

            ObjectTitle.color = Color.black;

            ObjectImage.sprite = UnknownSprite;

            gameManager.ClueComplete_Object3 = false;

            CheckPoint.SetActive(false); // 未達成蒐集數量，展品測驗畫面不會開啟
        }


        if (gameManager.ClueComplete_Object3)
        {
            Exam_Button.GetComponent<Interactable>().IsEnabled = true; // 提示庫中的「挑戰」按鈕 啟用互動
        }
        else
        {
            Exam_Button.GetComponent<Interactable>().IsEnabled = false;
        }


        if (gameManager.Object3_Question1 && gameManager.Object3_Question2 && gameManager.Object3_Question3 && gameManager.Object3_Question4) // 如果在CheckPoint視窗中，展品測驗中的問題全部回答正確後
        {
            gameManager.FinishExam_Object3 = true;

            ObjectImage.sprite = CompleteSprite; // 提示庫中的展品封面變更為「完成配對展品封面」

            ExamButton_Label.text = "複習"; // 挑戰測驗已經完成

            if (!review_flag)
            {
                audioSource.PlayOneShot(sound_Complete);

                review_flag = true;
            }

            if (!gameManager.check_flag_11)
            {
                CheckBoard.SetActive(true);
            }
        }
    }


    public void ReselectClue() // 「關鍵字歸位」按鈕
    {
        Debug.Log("Reselect the Clue from Object3");

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
        Debug.Log("Return Object3_Keyword1");

        if (gameManager.ClueNum_Object3 > 0) // 如果未達指定關鍵字蒐集數量
        {
            gameManager.Object3_Keyword1 = false; // 該關鍵字的蒐集狀態 : false

            Collected_Clue[0].SetActive(false); // 隱藏線索庫中的關鍵字

            Orginal_Clue[0].SetActive(true); // 顯示展品區中的關鍵字(原本蒐集後已經變為隱藏狀態)

            gameManager.ClueNum_Object3--; // 關鍵字蒐集數量 - 1

            Clue_Trans[gameManager.ClueNum_Object3].position = Collected_Clue[0].transform.position;

            Return_Trans[0].localPosition = new Vector3(0, 0, 0); // (線索庫)關鍵字復原的位置歸零
        }
    }

    public void Keyword2_return()
    {
        Debug.Log("Return Object3_Keyword2");

        if (gameManager.ClueNum_Object3 > 0)
        {
            gameManager.Object3_Keyword2 = false;

            Collected_Clue[1].SetActive(false);

            Orginal_Clue[1].SetActive(true);

            gameManager.ClueNum_Object3--;
            
            Clue_Trans[gameManager.ClueNum_Object3].position = Collected_Clue[1].transform.position;

            Return_Trans[1].localPosition = new Vector3(0, 0, 0);
        }
    }

    public void Keyword3_return()
    {
        Debug.Log("Return Object3_Keyword3");

        if (gameManager.ClueNum_Object3 > 0)
        {
            gameManager.Object3_Keyword3 = false;

            Collected_Clue[2].SetActive(false);

            Orginal_Clue[2].SetActive(true);

            gameManager.ClueNum_Object3--;

            Clue_Trans[gameManager.ClueNum_Object3].position = Collected_Clue[2].transform.position;

            Return_Trans[2].localPosition = new Vector3(0, 0, 0);
        }
    }



    // 方豪六十自定稿 第一個關鍵字；第一個正確的關鍵字
    public void ClueDetermine_1() // 用以判斷關鍵字與展品測驗回答區域之間的互動 (for每一個問題)
    {
        if (CheckPoint.activeSelf == true)
        { // pair the answer
            if (Vector3.Distance(Collected_Clue[0].transform.position, Detect_Area[0].transform.position) < snapDistance) // 如果(線索庫)關鍵字與目標偵測回答區域"小於"吸取距離
            {
                SnapToCorrectPos_1(); // 回答正確的後續處理
                audioSource.volume = successVolume;
                audioSource.PlayOneShot(sound_Success); // 播放"成功"的音效
            }
            else if (Vector3.Distance(Collected_Clue[0].transform.position, Detect_Area[0].transform.position) >= snapDistance) // 如果(線索庫)關鍵字與目標偵測回答區域"不小於"吸取距離
            {
                ResetThePos_1(); // 回答錯誤的後續處理(關鍵字配對錯誤、關鍵字放置位置距離過遠)
                audioSource.volume = failVolume;
                audioSource.PlayOneShot(sound_Fail); // 播放"失敗"的音效
            }
        }
    }

    void SnapToCorrectPos_1() // 回答正確
    {
        Debug.Log("Object3_Question1 is correct");

        Collected_Clue[0].SetActive(false); // 隱藏線索庫中的關鍵字

        Answer_Clue[0].SetActive(true); // 顯示回答區域中的正確答案(關鍵字)

        Detect_Area[1].SetActive(false); // 隱藏展品測驗中的題目提示字樣

        gameManager.Object3_Question1 = true; // 展品1的第一個問題已回答正確

        if (step < limitNum)
        {
            step++;
        }
        if (step == limitNum)
        {
            Debug.Log("Finish Object3_Exam!");

            gameManager.FinishExam_Object3 = true;
        }
    }

    void ResetThePos_1() // 回答錯誤
    {
        Debug.Log("Object3_Question1 is wrong");

        Collected_Clue[0].transform.position = Return_Trans[0].position; // (線索庫)關鍵字回復到已記錄的回歸位置

        Collected_Clue[0].transform.localEulerAngles = Return_Rotat;
    }


    // 方豪六十自定稿 第二個關鍵字；第二個正確的關鍵字
    public void ClueDetermine_2() // 用以判斷關鍵字與展品測驗回答區域之間的互動 (for每一個問題)
    {
        if (CheckPoint.activeSelf == true)
        { // pair the answer
            if (Vector3.Distance(Collected_Clue[1].transform.position, Detect_Area[0].transform.position) < snapDistance) // 如果(線索庫)關鍵字與目標偵測回答區域"小於"吸取距離
            {
                SnapToCorrectPos_2(); // 回答正確的後續處理
                audioSource.volume = successVolume;
                audioSource.PlayOneShot(sound_Success); // 播放"成功"的音效
            }
            else if (Vector3.Distance(Collected_Clue[1].transform.position, Detect_Area[0].transform.position) >= snapDistance) // 如果(線索庫)關鍵字與目標偵測回答區域"不小於"吸取距離
            {
                ResetThePos_2(); // 回答錯誤的後續處理(關鍵字配對錯誤、關鍵字放置位置距離過遠)
                audioSource.volume = failVolume;
                audioSource.PlayOneShot(sound_Fail); // 播放"失敗"的音效
            }
        }
    }

    void SnapToCorrectPos_2() // 回答正確
    {
        Debug.Log("Object3_Question2 is correct");

        Collected_Clue[1].SetActive(false); // 隱藏線索庫中的關鍵字

        Answer_Clue[1].SetActive(true); // 顯示回答區域中的正確答案(關鍵字)

        Detect_Area[2].SetActive(false); // 隱藏展品測驗中的題目提示字樣

        gameManager.Object3_Question2 = true; // 展品1的第四個問題已回答正確

        if (step < limitNum)
        {
            step++;
        }
        if (step == limitNum)
        {
            Debug.Log("Finish Object3_Exam!");

            gameManager.FinishExam_Object3 = true;
        }
    }

    void ResetThePos_2() // 回答錯誤
    {
        Debug.Log("Object3_Question2 is wrong");

        Collected_Clue[1].transform.position = Return_Trans[1].position; // (線索庫)關鍵字回復到已記錄的回歸位置

        Collected_Clue[1].transform.localEulerAngles = Return_Rotat;
    }


    // 方豪六十自定稿 第三個關鍵字(預設錯誤)
    public void ClueDetermine_3() // follow with Clue_list
    {
        if (CheckPoint.activeSelf == true)
        { // pair the answer
            if (Vector3.Distance(Collected_Clue[2].transform.position, Return_Trans[2].position) > 0.01f)
            {
                Debug.Log("Not the request keyword(Object3_Keyword3)");
                Collected_Clue[2].transform.position = Return_Trans[2].position;

                Collected_Clue[2].transform.localEulerAngles = Return_Rotat;

                audioSource.volume = failVolume;
                audioSource.PlayOneShot(sound_Fail);
            }
        }
    }


    // 方豪六十自定稿 特殊關鍵字1(臺灣史)；第三個正確關鍵字
    public void ClueDetermine_Final1() // 用以判斷關鍵字與展品測驗回答區域之間的互動 (for每一個問題)
    {
        if (CheckPoint.activeSelf == true)
        { // pair the answer
            if (Vector3.Distance(Collected_Final_Clue[0].transform.position, Detect_Area[0].transform.position) < snapDistance) // 如果(線索庫)關鍵字與目標偵測回答區域"小於"吸取距離
            {
                SnapToCorrectPos_Final1(); // 回答正確的後續處理
                audioSource.volume = successVolume;
                audioSource.PlayOneShot(sound_Success); // 播放"成功"的音效
            }
            else if (Vector3.Distance(Collected_Final_Clue[0].transform.position, Detect_Area[0].transform.position) >= snapDistance) // 如果(線索庫)關鍵字與目標偵測回答區域"不小於"吸取距離
            {
                ResetThePos_Final1(); // 回答錯誤的後續處理(關鍵字配對錯誤、關鍵字放置位置距離過遠)
                audioSource.volume = failVolume;
                audioSource.PlayOneShot(sound_Fail); // 播放"失敗"的音效
            }
        }
    }

    void SnapToCorrectPos_Final1() // 回答正確
    {
        Debug.Log("Object3_Question3 is correct");

        Collected_Final_Clue[0].SetActive(false); // 隱藏線索庫中的關鍵字

        Answer_Clue[2].SetActive(true); // 顯示回答區域中的正確答案(關鍵字)

        Detect_Area[3].SetActive(false); // 隱藏展品測驗中的題目提示字樣

        gameManager.Object3_Question3 = true; // 展品1的第四個問題已回答正確

        if (step < limitNum)
        {
            step++;
        }
        if (step == limitNum)
        {
            Debug.Log("Finish Object3_Exam!");

            gameManager.FinishExam_Object3 = true;
        }
    }

    void ResetThePos_Final1() // 回答錯誤
    {
        Debug.Log("Object3_Question3 is wrong");

        Collected_Final_Clue[0].transform.position = Return_Trans_Final[0].position; // (線索庫)關鍵字回復到已記錄的回歸位置

        Collected_Final_Clue[0].transform.localEulerAngles = Return_Rotat;
    }


    // 方豪六十自定稿 特殊關鍵字2(宗教史)；第四個正確關鍵字
    public void ClueDetermine_Final2() // 用以判斷關鍵字與展品測驗回答區域之間的互動 (for每一個問題)
    {
        if (CheckPoint.activeSelf == true)
        { // pair the answer
            if (Vector3.Distance(Collected_Final_Clue[1].transform.position, Detect_Area[0].transform.position) < snapDistance) // 如果(線索庫)關鍵字與目標偵測回答區域"小於"吸取距離
            {
                SnapToCorrectPos_Final2(); // 回答正確的後續處理
                audioSource.volume = successVolume;
                audioSource.PlayOneShot(sound_Success); // 播放"成功"的音效
            }
            else if (Vector3.Distance(Collected_Final_Clue[1].transform.position, Detect_Area[0].transform.position) >= snapDistance) // 如果(線索庫)關鍵字與目標偵測回答區域"不小於"吸取距離
            {
                ResetThePos_Final2(); // 回答錯誤的後續處理(關鍵字配對錯誤、關鍵字放置位置距離過遠)
                audioSource.volume = failVolume;
                audioSource.PlayOneShot(sound_Fail); // 播放"失敗"的音效
            }
        }
    }

    void SnapToCorrectPos_Final2() // 回答正確
    {
        Debug.Log("Object3_Question4 is correct");

        Collected_Final_Clue[1].SetActive(false); // 隱藏線索庫中的關鍵字

        Answer_Clue[3].SetActive(true); // 顯示回答區域中的正確答案(關鍵字)

        Detect_Area[4].SetActive(false); // 隱藏展品測驗中的題目提示字樣

        gameManager.Object3_Question4 = true; // 展品1的第四個問題已回答正確

        if (step < limitNum)
        {
            step++;
        }
        if (step == limitNum)
        {
            Debug.Log("Finish Object3_Exam!");

            gameManager.FinishExam_Object3 = true;
        }
    }

    void ResetThePos_Final2() // 回答錯誤
    {
        Debug.Log("Object3_Question4 is wrong");

        Collected_Final_Clue[1].transform.position = Return_Trans_Final[1].position; // (線索庫)關鍵字回復到已記錄的回歸位置

        Collected_Final_Clue[1].transform.localEulerAngles = Return_Rotat;
    }


    public void CheckWindow()
    {
        gameManager.check_flag_11 = true;
    }
}
