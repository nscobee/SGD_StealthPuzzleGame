using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureReader : MonoBehaviour
{
    public string words;
    public GameObject descPanel;
    public Text descTxt;
    bool reading = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (reading == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1;
                descTxt.text = "";
                descPanel.SetActive(false);
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                descTxt.text = words;
                descPanel.SetActive(true);
                reading = true;
                Time.timeScale = 0;
            }

        }


    }

    //public void OnTriggerExit(Collider other)
    //{

    //    if (other.CompareTag("Player"))
    //    {
    //        descTxt.text = "";
    //        descPanel.SetActive(false);
    //    }


    //}
}
