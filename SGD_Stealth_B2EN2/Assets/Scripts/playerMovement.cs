using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public bool isRunning;
    public float speed;
    public float BASESPEED;
    public float runMultiplier;
    public float MAXSPEED;
    public bool canMove = true;
    public bool isHolding = false;

    public Text interactTxt;
    public GameObject interactPanel;
    public puzzleController puzzleControls;
    public Transform pickUpRegion;
    public GameObject heldItem;

    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    // Start is called before the first frame update
    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
            speed = BASESPEED;
        }
        if (isRunning)
        {
            speed *= runMultiplier;
            if (speed > MAXSPEED) speed = MAXSPEED;
        }

        if (canMove)
        {
            //movement
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += -transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += -transform.right * speed * Time.deltaTime;
            }
        }

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        //rotX += mouseY * mouseSensitivity * Time.deltaTime;

        //rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(0.0f, rotY, 0.0f);
        transform.rotation = localRotation;


        //letting Go of Objects
        if(isHolding)
        {
            interactTxt.text = "Press 'F' to drop.";
            if(Input.GetKeyDown(KeyCode.F))
            {
                interactPanel.gameObject.SetActive(false);
                heldItem.transform.SetParent(null);
                heldItem.GetComponent<Rigidbody>().useGravity = true;
                heldItem.GetComponent<Rigidbody>().isKinematic = false;
                isHolding = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "buttonPush")
        {
            interactPanel.gameObject.SetActive(true);
            interactTxt.text = "Press 'E' to Read Description.";
        }        
        
        else if (other.tag == "Abe" && puzzleControls.puzzle1 >= 80 && puzzleControls.puzzle1 < 100)
        {
            interactPanel.gameObject.SetActive(true);
            interactTxt.text = "Press 'E' to Read Description.";
        }

        else if (other.tag == "Abe" && puzzleControls.puzzle1 <80)
        {
            interactPanel.gameObject.SetActive(true);
            interactTxt.text = "You can't do this yet.";
        }

        else if (!isHolding && (other.tag == "moveable" || !other.gameObject.GetComponent<itemMatching>().hasMatched))
        {
            interactPanel.gameObject.SetActive(true);
            interactTxt.text = "Press 'E' to pickup.";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Abe" && Input.GetKeyDown(KeyCode.E) && puzzleControls.puzzle1 >= 80)
        {
            other.GetComponent<popUpTextAbe>().activateText();
        }

        else if (other.tag == "buttonPush" && Input.GetKeyDown(KeyCode.E))
        {
            //print("button pressed");
            other.GetComponent<popUpText>().activateText();
        }

        else if(Input.GetKeyDown(KeyCode.E) && !other.gameObject.GetComponent<itemMatching>().hasMatched)
        {
            other.gameObject.transform.SetParent(pickUpRegion.transform);
            other.transform.localRotation = pickUpRegion.rotation;
            other.transform.position = pickUpRegion.position;
            other.GetComponent<Rigidbody>().useGravity = false;
            other.GetComponent<Rigidbody>().isKinematic = true;
            heldItem = other.gameObject;
            isHolding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "buttonPush" || other.tag == "Abe")
        {
            interactPanel.gameObject.SetActive(false);
        }

        else if (!isHolding && (other.tag == "moveable" || !other.gameObject.GetComponent<itemMatching>().hasMatched))
        {
            interactPanel.gameObject.SetActive(false);
        }
    }

}
