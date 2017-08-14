using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Liner6ReferencePanelFunctions : MonoBehaviour {

    // Panels
    public GameObject Panel;
    public GameObject QuitPanel;

    private GameObject ParentPanel;
    private GameObject ParentPanelRef;

    // GUI Elements changed by incoming data
    public Text Grid;
    public Text CTab;
    public Text Type;
    public Text Ord;
    public Text Ingress;
    public Text Marking;
    public Text Egress;
    public Text Notes;

    // Import Variables
    private string GridInput;
    private string CTabInput;
    private int TypeDropdown;
    private int OrdDropdown;
    private int IngressDropdown;
    private int MarkingDropdown;
    private int EgressDropdown;
    private int NotesCounter;

    // Awake function to configure variables
    private void Awake()
    {
        // Detect the Main UI Panel for later
        ParentPanel = GameObject.Find("UI");
        // Import PlayerPrefs to populate vars
        GridInput = PlayerPrefs.GetString("Liner6Grid");
        CTabInput = PlayerPrefs.GetString("Liner6cTab");
        TypeDropdown = PlayerPrefs.GetInt("Liner6Type");
        OrdDropdown = PlayerPrefs.GetInt("Liner6Ord");
        IngressDropdown = PlayerPrefs.GetInt("Liner6Ingress");
        MarkingDropdown = PlayerPrefs.GetInt("Liner6Marking");
        EgressDropdown = PlayerPrefs.GetInt("Liner6Egress");
        NotesCounter = PlayerPrefs.GetInt("Liner6NotesCount");

        // Call population function to fill out reference data based on vars
        DataPopulate();
    }
    private void DataPopulate()
    {
        Grid.text = GridInput;
        CTab.text = CTabInput;
        switch (TypeDropdown)
        {
            case 1:
                {
                    Type.text = "Infantry";
                    break;
                }
            case 2:
                {
                    Type.text = "Light";
                    break;
                }
            case 3:
                {
                    Type.text = "Heavy";
                    break;
                }
            case 4:
                {
                    Type.text = "Static";
                    break;
                }
        }
        switch (OrdDropdown)
        {
            case 1:
                {
                    Ord.text = "Guns";
                    break;
                }
            case 2:
                {
                    Ord.text = "Rockets";
                    break;
                }
            case 3:
                {
                    Ord.text = "Missiles";
                    break;
                }
            case 4:
                {
                    Ord.text = "Bombs";
                    break;
                }
        }
        switch (IngressDropdown)
        {
            case 1:
                {
                    Ingress.text = "North";
                    break;
                }
            case 2:
                {
                    Ingress.text = "North East";
                    break;
                }
            case 3:
                {
                    Ingress.text = "East";
                    break;
                }
            case 4:
                {
                    Ingress.text = "South East";
                    break;
                }
            case 5:
                {
                    Ingress.text = "South";
                    break;
                }
            case 6:
                {
                    Ingress.text = "South West";
                    break;
                }
            case 7:
                {
                    Ingress.text = "West";
                    break;
                }
            case 8:
                {
                    Ingress.text = "North West";
                    break;
                }
        }
        switch (MarkingDropdown)
        {
            case 1:
                {
                    Marking.text = "Smoke/Beacon";
                    break;
                }
            case 2:
                {
                    Marking.text = "Laser";
                    break;
                }
            case 3:
                {
                    Marking.text = "No Mark";
                    break;
                }
            case 4:
                {
                    Marking.text = "IR Pointer";
                    break;
                }
        }
        switch (EgressDropdown)
        {
            case 1:
                {
                    Egress.text = "North";
                    break;
                }
            case 2:
                {
                    Egress.text = "North East";
                    break;
                }
            case 3:
                {
                    Egress.text = "East";
                    break;
                }
            case 4:
                {
                    Egress.text = "South East";
                    break;
                }
            case 5:
                {
                    Egress.text = "South";
                    break;
                }
            case 6:
                {
                    Egress.text = "South West";
                    break;
                }
            case 7:
                {
                    Egress.text = "West";
                    break;
                }
            case 8:
                {
                    Egress.text = "North West";
                    break;
                }
        }

        int counter = 0;
        string s;
        for(int i = 0; i <= NotesCounter; i++)
        {
            s = PlayerPrefs.GetString("Liner6Notes " + counter);
            s = s + "\n";
            Notes.text = Notes.text + s;
            counter++;
        };
          
        Debug.Log("Liner6 Reference Panel loading complete");
    }

    // Button Functions
    public void TaskCompleteClicked()
    {
        // Destroy this panel to show previous
        ParentPanelRef = ParentPanel.transform.Find("Main Canvas").gameObject;
        ParentPanelRef.SetActive(true);
        Destroy(Panel);
        Debug.Log("Liner6 Reference Panel: Destory Liner3 Reference Panel");
    }

    public void QuitButtonClicked()
    {
        // Load Quit Panel
        Instantiate(QuitPanel);
        Debug.Log("Liner6 Reference Panel: Load Quit Panel");
    }

    public void CasAssistantClicked()
    {
        Debug.Log("Liner6 Reference Panel: Load CAS Assistant");
    }
}
