using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popUpText : MonoBehaviour
{
    public string message;
    public Text messageTxt;
    public GameObject messagePanel;
    public GameObject continuePanel;
    public puzzleController puzzleControls;
    public GameObject cameraLook;
    public GameObject player;

    public float cameraSens;
    public float playerSens;

    public bool isCritical = false;
    private bool hasRead = false;
    public bool isOpen = false;
    public bool isWill = false;
    

    // Start is called before the first frame update
    void Start()
    {
        cameraSens = cameraLook.GetComponent<cameraController>().mouseSensitivity;
        playerSens = player.GetComponent<playerMovement>().mouseSensitivity;
    }

    // Update is called once per frame
    void Update()
    {
        if(isOpen)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(isWill)
                {
                    Application.Quit();
                }
                deactivateText();
            }
        }
    }

    public void setText()
    {

        messageTxt.text = message;
    }

    public void activateText()
    {

        setText();
        messagePanel.SetActive(true);
        continuePanel.SetActive(true);

        
        cameraLook.GetComponent<cameraController>().mouseSensitivity = 0;

        
        player.GetComponent<playerMovement>().mouseSensitivity = 0;
        player.GetComponent<playerMovement>().canMove = false;

        isOpen = true;
    }

    public void deactivateText()
    {
        messagePanel.SetActive(false);
        continuePanel.SetActive(false);
        cameraLook.GetComponent<cameraController>().mouseSensitivity = cameraSens;
        player.GetComponent<playerMovement>().mouseSensitivity = playerSens;
        player.GetComponent<playerMovement>().canMove = true;
        if (isCritical)
        {
            if(!hasRead)
            {
                puzzleControls.puzzle1 += 20;
                hasRead = true;
            }            
        }
        isOpen = false;
    }
}
