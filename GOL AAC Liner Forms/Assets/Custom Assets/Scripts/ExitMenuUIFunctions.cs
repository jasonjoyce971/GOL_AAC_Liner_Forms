using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMenuUIFunctions : MonoBehaviour
{
    // Exit Panel Object
    public GameObject Panel;

    // Button Functions
    public void CancelButtonClick ()
    {
        Destroy(Panel);
        Debug.Log("Exit Panel: Destroy Exit Panel", Panel);
    }

    public void ConfirmButtonClick ()
    {
        Application.Quit();
        Debug.Log("Exit Panel: Exit Application", Panel);
    }
}
