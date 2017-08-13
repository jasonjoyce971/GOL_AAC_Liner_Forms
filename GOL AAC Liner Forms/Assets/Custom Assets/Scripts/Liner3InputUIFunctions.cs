using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Liner3InputUIFunctions : MonoBehaviour
{
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

    // Awake function to detect parent panel
    private void Awake()
    {
        // Detect the Main UI Panel for later
        ParentPanel = GameObject.Find("UI");
    }

    // Button Functions
    public void ConfirmButtonClicked ()
    {
        // Send data to PlayerPrefs for future reference
        PlayerPrefs.SetString("Liner3Grid", GridInput.text);
        PlayerPrefs.SetString("Liner3cTab", CTabInput.text);
        PlayerPrefs.SetInt("Liner3Type", TypeDropdown.value);
        PlayerPrefs.SetInt("Liner3Ord", OrdDropdown.value);
        PlayerPrefs.SetInt("Liner3Ingress", IngressDropdown.value);

        // Load the reference panel
        Instantiate(ReferencePanel);
        Destroy(Panel);
        Debug.Log("Liner3 Panel: Proceed to Reference Panel");
    }

    public void ClearButtonClicked ()
    {
        // Set Entries to defaults
        GridInput.text = " ";
        CTabInput.text = " ";
        TypeDropdown.value = 0;
        OrdDropdown.value = 0;
        IngressDropdown.value = 0;
        Debug.Log("Liner3 Panel: Clear button resets to defaults");
    }

    public void BackButtonClicked ()
    {
        // Destroy this panel to show previous
        ParentPanelRef = ParentPanel.transform.Find("Main Canvas").gameObject;
        ParentPanelRef.SetActive(true);
        Destroy(Panel);
        Debug.Log("Liner3 Panel: Destory Liner 3 Panel");
    }

    public void QuitButtonClicked ()
    {
        // Load Quit Panel
        Instantiate(QuitPanel);
        Debug.Log("Liner3 Panel: Load Quit Panel");
    }
}
