using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reference: Brackeys "FIRST PERSON MOVEMENT in Unity - FPS Controller"
// https://www.youtube.com/watch?v=_QajrabyTJc

public class PlayerMovementScript : MonoBehaviour
{
    public CharacterController controller;

    public Transform groundCheck;
    public float distance = 0.4f;
    public LayerMask mask;

    public float speed = 12f;
    public float gravity = -20f;
    public float height = 3f;

    Vector3 velocity;
    bool isGrounded;
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, distance, mask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Axis
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // new Vector3() would use global coordinates and therefore always move in the same direction
        // This way means that it takes the viewing angle into perspective!
        Vector3 move = transform.right * x + transform.forward * z;

        // Framerate independant
        controller.Move(move * speed * Time.deltaTime);

        // Jump

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(height * -2f * gravity);
        }

        // Gravity follows

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Door")
        {
            if(other.GetComponent<AutoDoor>().Moving == false)
            {
                other.GetComponent<AutoDoor>().Moving = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Explode")
        {
            other.GetComponent<Explosion>().Explode();
        }
    }
}
