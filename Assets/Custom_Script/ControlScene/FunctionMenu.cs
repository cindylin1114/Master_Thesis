using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionMenu : MonoBehaviour
{
    public Transform hololensCamera;

    public GameObject SceneContent;

    public GameObject Functionmenu;
    
    public int closeDistance;

    private float later_timer;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        Debug.Log(later_timer);

        if (gameManager.AutoClose)
        {
            later_timer += Time.deltaTime;

            if (later_timer >= 5.0f)
            {
                if (Vector3.Distance(hololensCamera.position, SceneContent.transform.position) >= closeDistance)
                {
                    SceneContent.SetActive(false);

                    gameManager.AutoClose = false;
                }
            }
        } else
        {
            later_timer = 0;
        } 
    }

    public void ChangePosition()
    {
        gameManager.AutoClose = true;

        SceneContent.SetActive(true);

        SceneContent.transform.position = new Vector3(Functionmenu.transform.position.x - 0.8f, hololensCamera.position.y, hololensCamera.position.z + 0.8f);

        SceneContent.transform.localEulerAngles = new Vector3(0.0f, hololensCamera.localEulerAngles.y, 0.0f);
    }
}
