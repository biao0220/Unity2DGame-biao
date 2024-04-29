using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class NowTime : MonoBehaviour
{
    //private DateTime dt3;

    public TextMeshProUGUI tmp;
    private DateTime dateTime;
    private string strNowTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dateTime = DateTime.Now;
        strNowTime = string.Format("{0:D4}" + "Äê" + "{1:D2}" + "ÔÂ" + "{2:D2}" + "ÈÕ"+"\n"
                     + "   " + "{3:D2}" + ":" + "{4:D2}" + ":" + "{5:D2}",
                     dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute,
                     dateTime.Second);
        tmp.text = strNowTime;
    }
}






