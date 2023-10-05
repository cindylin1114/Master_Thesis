using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Review_AllExam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Relocation_Review_Region_1()
    {
        GameObject Review_Region_1 = GameObject.Find("Review_Region_1");

        GameObject Checkpoint_Area_1_2 = Review_Region_1.transform.Find("Checkpoint_Area_1_2").gameObject;

        Checkpoint_Area_1_2.transform.localPosition = new Vector3(0.967f, -0.006f, 0.002f);

        Checkpoint_Area_1_2.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);


        GameObject Checkpoint_Area_1_3 = Review_Region_1.transform.Find("Checkpoint_Area_1_3").gameObject;

        Checkpoint_Area_1_3.transform.localPosition = new Vector3(0.967f, -0.006f, 0.002f);

        Checkpoint_Area_1_3.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);


        GameObject Checkpoint_Area_1_5 = Review_Region_1.transform.Find("Checkpoint_Area_1_5").gameObject;

        Checkpoint_Area_1_5.transform.localPosition = new Vector3(0.967f, -0.006f, 0.002f);

        Checkpoint_Area_1_5.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    }

    public void Relocation_Review_Region_2()
    {
        GameObject Review_Region_1 = GameObject.Find("Review_Region_2");

        GameObject Checkpoint_Area2 = Review_Region_1.transform.Find("Checkpoint_Area2").gameObject;

        Checkpoint_Area2.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);

        Checkpoint_Area2.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    }

    public void Relocation_Review_Region_3()
    {
        GameObject Review_Region_1 = GameObject.Find("Review_Region_3");

        GameObject Checkpoint_Area_1_2 = Review_Region_1.transform.Find("Checkpoint_Area_3_1").gameObject;

        Checkpoint_Area_1_2.transform.localPosition = new Vector3(0.963f, 0.001f, 0.017f);

        Checkpoint_Area_1_2.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);


        GameObject Checkpoint_Area_1_3 = Review_Region_1.transform.Find("Checkpoint_Area_3_2").gameObject;

        Checkpoint_Area_1_3.transform.localPosition = new Vector3(0.963f, 0.001f, 0.017f);

        Checkpoint_Area_1_3.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);


        GameObject Checkpoint_Area_1_5 = Review_Region_1.transform.Find("Checkpoint_Area_3_3").gameObject;

        Checkpoint_Area_1_5.transform.localPosition = new Vector3(0.963f, 0.001f, 0.017f);

        Checkpoint_Area_1_5.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    }
}
