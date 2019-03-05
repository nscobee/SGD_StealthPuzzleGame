using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class doorScript : MonoBehaviour
{
    public bool canOpen = false;
    public Transform teleLocation;
    public Text interactTxt;
    public GameObject interactPanel;
    public puzzleController puzzleControls;
    public Transform teleBackLocation;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(canOpen)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = teleLocation.position;
            puzzleControls.teleLocation = teleBackLocation;
        }

        else
        {
            interactPanel.gameObject.SetActive(true);
            interactTxt.text = "You can't do this yet.";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactPanel.gameObject.SetActive(false);
    }
}
