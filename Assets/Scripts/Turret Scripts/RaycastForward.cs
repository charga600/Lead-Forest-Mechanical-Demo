using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastForward : MonoBehaviour
{
	void Update ()
    {
        Debug.DrawLine(transform.position, transform.position + (transform.forward * 100), Color.green);
    }
}
