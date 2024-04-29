using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xiaobo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        


        if (other.gameObject.CompareTag("Bo"))
        {
            
            Destroy(gameObject.transform.parent.gameObject);


        }

        if (other.gameObject.CompareTag("BigBo"))
           
        {

            Destroy(gameObject.transform.parent.gameObject);


        }

    }
}
