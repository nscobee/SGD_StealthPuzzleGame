using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleController : MonoBehaviour
{
    public int puzzle1 = 0;
    public int puzzle2 = 0;
    public int puzzle3 = 0;
    public int puzzle4 = 0;

    public GameObject blockade1;
    public GameObject blockade2;
    public GameObject blockade3;
    public GameObject blockade4;

    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;

    public GameObject playerController;
    public Transform teleLocation;

    public Camera main;
    public Camera secondary;
    private bool cameraBool = true;

    // Start is called before the first frame update
    void Start()
    {
        secondary.enabled = false;
        main.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzle1 >= 100 && puzzle1 < 200)
        {
            main.enabled = false;
            secondary.enabled = true;
            Destroy(blockade1);
            puzzle1 = 250;
            door1.GetComponent<doorScript>().canOpen = false;
            door2.GetComponent<doorScript>().canOpen = true;
            StartCoroutine(PausePlayer());

        }
        if (puzzle2 >= 100 && puzzle2 < 200)
        {
            main.enabled = false;
            secondary.enabled = true;
            Destroy(blockade2);
            puzzle2 = 250;
            door2.GetComponent<doorScript>().canOpen = false;
            door3.GetComponent<doorScript>().canOpen = true;
            StartCoroutine(PausePlayer());
        }
        if (puzzle3 >= 100 && puzzle3 < 200)
        {
            main.enabled = false;
            secondary.enabled = true;
            Destroy(blockade3);
            puzzle3 = 250;
            door3.GetComponent<doorScript>().canOpen = false;
            door4.GetComponent<doorScript>().canOpen = true;
            StartCoroutine(PausePlayer());
        }
        if (puzzle4 >= 100 && puzzle4 < 200)
        {
            main.enabled = false;
            secondary.enabled = true;
            Destroy(blockade4);
            puzzle4 = 250;
            door4.GetComponent<doorScript>().canOpen = false;
            StartCoroutine(PausePlayer());
        }

        //Testing Only
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            switchCamera();
        }

       
    }

    private void switchCamera()
    {
        if(cameraBool)
        {
            main.enabled = false;
            secondary.enabled = true;
            cameraBool = false;
        }
        else
        {
            main.enabled = true;
            secondary.enabled = false;
            cameraBool = true;
        }
    }

    public void puzzleComplete()  //probably not used but w/e
    {
        //movePlayertoStarSpace

    }

    IEnumerator PausePlayer()
    {
        playerController.GetComponent<playerMovement>().enabled = false;
        yield return new WaitForSecondsRealtime(4);
        playerController.GetComponent<playerMovement>().enabled = true;
        main.enabled = true;
        secondary.enabled = false;
        playerController.transform.position = teleLocation.position;

    }
}
