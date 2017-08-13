using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIFunctions : MonoBehaviour
{
    // Panels
    public GameObject ParentPanel;
    public GameObject Liner3Panel;
    public GameObject Liner6Panel;
    public GameObject Liner6CASEVACPanel;
    public GameObject CASAssistPanel;
    public GameObject ExitPanel;

    // Button Functions
    public void Liner3ButtonClick ()
    {
        Instantiate(Liner3Panel);
        ParentPanel.SetActive(false);
        Debug.Log("Main Menu: Load 3 Liner Panel", Liner3Panel);
    }

    public void Liner6ButtonClick()
    {
        Instantiate(Liner6Panel);
        ParentPanel.SetActive(false);
        Debug.Log("Main Menu: Load 6 Liner Panel", Liner6Panel);
    }

    public void Liner6CASEVACButtonClick()
    {
        Instantiate(Liner6CASEVACPanel);
        ParentPanel.SetActive(false);
        Debug.Log("Main Menu: Load 6 Liner CASEVAC Panel", Liner6CASEVACPanel);
    }

    public void LinerCASAssistButtonClick()
    {
        Instantiate(CASAssistPanel);
        ParentPanel.SetActive(false);
        Debug.Log("Main Menu: Load CAS Assistant Panel", CASAssistPanel);
    }

    public void ExitButtonClick()
    {
        Instantiate(ExitPanel);
        Debug.Log("Main Menu: Load Exit Panel", ExitPanel);
    }
}
