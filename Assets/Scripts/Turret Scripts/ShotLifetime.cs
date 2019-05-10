using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotLifetime : MonoBehaviour
{
    public float lifetime;

    void Start()
    {
        StartCoroutine(startDeath());
    }

    IEnumerator startDeath()
    {
        yield return new WaitForSeconds(lifetime);

        Destroy(gameObject);
    }

}
