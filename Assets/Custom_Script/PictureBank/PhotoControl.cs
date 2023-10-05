using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.UI;

public class PhotoControl : MonoBehaviour
{
    [HeaderAttribute("Watch_Photo Collection")]
    public List<GameObject> Photo_Collection;

    [HeaderAttribute("Photo Button")]
    public List<GameObject> Photo_Button;

    public Transform Return_Trans;

    public GameObject ReturnButton;

    void Update()
    {
        foreach (GameObject i in Photo_Collection)
        {
            if (!i.activeSelf)
            {
                i.transform.position = Return_Trans.position;

                i.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

                i.transform.localScale = new Vector3(2500.0f, 2500.0f, 5000.0f);
            } 
        }
    }

    public void LockPhoto()
    {
        ReturnButton.GetComponent<Interactable>().IsEnabled = false;

        foreach (GameObject j in Photo_Button)
        {
            j.GetComponent<Interactable>().IsEnabled = false;
        }
    }

    public void UnlockPhoto()
    {
        ReturnButton.GetComponent<Interactable>().IsEnabled = true;

        foreach (GameObject j in Photo_Button)
        {
            j.GetComponent<Interactable>().IsEnabled = true;
        }
    }

    public void Reload()
    {
        foreach (GameObject i in Photo_Collection)
        {
            if (i.activeSelf)
            {
                i.transform.position = Return_Trans.position;

                i.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            }
        }
    }
}
