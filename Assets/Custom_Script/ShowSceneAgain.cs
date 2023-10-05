using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSceneAgain : MonoBehaviour
{
    public GameObject handmenu;

    public GameObject target;

    public GameObject tips;

    private float timer;


    void Update()
    {
        if (tips.activeSelf)
        {
            timer += Time.deltaTime;

            if (timer >= 3.0f)
            {
                tips.SetActive(false);
            }
        }
    }

    public void ChangePosition()
    {
        target.transform.position = new Vector3 (handmenu.transform.position.x, handmenu.transform.position.y + 0.2f, handmenu.transform.position.z);

        timer = 0;
    }
}
