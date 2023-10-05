using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePosition : MonoBehaviour
{
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void MoveScene() // Record the SceneContent position has changed
    {
        GameObject CurrentScene = GameObject.Find("SceneContent");

        GameObject MyCamera = GameObject.Find("Main Camera");

        gameManager.Pos = new Vector3((CurrentScene.transform.position.x - MyCamera.transform.position.x), (CurrentScene.transform.position.y - MyCamera.transform.position.y), (CurrentScene.transform.position.z - MyCamera.transform.position.z));

        gameManager.Rot = CurrentScene.transform.eulerAngles;
    }
}
