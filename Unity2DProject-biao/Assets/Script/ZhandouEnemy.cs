using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using UnityEngine.SceneManagement;

public class ZhandouEnemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject Dunpai;
    public GameObject smallBo;
    public Image qiImage;
    public TextMeshProUGUI qiText;
    public float Bodistance;
    private int qi;
    public static bool isEnemyTurn;
    private GameObject dun;
    public GameObject bigBo;
    public GameObject LosText;
    // Start is called before the first frame update
    void Start()
    {
        qi = 0;
        isEnemyTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        XianText();
        AI();
        EnemyDeath();
        //Test();

    }

    void EnemyDeath()
    {
       
        if ( gameObject.transform.position.y < -20f )
        {
            
            //Destroy(gameObject);
            LosText.SetActive(true);
            Invoke("Back", 1.5f);

        }
    }

    void Back()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void Test()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {


            Zhanqi();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {


            Fangbo();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {


            Fangyu();
        }
    }

        void AI()
    {
        //Debug.Log((!ZhandouPet.isPlayerTurn) && (isEnemyTurn));
        if((!ZhandouPet.isPlayerTurn) && (isEnemyTurn) )
        {
            isEnemyTurn = false;
           
         //  if(qi >=1 && qi <=2)
           // {
                int i = UnityEngine.Random.Range(1, 4);
                if(qi ==3)
                {
                Fangbo();
                i = 0;

                }
            if (qi == 0)
            {
                Zhanqi();
                i = 0;

            }
            if (i == 1)
                {
                    if(qi!=3)
                    {
                    Zhanqi();
                     }
                    else
                     {
                    Fangbo();
                         }
                   
                }
                if (i == 2)
                {
                    if(qi!=0)
                {
                    Fangbo();
                }
                  else
                {
                    Zhanqi();
                }
                }
                if (i == 3)
                {
                    Fangyu();
                }
                if (i == 4)
                {
                    Zhanqi();
                }

      


        }
    }

    void Zhanqi()
    {
        if (qi >= 0 && qi <= 2)
        {
            qi++;
        }
    }

    void Fangbo()
    {
       
        if(qi>0)
        {
            
            if(qi==1 || qi==2)
            {
                Instantiate(smallBo, new Vector2(transform.position.x - Bodistance, transform.position.y), Quaternion.Euler(0, 180, 0));
            }
            if(qi==3)
            {
                Instantiate(bigBo, new Vector2(transform.position.x - Bodistance, transform.position.y), Quaternion.Euler(0, 180, 0));
            }
            qi = 0;

        }
        
    }    

    void DestroyFangyu()
    {
        Destroy(dun);
    }
    void Fangyu()
    {

        dun = Instantiate(Dunpai, new Vector2(transform.position.x - Bodistance, transform.position.y), Quaternion.Euler(0, 180, 0));
        Invoke("DestroyFangyu", 3);
    }

    void XianText()
    {
        qiImage.fillAmount = (float)qi / 3;
        qiText.text = qi.ToString() + "/3";
    }

    
}
