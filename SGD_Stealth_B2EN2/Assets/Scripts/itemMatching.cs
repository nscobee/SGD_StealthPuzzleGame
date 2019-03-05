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
        if( baseTag == other.gameObject.tag && !hasMatched)
        {
            other.gameObject.tag = "matched";
            hasMatched = true;
            if(puzzleNumber == 1 && !isItem)
                puzzleControls.puzzle1 += 15;
            if (puzzleNumber == 2 && !isItem)
                puzzleControls.puzzle2 += 15;
            if (puzzleNumber == 3 && !isItem)
                puzzleControls.puzzle3 += 15;
            if (puzzleNumber == 4 && !isItem)
                puzzleControls.puzzle4 += 15;

        }
    }
}
