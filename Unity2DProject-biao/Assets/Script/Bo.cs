using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bo : MonoBehaviour
{
    private GameObject enemy;
    private Rigidbody2D rg2d;
    public float speed = 10;
    public float distance = 4;
    private Animator myAnim;
    public float time = 0.5f;
    public float dunpaiTime = 0.5f;

    


    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy");
        rg2d = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("BianBig", time);
        rg2d.velocity = transform.right * speed;
        //EnemyDeath();
        Destroydistance();

    }

    void Destroydistance()
    {
        if(Mathf.Abs(transform.position.x ) > 50)
        {
            Destroy(gameObject);
        }
    }

    void BianBig()
    {
        myAnim.SetTrigger("Run");
    }
    
    void DestroyDunpai(GameObject dunpai)
    {
        Destroy(dunpai);
    }
    


void OnTriggerEnter2D(Collider2D other)
    {
        
        

        if (other.gameObject.CompareTag("Bo"))
        {
            
            Destroy(other.gameObject);


        }

    }

   



}
