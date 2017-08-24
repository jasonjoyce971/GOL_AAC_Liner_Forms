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
        /////////////////////
        // Main Payload Logic
        /////////////////////

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
                                                            SuggestedAttack.text = "Self Des Laser";
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
                                                            SuggestedAttack.text = "Self Des Laser";
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
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon3 == 10 || pylon4 == 10 || pylon5 == 29 || pylon6 == 29 || pylon7 == 25 || pylon8 == 25) // CRV-7HE
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "CRV-7 HE";
                                                            SuggestedAttack.text = "Self Des Laser";
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
                                                            SuggestedAttack.text = "Self Des Laser";
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
                                                case 3: // Heavy
                                                    {
                                                        // List Available Weapons
                                                        if (pylon3 == 11 || pylon4 == 11 || pylon5 == 30 || pylon6 == 30 || pylon7 == 26 || pylon8 == 26) // CRV-7KEP
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CRV-7 KEP\n";
                                                        }
                                                        if (pylon3 == 9 || pylon4 == 9 || pylon5 == 28 || pylon6 == 28 || pylon7 == 24 || pylon8 == 24) // CRV-7FAT
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CRV-7 FAT\n";
                                                        }
                                                        if (pylon3 == 10 || pylon4 == 10 || pylon5 == 29 || pylon6 == 29 || pylon7 == 25 || pylon8 == 25) // CRV-7HE
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                        }
                                                        if (pylon3 == 8 || pylon4 == 8 || pylon5 == 27 || pylon6 == 27 || pylon7 == 23 || pylon8 == 23) // ZUNI
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "ZUNI HE";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon3 == 11 || pylon4 == 11 || pylon5 == 30 || pylon6 == 30 || pylon7 == 26 || pylon8 == 26) // CRV-7KEP
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "CRV-7 KEP";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon3 == 9 || pylon4 == 9 || pylon5 == 28 || pylon6 == 28 || pylon7 == 24 || pylon8 == 24) // CRV-7FAT
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "CRV-7 FAT";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon3 == 10 || pylon4 == 10 || pylon5 == 29 || pylon6 == 29 || pylon7 == 25 || pylon8 == 25) // CRV-7HE
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "CRV-7 HE";
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
                                                case 4: // Static
                                                    {
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
                                                            SuggestedAttack.text = "Self Des Laser";
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
                                                            SuggestedAttack.text = "Self Des Laser";
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
                                            switch (TypeDropdown)
                                            {
                                                case 1: // Infantry
                                                    {
                                                        // List Available Weapons
                                                        if (pylon3 == 10 || pylon4 == 10 || pylon5 == 29 || pylon6 == 29 || pylon7 == 25 || pylon8 == 25) // CRV-7HE
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                        }
                                                        if (pylon3 == 7 || pylon4 == 7 || pylon5 == 25 || pylon6 == 25 || pylon5 == 26 || pylon6 == 26 || pylon7 == 21 || pylon8 == 21 || pylon7 == 22 || pylon8 == 22) // APKWS
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                        }
                                                        if (pylon3 == 1 || pylon4 == 1 || pylon3 == 6 || pylon4 == 6 || pylon5 == 19 || pylon6 == 19 || pylon5 == 24 || pylon6 == 24 || pylon7 == 19 || pylon8 == 19 || pylon7 == 20 || pylon8 == 20) // HYDRA
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
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
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon3 == 7 || pylon4 == 7 || pylon5 == 25 || pylon6 == 25 || pylon5 == 26 || pylon6 == 26 || pylon7 == 21 || pylon8 == 21 || pylon7 == 22 || pylon8 == 22) // APKWS
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                            SuggestedWeapon.text = "APKWS HE";
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon3 == 1 || pylon4 == 1 || pylon3 == 6 || pylon4 == 6 || pylon5 == 19 || pylon6 == 19 || pylon5 == 24 || pylon6 == 24 || pylon7 == 19 || pylon8 == 19 || pylon7 == 20 || pylon8 == 20) // HYDRA
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
                                                            SuggestedWeapon.text = "HYDRA HE";
                                                            SuggestedAttack.text = "CCIP On Laser Point";
                                                        }
                                                        else if (pylon3 == 8 || pylon4 == 8 || pylon5 == 27 || pylon6 == 27 || pylon7 == 23 || pylon8 == 23) // ZUNI
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "ZUNI HE";
                                                            SuggestedWeapon.text = "ZUNI HE";
                                                            SuggestedAttack.text = "CCIP On Laser Point";
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
                                                        if (pylon3 == 7 || pylon4 == 7 || pylon5 == 25 || pylon6 == 25 || pylon5 == 26 || pylon6 == 26 || pylon7 == 21 || pylon8 == 21 || pylon7 == 22 || pylon8 == 22) // APKWS
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                        }
                                                        if (pylon3 == 1 || pylon4 == 1 || pylon3 == 6 || pylon4 == 6 || pylon5 == 19 || pylon6 == 19 || pylon5 == 24 || pylon6 == 24 || pylon7 == 19 || pylon8 == 19 || pylon7 == 20 || pylon8 == 20) // HYDRA
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
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
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon3 == 10 || pylon4 == 10 || pylon5 == 29 || pylon6 == 29 || pylon7 == 25 || pylon8 == 25) // CRV-7HE
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "CRV-7 HE";
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon3 == 7 || pylon4 == 7 || pylon5 == 25 || pylon6 == 25 || pylon5 == 26 || pylon6 == 26 || pylon7 == 21 || pylon8 == 21 || pylon7 == 22 || pylon8 == 22) // APKWS
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                            SuggestedWeapon.text = "APKWS HE";
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon3 == 1 || pylon4 == 1 || pylon3 == 6 || pylon4 == 6 || pylon5 == 19 || pylon6 == 19 || pylon5 == 24 || pylon6 == 24 || pylon7 == 19 || pylon8 == 19 || pylon7 == 20 || pylon8 == 20) // HYDRA
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
                                                            SuggestedWeapon.text = "HYDRA HE";
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
                                                case 3: // Heavy
                                                    {
                                                        // List Available Weapons
                                                        if (pylon3 == 11 || pylon4 == 11 || pylon5 == 30 || pylon6 == 30 || pylon7 == 26 || pylon8 == 26) // CRV-7KEP
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CRV-7 KEP\n";
                                                        }
                                                        if (pylon3 == 9 || pylon4 == 9 || pylon5 == 28 || pylon6 == 28 || pylon7 == 24 || pylon8 == 24) // CRV-7FAT
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CRV-7 FAT\n";
                                                        }
                                                        if (pylon3 == 10 || pylon4 == 10 || pylon5 == 29 || pylon6 == 29 || pylon7 == 25 || pylon8 == 25) // CRV-7HE
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                        }
                                                        if (pylon3 == 8 || pylon4 == 8 || pylon5 == 27 || pylon6 == 27 || pylon7 == 23 || pylon8 == 23) // ZUNI
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "ZUNI HE";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon3 == 11 || pylon4 == 11 || pylon5 == 30 || pylon6 == 30 || pylon7 == 26 || pylon8 == 26) // CRV-7KEP
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "CRV-7 KEP";
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon3 == 9 || pylon4 == 9 || pylon5 == 28 || pylon6 == 28 || pylon7 == 24 || pylon8 == 24) // CRV-7FAT
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "CRV-7 FAT";
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon3 == 10 || pylon4 == 10 || pylon5 == 29 || pylon6 == 29 || pylon7 == 25 || pylon8 == 25) // CRV-7HE
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "CRV-7 HE";
                                                            SuggestedAttack.text = "Laser Lock";
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
                                                case 4: // Static
                                                    {
                                                        if (pylon3 == 10 || pylon4 == 10 || pylon5 == 29 || pylon6 == 29 || pylon7 == 25 || pylon8 == 25) // CRV-7HE
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                        }
                                                        if (pylon3 == 7 || pylon4 == 7 || pylon5 == 25 || pylon6 == 25 || pylon5 == 26 || pylon6 == 26 || pylon7 == 21 || pylon8 == 21 || pylon7 == 22 || pylon8 == 22) // APKWS
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                        }
                                                        if (pylon3 == 1 || pylon4 == 1 || pylon3 == 6 || pylon4 == 6 || pylon5 == 19 || pylon6 == 19 || pylon5 == 24 || pylon6 == 24 || pylon7 == 19 || pylon8 == 19 || pylon7 == 20 || pylon8 == 20) // HYDRA
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
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
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon3 == 7 || pylon4 == 7 || pylon5 == 25 || pylon6 == 25 || pylon5 == 26 || pylon6 == 26 || pylon7 == 21 || pylon8 == 21 || pylon7 == 22 || pylon8 == 22) // APKWS
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                            SuggestedWeapon.text = "APKWS HE";
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon3 == 1 || pylon4 == 1 || pylon3 == 6 || pylon4 == 6 || pylon5 == 19 || pylon6 == 19 || pylon5 == 24 || pylon6 == 24 || pylon7 == 19 || pylon8 == 19 || pylon7 == 20 || pylon8 == 20) // HYDRA
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
                                                            SuggestedWeapon.text = "HYDRA HE";
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
                                    case 3: // no mark
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
                                                        if (pylon3 == 7 || pylon4 == 7 || pylon5 == 25 || pylon6 == 25 || pylon5 == 26 || pylon6 == 26 || pylon7 == 21 || pylon8 == 21 || pylon7 == 22 || pylon8 == 22) // APKWS
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                        }
                                                        if (pylon3 == 1 || pylon4 == 1 || pylon3 == 6 || pylon4 == 6 || pylon5 == 19 || pylon6 == 19 || pylon5 == 24 || pylon6 == 24 || pylon7 == 19 || pylon8 == 19 || pylon7 == 20 || pylon8 == 20) // HYDRA
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
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
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon3 == 7 || pylon4 == 7 || pylon5 == 25 || pylon6 == 25 || pylon5 == 26 || pylon6 == 26 || pylon7 == 21 || pylon8 == 21 || pylon7 == 22 || pylon8 == 22) // APKWS
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                            SuggestedWeapon.text = "APKWS HE";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon3 == 1 || pylon4 == 1 || pylon3 == 6 || pylon4 == 6 || pylon5 == 19 || pylon6 == 19 || pylon5 == 24 || pylon6 == 24 || pylon7 == 19 || pylon8 == 19 || pylon7 == 20 || pylon8 == 20) // HYDRA
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
                                                            SuggestedWeapon.text = "HYDRA HE";
                                                            SuggestedAttack.text = "Visual CCIP";
                                                        }
                                                        else if (pylon3 == 8 || pylon4 == 8 || pylon5 == 27 || pylon6 == 27 || pylon7 == 23 || pylon8 == 23) // ZUNI
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "ZUNI HE";
                                                            SuggestedWeapon.text = "ZUNI HE";
                                                            SuggestedAttack.text = "Visual CCIP";
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
                                                        if (pylon3 == 7 || pylon4 == 7 || pylon5 == 25 || pylon6 == 25 || pylon5 == 26 || pylon6 == 26 || pylon7 == 21 || pylon8 == 21 || pylon7 == 22 || pylon8 == 22) // APKWS
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                        }
                                                        if (pylon3 == 1 || pylon4 == 1 || pylon3 == 6 || pylon4 == 6 || pylon5 == 19 || pylon6 == 19 || pylon5 == 24 || pylon6 == 24 || pylon7 == 19 || pylon8 == 19 || pylon7 == 20 || pylon8 == 20) // HYDRA
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
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
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon3 == 10 || pylon4 == 10 || pylon5 == 29 || pylon6 == 29 || pylon7 == 25 || pylon8 == 25) // CRV-7HE
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "CRV-7 HE";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon3 == 7 || pylon4 == 7 || pylon5 == 25 || pylon6 == 25 || pylon5 == 26 || pylon6 == 26 || pylon7 == 21 || pylon8 == 21 || pylon7 == 22 || pylon8 == 22) // APKWS
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                            SuggestedWeapon.text = "APKWS HE";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon3 == 1 || pylon4 == 1 || pylon3 == 6 || pylon4 == 6 || pylon5 == 19 || pylon6 == 19 || pylon5 == 24 || pylon6 == 24 || pylon7 == 19 || pylon8 == 19 || pylon7 == 20 || pylon8 == 20) // HYDRA
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
                                                            SuggestedWeapon.text = "HYDRA HE";
                                                            SuggestedAttack.text = "Visual CCIP";
                                                        }
                                                        else if (pylon3 == 8 || pylon4 == 8 || pylon5 == 27 || pylon6 == 27 || pylon7 == 23 || pylon8 == 23) // ZUNI
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "ZUNI HE";
                                                            SuggestedWeapon.text = "ZUNI HE";
                                                            SuggestedAttack.text = "Visual CCIP";
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
                                                case 3: // Heavy
                                                    {
                                                        // List Available Weapons
                                                        if (pylon3 == 11 || pylon4 == 11 || pylon5 == 30 || pylon6 == 30 || pylon7 == 26 || pylon8 == 26) // CRV-7KEP
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CRV-7 KEP\n";
                                                        }
                                                        if (pylon3 == 9 || pylon4 == 9 || pylon5 == 28 || pylon6 == 28 || pylon7 == 24 || pylon8 == 24) // CRV-7FAT
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CRV-7 FAT\n";
                                                        }
                                                        if (pylon3 == 10 || pylon4 == 10 || pylon5 == 29 || pylon6 == 29 || pylon7 == 25 || pylon8 == 25) // CRV-7HE
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                        }
                                                        if (pylon3 == 8 || pylon4 == 8 || pylon5 == 27 || pylon6 == 27 || pylon7 == 23 || pylon8 == 23) // ZUNI
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "ZUNI HE";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon3 == 11 || pylon4 == 11 || pylon5 == 30 || pylon6 == 30 || pylon7 == 26 || pylon8 == 26) // CRV-7KEP
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "CRV-7 KEP";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon3 == 9 || pylon4 == 9 || pylon5 == 28 || pylon6 == 28 || pylon7 == 24 || pylon8 == 24) // CRV-7FAT
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "CRV-7 FAT";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon3 == 10 || pylon4 == 10 || pylon5 == 29 || pylon6 == 29 || pylon7 == 25 || pylon8 == 25) // CRV-7HE
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "CRV-7 HE";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon3 == 8 || pylon4 == 8 || pylon5 == 27 || pylon6 == 27 || pylon7 == 23 || pylon8 == 23) // ZUNI
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "ZUNI HE";
                                                            SuggestedWeapon.text = "ZUNI HE";
                                                            SuggestedAttack.text = "Visual CCIP";
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
                                                case 4: // Static
                                                    {
                                                        if (pylon3 == 10 || pylon4 == 10 || pylon5 == 29 || pylon6 == 29 || pylon7 == 25 || pylon8 == 25) // CRV-7HE
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                        }
                                                        if (pylon3 == 7 || pylon4 == 7 || pylon5 == 25 || pylon6 == 25 || pylon5 == 26 || pylon6 == 26 || pylon7 == 21 || pylon8 == 21 || pylon7 == 22 || pylon8 == 22) // APKWS
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                        }
                                                        if (pylon3 == 1 || pylon4 == 1 || pylon3 == 6 || pylon4 == 6 || pylon5 == 19 || pylon6 == 19 || pylon5 == 24 || pylon6 == 24 || pylon7 == 19 || pylon8 == 19 || pylon7 == 20 || pylon8 == 20) // HYDRA
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
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
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon3 == 7 || pylon4 == 7 || pylon5 == 25 || pylon6 == 25 || pylon5 == 26 || pylon6 == 26 || pylon7 == 21 || pylon8 == 21 || pylon7 == 22 || pylon8 == 22) // APKWS
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                            SuggestedWeapon.text = "APKWS HE";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon3 == 1 || pylon4 == 1 || pylon3 == 6 || pylon4 == 6 || pylon5 == 19 || pylon6 == 19 || pylon5 == 24 || pylon6 == 24 || pylon7 == 19 || pylon8 == 19 || pylon7 == 20 || pylon8 == 20) // HYDRA
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
                                                            SuggestedWeapon.text = "HYDRA HE";
                                                            SuggestedAttack.text = "Visual CCIP";
                                                        }
                                                        else if (pylon3 == 8 || pylon4 == 8 || pylon5 == 27 || pylon6 == 27 || pylon7 == 23 || pylon8 == 23) // ZUNI
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "ZUNI HE";
                                                            SuggestedWeapon.text = "ZUNI HE";
                                                            SuggestedAttack.text = "Visual CCIP";
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
                                    case 4: // ir pointer
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
                                                        if (pylon3 == 7 || pylon4 == 7 || pylon5 == 25 || pylon6 == 25 || pylon5 == 26 || pylon6 == 26 || pylon7 == 21 || pylon8 == 21 || pylon7 == 22 || pylon8 == 22) // APKWS
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                        }
                                                        if (pylon3 == 1 || pylon4 == 1 || pylon3 == 6 || pylon4 == 6 || pylon5 == 19 || pylon6 == 19 || pylon5 == 24 || pylon6 == 24 || pylon7 == 19 || pylon8 == 19 || pylon7 == 20 || pylon8 == 20) // HYDRA
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
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
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon3 == 7 || pylon4 == 7 || pylon5 == 25 || pylon6 == 25 || pylon5 == 26 || pylon6 == 26 || pylon7 == 21 || pylon8 == 21 || pylon7 == 22 || pylon8 == 22) // APKWS
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                            SuggestedWeapon.text = "APKWS HE";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon3 == 1 || pylon4 == 1 || pylon3 == 6 || pylon4 == 6 || pylon5 == 19 || pylon6 == 19 || pylon5 == 24 || pylon6 == 24 || pylon7 == 19 || pylon8 == 19 || pylon7 == 20 || pylon8 == 20) // HYDRA
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
                                                            SuggestedWeapon.text = "HYDRA HE";
                                                            SuggestedAttack.text = "CCIP on IR Point";
                                                        }
                                                        else if (pylon3 == 8 || pylon4 == 8 || pylon5 == 27 || pylon6 == 27 || pylon7 == 23 || pylon8 == 23) // ZUNI
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "ZUNI HE";
                                                            SuggestedWeapon.text = "ZUNI HE";
                                                            SuggestedAttack.text = "CCIP on IR Point";
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
                                                        if (pylon3 == 7 || pylon4 == 7 || pylon5 == 25 || pylon6 == 25 || pylon5 == 26 || pylon6 == 26 || pylon7 == 21 || pylon8 == 21 || pylon7 == 22 || pylon8 == 22) // APKWS
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                        }
                                                        if (pylon3 == 1 || pylon4 == 1 || pylon3 == 6 || pylon4 == 6 || pylon5 == 19 || pylon6 == 19 || pylon5 == 24 || pylon6 == 24 || pylon7 == 19 || pylon8 == 19 || pylon7 == 20 || pylon8 == 20) // HYDRA
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
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
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon3 == 10 || pylon4 == 10 || pylon5 == 29 || pylon6 == 29 || pylon7 == 25 || pylon8 == 25) // CRV-7HE
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "CRV-7 HE";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon3 == 7 || pylon4 == 7 || pylon5 == 25 || pylon6 == 25 || pylon5 == 26 || pylon6 == 26 || pylon7 == 21 || pylon8 == 21 || pylon7 == 22 || pylon8 == 22) // APKWS
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                            SuggestedWeapon.text = "APKWS HE";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon3 == 1 || pylon4 == 1 || pylon3 == 6 || pylon4 == 6 || pylon5 == 19 || pylon6 == 19 || pylon5 == 24 || pylon6 == 24 || pylon7 == 19 || pylon8 == 19 || pylon7 == 20 || pylon8 == 20) // HYDRA
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
                                                            SuggestedWeapon.text = "HYDRA HE";
                                                            SuggestedAttack.text = "CCIP on IR Point";
                                                        }
                                                        else if (pylon3 == 8 || pylon4 == 8 || pylon5 == 27 || pylon6 == 27 || pylon7 == 23 || pylon8 == 23) // ZUNI
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "ZUNI HE";
                                                            SuggestedWeapon.text = "ZUNI HE";
                                                            SuggestedAttack.text = "CCIP on IR Point";
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
                                                case 3: // Heavy
                                                    {
                                                        // List Available Weapons
                                                        if (pylon3 == 11 || pylon4 == 11 || pylon5 == 30 || pylon6 == 30 || pylon7 == 26 || pylon8 == 26) // CRV-7KEP
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CRV-7 KEP\n";
                                                        }
                                                        if (pylon3 == 9 || pylon4 == 9 || pylon5 == 28 || pylon6 == 28 || pylon7 == 24 || pylon8 == 24) // CRV-7FAT
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CRV-7 FAT\n";
                                                        }
                                                        if (pylon3 == 10 || pylon4 == 10 || pylon5 == 29 || pylon6 == 29 || pylon7 == 25 || pylon8 == 25) // CRV-7HE
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                        }
                                                        if (pylon3 == 8 || pylon4 == 8 || pylon5 == 27 || pylon6 == 27 || pylon7 == 23 || pylon8 == 23) // ZUNI
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "ZUNI HE";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon3 == 11 || pylon4 == 11 || pylon5 == 30 || pylon6 == 30 || pylon7 == 26 || pylon8 == 26) // CRV-7KEP
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "CRV-7 KEP";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon3 == 9 || pylon4 == 9 || pylon5 == 28 || pylon6 == 28 || pylon7 == 24 || pylon8 == 24) // CRV-7FAT
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "CRV-7 FAT";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon3 == 10 || pylon4 == 10 || pylon5 == 29 || pylon6 == 29 || pylon7 == 25 || pylon8 == 25) // CRV-7HE
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "CRV-7 HE";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon3 == 8 || pylon4 == 8 || pylon5 == 27 || pylon6 == 27 || pylon7 == 23 || pylon8 == 23) // ZUNI
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "ZUNI HE";
                                                            SuggestedWeapon.text = "ZUNI HE";
                                                            SuggestedAttack.text = "CCIP on IR Point";
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
                                                case 4: // Static
                                                    {
                                                        if (pylon3 == 10 || pylon4 == 10 || pylon5 == 29 || pylon6 == 29 || pylon7 == 25 || pylon8 == 25) // CRV-7HE
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                        }
                                                        if (pylon3 == 7 || pylon4 == 7 || pylon5 == 25 || pylon6 == 25 || pylon5 == 26 || pylon6 == 26 || pylon7 == 21 || pylon8 == 21 || pylon7 == 22 || pylon8 == 22) // APKWS
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                        }
                                                        if (pylon3 == 1 || pylon4 == 1 || pylon3 == 6 || pylon4 == 6 || pylon5 == 19 || pylon6 == 19 || pylon5 == 24 || pylon6 == 24 || pylon7 == 19 || pylon8 == 19 || pylon7 == 20 || pylon8 == 20) // HYDRA
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
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
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon3 == 7 || pylon4 == 7 || pylon5 == 25 || pylon6 == 25 || pylon5 == 26 || pylon6 == 26 || pylon7 == 21 || pylon8 == 21 || pylon7 == 22 || pylon8 == 22) // APKWS
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                            SuggestedWeapon.text = "APKWS HE";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon3 == 1 || pylon4 == 1 || pylon3 == 6 || pylon4 == 6 || pylon5 == 19 || pylon6 == 19 || pylon5 == 24 || pylon6 == 24 || pylon7 == 19 || pylon8 == 19 || pylon7 == 20 || pylon8 == 20) // HYDRA
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
                                                            SuggestedWeapon.text = "HYDRA HE";
                                                            SuggestedAttack.text = "CCIP on IR Point";
                                                        }
                                                        else if (pylon3 == 8 || pylon4 == 8 || pylon5 == 27 || pylon6 == 27 || pylon7 == 23 || pylon8 == 23) // ZUNI
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "ZUNI HE";
                                                            SuggestedWeapon.text = "ZUNI HE";
                                                            SuggestedAttack.text = "CCIP on IR Point";
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
                                }
                                break;
                            }
                    }
                    break;
                }
            case 3: // Missiles
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
                                                        AvailableWeapons.text = "NO SUITABLE ORDNANCE";
                                                        SuggestedWeapon.text = "NO SUITABLE ORDNANCE";
                                                        SuggestedAttack.text = "N/A";
                                                        break;
                                                    }
                                                case 2: // Light
                                                    {
                                                        // List Available Weapons
                                                        if (pylon5 == 35 || pylon6 == 35 || pylon5 == 36 || pylon6 == 36) // AGM-65L
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65L\n";
                                                        }
                                                        if (pylon5 == 31 || pylon6 == 31 || pylon5 == 32 || pylon6 == 32) // AGM-65D
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65D\n";
                                                        }
                                                        if (pylon5 == 33 || pylon6 == 33 || pylon5 == 34 || pylon6 == 34) // AGM-65H
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65H\n";
                                                        }
                                                        if (pylon5 == 37 || pylon6 == 37) // AGM-65G
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65G\n";
                                                        }
                                                        if (pylon5 == 38 || pylon6 == 38) // AGM-65K
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65K";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon5 == 35 || pylon6 == 35 || pylon5 == 36 || pylon6 == 36) // AGM-65L
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "AGM-65L";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon5 == 31 || pylon6 == 31 || pylon5 == 32 || pylon6 == 32) // AGM-65D
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "AGM-65D";
                                                            SuggestedAttack.text = "IR Lock";
                                                        }
                                                        else if (pylon5 == 33 || pylon6 == 33 || pylon5 == 34 || pylon6 == 34) // AGM-65H
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
                                                            SuggestedWeapon.text = "AGM-65H";
                                                            SuggestedAttack.text = "DTV Lock";
                                                        }
                                                        else if (pylon5 == 37 || pylon6 == 37) // AGM-65G
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                            SuggestedWeapon.text = "AGM-65G";
                                                            SuggestedAttack.text = "IR Lock";
                                                        }
                                                        else if (pylon5 == 38 || pylon6 == 38) // AGM-65K
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "ZUNI HE";
                                                            SuggestedWeapon.text = "AGM-65K";
                                                            SuggestedAttack.text = "DTV Lock";
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
                                                case 3: // Heavy
                                                    {
                                                        // List Available Weapons
                                                        if (pylon5 == 35 || pylon6 == 35 || pylon5 == 36 || pylon6 == 36) // AGM-65L
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65L\n";
                                                        }
                                                        if (pylon5 == 31 || pylon6 == 31 || pylon5 == 32 || pylon6 == 32) // AGM-65D
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65D\n";
                                                        }
                                                        if (pylon5 == 33 || pylon6 == 33 || pylon5 == 34 || pylon6 == 34) // AGM-65H
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65H\n";
                                                        }
                                                        if (pylon5 == 37 || pylon6 == 37) // AGM-65G
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65G\n";
                                                        }
                                                        if (pylon5 == 38 || pylon6 == 38) // AGM-65K
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65K";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon5 == 35 || pylon6 == 35 || pylon5 == 36 || pylon6 == 36) // AGM-65L
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "AGM-65L";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon5 == 31 || pylon6 == 31 || pylon5 == 32 || pylon6 == 32) // AGM-65D
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "AGM-65D";
                                                            SuggestedAttack.text = "IR Lock";
                                                        }
                                                        else if (pylon5 == 33 || pylon6 == 33 || pylon5 == 34 || pylon6 == 34) // AGM-65H
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
                                                            SuggestedWeapon.text = "AGM-65H";
                                                            SuggestedAttack.text = "DTV Lock";
                                                        }
                                                        else if (pylon5 == 37 || pylon6 == 37) // AGM-65G
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                            SuggestedWeapon.text = "AGM-65G";
                                                            SuggestedAttack.text = "IR Lock";
                                                        }
                                                        else if (pylon5 == 38 || pylon6 == 38) // AGM-65K
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "ZUNI HE";
                                                            SuggestedWeapon.text = "AGM-65K";
                                                            SuggestedAttack.text = "DTV Lock";
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
                                                case 4: // Static
                                                    {
                                                        // List Available Weapons
                                                        if (pylon5 == 35 || pylon6 == 35 || pylon5 == 36 || pylon6 == 36) // AGM-65L
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65L\n";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon5 == 35 || pylon6 == 35 || pylon5 == 36 || pylon6 == 36) // AGM-65L
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "AGM-65L";
                                                            SuggestedAttack.text = "Self Des Laser";
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
                                            switch (TypeDropdown)
                                            {
                                                case 1: // Infantry
                                                    {
                                                        AvailableWeapons.text = "NO SUITABLE ORDNANCE";
                                                        SuggestedWeapon.text = "NO SUITABLE ORDNANCE";
                                                        SuggestedAttack.text = "N/A";
                                                        break;
                                                    }
                                                case 2: // Light
                                                    {
                                                        // List Available Weapons
                                                        if (pylon5 == 35 || pylon6 == 35 || pylon5 == 36 || pylon6 == 36) // AGM-65L
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65L\n";
                                                        }
                                                        if (pylon5 == 31 || pylon6 == 31 || pylon5 == 32 || pylon6 == 32) // AGM-65D
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65D\n";
                                                        }
                                                        if (pylon5 == 33 || pylon6 == 33 || pylon5 == 34 || pylon6 == 34) // AGM-65H
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65H\n";
                                                        }
                                                        if (pylon5 == 37 || pylon6 == 37) // AGM-65G
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65G\n";
                                                        }
                                                        if (pylon5 == 38 || pylon6 == 38) // AGM-65K
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65K";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon5 == 35 || pylon6 == 35 || pylon5 == 36 || pylon6 == 36) // AGM-65L
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "AGM-65L";
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon5 == 31 || pylon6 == 31 || pylon5 == 32 || pylon6 == 32) // AGM-65D
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "AGM-65D";
                                                            SuggestedAttack.text = "IR Lock";
                                                        }
                                                        else if (pylon5 == 33 || pylon6 == 33 || pylon5 == 34 || pylon6 == 34) // AGM-65H
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
                                                            SuggestedWeapon.text = "AGM-65H";
                                                            SuggestedAttack.text = "DTV Lock";
                                                        }
                                                        else if (pylon5 == 37 || pylon6 == 37) // AGM-65G
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                            SuggestedWeapon.text = "AGM-65G";
                                                            SuggestedAttack.text = "IR Lock";
                                                        }
                                                        else if (pylon5 == 38 || pylon6 == 38) // AGM-65K
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "ZUNI HE";
                                                            SuggestedWeapon.text = "AGM-65K";
                                                            SuggestedAttack.text = "DTV Lock";
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
                                                case 3: // Heavy
                                                    {
                                                        // List Available Weapons
                                                        if (pylon5 == 35 || pylon6 == 35 || pylon5 == 36 || pylon6 == 36) // AGM-65L
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65L\n";
                                                        }
                                                        if (pylon5 == 31 || pylon6 == 31 || pylon5 == 32 || pylon6 == 32) // AGM-65D
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65D\n";
                                                        }
                                                        if (pylon5 == 33 || pylon6 == 33 || pylon5 == 34 || pylon6 == 34) // AGM-65H
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65H\n";
                                                        }
                                                        if (pylon5 == 37 || pylon6 == 37) // AGM-65G
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65G\n";
                                                        }
                                                        if (pylon5 == 38 || pylon6 == 38) // AGM-65K
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65K";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon5 == 35 || pylon6 == 35 || pylon5 == 36 || pylon6 == 36) // AGM-65L
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "AGM-65L";
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon5 == 31 || pylon6 == 31 || pylon5 == 32 || pylon6 == 32) // AGM-65D
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "AGM-65D";
                                                            SuggestedAttack.text = "IR Lock";
                                                        }
                                                        else if (pylon5 == 33 || pylon6 == 33 || pylon5 == 34 || pylon6 == 34) // AGM-65H
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
                                                            SuggestedWeapon.text = "AGM-65H";
                                                            SuggestedAttack.text = "DTV Lock";
                                                        }
                                                        else if (pylon5 == 37 || pylon6 == 37) // AGM-65G
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                            SuggestedWeapon.text = "AGM-65G";
                                                            SuggestedAttack.text = "IR Lock";
                                                        }
                                                        else if (pylon5 == 38 || pylon6 == 38) // AGM-65K
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "ZUNI HE";
                                                            SuggestedWeapon.text = "AGM-65K";
                                                            SuggestedAttack.text = "DTV Lock";
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
                                                case 4: // Static
                                                    {
                                                        // List Available Weapons
                                                        if (pylon5 == 35 || pylon6 == 35 || pylon5 == 36 || pylon6 == 36) // AGM-65L
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65L\n";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon5 == 35 || pylon6 == 35 || pylon5 == 36 || pylon6 == 36) // AGM-65L
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "AGM-65L";
                                                            SuggestedAttack.text = "Laser Lock";
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
                                    case 3: // no mark
                                        {
                                            switch (TypeDropdown)
                                            {
                                                case 1: // Infantry
                                                    {
                                                        AvailableWeapons.text = "NO SUITABLE ORDNANCE";
                                                        SuggestedWeapon.text = "NO SUITABLE ORDNANCE";
                                                        SuggestedAttack.text = "N/A";
                                                        break;
                                                    }
                                                case 2: // Light
                                                    {
                                                        // List Available Weapons
                                                        if (pylon5 == 35 || pylon6 == 35 || pylon5 == 36 || pylon6 == 36) // AGM-65L
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65L\n";
                                                        }
                                                        if (pylon5 == 31 || pylon6 == 31 || pylon5 == 32 || pylon6 == 32) // AGM-65D
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65D\n";
                                                        }
                                                        if (pylon5 == 33 || pylon6 == 33 || pylon5 == 34 || pylon6 == 34) // AGM-65H
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65H\n";
                                                        }
                                                        if (pylon5 == 37 || pylon6 == 37) // AGM-65G
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65G\n";
                                                        }
                                                        if (pylon5 == 38 || pylon6 == 38) // AGM-65K
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65K";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon5 == 35 || pylon6 == 35 || pylon5 == 36 || pylon6 == 36) // AGM-65L
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "AGM-65L";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon5 == 31 || pylon6 == 31 || pylon5 == 32 || pylon6 == 32) // AGM-65D
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "AGM-65D";
                                                            SuggestedAttack.text = "IR Lock";
                                                        }
                                                        else if (pylon5 == 33 || pylon6 == 33 || pylon5 == 34 || pylon6 == 34) // AGM-65H
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
                                                            SuggestedWeapon.text = "AGM-65H";
                                                            SuggestedAttack.text = "DTV Lock";
                                                        }
                                                        else if (pylon5 == 37 || pylon6 == 37) // AGM-65G
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                            SuggestedWeapon.text = "AGM-65G";
                                                            SuggestedAttack.text = "IR Lock";
                                                        }
                                                        else if (pylon5 == 38 || pylon6 == 38) // AGM-65K
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "ZUNI HE";
                                                            SuggestedWeapon.text = "AGM-65K";
                                                            SuggestedAttack.text = "DTV Lock";
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
                                                case 3: // Heavy
                                                    {
                                                        // List Available Weapons
                                                        if (pylon5 == 35 || pylon6 == 35 || pylon5 == 36 || pylon6 == 36) // AGM-65L
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65L\n";
                                                        }
                                                        if (pylon5 == 31 || pylon6 == 31 || pylon5 == 32 || pylon6 == 32) // AGM-65D
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65D\n";
                                                        }
                                                        if (pylon5 == 33 || pylon6 == 33 || pylon5 == 34 || pylon6 == 34) // AGM-65H
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65H\n";
                                                        }
                                                        if (pylon5 == 37 || pylon6 == 37) // AGM-65G
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65G\n";
                                                        }
                                                        if (pylon5 == 38 || pylon6 == 38) // AGM-65K
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65K";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon5 == 35 || pylon6 == 35 || pylon5 == 36 || pylon6 == 36) // AGM-65L
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "AGM-65L";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon5 == 31 || pylon6 == 31 || pylon5 == 32 || pylon6 == 32) // AGM-65D
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "AGM-65D";
                                                            SuggestedAttack.text = "IR Lock";
                                                        }
                                                        else if (pylon5 == 33 || pylon6 == 33 || pylon5 == 34 || pylon6 == 34) // AGM-65H
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
                                                            SuggestedWeapon.text = "AGM-65H";
                                                            SuggestedAttack.text = "DTV Lock";
                                                        }
                                                        else if (pylon5 == 37 || pylon6 == 37) // AGM-65G
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                            SuggestedWeapon.text = "AGM-65G";
                                                            SuggestedAttack.text = "IR Lock";
                                                        }
                                                        else if (pylon5 == 38 || pylon6 == 38) // AGM-65K
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "ZUNI HE";
                                                            SuggestedWeapon.text = "AGM-65K";
                                                            SuggestedAttack.text = "DTV Lock";
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
                                                case 4: // Static
                                                    {
                                                        // List Available Weapons
                                                        if (pylon5 == 35 || pylon6 == 35 || pylon5 == 36 || pylon6 == 36) // AGM-65L
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65L\n";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon5 == 35 || pylon6 == 35 || pylon5 == 36 || pylon6 == 36) // AGM-65L
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "AGM-65L";
                                                            SuggestedAttack.text = "Self Des Laser";
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
                                    case 4: // ir pointer
                                        {
                                            switch (TypeDropdown)
                                            {
                                                case 1: // Infantry
                                                    {
                                                        AvailableWeapons.text = "NO SUITABLE ORDNANCE";
                                                        SuggestedWeapon.text = "NO SUITABLE ORDNANCE";
                                                        SuggestedAttack.text = "N/A";
                                                        break;
                                                    }
                                                case 2: // Light
                                                    {
                                                        // List Available Weapons
                                                        if (pylon5 == 35 || pylon6 == 35 || pylon5 == 36 || pylon6 == 36) // AGM-65L
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65L\n";
                                                        }
                                                        if (pylon5 == 31 || pylon6 == 31 || pylon5 == 32 || pylon6 == 32) // AGM-65D
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65D\n";
                                                        }
                                                        if (pylon5 == 33 || pylon6 == 33 || pylon5 == 34 || pylon6 == 34) // AGM-65H
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65H\n";
                                                        }
                                                        if (pylon5 == 37 || pylon6 == 37) // AGM-65G
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65G\n";
                                                        }
                                                        if (pylon5 == 38 || pylon6 == 38) // AGM-65K
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65K";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon5 == 35 || pylon6 == 35 || pylon5 == 36 || pylon6 == 36) // AGM-65L
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "AGM-65L";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon5 == 31 || pylon6 == 31 || pylon5 == 32 || pylon6 == 32) // AGM-65D
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "AGM-65D";
                                                            SuggestedAttack.text = "IR Lock";
                                                        }
                                                        else if (pylon5 == 33 || pylon6 == 33 || pylon5 == 34 || pylon6 == 34) // AGM-65H
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
                                                            SuggestedWeapon.text = "AGM-65H";
                                                            SuggestedAttack.text = "DTV Lock";
                                                        }
                                                        else if (pylon5 == 37 || pylon6 == 37) // AGM-65G
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                            SuggestedWeapon.text = "AGM-65G";
                                                            SuggestedAttack.text = "IR Lock";
                                                        }
                                                        else if (pylon5 == 38 || pylon6 == 38) // AGM-65K
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "ZUNI HE";
                                                            SuggestedWeapon.text = "AGM-65K";
                                                            SuggestedAttack.text = "DTV Lock";
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
                                                case 3: // Heavy
                                                    {
                                                        // List Available Weapons
                                                        if (pylon5 == 35 || pylon6 == 35 || pylon5 == 36 || pylon6 == 36) // AGM-65L
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65L\n";
                                                        }
                                                        if (pylon5 == 31 || pylon6 == 31 || pylon5 == 32 || pylon6 == 32) // AGM-65D
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65D\n";
                                                        }
                                                        if (pylon5 == 33 || pylon6 == 33 || pylon5 == 34 || pylon6 == 34) // AGM-65H
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65H\n";
                                                        }
                                                        if (pylon5 == 37 || pylon6 == 37) // AGM-65G
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65G\n";
                                                        }
                                                        if (pylon5 == 38 || pylon6 == 38) // AGM-65K
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65K";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon5 == 35 || pylon6 == 35 || pylon5 == 36 || pylon6 == 36) // AGM-65L
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "AGM-65L";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon5 == 31 || pylon6 == 31 || pylon5 == 32 || pylon6 == 32) // AGM-65D
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "AGM-65D";
                                                            SuggestedAttack.text = "IR Lock";
                                                        }
                                                        else if (pylon5 == 33 || pylon6 == 33 || pylon5 == 34 || pylon6 == 34) // AGM-65H
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "HYDRA HE\n";
                                                            SuggestedWeapon.text = "AGM-65H";
                                                            SuggestedAttack.text = "DTV Lock";
                                                        }
                                                        else if (pylon5 == 37 || pylon6 == 37) // AGM-65G
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "APKWS HE\n";
                                                            SuggestedWeapon.text = "AGM-65G";
                                                            SuggestedAttack.text = "IR Lock";
                                                        }
                                                        else if (pylon5 == 38 || pylon6 == 38) // AGM-65K
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "ZUNI HE";
                                                            SuggestedWeapon.text = "AGM-65K";
                                                            SuggestedAttack.text = "DTV Lock";
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
                                                case 4: // Static
                                                    {
                                                        // List Available Weapons
                                                        if (pylon5 == 35 || pylon6 == 35 || pylon5 == 36 || pylon6 == 36) // AGM-65L
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "AGM-65L\n";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon5 == 35 || pylon6 == 35 || pylon5 == 36 || pylon6 == 36) // AGM-65L
                                                        {
                                                            //AvailableWeapons.text = AvailableWeapons.text + "CRV-7 HE\n";
                                                            SuggestedWeapon.text = "AGM-65L";
                                                            SuggestedAttack.text = "Self Des Laser";
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
                                }
                                break;
                            }
                    }
                    break;
                }
            case 4: // Bombs
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
                                                        // List Available Weapons (runs all from most useful to least)
                                                        if (pylon5 == 9 || pylon6 == 9 || pylon7 == 9 || pylon8 == 9 || pylon9 == 7 || pylon10 == 7) // CBU-103
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-103\n";
                                                        }
                                                        if (pylon1 == 4 || pylon2 == 4 || pylon3 == 14 || pylon4 == 14 || pylon5 == 6 || pylon6 == 6 || pylon7 == 6 || pylon8 == 6 || pylon9 == 4 || pylon10 == 4 || pylon11 == 4) // CBU-87
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-87\n";
                                                        }
                                                        if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 ||  pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "EGBU-12\n";
                                                        }
                                                        if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-54";
                                                        }
                                                        if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-38";
                                                        }
                                                        if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-31";
                                                        }
                                                        if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-12";
                                                        }
                                                        if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-10";
                                                        }
                                                        if (pylon1 == 3 || pylon2 == 3|| pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 GPB";
                                                        }
                                                        if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 AIR";
                                                        }
                                                        if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5  || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk84 GPB";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon5 == 9 || pylon6 == 9 || pylon7 == 9 || pylon8 == 9 || pylon9 == 7 || pylon10 == 7) // CBU-103
                                                        {
                                                            SuggestedWeapon.text = "CBU-103";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 4 || pylon2 == 4 || pylon3 == 14 || pylon4 == 14 || pylon5 == 6 || pylon6 == 6 || pylon7 == 6 || pylon8 == 6 || pylon9 == 4 || pylon10 == 4 || pylon11 == 4) // CBU-87
                                                        {
                                                            SuggestedWeapon.text = "CBU-87";
                                                            SuggestedAttack.text = "CCIP On Smoke";
                                                        }
                                                        else if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            SuggestedWeapon.text = "EGBU-12";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            SuggestedWeapon.text = "GBU-54";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            SuggestedWeapon.text = "GBU-38";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            SuggestedWeapon.text = "GBU-31";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            SuggestedWeapon.text = "GBU-12";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            SuggestedWeapon.text = "GBU-10";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            SuggestedWeapon.text = "Mk82 GPB";
                                                            SuggestedAttack.text = "CCIP On Smoke";
                                                        }
                                                        else if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            SuggestedWeapon.text = "Mk82 AIR";
                                                            SuggestedAttack.text = "CCIP On Smoke";
                                                        }
                                                        else if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            SuggestedWeapon.text = "Mk84 GPB";
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
                                                        // List Available Weapons (runs all from most useful to least)
                                                        if (pylon5 == 10 || pylon6 == 10 || pylon7 == 10 || pylon8 == 10 || pylon9 == 8 || pylon10 == 8) // CBU-105
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-105\n";
                                                        }
                                                        if (pylon5 == 9 || pylon6 == 9 || pylon7 == 9 || pylon8 == 9 || pylon9 == 7 || pylon10 == 7) // CBU-103
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-103\n";
                                                        }
                                                        if (pylon1 == 6 || pylon2 == 6 || pylon3 == 16 || pylon4 == 16 || pylon5 == 8 || pylon6 == 8 || pylon7 == 8 || pylon8 == 8 || pylon9 == 6 || pylon10 == 6 || pylon11 == 6) // CBU-97
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-97\n";
                                                        }
                                                        if (pylon1 == 4 || pylon2 == 4 || pylon3 == 14 || pylon4 == 14 || pylon5 == 6 || pylon6 == 6 || pylon7 == 6 || pylon8 == 6 || pylon9 == 4 || pylon10 == 4 || pylon11 == 4) // CBU-87
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-87\n";
                                                        }
                                                        if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "EGBU-12\n";
                                                        }
                                                        if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-54";
                                                        }
                                                        if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-38";
                                                        }
                                                        if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-31";
                                                        }
                                                        if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-12";
                                                        }
                                                        if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-10";
                                                        }
                                                        if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 GPB";
                                                        }
                                                        if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 AIR";
                                                        }
                                                        if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk84 GPB";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon5 == 10 || pylon6 == 10 || pylon7 == 10 || pylon8 == 10 || pylon9 == 8 || pylon10 == 8) // CBU-105
                                                        {
                                                            SuggestedWeapon.text = "CBU-105";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 9 || pylon6 == 9 || pylon7 == 9 || pylon8 == 9 || pylon9 == 7 || pylon10 == 7) // CBU-103
                                                        {
                                                            SuggestedWeapon.text = "CBU-103";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 6 || pylon2 == 6 || pylon3 == 16 || pylon4 == 16 || pylon5 == 8 || pylon6 == 8 || pylon7 == 8 || pylon8 == 8 || pylon9 == 6 || pylon10 == 6 || pylon11 == 6) // CBU-97
                                                        {
                                                            SuggestedWeapon.text = "CBU-97";
                                                            SuggestedAttack.text = "CCIP On Smoke";
                                                        }
                                                        else if (pylon1 == 4 || pylon2 == 4 || pylon3 == 14 || pylon4 == 14 || pylon5 == 6 || pylon6 == 6 || pylon7 == 6 || pylon8 == 6 || pylon9 == 4 || pylon10 == 4 || pylon11 == 4) // CBU-87
                                                        {
                                                            SuggestedWeapon.text = "CBU-87";
                                                            SuggestedAttack.text = "CCIP On Smoke";
                                                        }
                                                        else if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            SuggestedWeapon.text = "EGBU-12";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            SuggestedWeapon.text = "GBU-54";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            SuggestedWeapon.text = "GBU-38";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            SuggestedWeapon.text = "GBU-31";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            SuggestedWeapon.text = "GBU-12";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            SuggestedWeapon.text = "GBU-10";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            SuggestedWeapon.text = "Mk82 GPB";
                                                            SuggestedAttack.text = "CCIP On Smoke";
                                                        }
                                                        else if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            SuggestedWeapon.text = "Mk82 AIR";
                                                            SuggestedAttack.text = "CCIP On Smoke";
                                                        }
                                                        else if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            SuggestedWeapon.text = "Mk84 GPB";
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
                                                case 3: // Heavy
                                                    {
                                                        // List Available Weapons (runs all from most useful to least)
                                                        if (pylon5 == 10 || pylon6 == 10 || pylon7 == 10 || pylon8 == 10 || pylon9 == 8 || pylon10 == 8) // CBU-105
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-105\n";
                                                        }
                                                        if (pylon1 == 6 || pylon2 == 6 || pylon3 == 16 || pylon4 == 16 || pylon5 == 8 || pylon6 == 8 || pylon7 == 8 || pylon8 == 8 || pylon9 == 6 || pylon10 == 6 || pylon11 == 6) // CBU-97
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-97\n";
                                                        }
                                                        if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "EGBU-12\n";
                                                        }
                                                        if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-54";
                                                        }
                                                        if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-38";
                                                        }
                                                        if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-31";
                                                        }
                                                        if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-12";
                                                        }
                                                        if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-10";
                                                        }
                                                        if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 GPB";
                                                        }
                                                        if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 AIR";
                                                        }
                                                        if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk84 GPB";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon5 == 10 || pylon6 == 10 || pylon7 == 10 || pylon8 == 10 || pylon9 == 8 || pylon10 == 8) // CBU-105
                                                        {
                                                            SuggestedWeapon.text = "CBU-105";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 6 || pylon2 == 6 || pylon3 == 16 || pylon4 == 16 || pylon5 == 8 || pylon6 == 8 || pylon7 == 8 || pylon8 == 8 || pylon9 == 6 || pylon10 == 6 || pylon11 == 6) // CBU-97
                                                        {
                                                            SuggestedWeapon.text = "CBU-97";
                                                            SuggestedAttack.text = "CCIP On Smoke";
                                                        }
                                                        else if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            SuggestedWeapon.text = "EGBU-12";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            SuggestedWeapon.text = "GBU-54";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            SuggestedWeapon.text = "GBU-38";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            SuggestedWeapon.text = "GBU-31";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            SuggestedWeapon.text = "GBU-12";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            SuggestedWeapon.text = "GBU-10";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            SuggestedWeapon.text = "Mk82 GPB";
                                                            SuggestedAttack.text = "CCIP On Smoke";
                                                        }
                                                        else if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            SuggestedWeapon.text = "Mk82 AIR";
                                                            SuggestedAttack.text = "CCIP On Smoke";
                                                        }
                                                        else if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            SuggestedWeapon.text = "Mk84 GPB";
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
                                                case 4: // Static
                                                    {
                                                        // List Available Weapons (runs all from most useful to least)
                                                        if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "EGBU-12\n";
                                                        }
                                                        if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-54";
                                                        }
                                                        if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-38";
                                                        }
                                                        if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-31";
                                                        }
                                                        if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-12";
                                                        }
                                                        if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-10";
                                                        }
                                                        if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 GPB";
                                                        }
                                                        if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 AIR";
                                                        }
                                                        if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk84 GPB";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            SuggestedWeapon.text = "EGBU-12";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            SuggestedWeapon.text = "GBU-54";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            SuggestedWeapon.text = "GBU-38";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            SuggestedWeapon.text = "GBU-31";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            SuggestedWeapon.text = "GBU-12";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            SuggestedWeapon.text = "GBU-10";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            SuggestedWeapon.text = "Mk82 GPB";
                                                            SuggestedAttack.text = "CCIP On Smoke";
                                                        }
                                                        else if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            SuggestedWeapon.text = "Mk82 AIR";
                                                            SuggestedAttack.text = "CCIP On Smoke";
                                                        }
                                                        else if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            SuggestedWeapon.text = "Mk84 GPB";
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
                                            switch (TypeDropdown)
                                            {
                                                case 1: // Infantry
                                                    {
                                                        // List Available Weapons (runs all from most useful to least)
                                                        if (pylon5 == 9 || pylon6 == 9 || pylon7 == 9 || pylon8 == 9 || pylon9 == 7 || pylon10 == 7) // CBU-103
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-103\n";
                                                        }
                                                        if (pylon1 == 4 || pylon2 == 4 || pylon3 == 14 || pylon4 == 14 || pylon5 == 6 || pylon6 == 6 || pylon7 == 6 || pylon8 == 6 || pylon9 == 4 || pylon10 == 4 || pylon11 == 4) // CBU-87
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-87\n";
                                                        }
                                                        if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "EGBU-12\n";
                                                        }
                                                        if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-54";
                                                        }
                                                        if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-38";
                                                        }
                                                        if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-31";
                                                        }
                                                        if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-12";
                                                        }
                                                        if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-10";
                                                        }
                                                        if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 GPB";
                                                        }
                                                        if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 AIR";
                                                        }
                                                        if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk84 GPB";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon5 == 9 || pylon6 == 9 || pylon7 == 9 || pylon8 == 9 || pylon9 == 7 || pylon10 == 7) // CBU-103
                                                        {
                                                            SuggestedWeapon.text = "CBU-103";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 4 || pylon2 == 4 || pylon3 == 14 || pylon4 == 14 || pylon5 == 6 || pylon6 == 6 || pylon7 == 6 || pylon8 == 6 || pylon9 == 4 || pylon10 == 4 || pylon11 == 4) // CBU-87
                                                        {
                                                            SuggestedWeapon.text = "CBU-87";
                                                            SuggestedAttack.text = "CCIP On Laser Point";
                                                        }
                                                        else if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            SuggestedWeapon.text = "EGBU-12";
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            SuggestedWeapon.text = "GBU-54";
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            SuggestedWeapon.text = "GBU-38";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            SuggestedWeapon.text = "GBU-31";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            SuggestedWeapon.text = "GBU-12";
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            SuggestedWeapon.text = "GBU-10";
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            SuggestedWeapon.text = "Mk82 GPB";
                                                            SuggestedAttack.text = "CCIP On Laser Point";
                                                        }
                                                        else if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            SuggestedWeapon.text = "Mk82 AIR";
                                                            SuggestedAttack.text = "CCIP On Laser Point";
                                                        }
                                                        else if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            SuggestedWeapon.text = "Mk84 GPB";
                                                            SuggestedAttack.text = "CCIP On Laser Point";
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
                                                        // List Available Weapons (runs all from most useful to least)
                                                        if (pylon5 == 10 || pylon6 == 10 || pylon7 == 10 || pylon8 == 10 || pylon9 == 8 || pylon10 == 8) // CBU-105
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-105\n";
                                                        }
                                                        if (pylon5 == 9 || pylon6 == 9 || pylon7 == 9 || pylon8 == 9 || pylon9 == 7 || pylon10 == 7) // CBU-103
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-103\n";
                                                        }
                                                        if (pylon1 == 6 || pylon2 == 6 || pylon3 == 16 || pylon4 == 16 || pylon5 == 8 || pylon6 == 8 || pylon7 == 8 || pylon8 == 8 || pylon9 == 6 || pylon10 == 6 || pylon11 == 6) // CBU-97
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-97\n";
                                                        }
                                                        if (pylon1 == 4 || pylon2 == 4 || pylon3 == 14 || pylon4 == 14 || pylon5 == 6 || pylon6 == 6 || pylon7 == 6 || pylon8 == 6 || pylon9 == 4 || pylon10 == 4 || pylon11 == 4) // CBU-87
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-87\n";
                                                        }
                                                        if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "EGBU-12\n";
                                                        }
                                                        if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-54";
                                                        }
                                                        if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-38";
                                                        }
                                                        if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-31";
                                                        }
                                                        if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-12";
                                                        }
                                                        if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-10";
                                                        }
                                                        if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 GPB";
                                                        }
                                                        if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 AIR";
                                                        }
                                                        if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk84 GPB";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon5 == 10 || pylon6 == 10 || pylon7 == 10 || pylon8 == 10 || pylon9 == 8 || pylon10 == 8) // CBU-105
                                                        {
                                                            SuggestedWeapon.text = "CBU-105";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 9 || pylon6 == 9 || pylon7 == 9 || pylon8 == 9 || pylon9 == 7 || pylon10 == 7) // CBU-103
                                                        {
                                                            SuggestedWeapon.text = "CBU-103";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 6 || pylon2 == 6 || pylon3 == 16 || pylon4 == 16 || pylon5 == 8 || pylon6 == 8 || pylon7 == 8 || pylon8 == 8 || pylon9 == 6 || pylon10 == 6 || pylon11 == 6) // CBU-97
                                                        {
                                                            SuggestedWeapon.text = "CBU-97";
                                                            SuggestedAttack.text = "CCIP On Laser Point";
                                                        }
                                                        else if (pylon1 == 4 || pylon2 == 4 || pylon3 == 14 || pylon4 == 14 || pylon5 == 6 || pylon6 == 6 || pylon7 == 6 || pylon8 == 6 || pylon9 == 4 || pylon10 == 4 || pylon11 == 4) // CBU-87
                                                        {
                                                            SuggestedWeapon.text = "CBU-87";
                                                            SuggestedAttack.text = "CCIP On Laser Point";
                                                        }
                                                        else if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            SuggestedWeapon.text = "EGBU-12";
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            SuggestedWeapon.text = "GBU-54";
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            SuggestedWeapon.text = "GBU-38";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            SuggestedWeapon.text = "GBU-31";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            SuggestedWeapon.text = "GBU-12";
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            SuggestedWeapon.text = "GBU-10";
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            SuggestedWeapon.text = "Mk82 GPB";
                                                            SuggestedAttack.text = "CCIP On Laser Point";
                                                        }
                                                        else if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            SuggestedWeapon.text = "Mk82 AIR";
                                                            SuggestedAttack.text = "CCIP On Laser Point";
                                                        }
                                                        else if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            SuggestedWeapon.text = "Mk84 GPB";
                                                            SuggestedAttack.text = "CCIP On Laser Point";
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
                                                case 3: // Heavy
                                                    {
                                                        // List Available Weapons (runs all from most useful to least)
                                                        if (pylon5 == 10 || pylon6 == 10 || pylon7 == 10 || pylon8 == 10 || pylon9 == 8 || pylon10 == 8) // CBU-105
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-105\n";
                                                        }
                                                        if (pylon1 == 6 || pylon2 == 6 || pylon3 == 16 || pylon4 == 16 || pylon5 == 8 || pylon6 == 8 || pylon7 == 8 || pylon8 == 8 || pylon9 == 6 || pylon10 == 6 || pylon11 == 6) // CBU-97
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-97\n";
                                                        }
                                                        if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "EGBU-12\n";
                                                        }
                                                        if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-54";
                                                        }
                                                        if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-38";
                                                        }
                                                        if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-31";
                                                        }
                                                        if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-12";
                                                        }
                                                        if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-10";
                                                        }
                                                        if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 GPB";
                                                        }
                                                        if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 AIR";
                                                        }
                                                        if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk84 GPB";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon5 == 10 || pylon6 == 10 || pylon7 == 10 || pylon8 == 10 || pylon9 == 8 || pylon10 == 8) // CBU-105
                                                        {
                                                            SuggestedWeapon.text = "CBU-105";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 6 || pylon2 == 6 || pylon3 == 16 || pylon4 == 16 || pylon5 == 8 || pylon6 == 8 || pylon7 == 8 || pylon8 == 8 || pylon9 == 6 || pylon10 == 6 || pylon11 == 6) // CBU-97
                                                        {
                                                            SuggestedWeapon.text = "CBU-97";
                                                            SuggestedAttack.text = "CCIP On Laser Point";
                                                        }
                                                        else if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            SuggestedWeapon.text = "EGBU-12";
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            SuggestedWeapon.text = "GBU-54";
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            SuggestedWeapon.text = "GBU-38";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            SuggestedWeapon.text = "GBU-31";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            SuggestedWeapon.text = "GBU-12";
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            SuggestedWeapon.text = "GBU-10";
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            SuggestedWeapon.text = "Mk82 GPB";
                                                            SuggestedAttack.text = "CCIP On Laser Point";
                                                        }
                                                        else if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            SuggestedWeapon.text = "Mk82 AIR";
                                                            SuggestedAttack.text = "CCIP On Laser Point";
                                                        }
                                                        else if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            SuggestedWeapon.text = "Mk84 GPB";
                                                            SuggestedAttack.text = "CCIP On Laser Point";
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
                                                case 4: // Static
                                                    {
                                                        // List Available Weapons (runs all from most useful to least)
                                                        if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "EGBU-12\n";
                                                        }
                                                        if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-54";
                                                        }
                                                        if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-38";
                                                        }
                                                        if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-31";
                                                        }
                                                        if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-12";
                                                        }
                                                        if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-10";
                                                        }
                                                        if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 GPB";
                                                        }
                                                        if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 AIR";
                                                        }
                                                        if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk84 GPB";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            SuggestedWeapon.text = "EGBU-12";
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            SuggestedWeapon.text = "GBU-54";
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            SuggestedWeapon.text = "GBU-38";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            SuggestedWeapon.text = "GBU-31";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            SuggestedWeapon.text = "GBU-12";
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            SuggestedWeapon.text = "GBU-10";
                                                            SuggestedAttack.text = "Laser Lock";
                                                        }
                                                        else if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            SuggestedWeapon.text = "Mk82 GPB";
                                                            SuggestedAttack.text = "CCIP On Laser Point";
                                                        }
                                                        else if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            SuggestedWeapon.text = "Mk82 AIR";
                                                            SuggestedAttack.text = "CCIP On Laser Point";
                                                        }
                                                        else if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            SuggestedWeapon.text = "Mk84 GPB";
                                                            SuggestedAttack.text = "CCIP On Laser Point";
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
                                    case 3: // no mark
                                        {
                                            switch (TypeDropdown)
                                            {
                                                case 1: // Infantry
                                                    {
                                                        // List Available Weapons (runs all from most useful to least)
                                                        if (pylon5 == 9 || pylon6 == 9 || pylon7 == 9 || pylon8 == 9 || pylon9 == 7 || pylon10 == 7) // CBU-103
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-103\n";
                                                        }
                                                        if (pylon1 == 4 || pylon2 == 4 || pylon3 == 14 || pylon4 == 14 || pylon5 == 6 || pylon6 == 6 || pylon7 == 6 || pylon8 == 6 || pylon9 == 4 || pylon10 == 4 || pylon11 == 4) // CBU-87
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-87\n";
                                                        }
                                                        if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "EGBU-12\n";
                                                        }
                                                        if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-54";
                                                        }
                                                        if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-38";
                                                        }
                                                        if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-31";
                                                        }
                                                        if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-12";
                                                        }
                                                        if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-10";
                                                        }
                                                        if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 GPB";
                                                        }
                                                        if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 AIR";
                                                        }
                                                        if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk84 GPB";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon5 == 9 || pylon6 == 9 || pylon7 == 9 || pylon8 == 9 || pylon9 == 7 || pylon10 == 7) // CBU-103
                                                        {
                                                            SuggestedWeapon.text = "CBU-103";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 4 || pylon2 == 4 || pylon3 == 14 || pylon4 == 14 || pylon5 == 6 || pylon6 == 6 || pylon7 == 6 || pylon8 == 6 || pylon9 == 4 || pylon10 == 4 || pylon11 == 4) // CBU-87
                                                        {
                                                            SuggestedWeapon.text = "CBU-87";
                                                            SuggestedAttack.text = "Visual CCIP";
                                                        }
                                                        else if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            SuggestedWeapon.text = "EGBU-12";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            SuggestedWeapon.text = "GBU-54";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            SuggestedWeapon.text = "GBU-38";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            SuggestedWeapon.text = "GBU-31";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            SuggestedWeapon.text = "GBU-12";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            SuggestedWeapon.text = "GBU-10";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            SuggestedWeapon.text = "Mk82 GPB";
                                                            SuggestedAttack.text = "Visual CCIP";
                                                        }
                                                        else if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            SuggestedWeapon.text = "Mk82 AIR";
                                                            SuggestedAttack.text = "Visual CCIP";
                                                        }
                                                        else if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            SuggestedWeapon.text = "Mk84 GPB";
                                                            SuggestedAttack.text = "Visual CCIP";
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
                                                        // List Available Weapons (runs all from most useful to least)
                                                        if (pylon5 == 10 || pylon6 == 10 || pylon7 == 10 || pylon8 == 10 || pylon9 == 8 || pylon10 == 8) // CBU-105
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-105\n";
                                                        }
                                                        if (pylon5 == 9 || pylon6 == 9 || pylon7 == 9 || pylon8 == 9 || pylon9 == 7 || pylon10 == 7) // CBU-103
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-103\n";
                                                        }
                                                        if (pylon1 == 6 || pylon2 == 6 || pylon3 == 16 || pylon4 == 16 || pylon5 == 8 || pylon6 == 8 || pylon7 == 8 || pylon8 == 8 || pylon9 == 6 || pylon10 == 6 || pylon11 == 6) // CBU-97
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-97\n";
                                                        }
                                                        if (pylon1 == 4 || pylon2 == 4 || pylon3 == 14 || pylon4 == 14 || pylon5 == 6 || pylon6 == 6 || pylon7 == 6 || pylon8 == 6 || pylon9 == 4 || pylon10 == 4 || pylon11 == 4) // CBU-87
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-87\n";
                                                        }
                                                        if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "EGBU-12\n";
                                                        }
                                                        if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-54";
                                                        }
                                                        if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-38";
                                                        }
                                                        if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-31";
                                                        }
                                                        if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-12";
                                                        }
                                                        if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-10";
                                                        }
                                                        if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 GPB";
                                                        }
                                                        if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 AIR";
                                                        }
                                                        if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk84 GPB";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon5 == 10 || pylon6 == 10 || pylon7 == 10 || pylon8 == 10 || pylon9 == 8 || pylon10 == 8) // CBU-105
                                                        {
                                                            SuggestedWeapon.text = "CBU-105";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 9 || pylon6 == 9 || pylon7 == 9 || pylon8 == 9 || pylon9 == 7 || pylon10 == 7) // CBU-103
                                                        {
                                                            SuggestedWeapon.text = "CBU-103";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 6 || pylon2 == 6 || pylon3 == 16 || pylon4 == 16 || pylon5 == 8 || pylon6 == 8 || pylon7 == 8 || pylon8 == 8 || pylon9 == 6 || pylon10 == 6 || pylon11 == 6) // CBU-97
                                                        {
                                                            SuggestedWeapon.text = "CBU-97";
                                                            SuggestedAttack.text = "Visual CCIP";
                                                        }
                                                        else if (pylon1 == 4 || pylon2 == 4 || pylon3 == 14 || pylon4 == 14 || pylon5 == 6 || pylon6 == 6 || pylon7 == 6 || pylon8 == 6 || pylon9 == 4 || pylon10 == 4 || pylon11 == 4) // CBU-87
                                                        {
                                                            SuggestedWeapon.text = "CBU-87";
                                                            SuggestedAttack.text = "Visual CCIP";
                                                        }
                                                        else if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            SuggestedWeapon.text = "EGBU-12";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            SuggestedWeapon.text = "GBU-54";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            SuggestedWeapon.text = "GBU-38";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            SuggestedWeapon.text = "GBU-31";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            SuggestedWeapon.text = "GBU-12";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            SuggestedWeapon.text = "GBU-10";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            SuggestedWeapon.text = "Mk82 GPB";
                                                            SuggestedAttack.text = "Visual CCIP";
                                                        }
                                                        else if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            SuggestedWeapon.text = "Mk82 AIR";
                                                            SuggestedAttack.text = "Visual CCIP";
                                                        }
                                                        else if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            SuggestedWeapon.text = "Mk84 GPB";
                                                            SuggestedAttack.text = "Visual CCIP";
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
                                                case 3: // Heavy
                                                    {
                                                        // List Available Weapons (runs all from most useful to least)
                                                        if (pylon5 == 10 || pylon6 == 10 || pylon7 == 10 || pylon8 == 10 || pylon9 == 8 || pylon10 == 8) // CBU-105
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-105\n";
                                                        }
                                                        if (pylon1 == 6 || pylon2 == 6 || pylon3 == 16 || pylon4 == 16 || pylon5 == 8 || pylon6 == 8 || pylon7 == 8 || pylon8 == 8 || pylon9 == 6 || pylon10 == 6 || pylon11 == 6) // CBU-97
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-97\n";
                                                        }
                                                        if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "EGBU-12\n";
                                                        }
                                                        if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-54";
                                                        }
                                                        if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-38";
                                                        }
                                                        if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-31";
                                                        }
                                                        if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-12";
                                                        }
                                                        if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-10";
                                                        }
                                                        if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 GPB";
                                                        }
                                                        if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 AIR";
                                                        }
                                                        if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk84 GPB";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon5 == 10 || pylon6 == 10 || pylon7 == 10 || pylon8 == 10 || pylon9 == 8 || pylon10 == 8) // CBU-105
                                                        {
                                                            SuggestedWeapon.text = "CBU-105";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 6 || pylon2 == 6 || pylon3 == 16 || pylon4 == 16 || pylon5 == 8 || pylon6 == 8 || pylon7 == 8 || pylon8 == 8 || pylon9 == 6 || pylon10 == 6 || pylon11 == 6) // CBU-97
                                                        {
                                                            SuggestedWeapon.text = "CBU-97";
                                                            SuggestedAttack.text = "Visual CCIP";
                                                        }
                                                        else if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            SuggestedWeapon.text = "EGBU-12";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            SuggestedWeapon.text = "GBU-54";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            SuggestedWeapon.text = "GBU-38";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            SuggestedWeapon.text = "GBU-31";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            SuggestedWeapon.text = "GBU-12";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            SuggestedWeapon.text = "GBU-10";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            SuggestedWeapon.text = "Mk82 GPB";
                                                            SuggestedAttack.text = "Visual CCIP";
                                                        }
                                                        else if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            SuggestedWeapon.text = "Mk82 AIR";
                                                            SuggestedAttack.text = "Visual CCIP";
                                                        }
                                                        else if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            SuggestedWeapon.text = "Mk84 GPB";
                                                            SuggestedAttack.text = "Visual CCIP";
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
                                                case 4: // Static
                                                    {
                                                        // List Available Weapons (runs all from most useful to least)
                                                        if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "EGBU-12\n";
                                                        }
                                                        if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-54";
                                                        }
                                                        if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-38";
                                                        }
                                                        if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-31";
                                                        }
                                                        if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-12";
                                                        }
                                                        if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-10";
                                                        }
                                                        if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 GPB";
                                                        }
                                                        if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 AIR";
                                                        }
                                                        if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk84 GPB";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            SuggestedWeapon.text = "EGBU-12";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            SuggestedWeapon.text = "GBU-54";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            SuggestedWeapon.text = "GBU-38";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            SuggestedWeapon.text = "GBU-31";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            SuggestedWeapon.text = "GBU-12";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            SuggestedWeapon.text = "GBU-10";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            SuggestedWeapon.text = "Mk82 GPB";
                                                            SuggestedAttack.text = "Visual CCIP";
                                                        }
                                                        else if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            SuggestedWeapon.text = "Mk82 AIR";
                                                            SuggestedAttack.text = "Visual CCIP";
                                                        }
                                                        else if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            SuggestedWeapon.text = "Mk84 GPB";
                                                            SuggestedAttack.text = "Visual CCIP";
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
                                    case 4: // ir pointer
                                        {
                                            switch (TypeDropdown)
                                            {
                                                case 1: // Infantry
                                                    {
                                                        // List Available Weapons (runs all from most useful to least)
                                                        if (pylon5 == 9 || pylon6 == 9 || pylon7 == 9 || pylon8 == 9 || pylon9 == 7 || pylon10 == 7) // CBU-103
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-103\n";
                                                        }
                                                        if (pylon1 == 4 || pylon2 == 4 || pylon3 == 14 || pylon4 == 14 || pylon5 == 6 || pylon6 == 6 || pylon7 == 6 || pylon8 == 6 || pylon9 == 4 || pylon10 == 4 || pylon11 == 4) // CBU-87
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-87\n";
                                                        }
                                                        if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "EGBU-12\n";
                                                        }
                                                        if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-54";
                                                        }
                                                        if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-38";
                                                        }
                                                        if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-31";
                                                        }
                                                        if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-12";
                                                        }
                                                        if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-10";
                                                        }
                                                        if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 GPB";
                                                        }
                                                        if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 AIR";
                                                        }
                                                        if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk84 GPB";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon5 == 9 || pylon6 == 9 || pylon7 == 9 || pylon8 == 9 || pylon9 == 7 || pylon10 == 7) // CBU-103
                                                        {
                                                            SuggestedWeapon.text = "CBU-103";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 4 || pylon2 == 4 || pylon3 == 14 || pylon4 == 14 || pylon5 == 6 || pylon6 == 6 || pylon7 == 6 || pylon8 == 6 || pylon9 == 4 || pylon10 == 4 || pylon11 == 4) // CBU-87
                                                        {
                                                            SuggestedWeapon.text = "CBU-87";
                                                            SuggestedAttack.text = "CCIP On IR Point";
                                                        }
                                                        else if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            SuggestedWeapon.text = "EGBU-12";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            SuggestedWeapon.text = "GBU-54";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            SuggestedWeapon.text = "GBU-38";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            SuggestedWeapon.text = "GBU-31";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            SuggestedWeapon.text = "GBU-12";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            SuggestedWeapon.text = "GBU-10";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            SuggestedWeapon.text = "Mk82 GPB";
                                                            SuggestedAttack.text = "CCIP On IR Point";
                                                        }
                                                        else if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            SuggestedWeapon.text = "Mk82 AIR";
                                                            SuggestedAttack.text = "CCIP On IR Point";
                                                        }
                                                        else if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            SuggestedWeapon.text = "Mk84 GPB";
                                                            SuggestedAttack.text = "CCIP On IR Point";
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
                                                        // List Available Weapons (runs all from most useful to least)
                                                        if (pylon5 == 10 || pylon6 == 10 || pylon7 == 10 || pylon8 == 10 || pylon9 == 8 || pylon10 == 8) // CBU-105
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-105\n";
                                                        }
                                                        if (pylon5 == 9 || pylon6 == 9 || pylon7 == 9 || pylon8 == 9 || pylon9 == 7 || pylon10 == 7) // CBU-103
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-103\n";
                                                        }
                                                        if (pylon1 == 6 || pylon2 == 6 || pylon3 == 16 || pylon4 == 16 || pylon5 == 8 || pylon6 == 8 || pylon7 == 8 || pylon8 == 8 || pylon9 == 6 || pylon10 == 6 || pylon11 == 6) // CBU-97
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-97\n";
                                                        }
                                                        if (pylon1 == 4 || pylon2 == 4 || pylon3 == 14 || pylon4 == 14 || pylon5 == 6 || pylon6 == 6 || pylon7 == 6 || pylon8 == 6 || pylon9 == 4 || pylon10 == 4 || pylon11 == 4) // CBU-87
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-87\n";
                                                        }
                                                        if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "EGBU-12\n";
                                                        }
                                                        if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-54";
                                                        }
                                                        if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-38";
                                                        }
                                                        if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-31";
                                                        }
                                                        if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-12";
                                                        }
                                                        if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-10";
                                                        }
                                                        if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 GPB";
                                                        }
                                                        if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 AIR";
                                                        }
                                                        if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk84 GPB";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon5 == 10 || pylon6 == 10 || pylon7 == 10 || pylon8 == 10 || pylon9 == 8 || pylon10 == 8) // CBU-105
                                                        {
                                                            SuggestedWeapon.text = "CBU-105";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 9 || pylon6 == 9 || pylon7 == 9 || pylon8 == 9 || pylon9 == 7 || pylon10 == 7) // CBU-103
                                                        {
                                                            SuggestedWeapon.text = "CBU-103";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 6 || pylon2 == 6 || pylon3 == 16 || pylon4 == 16 || pylon5 == 8 || pylon6 == 8 || pylon7 == 8 || pylon8 == 8 || pylon9 == 6 || pylon10 == 6 || pylon11 == 6) // CBU-97
                                                        {
                                                            SuggestedWeapon.text = "CBU-97";
                                                            SuggestedAttack.text = "CCIP On IR Point";
                                                        }
                                                        else if (pylon1 == 4 || pylon2 == 4 || pylon3 == 14 || pylon4 == 14 || pylon5 == 6 || pylon6 == 6 || pylon7 == 6 || pylon8 == 6 || pylon9 == 4 || pylon10 == 4 || pylon11 == 4) // CBU-87
                                                        {
                                                            SuggestedWeapon.text = "CBU-87";
                                                            SuggestedAttack.text = "CCIP On IR Point";
                                                        }
                                                        else if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            SuggestedWeapon.text = "EGBU-12";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            SuggestedWeapon.text = "GBU-54";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            SuggestedWeapon.text = "GBU-38";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            SuggestedWeapon.text = "GBU-31";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            SuggestedWeapon.text = "GBU-12";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            SuggestedWeapon.text = "GBU-10";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            SuggestedWeapon.text = "Mk82 GPB";
                                                            SuggestedAttack.text = "CCIP On IR Point";
                                                        }
                                                        else if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            SuggestedWeapon.text = "Mk82 AIR";
                                                            SuggestedAttack.text = "CCIP On IR Point";
                                                        }
                                                        else if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            SuggestedWeapon.text = "Mk84 GPB";
                                                            SuggestedAttack.text = "CCIP On IR Point";
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
                                                case 3: // Heavy
                                                    {
                                                        // List Available Weapons (runs all from most useful to least)
                                                        if (pylon5 == 10 || pylon6 == 10 || pylon7 == 10 || pylon8 == 10 || pylon9 == 8 || pylon10 == 8) // CBU-105
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-105\n";
                                                        }
                                                        if (pylon1 == 6 || pylon2 == 6 || pylon3 == 16 || pylon4 == 16 || pylon5 == 8 || pylon6 == 8 || pylon7 == 8 || pylon8 == 8 || pylon9 == 6 || pylon10 == 6 || pylon11 == 6) // CBU-97
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "CBU-97\n";
                                                        }
                                                        if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "EGBU-12\n";
                                                        }
                                                        if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-54";
                                                        }
                                                        if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-38";
                                                        }
                                                        if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-31";
                                                        }
                                                        if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-12";
                                                        }
                                                        if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-10";
                                                        }
                                                        if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 GPB";
                                                        }
                                                        if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 AIR";
                                                        }
                                                        if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk84 GPB";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon5 == 10 || pylon6 == 10 || pylon7 == 10 || pylon8 == 10 || pylon9 == 8 || pylon10 == 8) // CBU-105
                                                        {
                                                            SuggestedWeapon.text = "CBU-105";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 6 || pylon2 == 6 || pylon3 == 16 || pylon4 == 16 || pylon5 == 8 || pylon6 == 8 || pylon7 == 8 || pylon8 == 8 || pylon9 == 6 || pylon10 == 6 || pylon11 == 6) // CBU-97
                                                        {
                                                            SuggestedWeapon.text = "CBU-97";
                                                            SuggestedAttack.text = "CCIP On IR Point";
                                                        }
                                                        else if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            SuggestedWeapon.text = "EGBU-12";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            SuggestedWeapon.text = "GBU-54";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            SuggestedWeapon.text = "GBU-38";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            SuggestedWeapon.text = "GBU-31";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            SuggestedWeapon.text = "GBU-12";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            SuggestedWeapon.text = "GBU-10";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            SuggestedWeapon.text = "Mk82 GPB";
                                                            SuggestedAttack.text = "CCIP On IR Point";
                                                        }
                                                        else if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            SuggestedWeapon.text = "Mk82 AIR";
                                                            SuggestedAttack.text = "CCIP On IR Point";
                                                        }
                                                        else if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            SuggestedWeapon.text = "Mk84 GPB";
                                                            SuggestedAttack.text = "CCIP On IR Point";
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
                                                case 4: // Static
                                                    {
                                                        // List Available Weapons (runs all from most useful to least)
                                                        if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "EGBU-12\n";
                                                        }
                                                        if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-54";
                                                        }
                                                        if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-38";
                                                        }
                                                        if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-31";
                                                        }
                                                        if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-12";
                                                        }
                                                        if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "GBU-10";
                                                        }
                                                        if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 GPB";
                                                        }
                                                        if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk82 AIR";
                                                        }
                                                        if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            AvailableWeapons.text = AvailableWeapons.text + "Mk84 GPB";
                                                        }

                                                        // Select Suggested Weapon (falls through from most useful to least)
                                                        if (pylon1 == 8 || pylon2 == 8 || pylon3 == 18 || pylon4 == 18 || pylon5 == 14 || pylon6 == 14 || pylon5 == 15 || pylon6 == 15 || pylon7 == 14 || pylon8 == 14 || pylon7 == 15 || pylon8 == 15 || pylon9 == 11 || pylon10 == 11 || pylon11 == 9) // EGBU-12
                                                        {
                                                            SuggestedWeapon.text = "EGBU-12";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 18 || pylon6 == 18 || pylon7 == 18 || pylon8 == 18 || pylon9 == 14 || pylon10 == 14) // GBU-54
                                                        {
                                                            SuggestedWeapon.text = "GBU-54";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 17 || pylon6 == 17 || pylon7 == 17 || pylon8 == 17 || pylon9 == 13 || pylon10 == 13) // GBU-38
                                                        {
                                                            SuggestedWeapon.text = "GBU-38";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon5 == 16 || pylon6 == 16 || pylon7 == 16 || pylon8 == 16 || pylon9 == 12 || pylon10 == 12) // GBU-31
                                                        {
                                                            SuggestedWeapon.text = "GBU-31";
                                                            SuggestedAttack.text = "GPS Guidance";
                                                        }
                                                        else if (pylon1 == 7 || pylon2 == 7 || pylon3 == 17 || pylon4 == 17 || pylon5 == 12 || pylon6 == 12 || pylon5 == 13 || pylon6 == 13 || pylon7 == 12 || pylon8 == 12 || pylon7 == 13 || pylon8 == 13 || pylon9 == 10 || pylon10 == 10 || pylon11 == 8) // GBU-12
                                                        {
                                                            SuggestedWeapon.text = "GBU-12";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon5 == 11 || pylon6 == 11 || pylon7 == 11 || pylon8 == 11 || pylon9 == 9 || pylon10 == 9 || pylon11 == 7) // GBU-10
                                                        {
                                                            SuggestedWeapon.text = "GBU-10";
                                                            SuggestedAttack.text = "Self Des Laser";
                                                        }
                                                        else if (pylon1 == 3 || pylon2 == 3 || pylon3 == 13 || pylon4 == 13 || pylon5 == 3 || pylon6 == 3 || pylon5 == 4 || pylon6 == 4 || pylon7 == 3 || pylon8 == 3 || pylon7 == 4 || pylon8 == 4 || pylon9 == 2 || pylon10 == 2 || pylon11 == 2) // Mk82 GPB
                                                        {
                                                            SuggestedWeapon.text = "Mk82 GPB";
                                                            SuggestedAttack.text = "CCIP On IR Point";
                                                        }
                                                        else if (pylon1 == 2 || pylon2 == 2 || pylon3 == 12 || pylon4 == 12 || pylon5 == 1 || pylon6 == 1 || pylon5 == 2 || pylon6 == 2 || pylon7 == 1 || pylon8 == 1 || pylon7 == 2 || pylon8 == 2 || pylon9 == 1 || pylon10 == 1 || pylon11 == 1) // Mk82 AIR
                                                        {
                                                            SuggestedWeapon.text = "Mk82 AIR";
                                                            SuggestedAttack.text = "CCIP On IR Point";
                                                        }
                                                        else if (pylon5 == 5 || pylon6 == 5 || pylon7 == 5 || pylon8 == 5 || pylon9 == 3 || pylon10 == 3 || pylon11 == 3) // Mk84
                                                        {
                                                            SuggestedWeapon.text = "Mk84 GPB";
                                                            SuggestedAttack.text = "CCIP On IR Point";
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
                                }
                                break;
                            }
                    }
                    break;
                }
        }
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
