using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildController : MonoBehaviour
{
    public BuildableTurretData[] BTD;
    public LayerMask buildableLayer;
    public GameObject zoneCheckObject;

    [HideInInspector] public bool canBuild = true;

    GameObject buildObject, buildWireframe;
    GameController gameCon;

    void Start()
    {
        gameCon = GameObject.FindObjectOfType<GameController>();
        buildObject = BTD[0].turretPrefab;
        buildWireframe = Instantiate(BTD[0].turretWireframe, Vector3.zero, Quaternion.identity);
        buildWireframe.SetActive(false);
    }

    void FixedUpdate()
    {
        if(gameCon.buildActive)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f, buildableLayer))
            {
                zoneCheckObject.transform.position = hit.point + Vector3.up;
                
                if(canBuild)
                {
                    if(!buildWireframe.activeInHierarchy)
                    {   buildWireframe.SetActive(true);  }

                    buildWireframe.transform.position = hit.point;

                    if(Input.GetMouseButtonUp(0))
                    {   GameObject spawnTurret = Instantiate(buildObject, hit.point, Quaternion.identity);  }
                }
                else if(buildWireframe.activeInHierarchy)
                {   buildWireframe.SetActive(false);  }
            }
        }
        else if(buildWireframe.activeInHierarchy)
        {   buildWireframe.SetActive(false);  }
    }

    public void switchBuildTurret(string deltaName)
    {
        foreach(BuildableTurretData btd in BTD)
        {
            if (deltaName == btd.turretName)
            {
                buildObject = btd.turretPrefab;
                buildWireframe = Instantiate(btd.turretWireframe, Vector3.zero, Quaternion.identity);
                zoneCheckObject.GetComponent<CapsuleCollider>().radius = btd.clearRadius;
                zoneCheckObject.GetComponent<CapsuleCollider>().height = btd.clearRadius * 3;
            }
        }
    }
}

[System.Serializable]
public class BuildableTurretData
{
    public string turretName;
    public float clearRadius;
    public GameObject turretPrefab, turretWireframe;
}
