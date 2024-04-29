using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class TimeDistance : MonoBehaviour
{
    private TextMeshProUGUI tmp1;
    public static DateTime dt3;
    private DateTime dt1;
    //private DateTime dt2;
    private TimeSpan span;
    // Start is called before the first frame update
    void Start()
    {
        tmp1 = GameObject.FindWithTag("Heiban").transform.GetChild(0).GetChild(0).gameObject.
            GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

        dt1 = DateTime.Now;
        span = dt1.Subtract(dt3);
        //Debug.Log(span.Seconds);
        
        

        
        if(span.Seconds <= 0f)
        {
            tmp1.text = "离成熟还有\n" + (-1.0 * span.Seconds).ToString() + "秒";
        }
        else
        {
            tmp1.text = "成熟了！\n可以采摘了！";
            Debug.Log(span.Seconds);
        }
        


    }
}
