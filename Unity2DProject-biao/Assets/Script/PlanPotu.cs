using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanPotu : MonoBehaviour
{
    public GameObject plantPrefab;
    //


    private DateTime dt1;
    private DateTime dt2;
    
    private TimeSpan span;

    void Start()
    {

        dt1 = DateTime.Now;
        dt2 = DateTime.Now.AddSeconds(10f);
        

    }

    void Update()
    {

        dt1 = DateTime.Now;
        span = dt1.Subtract(dt2);

        if (span.TotalSeconds >= 0f)
        {
            GrowPlant();
        }
    }
    void GrowPlant()
    {


        Instantiate(plantPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
