using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Transform HololensCamera;

    public GameObject target;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Next_MapTour_1()
    {
        SceneManager.LoadScene("MapTour_1");

        if (gameManager.chooseregion_1)
        {
            Debug.Log("Start Region_1 MapTour");
        }
    }

    public void Next_MapTour_2()
    {
        SceneManager.LoadScene("MapTour_2");

        if (gameManager.chooseregion_2)
        {
            Debug.Log("Start Region_2 MapTour");
        }
    }

    public void Next_MapTour_3()
    {
        SceneManager.LoadScene("MapTour_3");

        if (gameManager.chooseregion_3)
        {
            Debug.Log("Start Region_3 MapTour");
        }
    }

    public void Next_VirtualTour_1()
    {
        SceneManager.LoadScene("VirtualTour_1");

        if (gameManager.chooseregion_1)
        {
            Debug.Log("Start Region_1 VirtualTour");
        }
    }

    public void Next_VirtualTour_2()
    {
        SceneManager.LoadScene("VirtualTour_2");

        if (gameManager.chooseregion_2)
        {
            Debug.Log("Start Region_2 VirtualTour");
        }
    }

    public void Next_VirtualTour_3()
    {
        SceneManager.LoadScene("VirtualTour_3");

        if (gameManager.chooseregion_3)
        {
            Debug.Log("Start Region_3 VirtualTour");
        }
    }

    public void Next_Regional_Hints_1()
    {
        SceneManager.LoadScene("Regional_Hints_1");

        Debug.Log("Start Region_1 Regional_Hints");
    }

    public void Next_Regional_Hints_2()
    {
        SceneManager.LoadScene("Regional_Hints_2");

        Debug.Log("Start Region_2 Regional_Hints");
    }

    public void Next_Regional_Hints_3()
    {
        SceneManager.LoadScene("Regional_Hints_3");

        Debug.Log("Start Region_3 Regional_Hints");
    }

    public void Next_FinalReview()
    {
        SceneManager.LoadScene("FinalReview");

        Debug.Log("Enter FinalReview");
    }

    public void ChooseRegion()
    {
        target.transform.position = new Vector3(HololensCamera.position.x, HololensCamera.position.y + 0.2f, HololensCamera.position.z);

        if (!gameManager.Complete_Region_3)
        {
            SceneManager.LoadScene("ChooseRegion");

            Debug.Log("Enter ChooseRegion");
        }
        else
        {
            SceneManager.LoadScene("FinalReview");

            Debug.Log("Enter FinalReview");
        }
    }

    public void Enter_Photo()
    {
        SceneManager.LoadScene("PhotoCollection");

        Debug.Log("Enter Photo Area");
    }

    public void CloseApp()
    {
        Application.Quit();

        Debug.Log("Exit app");
    }
}