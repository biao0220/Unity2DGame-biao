using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class ZhandouPet : MonoBehaviour
{
    private string petName;
    private GameObject pet;
    private GameObject petCreate;
    private GameObject dun;

    private int qi;
    public TextMeshProUGUI qiText;
    public Image qiImage;
    public GameObject enemy;
    private bool isAttack;
    public float distance;

    private GameObject smallBo;
    private string smallboName;
    public GameObject Dunpai;
    public float Bodistance;

    //button вўВи
    public static bool isPlayerTurn;

    public GameObject zhanqiButton;
    public GameObject fangboButton;
    public GameObject fangyuButton;
    public GameObject WinText;
    public float buttonTime;

    private GameObject bigBo;
    private string bigBoName;
    bool canButton = true;




    // Start is called before the first frame update
    void Start()
    {
        isPlayerTurn = true;
        petName = PlayerPrefs.GetString("petName");
        pet = Resources.Load<GameObject>(petName);
        petCreate = Instantiate(pet, transform.position, Quaternion.identity);
        

        qi = 0;

        BoChoice();
        smallBo = Resources.Load<GameObject>(smallboName);
        bigBo = Resources.Load<GameObject>(bigBoName);

    }

    // Update is called once per frame
    void Update()
    {
        PetDeath();
        Zhandou();
        ChoiceButton(isPlayerTurn);
        //Debug.Log(isPlayerTurn);
        if(Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(bigBo, new Vector2(transform.position.x -2 + Bodistance, transform.position.y +1), Quaternion.identity);
        }
    }

    void PetDeath()
    {
        
        if (petCreate.transform.position.y < -20f )
        {
            
           
            WinText.SetActive(true);
            Invoke("Back", 1.5f);
        }
    }

    void Back()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void ChoiceButton(bool isplayerturn)
    {
        
        zhanqiButton.SetActive(isplayerturn);
        fangboButton.SetActive(isplayerturn);
        fangyuButton.SetActive(isplayerturn);

        if( qi == 0)
        {
            fangboButton.SetActive(false);
        }
        if (qi == 3)
        {
            zhanqiButton.SetActive(false);
        }

        if (isplayerturn == false && canButton)
        {
            canButton = false;
            Invoke("OpenButton", buttonTime);
        }

    }

    void OpenButton()
    {
        isPlayerTurn = true;
        canButton = true;
    }
    
    void BoChoice()
    {
        if(petName =="xiaoya")
        {
            smallboName = "Shuixiao";
            bigBoName = "ShuiDa";
        }
        if (petName == "xiaoshe")
        {
            smallboName = "Huoxiao";
            bigBoName = "HuoDa";
        }
        if (petName == "xiaocao")
        {
            smallboName = "Caoxiao";
            bigBoName = "CaoDa";
        }
    }

    public void Zhandou()
    {
        qiImage.fillAmount = (float)qi / 3;
        qiText.text = qi.ToString() + "/3";

        if (isAttack)
        {
            isAttack = false;
            if(qi!=3)
            {
                Instantiate(smallBo, new Vector2(transform.position.x + Bodistance, transform.position.y), Quaternion.identity);
            }
            else
            {
                Instantiate(bigBo, new Vector2(transform.position.x + Bodistance, transform.position.y), Quaternion.identity);
            }
            
            qi = 0;
          
        }
    }

    public void Jiqi()
    {
        if (qi >= 0 && qi <= 2)
        {
            qi++;
            isPlayerTurn = false;
            ZhandouEnemy.isEnemyTurn = true;
        }



    }

    public void Fangbo()
    {
        if (qi >= 1)
        {
            isAttack = true;
            isPlayerTurn = false;
            ZhandouEnemy.isEnemyTurn = true;


        }

        // enemy.transform.position = enemyPos.position;



    }

    public void Fangyu()
    {
        isPlayerTurn = false;
        ZhandouEnemy.isEnemyTurn = true;
        dun =Instantiate(Dunpai, new Vector2(transform.position.x + Bodistance, transform.position.y), Quaternion.identity);
        Invoke("DestroyFangyu", 3);
    }

    void DestroyFangyu()
    {
        Destroy(dun);
    }

}
