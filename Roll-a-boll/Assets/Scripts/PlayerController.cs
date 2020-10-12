using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject endMessage; // all elements are gameObject
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int count;
    public TextMeshProUGUI AccText;
    public Boolean isMobileBuild;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>(); //access to rigidbody of the player andapply forces on it
        count = 0; //initiate count 
        endMessage.SetActive(false); //disable the end message
        SetCountText();
        if (isMobileBuild)
        {
            // enable readingsensor values
            InputSystem.EnableDevice(UnityEngine.InputSystem.Accelerometer.current);
        }
    }

    
    void OnMove(InputValue movementValue) 
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); 

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    void SetCountText()
    {
        countText.text = "Score : " + count.ToString();
        if (count >= 25)
        {
            endMessage.SetActive(true);
        }
    }

    private void FixedUpdate() //not update to not overload the pc if no one is playing
    {
        Vector3 movement = Vector3.zero;
        if (isMobileBuild)
        {
            Vector3 a = UnityEngine.InputSystem.Accelerometer.current.acceleration.ReadValue();
            AccText.text = "Accelerometer: " + a.ToString("F6");
            movement = new Vector3(a.x, 0.0f, a.y);
        }
        else
        {
            movement = new Vector3(movementX, 0.0f, movementY); //!!AddForce need a vector3, that the objective of this line.
        }
        rb.AddForce(movement * speed); //apply force on our player 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false); //PickUp objects disapeared
            count += 1; //the score increase by one
            SetCountText();
        }
    }
}
