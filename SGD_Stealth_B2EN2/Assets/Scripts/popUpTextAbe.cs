using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popUpTextAbe : popUpText
{ 

    public GameObject messagePanelAbe;
    
    public Dropdown answer1;
    public Dropdown answer2;
    public Dropdown answer3;
    public Dropdown answer4;

    public int correctAnswer1;
    public int correctAnswer2;
    public int correctAnswer3;
    public int correctAnswer4;

    private bool isComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        cameraSens = cameraLook.GetComponent<cameraController>().mouseSensitivity;
        playerSens = player.GetComponent<playerMovement>().mouseSensitivity;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DeactivateText();
            }
        }

        if(correctAnswer1 == answer1.value && correctAnswer2 == answer2.value && correctAnswer3 == answer3.value && correctAnswer4 == answer4.value)
        {
            if(!isComplete)
                completePuzzle();
        }
    }

    public void ActivateText()
    {
        messagePanelAbe.SetActive(true);
        continuePanel.SetActive(true);
        cameraLook.GetComponent<cameraController>().mouseSensitivity = 0;

        playerSens = player.GetComponent<playerMovement>().mouseSensitivity;
        player.GetComponent<playerMovement>().mouseSensitivity = 0;
        player.GetComponent<playerMovement>().canMove = false;

        isOpen = true;
    }

    public void DeactivateText()
    {
        messagePanelAbe.SetActive(false);
        continuePanel.SetActive(false);
        cameraLook.GetComponent<cameraController>().mouseSensitivity = cameraSens;
        player.GetComponent<playerMovement>().mouseSensitivity = playerSens;
        player.GetComponent<playerMovement>().canMove = true;
        isOpen = false;
    }

    private void completePuzzle()
    {
        if (!isComplete)
        {
            puzzleControls.numPuzzlesCompleted++;
            isComplete = true;
        }

        DeactivateText();
        puzzleControls.puzzle1 = 105;
        
    }
}
