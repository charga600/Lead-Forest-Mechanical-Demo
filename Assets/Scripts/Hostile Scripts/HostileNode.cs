using UnityEngine;
using UnityEditor;
using System;

[RequireComponent(typeof(Collider)), ExecuteAlways]
public class HostileNode : MonoBehaviour
{
    public Transform[] forwardNodes;

    void OnEnable()
    {   SceneView.onSceneGUIDelegate += drawNodePathways;   }

    void OnDisable()
    {   SceneView.onSceneGUIDelegate -= drawNodePathways;   }
    
    void drawNodePathways(SceneView SV)
    {
        GameController gameCon = FindObjectOfType<GameController>();

        foreach(Transform t in forwardNodes)
        {
            if(t == null)
            {   return; }
        }

        if(gameCon.connectionOnlyMode)
        {
            GameObject SO = null;

            try
            {   SO = Selection.activeGameObject; }
            catch (NullReferenceException) { }
            
            if(gameObject == SO)
            {
                foreach(Transform t in forwardNodes)
                {
                    Handles.color = Color.green;
                    Handles.DrawLine(transform.position, t.position);
                }
            }
            else
            {
                foreach(Transform t in forwardNodes)
                {
                    if(t.gameObject == SO)
                    {
                        Handles.color = Color.red;
                        Handles.DrawLine(transform.position, t.position);
                    }
                }
            }
        }
        else
        {
            foreach(Transform t in forwardNodes)
            {
                Handles.color = Color.green;
                Handles.DrawLine(transform.position, t.position);
            }
        }
    }
}
