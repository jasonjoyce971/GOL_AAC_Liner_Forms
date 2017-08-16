using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CASAssistUIFunctions : MonoBehaviour {


    // Panel Objects
    public GameObject Panel;

    public Dropdown AircraftSelection;
    public Dropdown Preset;

    public Text Pylon1Text;
    public Dropdown Pylon1;
    public Text Pylon2Text;
    public Dropdown Pylon2;
    public Text Pylon3Text;
    public Dropdown Pylon3;
    public Text Pylon4Text;
    public Dropdown Pylon4;
    public Text Pylon5Text;
    public Dropdown Pylon5;
    public Text Pylon6Text;
    public Dropdown Pylon6;
    public Text Pylon7Text;
    public Dropdown Pylon7;
    public Text Pylon8Text;
    public Dropdown Pylon8;
    public Text Pylon9Text;
    public Dropdown Pylon9;
    public Text Pylon10Text;
    public Dropdown Pylon10;
    public Text Pylon11Text;
    public Dropdown Pylon11;
    public Text Pylon12Text;
    public Dropdown Pylon12;
    public Text Pylon13Text;
    public Dropdown Pylon13;
    public Text Pylon14Text;
    public Dropdown Pylon14;

    public Text ConfirmTitle;
    public Button ConfirmButton;

    // Private int to store value of dropdown and pass to switch in AircraftSelectionChanged()
    private int AircraftSelectionValue;
    private int PresetSelectionValue;

    private GameObject ParentPanel;
    private GameObject ParentPanelRef;

    // Use awake to populate relevant data
    private void Awake()
    {
        AircraftSelectionValue = AircraftSelection.value;
        ConfirmTitle.text = " ";
        ConfirmButton.interactable = false;
        ParentPanel = GameObject.Find("UI");
    }

    // Aircraft Dropdown Changed marks start point of input operations
    public void AircraftSelectionChanged()
    {
        // Main switch case to determine aircraft selected and pass code on appropriately
        switch (AircraftSelectionValue)
        {
            case 0:
                {
                    // A-10
                    // Clear Presets
                    Preset.ClearOptions();
                    // Populate Presets
                    string PresetInput = "NIL\nFEBA\nCAS Day\nCAS Night\nBAI Infrastructure\nBAI Convoy\nBAI Structures\nAFAC";
                    string[] PresetsplitString = PresetInput.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                    foreach (string s in PresetsplitString)
                    {
                        Preset.options.Add(new Dropdown.OptionData(s));
                    }

                    // Activate Pylon Dropdowns
                    Pylon1Text.text = "Left Outboard";
                    Pylon2Text.text = "Right Outboard";
                    Pylon1.ClearOptions();
                    Pylon2.ClearOptions();
                    string Pylon1Input = "Empty\nAIM-9L x2\nMk82 Snakeye\nMk82 GPB\nCBU-87 CEM\nCBU-89 GATOR\nCBU-97 SFW\nGBU-12\nEGBU-12\nECM Pod";
                    string[] Pylon1splitString = Pylon1Input.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                    foreach (string s in Pylon1splitString)
                    {
                        Pylon1.options.Add(new Dropdown.OptionData(s));
                        Pylon2.options.Add(new Dropdown.OptionData(s));
                    }

                    Pylon3Text.text = "Left Midline";
                    Pylon4Text.text = "Right Midline";
                    Pylon3.ClearOptions();
                    Pylon4.ClearOptions();
                    string Pylon3Input = "Empty\nHYDRA HE x7\nHYDRA SMK W x7\nHYDRA SMK R x7\nHYDRA SMK O x7\nHYDRA SMK P x7\nHYDRA HE x21\nAPKWS x7\nZUNI x4\nCRV-7 FAT x19\nCRV-7 HE x19\nCRV-7 KEP x19\nMk82 Snakeye\nMk82 GPB\nCBU-87 CEM\nCBU-89 GATOR\nCBU-97 SFW\nGBU-12\nEGBU-12\nLightning Pod\nSUU-25 x8";
                    string[] Pylon3splitString = Pylon3Input.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                    foreach (string s in Pylon3splitString)
                    {
                        Pylon3.options.Add(new Dropdown.OptionData(s));
                        Pylon4.options.Add(new Dropdown.OptionData(s));
                    }

                    Pylon5Text.text = "Left Inboard";
                    Pylon6Text.text = "Right Inboard";
                    Pylon5.ClearOptions();
                    Pylon6.ClearOptions();
                    string Pylon5Input = "Empty\nMk82 Snakeye\nMk82 Snakeye x3\nMk82 GPB\nMk82 GPB x3\nMk84 GPB\nCBU-87 CEM\nCBU-89 GATOR\nCBU-97 SFW\nCBU-103 CEM WCMD\nCBU-105 SFW WCMD\nGBU-10\nGBU-12\nGBU-12 x3\nEGBU-12 II\nEGBU-12 II x3\nGBU-31\nGBU-38\nGBU-54\nHYDRA x7\nHYDRA SMK W x7\nHYDRA SMK R x7\nHYDRA SMK O x7\nHYDRA SMK P x7\nHYDRA x21\nAPKWS HYDRA x7\nAPKWS HYDRA x21\nZUNI x4\nCRV7 FAT x19\nCRV7 HE x19\nCRV7 KEP x19\nAGM-65D\nAGM-65D x3\nAGM-65H\nAGM-65H x3\nAGM-65L\nAGM-65L x3\nAGM-65G\nAGM-65K";
                    string[] Pylon5splitString = Pylon5Input.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                    foreach (string s in Pylon5splitString)
                    {
                        Pylon5.options.Add(new Dropdown.OptionData(s));
                        Pylon6.options.Add(new Dropdown.OptionData(s));
                    }

                    Pylon7Text.text = "Left Belly Outer";
                    Pylon8Text.text = "Right Belly Outer";
                    Pylon7.ClearOptions();
                    Pylon8.ClearOptions();
                    string Pylon7Input = "Empty\nMk82 Snakeye\nMk82 Snakeye x3\nMk82 GPB\nMk82 GPB x3\nMk84 GPB\nCBU-87 CEM\nCBU-89 GATOR\nCBU - 97 SFW\nCBU - 103 CEM WCMD\nCBU - 105 SFW WCMD\nGBU - 10\nGBU - 12\nGBU - 12 x3\nEGBU - 12 II\nEGBU - 12 II x3\nGBU - 31\nGBU - 38\nGBU - 54\nHYDRA x7\nHYDRA x21\nAPKWS HYDRA x7\nAPKWS HYDRA x21\nZUNI x4\nCRV7 FAT x19\nCRV7 HE x19\nCRV7 KEP x19";
                    string[] Pylon7splitString = Pylon7Input.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                    foreach (string s in Pylon7splitString)
                    {
                        Pylon7.options.Add(new Dropdown.OptionData(s));
                        Pylon8.options.Add(new Dropdown.OptionData(s));
                    }

                    Pylon9Text.text = "Left Belly Inner";
                    Pylon10Text.text = "Right Belly Inner";
                    Pylon9.ClearOptions();
                    Pylon10.ClearOptions();
                    string Pylon9Input = "Empty\nMk82 Snakeye\nMk82 GPB\nMk84 GPB\nCBU-87 CEM\nCBU-89 GATOR\nCBU-97 SFW\nCBU-103 CEM WCMD\nCBU-105 SFW WCMD\nGBU-10\nGBU-12\nEGBU-12 II\nGBU-31\nGBU-38\nGBU-54";
                    string[] Pylon9splitString = Pylon9Input.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                    foreach (string s in Pylon9splitString)
                    {
                        Pylon9.options.Add(new Dropdown.OptionData(s));
                        Pylon10.options.Add(new Dropdown.OptionData(s));
                    }

                    Pylon11Text.text = "Belly Centre";
                    Pylon11.ClearOptions();
                    string Pylon11Input = "Empty\nMk82 Snakeye\nMk82 GPB\nMk84 GPB\nCBU-87 CEM\nCBU-89 GATOR\nCBU-97 SFW\nGBU-10\nGBU-12\nEGBU-12 II";
                    string[] Pylon11splitString = Pylon11Input.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                    foreach (string s in Pylon11splitString)
                    {
                        Pylon11.options.Add(new Dropdown.OptionData(s));
                    }

                    // Activate confirm and clear buttons
                    ConfirmTitle.text = "CONFIRM?";
                    ConfirmButton.interactable = true;

                    return;
                }
            case 1:
                {
                    // AH-1Z
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 2:
                {
                    // AH-64D
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 3:
                {
                    // WAH-64(AH-1)
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 4:
                {
                    // AV-8b
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 5:
                {
                    // GR.9
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 6:
                {
                    // AW-159
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 7:
                {
                    // F-35(USMC)
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 8:
                {
                    // F-35(RAF)
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 9:
                {
                    // AH-6M
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 10:
                {
                    // A-164
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 11:
                {
                    // F/A-181
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 12:
                {
                    // Yak-131
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 13:
                {
                    // To-201
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 14:
                {
                    // A-143
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 15:
                {
                    // A-149
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 16:
                {
                    // RAH-66
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 17:
                {
                    // Mi-48
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 18:
                {
                    // Y-32
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 19:
                {
                    // Ka-50
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 20:
                {
                    // Ka-52
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 21:
                {
                    // L-39
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 22:
                {
                    // MH-60L
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 23:
                {
                    // MH-60S
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 24:
                {
                    // Mi-8
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 25:
                {
                    // Mi-17
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 26:
                {
                    // Mi-24D
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 27:
                {
                    // Mi-24P
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 28:
                {
                    // Mi-24V
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 29:
                {
                    // Mi-24 III
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 30:
                {
                    // Mi-24 IV
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 31:
                {
                    // Mi-35
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 32:
                {
                    // Su-25
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 33:
                {
                    // Su-34
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
        }
    }

    // Process Presets if selected
    public void PresetSelectionChanged()
    {
        // Main switch case to determine aircraft selected and pass code on appropriately
        switch (AircraftSelectionValue)
        {
            case 0:
                {
                    // A-10
                    PresetSelectionValue = Preset.value;
                    switch(PresetSelectionValue)
                    {
                        case 0: // NIL or Empty
                            {
                                Pylon1.value = 0;
                                Pylon2.value = 0;
                                Pylon3.value = 0;
                                Pylon4.value = 0;
                                Pylon5.value = 0;
                                Pylon6.value = 0;
                                Pylon7.value = 0;
                                Pylon8.value = 0;
                                Pylon9.value = 0;
                                Pylon10.value = 0;
                                Pylon11.value = 0;
                                return;
                            }
                        case 1: // FEBA
                            {
                                Pylon1.value = 1;
                                Pylon2.value = 9;
                                Pylon3.value = 19;
                                Pylon4.value = 9;
                                Pylon5.value = 34;
                                Pylon6.value = 32;
                                Pylon7.value = 15;
                                Pylon8.value = 15;
                                Pylon9.value = 8;
                                Pylon10.value = 8;
                                Pylon11.value = 9;
                                return;
                            }
                        case 2: // CAS Day
                            {
                                Pylon1.value = 1;
                                Pylon2.value = 9;
                                Pylon3.value = 19;
                                Pylon4.value = 9;
                                Pylon5.value = 36;
                                Pylon6.value = 32;
                                Pylon7.value = 22;
                                Pylon8.value = 22;
                                Pylon9.value = 10;
                                Pylon10.value = 10;
                                Pylon11.value = 8;
                                return;
                            }
                        case 3: // CAS Night
                            {
                                Pylon1.value = 1;
                                Pylon2.value = 9;
                                Pylon3.value = 19;
                                Pylon4.value = 20;
                                Pylon5.value = 36;
                                Pylon6.value = 32;
                                Pylon7.value = 22;
                                Pylon8.value = 22;
                                Pylon9.value = 10;
                                Pylon10.value = 10;
                                Pylon11.value = 8;
                                return;
                            }
                        case 4: // BAI Infrastructure
                            {
                                Pylon1.value = 1;
                                Pylon2.value = 9;
                                Pylon3.value = 19;
                                Pylon4.value = 10;
                                Pylon5.value = 36;
                                Pylon6.value = 36;
                                Pylon7.value = 13;
                                Pylon8.value = 13;
                                Pylon9.value = 4;
                                Pylon10.value = 4;
                                Pylon11.value = 6;
                                return;
                            }
                        case 5: // BAI Convoy
                            {
                                Pylon1.value = 1;
                                Pylon2.value = 9;
                                Pylon3.value = 19;
                                Pylon4.value = 9;
                                Pylon5.value = 34;
                                Pylon6.value = 32;
                                Pylon7.value = 26;
                                Pylon8.value = 26;
                                Pylon9.value = 6;
                                Pylon10.value = 6;
                                Pylon11.value = 6;
                                return;
                            }
                        case 6: // BAI Structures
                            {
                                Pylon1.value = 1;
                                Pylon2.value = 9;
                                Pylon3.value = 19;
                                Pylon4.value = 9;
                                Pylon5.value = 36;
                                Pylon6.value = 36;
                                Pylon7.value = 16;
                                Pylon8.value = 16;
                                Pylon9.value = 12;
                                Pylon10.value = 12;
                                Pylon11.value = 3;
                                return;
                            }
                        case 7: // AFAC
                            {
                                Pylon1.value = 1;
                                Pylon2.value = 9;
                                Pylon3.value = 19;
                                Pylon4.value = 20;
                                Pylon5.value = 21;
                                Pylon6.value = 21;
                                Pylon7.value = 22;
                                Pylon8.value = 22;
                                Pylon9.value = 11;
                                Pylon10.value = 11;
                                Pylon11.value = 9;
                                return;
                            }
                    }
                    return;
                }
            case 1:
                {
                    // AH-1Z
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 2:
                {
                    // AH-64D
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 3:
                {
                    // WAH-64(AH-1)
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 4:
                {
                    // AV-8b
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 5:
                {
                    // GR.9
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 6:
                {
                    // AW-159
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 7:
                {
                    // F-35(USMC)
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 8:
                {
                    // F-35(RAF)
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 9:
                {
                    // AH-6M
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 10:
                {
                    // A-164
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 11:
                {
                    // F/A-181
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 12:
                {
                    // Yak-131
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 13:
                {
                    // To-201
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 14:
                {
                    // A-143
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 15:
                {
                    // A-149
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 16:
                {
                    // RAH-66
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 17:
                {
                    // Mi-48
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 18:
                {
                    // Y-32
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 19:
                {
                    // Ka-50
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 20:
                {
                    // Ka-52
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 21:
                {
                    // L-39
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 22:
                {
                    // MH-60L
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 23:
                {
                    // MH-60S
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 24:
                {
                    // Mi-8
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 25:
                {
                    // Mi-17
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 26:
                {
                    // Mi-24D
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 27:
                {
                    // Mi-24P
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 28:
                {
                    // Mi-24V
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 29:
                {
                    // Mi-24 III
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 30:
                {
                    // Mi-24 IV
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 31:
                {
                    // Mi-35
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 32:
                {
                    // Su-25
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
            case 33:
                {
                    // Su-34
                    // Populate Presets
                    // Activate Pylon Dropdowns
                    // Set Pylons to Chosen Preset
                    // Activate continue button
                    return;
                }
        }
    }

    // Confirm Button Passes data to PlayerPrefs ready for further use
    public void ConfirmButtonClicked()
    {
        PlayerPrefs.SetInt("CASAssistPylon1", Pylon1.value);
        PlayerPrefs.SetInt("CASAssistPylon2", Pylon2.value);
        PlayerPrefs.SetInt("CASAssistPylon3", Pylon3.value);
        PlayerPrefs.SetInt("CASAssistPylon4", Pylon4.value);
        PlayerPrefs.SetInt("CASAssistPylon5", Pylon5.value);
        PlayerPrefs.SetInt("CASAssistPylon6", Pylon6.value);
        PlayerPrefs.SetInt("CASAssistPylon7", Pylon7.value);
        PlayerPrefs.SetInt("CASAssistPylon8", Pylon8.value);
        PlayerPrefs.SetInt("CASAssistPylon9", Pylon9.value);
        PlayerPrefs.SetInt("CASAssistPylon10", Pylon10.value);
        PlayerPrefs.SetInt("CASAssistPylon11", Pylon11.value);
        PlayerPrefs.SetInt("CASAssistPylon12", Pylon12.value);
        PlayerPrefs.SetInt("CASAssistPylon13", Pylon13.value);
        PlayerPrefs.SetInt("CASAssistPylon14", Pylon14.value);

        ParentPanelRef = ParentPanel.transform.Find("Main Canvas").gameObject;
        ParentPanelRef.SetActive(true);
        Destroy(Panel);
        Debug.Log("CAS Assist Panel: Destory CAS Assist Panel With Data Entry");
    }

    // Back Button closes CAS Assist without data transfer
    public void BackButtonClicked()
    {
        // Destroy this panel to show previous
        ParentPanelRef = ParentPanel.transform.Find("Main Canvas").gameObject;
        ParentPanelRef.SetActive(true);
        Destroy(Panel);
        Debug.Log("CAS Assist Panel: Destory CAS Assist Panel Without Data Entry");
    }
}
