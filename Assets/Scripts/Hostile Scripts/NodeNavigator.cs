using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class NodeNavigator : MonoBehaviour
{
    public Transform startNode;
    public float speed = 1f;

    void Start()
    {   transform.LookAt(startNode);    }

    void FixedUpdate()
    {
        Vector3 dir = transform.forward.normalized;
        transform.Translate(dir * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider collider)
    {
        try
        {
            if(collider.transform.tag == "Node")
            {
                HostileNode HN = collider.transform.GetComponent<HostileNode>();
                Transform newTarget = HN.forwardNodes[UnityEngine.Random.Range(0, HN.forwardNodes.Length)];
                transform.LookAt(newTarget);
            }
        }
        catch (IndexOutOfRangeException) { }
        catch (NullReferenceException) { }
    }
}
