using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CASAssistDisplayUIFunctions : MonoBehaviour {

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
    public Text AvailableWeapons;
    public Text SuggestedWeapon;
    public Text SuggestedAttack;

    // Import Variables
    private string GridInput;
    private string CTabInput;
    private int TypeDropdown;
    private int OrdDropdown;
    private int IngressDropdown;
    private int MarkingDropdown;
    private int EgressDropdown;
    private int NotesCounter;
    private int aircraft;
    private int pylon1;
    private int pylon2;
    private int pylon3;
    private int pylon4;
    private int pylon5;
    private int pylon6;
    private int pylon7;
    private int pylon8;
    private int pylon9;
    private int pylon10;
    private int pylon11;
    private int pylon12;
    private int pylon13;
    private int pylon14;

    // Calculation Variables
    private string pylon1Load;
    private string pylon2Load;
    private string pylon3Load;
    private string pylon4Load;
    private string pylon5Load;

    private int pylonCount;
    private List <int> payloadArray = new List<int>();
    private List<string> rocketType = new List<string>();

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
        aircraft = PlayerPrefs.GetInt("CASAssistAirframeToken");
        pylon1 = PlayerPrefs.GetInt("CASAssistPylon1");
        pylon2 = PlayerPrefs.GetInt("CASAssistPylon2");
        pylon3 = PlayerPrefs.GetInt("CASAssistPylon3");
        pylon4 = PlayerPrefs.GetInt("CASAssistPylon4");
        pylon5 = PlayerPrefs.GetInt("CASAssistPylon5");
        pylon6 = PlayerPrefs.GetInt("CASAssistPylon6");
        pylon7 = PlayerPrefs.GetInt("CASAssistPylon7");
        pylon8 = PlayerPrefs.GetInt("CASAssistPylon8");
        pylon9 = PlayerPrefs.GetInt("CASAssistPylon9");
        pylon10 = PlayerPrefs.GetInt("CASAssistPylon10");
        pylon11 = PlayerPrefs.GetInt("CASAssistPylon11");
        pylon12 = PlayerPrefs.GetInt("CASAssistPylon12");
        pylon13 = PlayerPrefs.GetInt("CASAssistPylon13");
        pylon14 = PlayerPrefs.GetInt("CASAssistPylon14");

        // Call population function to fill out reference data
        DataPopulate();

        // Ascertain Current Payload
        GeneratePayloadData();

    }

    private void GeneratePayloadData()
    {
        // Ascertain ord type to discover if aircraft is capable
        switch (OrdDropdown)
        {
            case 1: // Guns
                {
                    switch (aircraft)
                    {
                        case 0: // A-10
                            {
                                switch (MarkingDropdown)
                                {
                                    case 1: // smoke
                                        {
                                            AvailableWeapons.text = "GAU-8 30mm Cannon";
                                            SuggestedWeapon.text = "GAU-8 30mm Cannon";
                                            SuggestedAttack.text = "CCIP On Smoke";
                                            break;
                                        }
                                    case 2: // laser
                                        {
                                            AvailableWeapons.text = "GAU-8 30mm Cannon";
                                            SuggestedWeapon.text = "GAU-8 30mm Cannon";
                                            SuggestedAttack.text = "CCIP On Laser Point";
                                            break;
                                        }
                                    case 3: // no mark
                                        {
                                            AvailableWeapons.text = "GAU-8 30mm Cannon";
                                            SuggestedWeapon.text = "GAU-8 30mm Cannon";
                                            SuggestedAttack.text = "Visual CCIP";
                                            break;
                                        }
                                    case 4: // ir pointer
                                        {
                                            AvailableWeapons.text = "GAU-8 30mm Cannon";
                                            SuggestedWeapon.text = "GAU-8 30mm Cannon";
                                            SuggestedAttack.text = "CCIP On IR Point";
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                    break;
                }
            case 2: // Rockets
                {
                    switch (aircraft)
                    {
                        case 0: // A-10
                            {
                                switch (MarkingDropdown)
                                {
                                    case 1: // smoke
                                        {
                                            switch (TypeDropdown)
                                            {
                                                case 1: // Infantry
                                                    {
                                                        // List Available Weapons
                                                        if (pylon3 == 10 || pylon4 == 10 || pylon5 == 29 || pylon6 == 29 || pylon7 == 25 || pylon8 == 25) // CRV-7HE
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                        }
                                                        if (pylon3 == 1 || pylon4 == 1 || pylon3 == 6 || pylon4 == 6 || pylon5 == 19 || pylon6 == 19 || pylon5 == 24 || pylon6 == 24 || pylon7 == 19 || pylon8 == 19 || pylon7 == 20 || pylon8 == 20) // HYDRA
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
                                                        }
                                                        if (pylon3 == 7 || pylon4 == 7 || pylon5 == 25 || pylon6 == 25 || pylon5 == 26 || pylon6 == 26 || pylon7 == 21 || pylon8 == 21 || pylon7 == 22 || pylon8 == 22) // APKWS
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                        }
                                                        if (pylon3 == 8 || pylon4 == 8 || pylon5 == 27 || pylon6 == 27 || pylon7 == 23 || pylon8 == 23) // ZUNI
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "ZUNI HE";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon3 == 10 || pylon4 == 10 || pylon5 == 29 || pylon6 == 29 || pylon7 == 25 || pylon8 == 25) // CRV-7HE
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "CRV-7 HE";
                                                            SuggestedAttack.text = "CCIP On Smoke";
                                                        }
                                                        else if(pylon3 == 1 || pylon4 == 1 || pylon3 == 6 || pylon4 == 6 || pylon5 == 19 || pylon6 == 19 || pylon5 == 24 || pylon6 == 24 || pylon7 == 19 || pylon8 == 19 || pylon7 == 20 || pylon8 == 20) // HYDRA
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
                                                            SuggestedWeapon.text = "HYDRA HE";
                                                            SuggestedAttack.text = "CCIP On Smoke";
                                                        }
                                                        else if (pylon3 == 7 || pylon4 == 7 || pylon5 == 25 || pylon6 == 25 || pylon5 == 26 || pylon6 == 26 || pylon7 == 21 || pylon8 == 21 || pylon7 == 22 || pylon8 == 22) // APKWS
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                            SuggestedWeapon.text = "APKWS HE";
                                                            SuggestedAttack.text = "CCIP On Smoke";
                                                        }
                                                        else if (pylon3 == 8 || pylon4 == 8 || pylon5 == 27 || pylon6 == 27 || pylon7 == 23 || pylon8 == 23) // ZUNI
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "ZUNI HE";
                                                            SuggestedWeapon.text = "ZUNI HE";
                                                            SuggestedAttack.text = "CCIP On Smoke";
                                                        }

                                                        // If all fails - we have no available ordnance for the solution
                                                        else
                                                        {
                                                            AvailableWeapons.text = "NO SUITABLE ORDNANCE";
                                                            SuggestedWeapon.text = "NO SUITABLE ORDNANCE";
                                                            SuggestedAttack.text = "N/A";
                                                        }
                                                        break;
                                                    }
                                                case 2: // Light
                                                    {
                                                        // List Available Weapons
                                                        if (pylon3 == 9 || pylon4 == 9 || pylon5 == 28 || pylon6 == 28 || pylon7 == 24 || pylon8 == 24) // CRV-7FAT
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CRV-7 FAT\n";
                                                        }
                                                        if (pylon3 == 10 || pylon4 == 10 || pylon5 == 29 || pylon6 == 29 || pylon7 == 25 || pylon8 == 25) // CRV-7HE
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                        }
                                                        if (pylon3 == 1 || pylon4 == 1 || pylon3 == 6 || pylon4 == 6 || pylon5 == 19 || pylon6 == 19 || pylon5 == 24 || pylon6 == 24 || pylon7 == 19 || pylon8 == 19 || pylon7 == 20 || pylon8 == 20) // HYDRA
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
                                                        }
                                                        if (pylon3 == 7 || pylon4 == 7 || pylon5 == 25 || pylon6 == 25 || pylon5 == 26 || pylon6 == 26 || pylon7 == 21 || pylon8 == 21 || pylon7 == 22 || pylon8 == 22) // APKWS
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                        }
                                                        if (pylon3 == 8 || pylon4 == 8 || pylon5 == 27 || pylon6 == 27 || pylon7 == 23 || pylon8 == 23) // ZUNI
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "ZUNI HE";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon3 == 9 || pylon4 == 9 || pylon5 == 28 || pylon6 == 28 || pylon7 == 24 || pylon8 == 24) // CRV-7FAT
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "CRV-7 FAT";
                                                            SuggestedAttack.text = "CCIP On Smoke";
                                                        }
                                                        else if (pylon3 == 10 || pylon4 == 10 || pylon5 == 29 || pylon6 == 29 || pylon7 == 25 || pylon8 == 25) // CRV-7HE
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "CRV-7 HE";
                                                            SuggestedAttack.text = "CCIP On Smoke";
                                                        }
                                                        else if (pylon3 == 1 || pylon4 == 1 || pylon3 == 6 || pylon4 == 6 || pylon5 == 19 || pylon6 == 19 || pylon5 == 24 || pylon6 == 24 || pylon7 == 19 || pylon8 == 19 || pylon7 == 20 || pylon8 == 20) // HYDRA
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
                                                            SuggestedWeapon.text = "HYDRA HE";
                                                            SuggestedAttack.text = "CCIP On Smoke";
                                                        }
                                                        else if (pylon3 == 7 || pylon4 == 7 || pylon5 == 25 || pylon6 == 25 || pylon5 == 26 || pylon6 == 26 || pylon7 == 21 || pylon8 == 21 || pylon7 == 22 || pylon8 == 22) // APKWS
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                            SuggestedWeapon.text = "APKWS HE";
                                                            SuggestedAttack.text = "CCIP On Smoke";
                                                        }
                                                        else if (pylon3 == 8 || pylon4 == 8 || pylon5 == 27 || pylon6 == 27 || pylon7 == 23 || pylon8 == 23) // ZUNI
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "ZUNI HE";
                                                            SuggestedWeapon.text = "ZUNI HE";
                                                            SuggestedAttack.text = "CCIP On Smoke";
                                                        }

                                                        // If all fails - we have no available ordnance for the solution
                                                        else
                                                        {
                                                            AvailableWeapons.text = "NO SUITABLE ORDNANCE";
                                                            SuggestedWeapon.text = "NO SUITABLE ORDNANCE";
                                                            SuggestedAttack.text = "N/A";
                                                        }
                                                        break;
                                                    }
                                            }
                                            break;
                                        }
                                    case 2: // laser
                                        {
                                            AvailableWeapons.text = "GAU-8 30mm Cannon";
                                            SuggestedWeapon.text = "GAU-8 30mm Cannon";
                                            SuggestedAttack.text = "CCIP On Laser Point";
                                            break;
                                        }
                                    case 3: // no mark
                                        {
                                            AvailableWeapons.text = "GAU-8 30mm Cannon";
                                            SuggestedWeapon.text = "GAU-8 30mm Cannon";
                                            SuggestedAttack.text = "Visual CCIP";
                                            break;
                                        }
                                    case 4: // ir pointer
                                        {
                                            AvailableWeapons.text = "GAU-8 30mm Cannon";
                                            SuggestedWeapon.text = "GAU-8 30mm Cannon";
                                            SuggestedAttack.text = "CCIP On IR Point";
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                    break;
                }
        }
        /*aircraft = PlayerPrefs.GetInt("CASAssistAirframeToken");
        pylon1 = PlayerPrefs.GetInt("CASAssistPylon1");
        pylon2 = PlayerPrefs.GetInt("CASAssistPylon2");
        pylon3 = PlayerPrefs.GetInt("CASAssistPylon3");
        pylon4 = PlayerPrefs.GetInt("CASAssistPylon4");
        pylon5 = PlayerPrefs.GetInt("CASAssistPylon5");
        pylon6 = PlayerPrefs.GetInt("CASAssistPylon6");
        pylon7 = PlayerPrefs.GetInt("CASAssistPylon7");
        pylon8 = PlayerPrefs.GetInt("CASAssistPylon8");
        pylon9 = PlayerPrefs.GetInt("CASAssistPylon9");
        pylon10 = PlayerPrefs.GetInt("CASAssistPylon10");
        pylon11 = PlayerPrefs.GetInt("CASAssistPylon11");
        pylon12 = PlayerPrefs.GetInt("CASAssistPylon12");
        pylon13 = PlayerPrefs.GetInt("CASAssistPylon13");
        pylon14 = PlayerPrefs.GetInt("CASAssistPylon14");*/
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
        for (int i = 0; i <= NotesCounter; i++)
        {
            s = PlayerPrefs.GetString("Liner6Notes " + counter);
            s = s + "\n";
            Notes.text = Notes.text + s;
            counter++;
        };

        Debug.Log("CAS Assist Display Panel loading complete");
    }
    
    // Button Functions
    public void TaskCompleteClicked()
    {
        // Destroy this panel to show previous
        ParentPanelRef = ParentPanel.transform.Find("Main Canvas").gameObject;
        ParentPanelRef.SetActive(true);
        Destroy(Panel);
        PlayerPrefs.DeleteKey("Liner6Grid");
        PlayerPrefs.DeleteKey("Liner6cTab");
        PlayerPrefs.DeleteKey("Liner6Type");
        PlayerPrefs.DeleteKey("Liner6Ord");
        PlayerPrefs.DeleteKey("Liner6Ingress");
        PlayerPrefs.DeleteKey("Liner6Marking");
        PlayerPrefs.DeleteKey("Liner6Egress");
        int counter = 0;
        for (int i = 0; i <= NotesCounter; i++)
        {
            PlayerPrefs.DeleteKey("Liner6Notes " + counter);
            counter++;
        };
        PlayerPrefs.DeleteKey("Liner6NotesCount");
        Debug.Log("CAS Assist Display Panel: Destory CAS Assist Display Panel");
    }

    public void QuitButtonClicked()
    {
        // Load Quit Panel
        Instantiate(QuitPanel);
        Debug.Log("CAS Assist Display Panel: Load Quit Panel");
    }
}
