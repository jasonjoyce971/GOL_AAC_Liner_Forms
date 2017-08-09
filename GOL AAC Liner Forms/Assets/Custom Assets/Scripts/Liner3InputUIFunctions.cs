using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liner3InputUIFunctions : MonoBehaviour
{
    // Panel Objects
    public GameObject Panel;
    public GameObject QuitPanel;
    public GameObject ReferencePanel;

    // Button Functions
    public void ConfirmButtonClicked ()
    {
        // Send Grid Text Value to data manager
        // Send cTab Text Value to data manager
        // Send Type Int Value to data manager
        // Send Ord Int Value to data manager
        // Sent Ingress Int Value to data manager
        Instantiate(ReferencePanel);
    }

    public void ClearButtonClicked ()
    {
        // Delete Grid Text -> Must Replace
        // Delete cTab Text -> Must Replace
        // Set Type Int Value to origin
        // Set Ord Int Value to origin
        // Set Ingress Int Value to origin
    }

    public void BackButtonClicked ()
    {
        Destroy(Panel);
        Debug.Log("Liner3 Panel: Destory Liner 3 Panel", Panel);
    }

    public void QuitButtonClicked ()
    {
        Instantiate(QuitPanel);
        Debug.Log("Liner3 Panel: Load Quit Panel", Panel);
    }
}
