using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    private Rigidbody2D myRigidbody;
    private Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();



    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Hou();
        Filp();

    }


    void Hou()
    {
        float moveDir = Input.GetAxis("Vertical");
        Vector2 playerVel = new Vector2(myRigidbody.velocity.x, moveDir * runSpeed);
        myRigidbody.velocity = playerVel;

        bool playerHasYAxisSpeedUp = myRigidbody.velocity.y > 0.1f;
        myAnim.SetBool("Hou", playerHasYAxisSpeedUp);

        bool playerHasYAxisSpeedDown = myRigidbody.velocity.y < -0.1f;
        myAnim.SetBool("Qian", playerHasYAxisSpeedDown);

    }
    void Run()
    {
        float moveDir = Input.GetAxis("Horizontal");
        Vector2 playerVel = new Vector2(moveDir * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVel;

        bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnim.SetBool("Run", playerHasXAxisSpeed);
    }

    void Filp()
    {
        bool plyerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (plyerHasXAxisSpeed)
        {
            if (myRigidbody.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }

            if (myRigidbody.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }


        }
    }
}
