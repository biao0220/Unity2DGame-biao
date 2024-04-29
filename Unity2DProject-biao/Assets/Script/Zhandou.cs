using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Zhandou : MonoBehaviour
{   
    private int qi;
    public TextMeshProUGUI qiText;
    public Image qiImage;
    public GameObject enemy;
    public Transform enemyPos;
    private bool isAttack;
    // Start is called before the first frame update
    void Start()
    {
        qi = 0;
    }

    // Update is called once per frame
    void Update()
    {
        qiImage.fillAmount = (float)qi / 3;
        qiText.text = qi.ToString() + "/3";

        if(isAttack)
        {
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemyPos.position, 2 * Time.deltaTime);
           // Invoke("isAttackflase", 3);

            if(enemy.transform.position.y< -20f)
            {
                Destroy(enemy);
                isAttack = false;
            }
        }
    }

   
    public void  Jiqi()
    {
        if(qi>=0 && qi<=2)
        {
            qi++;
        }
        
    }

    public void Fangbo()
    {
        if(qi>=1)
        {
            isAttack = true;
        }
        
       // enemy.transform.position = enemyPos.position;
       


    }
}
