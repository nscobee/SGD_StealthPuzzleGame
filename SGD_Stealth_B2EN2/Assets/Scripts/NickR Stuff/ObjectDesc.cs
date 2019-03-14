using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDesc : MonoBehaviour
{
    public string words;
    public GameObject panel_Interact;
    public Text infoWindowTxt;
    public GameObject playerController;

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(playerController.GetComponent<playerMovement>().isHolding)
        {
            panel_Interact.SetActive(false);
        }
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
