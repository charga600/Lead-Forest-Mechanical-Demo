using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class ZoneCheckCon : MonoBehaviour
{
    void OnTriggerEnter(Collider target)
    {   FindObjectOfType<BuildController>().canBuild = false;   }

    void OnTriggerExit(Collider target)
    {   FindObjectOfType<BuildController>().canBuild = true;    }
}
