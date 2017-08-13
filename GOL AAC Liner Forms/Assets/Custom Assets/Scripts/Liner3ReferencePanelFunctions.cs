using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Liner3ReferencePanelFunctions : MonoBehaviour
{
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

    // Import Variables
    private string GridInput;
    private string CTabInput;
    private int TypeDropdown;
    private int OrdDropdown;
    private int IngressDropdown;

    // Awake function to configure variables
    private void Awake()
    {
        // Detect the Main UI Panel for later
        ParentPanel = GameObject.Find("UI");
        // Import PlayerPrefs to populate vars
        GridInput = PlayerPrefs.GetString("Liner3Grid");
        CTabInput = PlayerPrefs.GetString("Liner3cTab");
        TypeDropdown = PlayerPrefs.GetInt("Liner3Type");
        OrdDropdown = PlayerPrefs.GetInt("Liner3Ord");
        IngressDropdown = PlayerPrefs.GetInt("Liner3Ingress");

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

        Debug.Log("Liner3 Reference Panel loading complete");
    }

    // Button Functions
    public void TaskCompleteClicked()
    {
        // Destroy this panel to show previous
        ParentPanelRef = ParentPanel.transform.Find("Main Canvas").gameObject;
        ParentPanelRef.SetActive(true);
        Destroy(Panel);
        Debug.Log("Liner3 Reference Panel: Destory Liner3 Reference Panel");
    }

    public void QuitButtonClicked()
    {
        // Load Quit Panel
        Instantiate(QuitPanel);
        Debug.Log("Liner3 Reference Panel: Load Quit Panel");
    }
}
