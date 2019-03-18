using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemMatching : MonoBehaviour
{
    public string baseTag;
    public puzzleController puzzleControls;
    public int puzzleNumber;

    public bool isItem;
    public bool hasMatched = false;

    public Material correctItem;
    public Material wrongItem;
    
    // Start is called before the first frame update
    void Start()
    {
        baseTag = this.gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if( (baseTag == other.gameObject.tag) && !hasMatched)
        {
            
            hasMatched = true;
            other.gameObject.GetComponent<itemMatching>().hasMatched = true;
            
            if(puzzleNumber == 1 && !isItem)
                puzzleControls.puzzle1 += 15;

            if (puzzleNumber == 2 && !isItem)
            {
                puzzleControls.puzzle2 += 17;
                if (puzzleControls.puzzle2 >= 100) puzzleControls.numPuzzlesCompleted++;
                this.gameObject.GetComponent<Renderer>().material = correctItem;
            }
            if (puzzleNumber == 3 && !isItem)
            {
                puzzleControls.puzzle3 += 15;
                if (puzzleControls.puzzle3 >= 100) puzzleControls.numPuzzlesCompleted++;
                this.gameObject.GetComponent<Renderer>().material = correctItem;
            }

            if (puzzleNumber == 4 && hasMatched)
            {
                print("Done!");
                puzzleControls.puzzle4 = 105;
                puzzleControls.numPuzzlesCompleted++;
                GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().ForceDropItem();
            }


        }
        else
        {
            if (puzzleNumber == 3 && !isItem && other.gameObject.GetComponent<itemMatching>() && !hasMatched && other.gameObject.tag != "range") this.gameObject.GetComponent<Renderer>().material = wrongItem;
            if (puzzleNumber == 2 && !isItem && other.gameObject.GetComponent<itemMatching>() && !hasMatched && other.gameObject.tag != "range") this.gameObject.GetComponent<Renderer>().material = wrongItem;

        }
    }
}
