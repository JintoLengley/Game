using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{

    public static int monetCount;
    private Text monetConter;
        

    void Start()
    {
        monetConter = GetComponent<Text>();
        monetCount = 0;
    }
    void Update()
    {
        monetConter.text = "X" + monetCount;
    }
}
