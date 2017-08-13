using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ExitMenuUIFunctions : MonoBehaviour
{
    // Store this panel for cancel code
    public GameObject Panel;

    // Button Functions
    public void CancelButtonClick ()
    {
        // Destroy this panel to show previous
        Destroy(Panel);
        Debug.Log("Exit Panel: Destroy Exit Panel");
    }

    public void ConfirmButtonClick ()
    {
        // Exit application with Editor pseudo quit code
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        Debug.Log("Exit Panel: Exit Application");
#else
        Application.Quit();
        Debug.Log("Exit Panel: Exit Application");
#endif
    }
}
