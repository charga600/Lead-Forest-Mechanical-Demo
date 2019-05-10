using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
    public int health = 60;

    void OnTriggerEnter(Collider impact)
    {
        if(impact.transform.tag == "Gatling Shot")
        {
            Destroy(impact.gameObject);
            health -= 3;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}