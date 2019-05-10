using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCV2 : MonoBehaviour
{
    public float rotationSpeed;

    [Header("Turret Variables")]
    public Transform turret;
    //public float maxYaw, minYaw;

    [Header("Barrell Variables")]
    public Transform barrell;
    public Transform barrelEnd;
    //public float maxPitch, minPitch;

    [HideInInspector] public GameObject target;

    float targetDist = Mathf.Infinity, CD, velocity;
    LayerMask ignoreLayer;
    GameController gameCon;
    Rigidbody shotPrefab;
    NodeNavigator NN;
    Vector3 leadPoint;

    struct leadMargin
    {
        Vector3 calcPoint;
        float errorMargin;
    }

    void Start()
    {
        gameCon = FindObjectOfType<GameController>();
        ignoreLayer = ~gameCon.turretRayIgnore;
        IdentifyTurret();
        StartCoroutine(updateDistance());
    }

    void FixedUpdate()
    {   
        //Create planes relative to turret and barrell
        Plane BPlane = new Plane(barrell.right, barrell.transform.position);
        Plane TPlane = new Plane(turret.up, turret.transform.localPosition);
        
        //find closest point on plane to the target object
        Vector3 BTarPoint;
        Vector3 TTarPoint;
        
        if(target != null)
        {
            leadPoint = target.transform.position;
            float tarVelo = target.GetComponent<NodeNavigator>().speed;
            float dist = Vector3.Distance(barrelEnd.position, target.transform.position);
            float time = dist / velocity;
            dist = tarVelo * time;
            leadPoint = target.transform.position + (target.transform.forward.normalized * dist);
            BTarPoint = BPlane.ClosestPointOnPlane(leadPoint);
            TTarPoint = TPlane.ClosestPointOnPlane(leadPoint);
        }
        else
        {
            BTarPoint = TPlane.ClosestPointOnPlane(barrelEnd.position);
            TTarPoint = TPlane.ClosestPointOnPlane(barrelEnd.position);
        }

        //calculate direction along the respective plane to from the object to the target
        BTarPoint = BTarPoint - barrell.position;
        TTarPoint = TTarPoint - turret.position;

        //normalise the result
        BTarPoint = Vector3.Normalize(BTarPoint);
        TTarPoint = Vector3.Normalize(TTarPoint);

        //calculate the angle from the objects current forward to direction needed to point qt the target object
        float barrellAngle = Vector3.SignedAngle(barrell.forward, BTarPoint, barrell.right);
        float turretAngle = Vector3.SignedAngle(turret.forward, TTarPoint, turret.up);

        //clamp the angle to the rotation possible in one physics frame
        barrellAngle = Mathf.Clamp(barrellAngle, -rotationSpeed * Time.fixedDeltaTime, rotationSpeed * Time.fixedDeltaTime);
        turretAngle = Mathf.Clamp(turretAngle, -rotationSpeed * Time.fixedDeltaTime, rotationSpeed * Time.fixedDeltaTime);

        //apply the rotation to the objects
        barrell.Rotate(new Vector3(barrellAngle, 0 , 0), Space.Self);
        turret.Rotate(new Vector3(0 , turretAngle, 0), Space.Self);
    }

    leadMargin reduceLeadError(leadMargin workingValues)
    {

        return workingValues;
    }

    IEnumerator updateDistance()
    {
        yield return new WaitForEndOfFrame();
        StartCoroutine(fireShot());

        while (true)
        {
            try
            {
                float dist = 0f;
                targetDist = Mathf.Infinity;
                GameObject holdTarget = target;

                foreach (GameObject tar in gameCon.initialHostiles)
                {
                    dist = Vector3.Distance(barrelEnd.position, tar.transform.position);

                    if (dist < targetDist)
                    {
                        targetDist = dist;
                        holdTarget = tar;
                    }
                }

                Vector3 dir = (holdTarget.transform.position - barrelEnd.position).normalized;
                RaycastHit hit;
                float maxDist = Vector3.Distance(barrelEnd.position, leadPoint) + 3f;
                
                if (Physics.Raycast(barrelEnd.position, dir, out hit, Mathf.Infinity, ignoreLayer))
                {
                    if (hit.transform == holdTarget.transform)
                    {   
                        target = holdTarget;
                        NN = target.GetComponent<NodeNavigator>();
                    }
                    else
                    {   target = null;  }

                    Debug.DrawLine(barrelEnd.position, hit.point, Color.yellow, .2f);
                }
                
                if(Physics.Raycast(barrelEnd.position, dir, out hit, maxDist, ignoreLayer))
                {   
                    if(hit.transform.tag != "Hostile")
                    {   target = null;  }
                }
            }
            catch(MissingReferenceException) { }

            yield return new WaitForSeconds(.2f);
        }
    }

    void IdentifyTurret()
    {
        foreach(TurretType TD in FindObjectOfType<TurretData>().Turrets)
        {
            if (transform.tag.Equals(TD.name))
            {
                CD = TD.cooldown;
                velocity = TD.velocity;
                shotPrefab = TD.shotPrefab;
            }
        }
    }

    IEnumerator fireShot()
    {
        yield return new WaitForEndOfFrame();

        while(true)
        {
            if (target != null)
            {
                Rigidbody shot = Instantiate(shotPrefab, barrelEnd.position, barrelEnd.rotation);
                Vector3 dir = barrelEnd.forward;
                dir.Normalize();
                dir *= velocity;
                shot.AddForce(dir, ForceMode.Impulse);
            }

            yield return new WaitForSeconds(CD);
        }
    }
}
