using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class noEntryDoor : MonoBehaviour
{
    public Text interactTxt;
    public GameObject interactPanel;
    public string message;





    private void OnTriggerEnter(Collider other)
    {

        interactPanel.gameObject.SetActive(true);
        interactTxt.text = message;
    }


    private void OnTriggerExit(Collider other)
    {
        interactPanel.gameObject.SetActive(false);
    }
}
