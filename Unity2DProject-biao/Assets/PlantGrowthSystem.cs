using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlantGrowthSystem : MonoBehaviour
{
    public GameObject plantPrefab;
    private GameObject heiban;
    private Renderer myRenderer;
    private DateTime dt1;
    private DateTime dt2;
    private TimeSpan span;

    void Start()
    {
        
        dt1 = DateTime.Now;
        dt2 = DateTime.Now.AddSeconds(10f);
        myRenderer = GetComponent<Renderer>();
        heiban = GameObject.FindWithTag("Heiban").transform.GetChild(0).gameObject;
        
       // Debug.Log(heiban);
        


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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")
            && other.GetType().ToString() ==
            "UnityEngine.BoxCollider2D")
        {
            
            heiban.SetActive(true);
            myRenderer.material.color = new Color(200 / 255f, 200 / 255f, 200 / 255f, 255 / 255f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")
            && other.GetType().ToString() ==
            "UnityEngine.BoxCollider2D")
        {
            
            heiban.SetActive(false);
            myRenderer.material.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
        }
    }

}










