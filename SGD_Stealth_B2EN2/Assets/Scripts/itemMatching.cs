using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemMatching : MonoBehaviour
{
    public string baseTag;
    public puzzleController puzzleControls;

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
            puzzleControls.puzzle3 += 15;
            
        }
    }
}
