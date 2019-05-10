using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretData : MonoBehaviour
{
    public TurretType[] Turrets;
}

[System.Serializable]
public class TurretType
{
    public string name = "null";
    public float cooldown = 1f;
    public float velocity = 1f;
    public Rigidbody shotPrefab;
}
