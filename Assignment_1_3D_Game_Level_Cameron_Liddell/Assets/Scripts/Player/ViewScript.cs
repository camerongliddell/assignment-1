using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reference: Brackeys "FIRST PERSON MOVEMENT in Unity - FPS Controller"
// https://www.youtube.com/watch?v=_QajrabyTJc

public class ViewScript : MonoBehaviour
{
    public float sensitivity = 100f;
    public Transform player;
    float rotationX = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Time.deltaTime allows for the sensitivity to be FPS independant
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        rotationX = rotationX - mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        // Quaternion is used to represent a rotation
        // Euler returns the rotations around the axis
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
