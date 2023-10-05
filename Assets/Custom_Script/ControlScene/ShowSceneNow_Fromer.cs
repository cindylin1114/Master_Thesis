using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers; // "SolverHandler" namespace
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro; // TextMeshPro

public class ShowSceneNow_Fromer : MonoBehaviour
{
    public GameObject handmenu;

    public GameObject target;

    public void ShowScene()
    {
        target.transform.position = new Vector3(handmenu.transform.position.x, handmenu.transform.position.y + 0.2f, handmenu.transform.position.z);
    }
}
