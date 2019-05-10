using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEndNodeController : MonoBehaviour
{
    public Transform startNode;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.tag == "Hostile")
        {   collider.transform.position = startNode.position;   }
    }
}
