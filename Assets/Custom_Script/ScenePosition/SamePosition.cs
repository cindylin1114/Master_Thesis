using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamePosition : MonoBehaviour
{
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Transform>().position = gameManager.Pos;

        // Quternion rotation (x,y,z,w) ; Vector3 eulerAngles (x,y,z)
        Quaternion rotation = Quaternion.Euler(gameManager.Rot);
        gameObject.GetComponent<Transform>().rotation = rotation;
    }
}
