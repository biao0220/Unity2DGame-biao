using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tudi2 : MonoBehaviour
{

    public TextMeshProUGUI tmp1;
    private DateTime dt3;

    private Renderer myRenderer;
    private bool inTudi;
    private Animator myAnim;
    private DateTime dt1;
    private DateTime dtpotu;
    private DateTime dtfaya;
    private DateTime dtzhangye;
    private DateTime dtkaihua;
    private DateTime dtjieguo;
    private int type;
    private TimeSpan span;
    private TimeSpan spandistance;
    private BoxCollider2D box;
    //public GameObject plan;
    // public GameObject timeDist
    public GameObject heiban;



    public Animator playerAnim;
    private GameObject Pet1;
    public float time;
    private bool Pet1mount;
    private string pet;
    private GameObject Petds;
    // Start is called before the first frame update
    void Start()
    {
        Pet1mount = true;
       
        type = 0;
        myRenderer = GetComponent<Renderer>();
        myAnim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        dt3 = LoadDateTime("tu12");
        dtpotu = LoadDateTime("dtpotu2");
        dtfaya = LoadDateTime("dtfaya2");
        dtzhangye = LoadDateTime("dtzhangye2");
        dtkaihua = LoadDateTime("dtkaihua2");
        dtjieguo = LoadDateTime("dtjieguo2");

        type = PlayerPrefs.GetInt("type2");

        dt1 = DateTime.Now;

        Pet1 = LoadGameObject("Pet2");
        if (Pet1 != null)
        {
            Pet1mount = false;
        Petds= Instantiate(Pet1, new Vector2(transform.position.x, 3.5f), Quaternion.identity);
        }


        if (type == 6)
        {
            myAnim.SetBool("Bozhong", true);
            myAnim.SetBool("Potu", true);
            myAnim.SetBool("Faya", true);
            myAnim.SetBool("Zhangye", true);
            myAnim.SetBool("Kaihua", true);
            myAnim.SetBool("Jieguo", true);

        }

        if (dt1 > dt3 && type > 0)
        {
            type = 1;
        }


        if (dt1 < dt3)
        {

            type = 1;

        }



    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && inTudi)
        {
            PlayerPrefs.DeleteKey("Pet1");
            Debug.Log("已删除");
            Destroy(Petds);
            Pet1mount = true;

        }
        PlayerPrefs.SetInt("type2", type);

        
        Potu();
        Faya();
        Zhangye();
        Kaihua();
        Jieguo();

        if (type == 0)
        {
            if (inTudi)
            {

                tmp1.text = "按F键可以播种";
            }
            if (Input.GetKeyDown(KeyCode.F) && inTudi)
            {




                dt3 = DateTime.Now.AddSeconds(15f);
                SaveDateTime("tu12", dt3);

                dtpotu = dt3.AddSeconds(-12f);

                dtfaya = dt3.AddSeconds(-9);
                dtzhangye = dt3.AddSeconds(-6f);
                dtkaihua = dt3.AddSeconds(-3f);
                dtjieguo = dt3;
                SaveDateTime("dtpotu2", dtpotu);
                SaveDateTime("dtfaya2", dtfaya);
                SaveDateTime("dtzhangye2", dtzhangye);
                SaveDateTime("dtkaihua2", dtkaihua);
                SaveDateTime("dtjieguo2", dtjieguo);






                myAnim.SetBool("Bozhong", true);
                type = 1;
            }

        }

        if (type >= 1 && type < 6)
        {
            DateTime dt11 = DateTime.Now;
            spandistance = dt11.Subtract(dt3);
            if (inTudi)
            {
                tmp1.text = "离成熟还有\n" + (-1.0 * spandistance.Seconds).ToString() + "秒";
            }

        }

        if (type >= 6)
        {
            if (inTudi)
            {
                tmp1.text = "成熟了！\n按F键进行采摘";
            }

        }


        if (type == 6)
        {

            if (Input.GetKeyDown(KeyCode.F) && inTudi)
            {

                myAnim.SetBool("Bozhong", false);
                myAnim.SetBool("Potu", false);
                myAnim.SetBool("Faya", false);
                myAnim.SetBool("Zhangye", false);
                myAnim.SetBool("Kaihua", false);
                myAnim.SetBool("Jieguo", false);
                myAnim.SetBool("Idle", true);

                type = 0;

                playerAnim.SetTrigger("Get1");
                Invoke("CreatePet", time);
                // box.enabled = false;
                // box.enabled = true;

            }


        }

    }



    public void CreatePet()
    {
        int i = UnityEngine.Random.Range(1, 4);

        if (i == 1)
        {
            pet = "Pet1";
        }
        if (i == 2)
        {
            pet = "Pet2";
        }
        if (i == 3)
        {
            pet = "Pet3";
        }
        if (i == 4)
        {
            pet = "Pet3";
        }

        if (Pet1mount)
        {
            Pet1mount = false;
            Pet1 = Resources.Load<GameObject>(pet);
            SaveGameObject(Pet1, "Pet2");
            Petds = Instantiate(Pet1, new Vector2(transform.position.x, 3.5f), Quaternion.identity);
        }
        else
        {


            PlayerPrefs.DeleteKey("Pet2");
            Destroy(Petds);

            Pet1 = Resources.Load<GameObject>(pet);
            SaveGameObject(Pet1, "Pet2");
            Petds = Instantiate(Pet1, new Vector2(transform.position.x, 3.5f), Quaternion.identity);


        }

    }



    // 保存GameObject
    public void SaveGameObject(GameObject obj, string key)
    {
        // 获取GameObject的唯一标识符，例如名称或实例ID
        string objectIdentifier = obj.name; // 或者使用 obj.GetInstanceID().ToString();
                                            // Debug.Log(objectIdentifier);
                                            // 保存唯一标识符到PlayerPrefs
        PlayerPrefs.SetString(key, objectIdentifier);
        PlayerPrefs.Save();
    }

    // 加载GameObject
    public GameObject LoadGameObject(string key)
    {
        // 从PlayerPrefs获取唯一标识符
        string objectIdentifier = PlayerPrefs.GetString(key);

        // 使用唯一标识符查找GameObject
        // GameObject loadedObject = GameObject.Find(objectIdentifier);
        GameObject loadedObject = Resources.Load<GameObject>(objectIdentifier);


        return loadedObject;
    }

    // 保存DateTime数据
    void SaveDateTime(string key, DateTime date)
    {
        string dateString = date.ToString("O"); // 将DateTime转换为字符串
        PlayerPrefs.SetString(key, dateString);
        PlayerPrefs.Save();
    }

    // 读取DateTime数据
    DateTime LoadDateTime(string key)
    {
        string dateString = PlayerPrefs.GetString(key);
        DateTime date = DateTime.Parse(dateString); // 将字符串转换为DateTime
        return date;
    }

    void Potu()
    {
        //
        if (type == 1)
        {
            myAnim.SetBool("Bozhong", true);
            myAnim.SetBool("Idle", false);

            dt1 = DateTime.Now;
            span = dt1.Subtract(dtpotu);


            if (span.TotalSeconds >= 0f)
            {
                //myAnim.SetBool("Bozhong", false);
                myAnim.SetBool("Potu", true);
                type = 2;

            }



        }
    }
    void Faya()
    {
        if (type == 2)
        {
            dt1 = DateTime.Now;
            span = dt1.Subtract(dtfaya);

            if (span.TotalSeconds >= 0f)
            {
                //myAnim.SetBool("Potu", false);
                myAnim.SetBool("Faya", true);
                type = 3;

            }


        }
    }

    void Zhangye()
    {
        if (type == 3)
        {
            dt1 = DateTime.Now;
            span = dt1.Subtract(dtzhangye);

            if (span.TotalSeconds >= 0f)
            {
                //yAnim.SetBool("Faya", false);
                myAnim.SetBool("Zhangye", true);
                type = 4;

            }


        }
    }

    void Kaihua()
    {
        if (type == 4)
        {
            dt1 = DateTime.Now;
            span = dt1.Subtract(dtkaihua);

            if (span.TotalSeconds >= 0f)
            {
                //yAnim.SetBool("Zhangye", false);
                myAnim.SetBool("Kaihua", true);
                type = 5;

            }


        }
    }

    void Jieguo()
    {


        if (type == 5)
        {

            dt1 = DateTime.Now;
            span = dt1.Subtract(dtjieguo);

            if (span.TotalSeconds >= 0f)
            {
                //yAnim.SetBool("Kaihua", false);
                myAnim.SetBool("Jieguo", true);
                type = 6;



            }


        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")
            && other.GetType().ToString() ==
            "UnityEngine.BoxCollider2D")
        {
            inTudi = true;
            myRenderer.material.color = new Color(200 / 255f, 200 / 255f, 200 / 255f, 255 / 255f);
            heiban.SetActive(true);


        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")
            && other.GetType().ToString() ==
            "UnityEngine.BoxCollider2D")
        {
            inTudi = false;

            heiban.SetActive(false);
            myRenderer.material.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
        }
    }



}
