using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public float latMove = 1, vertMove = 1, rotMod = 1; // Lateral and Vertical movement multipliers
    
    void FixedUpdate() // Using fixed update as the camera has a collider and a rigidbody
    {
        float h = Input.GetAxis("Horizontal"); // Retriving 3 standard input axis and 1 custom (Rotation) input axis 
        float v = Input.GetAxis("Vertical");
        float l = Input.GetAxis("Mouse ScrollWheel");
        float r = Input.GetAxis("Rotation");

        Vector3 forward = transform.forward; // Get the camera's forward facing direction
        forward.y = 0;      forward *= (v * latMove); // Zero the vertical input and multiply by the lateral multiplier

        Vector3 side = transform.right; // Get the camera's right facing direction
        side.y = 0;     side *= (h * latMove); // Zero the vertical input and multiply by the lateral multiplier

        Vector3 up = transform.up; // Get the camera's vertical direction
        up.x = 0;       up.z = 0;       up *= (l * vertMove); // Zero the lateral input and multiply by the vertical multiplier
        
        Vector3 comMove = forward + side + up; // Combine the zeroed and multiplied vectors into one vector which can be applied

        transform.Translate(comMove, Space.World); // Apply the combined vectors relative to world space

        Vector3 rot = transform.rotation.eulerAngles; // Retrieve the camera's current rotation as euler angles
        rot.y += r * rotMod; // Add the rotational input to the current rotation on the Y axis
        
        if (rot.y > 360f)
        {   rot.y -= 360f;  } // If the rotation is greater than 360 degrees then subtract 360 degrees to bring within the usable values

        if (rot.y < 0f)
        {   rot.y += 360f;  } // If the rotation is less than 360 degrees then add 360 degrees to bring within the usable values

        Mathf.Clamp(rot.y, 0f, 360f); // Clamp the camera's rotation on the Y axis between 0 and 360 degrees
        transform.rotation = Quaternion.Euler(rot); // Apply the adjusted rotation
    }
}
