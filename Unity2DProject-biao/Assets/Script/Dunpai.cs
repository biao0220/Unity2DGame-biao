using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dunpai : MonoBehaviour
{
    private Animator myAnim;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyDun()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Bo"))
        {
            myAnim.SetTrigger("Attack");
            Destroy(other.gameObject.transform.parent.gameObject);
            
        }

        if (other.gameObject.CompareTag("BigBo"))
        {
            myAnim.SetTrigger("Destroy");
            Invoke("DestroyDun", 1);
            

        }

    }
    }
