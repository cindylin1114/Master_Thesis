using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AutoClose : MonoBehaviour
{
    public Transform hololensCamera;
    
    public GameObject tips;

    public float closeDistance;

    void Update()
    {
        if (Vector3.Distance(hololensCamera.position, this.transform.position) >= closeDistance)
        {
            this.gameObject.SetActive(false);

            tips.SetActive(true);
        }
    }
}
