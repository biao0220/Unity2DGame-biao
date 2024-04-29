using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.SceneManagement;


public class Pet1 : MonoBehaviour
{
    private bool inPet1;
    private GameObject heiban3;
    private TextMeshProUGUI tmp1;
    private string petName;
    // Start is called before the first frame update
    void Start()
    {
        inPet1 = false;
        heiban3 = GameObject.FindWithTag("Heiban").transform.GetChild(3).gameObject;
        tmp1 = heiban3.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
       // r = obj.name; // ����ʹ�� obj.GetInstanceID().ToString();
                                            // Debug.Log(objectIdentifier);
                                            // ����Ψһ��ʶ����PlayerPrefs
       // PlayerPrefs.SetString(key, objectIdentifier);
       // PlayerPrefs.Save();

        if (inPet1 && Input.GetKeyDown(KeyCode.F))
        {
            PlayerPrefs.SetString("petName", petName);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Scene1");

        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")
            && other.GetType().ToString() ==
            "UnityEngine.BoxCollider2D")
        {

            inPet1 = true;
            heiban3.SetActive(true);
            tmp1.text = "��F������Я���˾������ս��";
            petName = gameObject.tag;
            //Debug.Log(petName);

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")
            && other.GetType().ToString() ==
            "UnityEngine.BoxCollider2D")
        {
            inPet1 = false;
            heiban3.SetActive(false);
            //PlayerPrefs.DeleteKey("petName");
        }
    }
}
