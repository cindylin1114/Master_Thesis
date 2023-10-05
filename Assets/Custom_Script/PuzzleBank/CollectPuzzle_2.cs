using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro; // TextMeshPro

public class CollectPuzzle_2 : MonoBehaviour
{
    [HeaderAttribute("Puzzle Image")] // 顯示的拼圖圖樣
    public List<Image> Puzzle_Image;

    [HeaderAttribute("Puzzle Sprite")] // 拖曳的拼圖圖檔
    [SerializeField] private List<Sprite> PuzzleSprite;

    [SerializeField] private Sprite UnknownSprite; // 未解鎖圖片

    [SerializeField] private TextMeshProUGUI PuzzleTitle; // 拼圖庫中的拼圖進度

    private string PuzzleDes = "拼圖碎片收集進度(";

    public int limitNum;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.PuzzleProgress_2 >= limitNum)
        {
            PuzzleTitle.text = "拼圖碎片收集進度(完成) : ";

            PuzzleTitle.color = Color.green;
        }
        else
        {
            PuzzleTitle.text = PuzzleDes + gameManager.PuzzleProgress_2 + "/" + limitNum + ") : ";
        }
    }

    public void CollectPuzzle_2_1()
    {
        gameManager.CollectPuzzle_2_1 = true;

        Puzzle_Image[0].sprite = PuzzleSprite[0];

        gameManager.PuzzleProgress_2++;

        Debug.Log("Collect Puzzle_2_1");
    }

    public void CollectPuzzle_2_2()
    {
        gameManager.CollectPuzzle_2_2 = true;

        Puzzle_Image[1].sprite = PuzzleSprite[1];

        gameManager.PuzzleProgress_2++;

        Debug.Log("Collect Puzzle_2_2");
    }

    public void CollectPuzzle_2_3()
    {
        gameManager.CollectPuzzle_2_3 = true;

        Puzzle_Image[2].sprite = PuzzleSprite[2];

        gameManager.PuzzleProgress_2++;

        Debug.Log("Collect Puzzle_2_3");
    }
}
