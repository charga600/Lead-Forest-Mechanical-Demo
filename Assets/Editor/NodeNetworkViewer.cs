using System;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HostileNode))]
public class NodeNetworkViewer : Editor
{
    // void OnEnable()
    // {   SceneView.onSceneGUIDelegate += drawNodePathways;   }

    // void OnDisable()
    // {   SceneView.onSceneGUIDelegate -= drawNodePathways;   }
    
    // void drawNodePathways(SceneView SV)
    // {
    //     GameController gameCon = FindObjectOfType<GameController>();
    //     HostileNode HN = target as HostileNode;
    //     GameObject PO = target as GameObject;

    //     if(gameCon.connectionOnlyMode)
    //     {
    //         GameObject SO = null;

    //         try
    //         {   SO = Selection.activeGameObject; }
    //         catch (NullReferenceException) { }
            
    //         if(PO == SO)
    //         {
    //             foreach(Transform t in HN.forwardNodes)
    //             {
    //                 Handles.color = Color.red;
    //                 Handles.DrawDottedLine(PO.transform.position, t.position, 4f);
    //             }
    //         }
    //         else
    //         {
    //             foreach(Transform t in HN.forwardNodes)
    //             {
    //                 if(t.gameObject == SO)
    //                 {
    //                     Debug.Log(PO.name);
    //                     Handles.color = Color.green;
    //                     Handles.DrawLine(PO.transform.position, t.position);
    //                 }
    //             }
    //         }
    //     }
    //     else
    //     {
    //         foreach(Transform t in HN.forwardNodes)
    //         {
    //             Handles.color = Color.green;
    //             Handles.DrawLine(PO.transform.position, t.position);
    //         }
    //     }
    // }
}
