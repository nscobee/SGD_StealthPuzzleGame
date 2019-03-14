using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDesc : MonoBehaviour
{
    public string words;
    public GameObject panel_Interact;
    public Text infoWindowTxt;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            infoWindowTxt.text = words;
            panel_Interact.SetActive(true);
        }


    }

    public void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            infoWindowTxt.text = "";
            panel_Interact.SetActive(false);
        }


    }
}
