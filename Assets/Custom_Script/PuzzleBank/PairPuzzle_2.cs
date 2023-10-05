using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro; // TextMeshPro

public class PairPuzzle_2 : MonoBehaviour
{
    public GameObject Start_To_Puzzle;

    public GameObject NextRegion_Checkboard;

    public float snapDistance;

    [HeaderAttribute("Collected Puzzle")]
    public List<GameObject> Collected_Puzzle;

    [HeaderAttribute("Complete Puzzle")]
    public List<GameObject> Complete_Puzzle;

    [HeaderAttribute("Puzzle Detection Area")]
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

    public static int step = 0;

    [SerializeField] private GameObject Complete_Description;

    private Vector3 Return_Rotat = new Vector3(0.0f, 0.0f, 0.0f);

    private float finish_timer;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        finish_timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.RegionReward_2 && !gameManager.finish_flag_2)
        {
            Complete_Description.SetActive(true);

            finish_timer += Time.deltaTime;

            if (finish_timer >= 0.5f)
            {
                NextRegion_Checkboard.SetActive(true);

                if (!NextRegion_Checkboard.activeSelf)
                {
                    finish_timer = 0;
                }
            }
        }
    }


    public void PuzzleDetermine_1()
    {
        if (Start_To_Puzzle.activeSelf == true)
        {
            if (Vector3.Distance(Collected_Puzzle[0].transform.position, Detect_Area[0].transform.position) < snapDistance)
            {
                SnapToCorrectPos_1();
                audioSource.volume = successVolume;
                audioSource.PlayOneShot(sound_Success);
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
        Collected_Puzzle[0].SetActive(false);

        Complete_Puzzle[0].GetComponent<Image>().color = new Color32(255, 255, 225, 255);

        if (step < Detect_Area.Count)
        {
            step++;
        }
        if (step == Detect_Area.Count)
        {
            Debug.Log("Complete the puzzle!");

            gameManager.RegionReward_2 = true;
        }
    }

    void ResetThePos_1()
    {
        Collected_Puzzle[0].transform.position = Return_Trans[0].position;

        Collected_Puzzle[0].transform.localEulerAngles = Return_Rotat;
    }


    public void PuzzleDetermine_2()
    {
        if (Start_To_Puzzle.activeSelf == true)
        {
            if (Vector3.Distance(Collected_Puzzle[1].transform.position, Detect_Area[1].transform.position) < snapDistance)
            {
                SnapToCorrectPos_2();
                audioSource.volume = successVolume;
                audioSource.PlayOneShot(sound_Success);
            }
            else if (Vector3.Distance(Collected_Puzzle[1].transform.position, Detect_Area[1].transform.position) >= snapDistance)
            {
                ResetThePos_2();
                audioSource.volume = failVolume;
                audioSource.PlayOneShot(sound_Fail);
            }
        }
    }

    void SnapToCorrectPos_2()
    {
        Collected_Puzzle[1].SetActive(false);

        Complete_Puzzle[1].GetComponent<Image>().color = new Color32(255, 255, 225, 255);

        if (step < Detect_Area.Count)
        {
            step++;
        }
        if (step == Detect_Area.Count)
        {
            Debug.Log("Complete the puzzle!");

            gameManager.RegionReward_2 = true;
        }
    }

    void ResetThePos_2()
    {
        Collected_Puzzle[1].transform.position = Return_Trans[1].position;

        Collected_Puzzle[1].transform.localEulerAngles = Return_Rotat;
    }


    public void PuzzleDetermine_3()
    {
        if (Start_To_Puzzle.activeSelf == true)
        {
            if (Vector3.Distance(Collected_Puzzle[2].transform.position, Detect_Area[2].transform.position) < snapDistance)
            {
                SnapToCorrectPos_3();
                audioSource.volume = successVolume;
                audioSource.PlayOneShot(sound_Success);
            }
            else if (Vector3.Distance(Collected_Puzzle[2].transform.position, Detect_Area[2].transform.position) >= snapDistance)
            {
                ResetThePos_3();
                audioSource.volume = failVolume;
                audioSource.PlayOneShot(sound_Fail);
            }
        }
    }

    void SnapToCorrectPos_3()
    {
        Collected_Puzzle[2].SetActive(false);

        Complete_Puzzle[2].GetComponent<Image>().color = new Color32(255, 255, 225, 255);

        if (step < Detect_Area.Count)
        {
            step++;
        }
        if (step == Detect_Area.Count)
        {
            Debug.Log("Complete the puzzle!");

            gameManager.RegionReward_2 = true;
        }
    }

    void ResetThePos_3()
    {
        Collected_Puzzle[2].transform.position = Return_Trans[2].position;

        Collected_Puzzle[2].transform.localEulerAngles = Return_Rotat;
    }


    public void PuzzleDetermine_4()
    {
        if (Start_To_Puzzle.activeSelf == true)
        {
            if (Vector3.Distance(Collected_Puzzle[3].transform.position, Detect_Area[3].transform.position) < snapDistance)
            {
                SnapToCorrectPos_4();
                audioSource.volume = successVolume;
                audioSource.PlayOneShot(sound_Success);
            }
            else if (Vector3.Distance(Collected_Puzzle[3].transform.position, Detect_Area[3].transform.position) >= snapDistance)
            {
                ResetThePos_4();
                audioSource.volume = failVolume;
                audioSource.PlayOneShot(sound_Fail);
            }
        }
    }

    void SnapToCorrectPos_4()
    {
        Collected_Puzzle[3].SetActive(false);

        Complete_Puzzle[3].GetComponent<Image>().color = new Color32(255, 255, 225, 255);

        if (step < Detect_Area.Count)
        {
            step++;
        }
        if (step == Detect_Area.Count)
        {
            Debug.Log("Complete the puzzle!");

            gameManager.RegionReward_2 = true;
        }
    }

    void ResetThePos_4()
    {
        Collected_Puzzle[3].transform.position = Return_Trans[3].position;

        Collected_Puzzle[3].transform.localEulerAngles = Return_Rotat;
    }


    public void PuzzleDetermine_5()
    {
        if (Start_To_Puzzle.activeSelf == true)
        {
            if (Vector3.Distance(Collected_Puzzle[4].transform.position, Detect_Area[4].transform.position) < snapDistance)
            {
                SnapToCorrectPos_5();
                audioSource.volume = successVolume;
                audioSource.PlayOneShot(sound_Success);
            }
            else if (Vector3.Distance(Collected_Puzzle[4].transform.position, Detect_Area[4].transform.position) >= snapDistance)
            {
                ResetThePos_5();
                audioSource.volume = failVolume;
                audioSource.PlayOneShot(sound_Fail);
            }
        }
    }

    void SnapToCorrectPos_5()
    {
        Collected_Puzzle[4].SetActive(false);

        Complete_Puzzle[4].GetComponent<Image>().color = new Color32(255, 255, 225, 255);

        if (step < Detect_Area.Count)
        {
            step++;
        }
        if (step == Detect_Area.Count)
        {
            Debug.Log("Complete the puzzle!");

            gameManager.RegionReward_2 = true;
        }
    }

    void ResetThePos_5()
    {
        Collected_Puzzle[4].transform.position = Return_Trans[4].position;

        Collected_Puzzle[4].transform.localEulerAngles = Return_Rotat;
    }


    public void KeepTouring()
    {
        gameManager.finish_flag_2 = true;
    }

    public void FinishRegion()
    {
        gameManager.Complete_Region_2 = true;
    }
}