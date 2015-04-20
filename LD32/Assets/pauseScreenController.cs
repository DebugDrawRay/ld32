using UnityEngine;
using System.Collections;

public class pauseScreenController : MonoBehaviour 
{
    private PausingMaster pMaster;

    public Vector3 hidePos;

    void Awake()
    {
        pMaster = GameObject.FindGameObjectWithTag("PauseMaster").GetComponent<PausingMaster>();
    }

    void Update()
    {
        if(pMaster.paused)
        {
            transform.localPosition = Vector3.zero;
        }
        else
        {
            transform.localPosition = hidePos;
        }
    }
    public void pauseGame()
    {
        pMaster.pauseGame = true;
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
