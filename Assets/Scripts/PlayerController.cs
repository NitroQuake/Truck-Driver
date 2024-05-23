using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Private variables
    [SerializeField] float speed;
    [SerializeField] float rpm;
    [SerializeField] float horsePower;
    [SerializeField] const float turnSpeed = 45.0f;
        // [SerializeField] make it so you can only edit on the inspector //
        // const: keeps the value the same static: makes it so you don't need to instantiate something in Start() protected: makes it so you can only access this variable from the child class of the parent class with the protect variable
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
        // Makes the objects collide better, where it doesn't go into each other
    {
        // Player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            // Moves the vehicle
            playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);

            // transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            // (0, 0, 1) * time * 20 = 0, 0, 20
            // Vector3 represent the three values in transform -> position

            // Turns the vehicle
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.237f); // // 3.6 for kph
            speedometerText.SetText("Speed: " + speed + " mph");

            rpm = (speed % 30) * 40;
            rpmText.SetText("RPM: " + rpm);
        }

    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheels in allWheels)
        {
            if (wheels.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if(wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
