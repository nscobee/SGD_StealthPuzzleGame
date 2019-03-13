using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePicker : MonoBehaviour
{

    public bool isPicker;
    public bool isNotPiece;
    public bool isThePiece;

    void Start()
    {

    }


    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (isPicker == true)
        {
            if (other.gameObject.GetComponent<PiecePicker>().isThePiece == true)
            {
                Debug.Log("Good Job");
            }
            else if (other.gameObject.GetComponent<PiecePicker>().isNotPiece == true)
            {
                Debug.Log("Pathetic");
            }
        }


    }

}
