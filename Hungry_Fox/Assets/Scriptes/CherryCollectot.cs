using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CherryCollectot : MonoBehaviour
{
    public static int cherryCount;
    public Text cherryCounter;
    void Start()
    {
        cherryCounter = GetComponent<Text>();
        cherryCount = 3;
    }

    void Update()
    {
        cherryCounter.text = "X" + cherryCount;
    }

    public static void CherrySteal(int quantity)
    {
        cherryCount = cherryCount - quantity;
    }
}
