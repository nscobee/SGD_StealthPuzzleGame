using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puzzleController : MonoBehaviour
{
    public int puzzle1 = 0;
    public int puzzle2 = 0;
    public int puzzle3 = 0;
    public int puzzle4 = 0;

    public int numPuzzlesCompleted = 0;

    public GameObject blockade1;
    public GameObject blockade2;
    public GameObject blockade3;
    public GameObject blockade4;

    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;

    public Text interactTxt;
    public GameObject interactPnl;

    public GameObject playerController;
    public Transform teleLocation;
    private bool keyDown = false;

    public Camera main;
    public Camera secondary;
    public bool onMainCamera = true;

    // Start is called before the first frame update
    void Start()
    {
        secondary.enabled = false;
        main.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!onMainCamera && Input.anyKeyDown)
        {
            onMainCamera = true;
            print(onMainCamera + " inside method");
            print("changeee");
            interactPnl.SetActive(false);
            playerController.GetComponent<playerMovement>().enabled = true;
            main.enabled = true;
            secondary.enabled = false;
            
        }

      
        if (puzzle1 >= 100 && puzzle1 < 200)
        {
            print("puzzle calling");
            onMainCamera = false;
            keyDown = false;
            if (numPuzzlesCompleted == 1) cameraCutscene(blockade1);
            if (numPuzzlesCompleted == 2) cameraCutscene(blockade2);
            if (numPuzzlesCompleted == 3) cameraCutscene(blockade3);
            if (numPuzzlesCompleted == 4) cameraCutscene(blockade4);
            puzzle1 = 250;
            door1.GetComponent<doorScript>().canOpen = false;

        }
        if (puzzle2 >= 100 && puzzle2 < 200)
        {
            onMainCamera = false;
            keyDown = false;
            if (numPuzzlesCompleted == 1) cameraCutscene(blockade1);
            if (numPuzzlesCompleted == 2) cameraCutscene(blockade2);
            if (numPuzzlesCompleted == 3) cameraCutscene(blockade3);
            if (numPuzzlesCompleted == 4) cameraCutscene(blockade4);
            puzzle2 = 250;
            door2.GetComponent<doorScript>().canOpen = false;

        }
        if (puzzle3 >= 100 && puzzle3 < 200)
        {
            onMainCamera = false;
            keyDown = false;
            if (numPuzzlesCompleted == 1) cameraCutscene(blockade1);
            if (numPuzzlesCompleted == 2) cameraCutscene(blockade2);
            if (numPuzzlesCompleted == 3) cameraCutscene(blockade3);
            if (numPuzzlesCompleted == 4) cameraCutscene(blockade4);
            puzzle3 = 250;
            door3.GetComponent<doorScript>().canOpen = false;

        }
        if (puzzle4 >= 100 && puzzle4 < 200)
        {
            onMainCamera = false;
            keyDown = false;
            if (numPuzzlesCompleted == 1) cameraCutscene(blockade1);
            if (numPuzzlesCompleted == 2) cameraCutscene(blockade2);
            if (numPuzzlesCompleted == 3) cameraCutscene(blockade3);
            if (numPuzzlesCompleted == 4) cameraCutscene(blockade4);
            puzzle4 = 250;
            door4.GetComponent<doorScript>().canOpen = false;

        }


       
    }

    private void cameraCutscene(GameObject blockade)
    {
        if (!keyDown)
        {
            print("I am being run");
            Destroy(blockade);
            interactPnl.SetActive(true);
            interactTxt.text = "Press any Key to Continue..";
            playerController.GetComponent<playerMovement>().enabled = false;
            main.enabled = false;
            secondary.enabled = true;
            keyDown = true;
        }

    }

   




 }
