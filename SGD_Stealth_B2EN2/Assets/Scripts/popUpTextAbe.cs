using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popUpTextAbe : MonoBehaviour
{ 

    public GameObject messagePanelAbe;
    public puzzleController puzzleControls;
    public GameObject cameraLook;
    public GameObject player;

    private float cameraSens;
    private float playerSens;

    public Dropdown answer1;
    public Dropdown answer2;
    public Dropdown answer3;
    public Dropdown answer4;

    public int correctAnswer1;
    public int correctAnswer2;
    public int correctAnswer3;
    public int correctAnswer4;

    private bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                deactivateText();
            }
        }

        if(correctAnswer1 == answer1.value && correctAnswer2 == answer2.value && correctAnswer3 == answer3.value && correctAnswer4 == answer4.value)
        {
            completePuzzle();
        }
    }

    public void activateText()
    {
        messagePanelAbe.SetActive(true);
        cameraSens = cameraLook.GetComponent<cameraController>().mouseSensitivity;
        cameraLook.GetComponent<cameraController>().mouseSensitivity = 0;

        playerSens = player.GetComponent<playerMovement>().mouseSensitivity;
        player.GetComponent<playerMovement>().mouseSensitivity = 0;
        player.GetComponent<playerMovement>().canMove = false;

        isOpen = true;
    }

    public void deactivateText()
    {
        messagePanelAbe.SetActive(false);
        cameraLook.GetComponent<cameraController>().mouseSensitivity = cameraSens;
        player.GetComponent<playerMovement>().mouseSensitivity = playerSens;
        player.GetComponent<playerMovement>().canMove = true;
        isOpen = false;
    }

    private void completePuzzle()
    {
        deactivateText();
        puzzleControls.puzzle1 = 100;
    }
}
