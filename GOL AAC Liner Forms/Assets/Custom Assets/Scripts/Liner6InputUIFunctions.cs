using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Liner6InputUIFunctions : MonoBehaviour {

    // Panels
    public GameObject Panel;
    public GameObject QuitPanel;
    public GameObject ReferencePanel;

    private GameObject ParentPanel;
    private GameObject ParentPanelRef;

    // Input Fields and Dropdowns
    public InputField GridInput;
    public InputField CTabInput;
    public Dropdown TypeDropdown;
    public Dropdown OrdDropdown;
    public Dropdown IngressDropdown;
    public Dropdown MarkingDropdown;
    public Dropdown EgressDropdown;
    public InputField NotesInput;

    // Awake function to detect parent panel
    private void Awake()
    {
        // Detect the Main UI Panel for later
        ParentPanel = GameObject.Find("UI");
    }

    // Button Functions
    public void ConfirmButtonClicked()
    {
        // Send data to PlayerPrefs for future reference
        PlayerPrefs.SetString("Liner6Grid", GridInput.text);
        PlayerPrefs.SetString("Liner6cTab", CTabInput.text);
        PlayerPrefs.SetInt("Liner6Type", TypeDropdown.value);
        PlayerPrefs.SetInt("Liner6Ord", OrdDropdown.value);
        PlayerPrefs.SetInt("Liner6Ingress", IngressDropdown.value);
        PlayerPrefs.SetInt("Liner6Marking", MarkingDropdown.value);
        PlayerPrefs.SetInt("Liner6Egress", EgressDropdown.value);

        // Notes requires a separate func to break lines apart
        CompileNotes(NotesInput.text);

        // Load the reference panel
        Instantiate(ReferencePanel);
        Destroy(Panel);
        Debug.Log("Liner6 Panel: Proceed to Reference Panel");
    }

    public void ClearButtonClicked()
    {
        // Set Entries to defaults
        GridInput.text = " ";
        CTabInput.text = " ";
        TypeDropdown.value = 0;
        OrdDropdown.value = 0;
        IngressDropdown.value = 0;
        MarkingDropdown.value = 0;
        EgressDropdown.value = 0;
        NotesInput.text = " ";
        Debug.Log("Liner6 Panel: Clear button resets to defaults");
    }

    public void BackButtonClicked()
    {
        // Destroy this panel to show previous
        ParentPanelRef = ParentPanel.transform.Find("Main Canvas").gameObject;
        ParentPanelRef.SetActive(true);
        Destroy(Panel);
        Debug.Log("Liner6 Panel: Destory Liner 6 Panel");
    }

    public void QuitButtonClicked()
    {
        // Load Quit Panel
        Instantiate(QuitPanel);
        Debug.Log("Liner6 Panel: Load Quit Panel");
    }

    private void CompileNotes(string Input)
    {
        string[] splitString = Input.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
        int counter = 0;
        foreach (string s in splitString)
        {
            PlayerPrefs.SetString("Liner6Notes " + counter, s);
            counter = counter + 1;
        }
        PlayerPrefs.SetInt("Liner6NotesCount", counter);
        Debug.Log("Liner6 Notes Array index value " + counter);
    }
}
