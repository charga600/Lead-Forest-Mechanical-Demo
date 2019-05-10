using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool connectionOnlyMode = false;
    public LayerMask turretRayIgnore;
    public GameObject pauseMenuPanel;
    public GameObject buildMenuPanel;

    [HideInInspector] public bool gamePaused = false, buildActive = false;
    [HideInInspector] public GameObject[] initialHostiles;

    bool escDownOnce = false, bDownTwice = false;

	void Start ()
    {
        //pauseManager(gamePaused);
        updateHostiles();
	}
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape) && !escDownOnce)
        {
            pauseManager(true);
            escDownOnce = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && escDownOnce)
        {
            pauseManager(false);
            escDownOnce = false;
        }

        if(Input.GetKeyDown(KeyCode.B) && !bDownTwice)
        {
            buildManager(true);
            bDownTwice = true;
        }
        else if (Input.GetKeyDown(KeyCode.B) && bDownTwice)
        {
            buildManager(false);
            bDownTwice = false;
        }
	}

    public void pauseManager(bool paramBool)
    {
        gamePaused = paramBool;
        //pauseMenuPanel.SetActive(paramBool);
    }
    
    public void buildManager(bool pauseBool)
    {
        buildActive = pauseBool;
        //buildMenuPanel.SetActive(pauseBool);
    }

    public void updateHostiles()
    {
        initialHostiles = GameObject.FindGameObjectsWithTag("Hostile");
    }
}
