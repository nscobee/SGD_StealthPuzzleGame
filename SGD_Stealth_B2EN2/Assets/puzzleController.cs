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
        if (puzzle1 >= 100)
            Destroy(blockade1);
        if (puzzle2 >= 100)
            Destroy(blockade2);
        if (puzzle3 >= 100)
            Destroy(blockade3);
        if (puzzle4 >= 100)
            Destroy(blockade4);

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
}
