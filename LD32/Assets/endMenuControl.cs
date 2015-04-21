using UnityEngine;
using System.Collections;

public class endMenuControl : MonoBehaviour 
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void end()
    {
        Application.Quit();
    }
}
