using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dabo : MonoBehaviour
{
    
    private Rigidbody2D rg2d;
    public float speed = 2;
  
    // Start is called before the first frame update
    void Start()
    {
        
        rg2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rg2d.velocity = transform.right * speed;
        
        Destroydistance();
    }

    void Destroydistance()
    {
        if (Mathf.Abs(transform.position.x) > 50)
        {
            Destroy(gameObject);
        }
    }

    
  
 



   




}
