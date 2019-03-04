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

    public GameObject playerController;

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
            switchCamera();
            Destroy(blockade1);
            puzzle1 = 250;
            StartCoroutine(PausePlayer());

        }
        if (puzzle2 >= 100 && puzzle2 < 200)
        {
            switchCamera();
            Destroy(blockade2);
            puzzle2 = 250;
            StartCoroutine(PausePlayer());
        }
        if (puzzle3 >= 100 && puzzle3 < 200)
        {
            switchCamera();
            Destroy(blockade3);
            puzzle3 = 250;
            StartCoroutine(PausePlayer());
        }
        if (puzzle4 >= 100 && puzzle4 < 200)
        {
            switchCamera();
            Destroy(blockade4);
            puzzle4 = 250;
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

    IEnumerator PausePlayer()
    {
        playerController.GetComponent<playerMovement>().enabled = false;
        yield return new WaitForSecondsRealtime(4);
        playerController.GetComponent<playerMovement>().enabled = true;
        switchCamera();

    }
}
