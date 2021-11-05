using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{

    // Vars
    public Vector3 endPos; // Where the door should end up (on opening)
    public float speed = 1.0f; // The speed that the door will move

    private bool moving = false; // If the door is moving or not
    private bool opening = true; // If the door will be opening or closing
    private Vector3 startPos; // Start pos that's set later in the code
    private float delay = 1.0f; // The delay after opening, before closing

    // Start is called before the first frame update
    void Start()
    {
        // Set the start position
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // If the door is currently moving, and the door is set to open instead of close, use X method, else use the other one


        if (moving)
        {
            if (opening)
            {
                MoveDoor(endPos);
            }
            else
            {
                MoveDoor(startPos);
            }
        }
    }

    void MoveDoor(Vector3 pos)
    {
        // Distance between the current position, and the position we want to end up at
        float dist = Vector3.Distance(transform.position, pos);
        if(dist > .1f)
        {
            // Lerping between current position and the end position (Either the start or the end of the animation)
            transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);
        }
        else
        {
            // If the door is set to open, give it a delay and and change bools
            if (opening)
            {
                delay += Time.deltaTime; // FPS independant
                if (delay > 1.5f)
                {
                    // Ensure that the door is now closing
                    opening = false;
                }
                else
                {
                    // Swap values for both
                    moving = false;
                    opening = true;
                }
            }
        }
    }

    public bool Moving // Getter/Setter for the moving boolean
    {
        get { return moving; }
        set { moving = value; }
    }
}
