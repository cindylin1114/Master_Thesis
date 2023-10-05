using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro; // TextMeshPro

public class PairPicture : MonoBehaviour
{
    private string Correct_ObjectTitle_1 = "台大文學院致方豪函(已解鎖)";

    private string Correct_ObjectTitle_2 = "愛國史家陳援庵先生(已解鎖)";

    public float snapDistance;

    public GameObject Checkpoint_Final;

    public GameObject Checkboard_Final;

    public GameObject Collected_Puzzle_Final;

    [HeaderAttribute("Region_3 Keyword_Area")]
    public List<GameObject> Keyword_Area;

    [HeaderAttribute("Region_3 Keyword_Collection")]
    public List<GameObject> Keyword_Collection;

    [HeaderAttribute("Region_3 ObjectTitle")]
    public List<TextMeshProUGUI> ObjectTitle;

    [HeaderAttribute("Region_3 ObjectImage")]
    public List<Image> ObjectImage;

    [HeaderAttribute("Collected Puzzle")]
    public List<GameObject> Collected_Puzzle;

    [HeaderAttribute("Correct Picture")]
    public List<Sprite> RegionReward_Image;

    [HeaderAttribute("Origin Description")]
    public List<GameObject> Origin_Description;

    [HeaderAttribute("Paired Description")]
    public List<GameObject> Complete_Description;

    [HeaderAttribute("Picture Detection Area")]
    public List<GameObject> Detect_Area;

    [HeaderAttribute("Return Transform")]
    public List<Transform> Return_Trans;

    [HeaderAttribute("Audio Setting")]
    private AudioSource audioSource;
    public AudioClip sound_Success;
    public AudioClip sound_Fail;
    [Range(0.0f, 1.0f)]
    public float successVolume;
    [Range(0.0f, 1.0f)]
    public float failVolume;

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
        foreach (GameObject i in Collected_Puzzle)
        {
            if (!Keyword_Area[0].activeSelf && !Keyword_Area[1].activeSelf)
            {
                i.GetComponent<ObjectManipulator>().enabled = false;
            }
            else
            {
                i.GetComponent<ObjectManipulator>().enabled = true;
            }
        }
    }

    // 第一張拼圖
    public void PuzzleDetermine_1()
    {
        if (Keyword_Area[0].activeSelf || Keyword_Area[1].activeSelf)
        {
            if (Vector3.Distance(Collected_Puzzle[0].transform.position, Detect_Area[0].transform.position) < snapDistance)
            {
                if (Keyword_Area[0].activeSelf)
                {
                    SnapToCorrectPos_1();
                    audioSource.volume = successVolume;
                    audioSource.PlayOneShot(sound_Success);
                } else
                {
                    ResetThePos_1();
                    audioSource.volume = failVolume;
                    audioSource.PlayOneShot(sound_Fail);
                }
            }
            else if (Vector3.Distance(Collected_Puzzle[0].transform.position, Detect_Area[0].transform.position) >= snapDistance) { 
                ResetThePos_1();
                audioSource.volume = failVolume;
                audioSource.PlayOneShot(sound_Fail);
            }
        }
    }

    void SnapToCorrectPos_1()
    {
        Debug.Log("Pair the correct picture from Object1");

        Collected_Puzzle[0].SetActive(false);

        Origin_Description[0].SetActive(false);

        Complete_Description[0].SetActive(true);

        ObjectTitle[0].text = Correct_ObjectTitle_1;

        ObjectTitle[0].color = Color.green;

        ObjectImage[0].sprite = RegionReward_Image[0];

        Keyword_Collection[0].SetActive(true);
    }

    void ResetThePos_1()
    {
        Collected_Puzzle[0].transform.position = Return_Trans[0].position;

        Collected_Puzzle[0].transform.localEulerAngles = Return_Rotat;
    }


    // 第二張拼圖
    public void PuzzleDetermine_2()
    {
        if (Keyword_Area[0].activeSelf || Keyword_Area[1].activeSelf)
        {
            if (Vector3.Distance(Collected_Puzzle[1].transform.position, Detect_Area[1].transform.position) < snapDistance)
            {
                if (Keyword_Area[1].activeSelf)
                {
                    SnapToCorrectPos_2();
                    audioSource.volume = successVolume;
                    audioSource.PlayOneShot(sound_Success);
                }
                else
                {
                    ResetThePos_2();
                    audioSource.volume = failVolume;
                    audioSource.PlayOneShot(sound_Fail);
                }
            }
            else if (Vector3.Distance(Collected_Puzzle[1].transform.position, Detect_Area[1].transform.position) >= snapDistance) { 
                ResetThePos_2();
                audioSource.volume = failVolume;
                audioSource.PlayOneShot(sound_Fail);
            }
        }
    }

    void SnapToCorrectPos_2()
    {
        Debug.Log("Pair the correct picture from Object2");

        Collected_Puzzle[1].SetActive(false);

        Origin_Description[1].SetActive(false);

        Complete_Description[1].SetActive(true);

        ObjectTitle[1].text = Correct_ObjectTitle_2;

        ObjectTitle[1].color = Color.green;

        ObjectImage[1].sprite = RegionReward_Image[1];

        Keyword_Collection[1].SetActive(true);
    }

    void ResetThePos_2()
    {
        Collected_Puzzle[1].transform.position = Return_Trans[1].position;

        Collected_Puzzle[1].transform.localEulerAngles = Return_Rotat;
    }


    // 最終拼圖(中研院士證書)
    public void PuzzleDetermine_3()
    {
        if (Checkpoint_Final.activeSelf)
        {
            if (Vector3.Distance(Collected_Puzzle_Final.transform.position, Detect_Area[2].transform.position) < snapDistance)
            {
                SnapToCorrectPos_3();
                audioSource.volume = successVolume;
                audioSource.PlayOneShot(sound_Success);

                gameManager.Complete_Region_3 = true;
            }
            else if (Vector3.Distance(Collected_Puzzle_Final.transform.position, Detect_Area[2].transform.position) >= snapDistance)
            {
                ResetThePos_3();
                audioSource.volume = failVolume;
                audioSource.PlayOneShot(sound_Fail);
            }
        }
    }

    void SnapToCorrectPos_3()
    {
        Debug.Log("Pair the correct picture from Object_Final");

        Collected_Puzzle_Final.SetActive(false);

        ObjectImage[2].sprite = RegionReward_Image[2];

        Checkboard_Final.SetActive(true);
    }

    void ResetThePos_3()
    {
        Collected_Puzzle_Final.transform.position = Return_Trans[2].position;

        Collected_Puzzle_Final.transform.localEulerAngles = Return_Rotat;
    }



    public void QuickPairPicture_1()
    {
        Collected_Puzzle[0].SetActive(false);

        Origin_Description[0].SetActive(false);

        Complete_Description[0].SetActive(true);

        ObjectTitle[0].text = Correct_ObjectTitle_1;

        ObjectTitle[0].color = Color.green;

        ObjectImage[0].sprite = RegionReward_Image[0];

        Keyword_Collection[0].SetActive(true);
    }

    public void QuickPairPicture_2()
    {
        Collected_Puzzle[1].SetActive(false);

        Origin_Description[1].SetActive(false);

        Complete_Description[1].SetActive(true);

        ObjectTitle[1].text = Correct_ObjectTitle_2;

        ObjectTitle[1].color = Color.green;

        ObjectImage[1].sprite = RegionReward_Image[1];

        Keyword_Collection[1].SetActive(true);
    }
}