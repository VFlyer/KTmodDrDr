using System;
using DrDoctor;
using System.Collections.Generic;
using System.Linq;
using BlindAlley;
using UnityEngine;
using Rnd = UnityEngine.Random;

/// <summary>
/// On the Subject of Dr. Doctor
/// Created by ligio90
/// </summary>
public class DrDoctorModule : MonoBehaviour
{
    public KMBombInfo Bomb;
    public KMBombModule Module;
    public KMAudio Audio;
    public KMSelectable Caduceus;
    public KMSelectable DateUp;
    public KMSelectable DateDwn;
    public KMSelectable MnthUp;
    public KMSelectable MnthDwn;
    public KMSelectable SympRight;
    public KMSelectable SympLeft;
    public KMSelectable DrugRight;
    public KMSelectable DrugLeft;
    public KMSelectable DoseRight;
    public KMSelectable DoseLeft;
    public KMSelectable DiagnoseRight;
    public KMSelectable DiagnoseLeft;

    public TextMesh SympText;
    public TextMesh DrugText;
    public TextMesh DoseText;
    public TextMesh DiagnoseText;
    public TextMesh DateText;
    public TextMesh MnthText;

    private static int _moduleIdCounter = 1;
    private int _moduleId;

    private bool _exploded = false;
    private bool _lastdigitSN;

    private static DiseaseInfo[] _diseases = new DiseaseInfo[]
    {
        new DiseaseInfo { Character = 'A', Disease = "Macrosoft",       Symptoms = new[] { "Fever", "Chills", "Dizziness" },                       Treatment = "Minecraft"               },
        new DiseaseInfo { Character = 'B', Disease = "Pear",            Symptoms = new[] { "Headache", "Sleepiness", "Thirstiness" },              Treatment = "GTA"                     },
        new DiseaseInfo { Character = 'C', Disease = "Moca-Cola",       Symptoms = new[] { "Bloating", "Cough", "Diarrhea" },                      Treatment = "Gears Of War"            },
        new DiseaseInfo { Character = 'D', Disease = "MicDonald’s",     Symptoms = new[] { "Dizziness", "Fatigue", "Fever" },                      Treatment = "Resident Evil"           },
        new DiseaseInfo { Character = 'E', Disease = "Drowning Donuts", Symptoms = new[] { "Headache", "Muscle Cramp", "Nausea" },                 Treatment = "PUBG"                    },
        new DiseaseInfo { Character = 'F', Disease = "Blueberry",       Symptoms = new[] { "Throat irritation", "Constipation", "Foot swelling" }, Treatment = "Fortnite"                },
        new DiseaseInfo { Character = 'G', Disease = "Buddylight",      Symptoms = new[] { "Hallucination", "Cold Hands", "Excessive Crying" },    Treatment = "Scrap Mechanic"          },
        new DiseaseInfo { Character = 'H', Disease = "Minttel",         Symptoms = new[] { "Gas", "Numbness", "Loss of smell" },                   Treatment = "Five Nights at Freddy’s" },
        new DiseaseInfo { Character = 'I', Disease = "Quitter",         Symptoms = new[] { "Bloating", "Fever", "Hallucination" },                 Treatment = "The Forest"              },
        new DiseaseInfo { Character = 'K', Disease = "Vulvo",           Symptoms = new[] { "Headache", "Sleepiness", "Fever" },                    Treatment = "Candy Crush"             },
        new DiseaseInfo { Character = 'L', Disease = "Marcedes",        Symptoms = new[] { "Cough", "Excessive Crying", "Muscle Cramp" },          Treatment = "Super Mario Bros."       },
        new DiseaseInfo { Character = 'M', Disease = "Chuvrolit",       Symptoms = new[] { "Diarrhea", "Cold Hands", "Gas" },                      Treatment = "Pac-Man"                 },
        new DiseaseInfo { Character = 'N', Disease = "MustardCard",     Symptoms = new[] { "Numbness", "Constipation", "Fatigue" },                Treatment = "Splatoon"                },
        new DiseaseInfo { Character = 'O', Disease = "Funta",           Symptoms = new[] { "Sleepiness", "Dizziness", "Thirstiness" },             Treatment = "Stardew Valley"          },
        new DiseaseInfo { Character = 'P', Disease = "Moreo",           Symptoms = new[] { "Sleepiness", "Cold Hands", "Thirstiness" },            Treatment = "Zelda"                   },
        new DiseaseInfo { Character = 'Q', Disease = "Flickers",        Symptoms = new[] { "Chills", "Loss of Smell", "Throat irritation" },       Treatment = "Farcry"                  },
        new DiseaseInfo { Character = 'R', Disease = "Shingles",        Symptoms = new[] { "Thirstiness", "Fever", "Headache" },                   Treatment = "World of Warcraft"       },
        new DiseaseInfo { Character = 'S', Disease = "OFC",             Symptoms = new[] { "Constipation", "Bloating", "Hallucination" },          Treatment = "League of Legends"       },
        new DiseaseInfo { Character = 'T', Disease = "Dalte Airlines",  Symptoms = new[] { "Hallucination", "Cold Hands", "Dizziness" },           Treatment = "Overwatch"               },
        new DiseaseInfo { Character = 'U', Disease = "Nuntendo",        Symptoms = new[] { "Chills", "Nausea", "Numbness" },                       Treatment = "Assassin’s Creed"        },
        new DiseaseInfo { Character = 'V', Disease = "Sonie",           Symptoms = new[] { "Loss of smell", "Cold Hands", "Sleepiness" },          Treatment = "Cuphead"                 },
        new DiseaseInfo { Character = 'W', Disease = "Aturi",           Symptoms = new[] { "Thirstiness", "Cough", "Fatigue" },                    Treatment = "Portal"                  },
        new DiseaseInfo { Character = 'X', Disease = "Wallshop",        Symptoms = new[] { "Diarrhea", "Sleepiness", "Foot swelling" },            Treatment = "Call of Duty"            },
        new DiseaseInfo { Character = 'Y', Disease = "Mootella",        Symptoms = new[] { "Gas", "Throat irritation", "Muscle Cramp" },           Treatment = "Battlefield"             },
        new DiseaseInfo { Character = 'Z', Disease = "Burger Queen",    Symptoms = new[] { "Muscle Cramp", "Constipation", "Sleepiness" },         Treatment = "CS:GO"                   },
        new DiseaseInfo { Character = '1', Disease = "Samsang",         Symptoms = new[] { "Throat irritation", "Cough", "Foot swelling" },        Treatment = "Red Dead Redemption"     },
        new DiseaseInfo { Character = '2', Disease = "Foyota",          Symptoms = new[] { "Sleepiness", "Headache", "Dizziness" },                Treatment = "Metal Gear Solid"        },
        new DiseaseInfo { Character = '3', Disease = "Aircar",          Symptoms = new[] { "Foot swelling", "Excessive", "Crying Nausea" },        Treatment = "Stranded Deep"           },
        new DiseaseInfo { Character = '4', Disease = "Buggies",         Symptoms = new[] { "Sleepiness", "Bloating", "Dizziness" },                Treatment = "Where’s Waldo"           },
        new DiseaseInfo { Character = '5', Disease = "Starducks",       Symptoms = new[] { "Constipation", "Hallucination", "Fatigue" },           Treatment = "KTaNE"                   },
        new DiseaseInfo { Character = '6', Disease = "Mike",            Symptoms = new[] { "Cold Hands", "Sleepiness", "Throat irritation" },      Treatment = "Tetris"                  },
    };
    private static CorrectDates[] _dates = new CorrectDates[]
    {
        new CorrectDates { Day = "28", Month = "7"},
        new CorrectDates { Day = "11", Month = "11"},
        new CorrectDates { Day = "12", Month = "4"},
        new CorrectDates { Day = "13", Month = "11"},
        new CorrectDates { Day = "1", Month = "9"},
        new CorrectDates { Day = "2", Month = "9"},
        new CorrectDates { Day = "11", Month = "9"},
        new CorrectDates { Day = "30", Month = "4"},
        new CorrectDates { Day = "16", Month = "7"},
        new CorrectDates { Day = "14", Month = "2"},
        new CorrectDates { Day = "4", Month = "9"},
        new CorrectDates { Day = "4", Month = "4"},
        new CorrectDates { Day = "1", Month = "4"},
        new CorrectDates { Day = "1", Month = "3"},
        new CorrectDates { Day = "13", Month = "1"},
        new CorrectDates { Day = "25", Month = "6"},
        new CorrectDates { Day = "27", Month = "7"},
        new CorrectDates { Day = "2", Month = "8"},
        new CorrectDates { Day = "16", Month = "10"},
        new CorrectDates { Day = "18", Month = "12"},
        new CorrectDates { Day = "7", Month = "12"},
        new CorrectDates { Day = "30", Month = "1"},
        new CorrectDates { Day = "2", Month = "10"},
        new CorrectDates { Day = "20", Month = "8"},
        new CorrectDates { Day = "5", Month = "6"},
        new CorrectDates { Day = "27", Month = "5"},
        new CorrectDates { Day = "11", Month = "5"},
        new CorrectDates { Day = "20", Month = "11"},
        new CorrectDates { Day = "4", Month = "7"},



    };
    private string[] _selectableSymptoms;
    private string[] _selectableDiagnoses;
    private string[] _selectableTreatments;
    private string[] _selectableDoses;
    private string[] _selectableDates;
    private string[] _selectableMonths;
    private string indicatorLetters;

    private int _selectedSymptom;
    private int _selectedDiagnosis;
    private int _selectedTreatment;
    private int _selectedDose;
    private int _selectedDates;
    private int _selectedMonths;
    private int _unsolvedModules;

    private float _initialBombTime;
    private float _bombModulesTotal;

    void Update()
    {
        _unsolvedModules = (Bomb.GetSolvableModuleNames().Count() - Bomb.GetSolvedModuleNames().Count);
    }

    void Start()
    {
        _moduleId = _moduleIdCounter++;

        Module.OnActivate += ActivateModule;
        Caduceus.OnInteract += CaduceusPressed;
        DateUp.OnInteract += DateUpPressed;
        DateDwn.OnInteract += DateDwnPressed;
        MnthUp.OnInteract += MnthUpPressed;
        MnthDwn.OnInteract += MnthDwnPressed;
        DoseLeft.OnInteract += DoseLeftPressed;
        DoseRight.OnInteract += DoseRightPressed;
        DiagnoseRight.OnInteract += DiaRightPressed;
        DiagnoseLeft.OnInteract += DiaLeftPressed;
        DrugRight.OnInteract += DrugRightPressed;
        DrugLeft.OnInteract += DrugLeftPressed;
        SympLeft.OnInteract += SympLeftPressed;
        SympRight.OnInteract += SympRightPressed;

        _initialBombTime = Bomb.GetTime();
        _bombModulesTotal = Bomb.GetSolvableModuleNames().Count();

        var randomDisease = _diseases.PickRandom();
        var symptoms = randomDisease.Symptoms.ToList();
        var additionalSymptoms = _diseases.SelectMany(d => d.Symptoms).Distinct().Except(symptoms).ToList().Shuffle().Take(2);
        _selectableSymptoms = symptoms.Concat(additionalSymptoms).ToArray().Shuffle();

        _selectableDiagnoses = _diseases.ToList().Shuffle().Take(5).Select(d => d.Disease).ToArray();
        if (!_selectableDiagnoses.Any(s => s.Equals(randomDisease.Disease)))
            _selectableDiagnoses[Rnd.Range(0, 5)] = randomDisease.Disease;

        var selectableTreatments = new List<string>();
        selectableTreatments.AddRange(_diseases.ToList().Shuffle().Take(4).Select(d => d.Treatment));
        if (selectableTreatments.Any(s => s.Equals(randomDisease.Treatment)))
            selectableTreatments[0] = randomDisease.Treatment;
        selectableTreatments.Add("Cyanide");
        _selectableTreatments = selectableTreatments.ToArray().Shuffle();

        _selectableDoses = new[] { CalculateCorrectDose(), "420g" }.Concat(Enumerable.Range(0, 3).Select(i => Rnd.Range(1, 999) + "mg")).ToArray().Shuffle();

        _lastdigitSN = Bomb.GetSerialNumberNumbers().Last() <= 9;

        _selectedMonths = UnityEngine.Random.Range(1, 12);
        _selectedDates = UnityEngine.Random.Range(1, 30);

        if (Bomb.GetIndicators().Count() > 0)
            {

            indicatorLetters = Bomb.GetOnIndicators().;

            LogMessage(indicatorLetters);


        }
      



        SetTexts();
    }



    private void SetTexts()
    {
        //DiagnoseText.text = _selectableDiagnoses[_selectedDiagnosis];
        SympText.text = _selectableSymptoms[_selectedSymptom];
        DiagnoseText.text = _selectableDiagnoses[_selectedDiagnosis];
        DoseText.text = _selectableDoses[_selectedDose];
        DrugText.text = _selectableTreatments[_selectedTreatment];
        //DateText.text = _selectableDates[_selectedDates];
        //MnthText.text = _selectableMonths[_selectedMonths];
        // TODO: Alle 6
    }

    private string CalculateCorrectDose()
    {
        // && = und
        // || = or

        // ...

        if (Bomb.GetSolvableModuleNames().Contains("Forget Me Not") && (Bomb.GetBatteryHolderCount() == 3) && (Bomb.GetBatteryCount() == 3) && (Bomb.GetOnIndicators().Contains("FRK") && Bomb.GetOffIndicators().Contains("TRN")))
        {

            return "420g";

        }
        else
        {
            if (Bomb.GetOnIndicators().Contains("FRQ"))
            {



            }
            else
            {

                if (_selectableSymptoms.Contains("Fever"))
                {

                    return (Bomb.GetSolvedModuleNames().Count() * _unsolvedModules).ToString();

                }
                else
                {
                    if (Bomb.GetModuleNames().Contains("iPhone"))
                    {
                        return (Bomb.GetSerialNumberNumbers().First() * Bomb.GetSerialNumberNumbers().Last()).ToString();

                    }
                    else
                    {

                        //return sumofalphanumericvalues of indicators

                        return "itworks";

                    }
                }

            }

        };

        return "420mg";
    }

    private bool SympRightPressed()
    {
        _selectedSymptom = (_selectedSymptom + 1) % _selectableSymptoms.Length;
        SetTexts();
        return false;
    }

    private bool SympLeftPressed()
    {
        _selectedSymptom = (_selectedSymptom + _selectableSymptoms.Length - 1) % _selectableSymptoms.Length;
        SetTexts();
        return false;
    }

    private bool DrugLeftPressed()
    {
        _selectedTreatment = (_selectedTreatment - 1) % _selectableTreatments.Length;
        SetTexts();
        return false;
    }

    private bool DrugRightPressed()
    {
        _selectedTreatment = (_selectedTreatment + 1) % _selectableTreatments.Length;
        SetTexts();
        return false;
    }

    private bool DiaLeftPressed()
    {
        _selectedDiagnosis = (_selectedDiagnosis - 1) % _selectableDiagnoses.Length;
        SetTexts();
        return false;
    }

    private bool DiaRightPressed()
    {
        _selectedDiagnosis = (_selectedDiagnosis + 1) % _selectableDiagnoses.Length;
        SetTexts();
        return false;
    }

    private bool DoseRightPressed()
    {
        _selectedDose = (_selectedDose + 1) % _selectableDoses.Length;
        SetTexts();
        return false;
    }

    private bool DoseLeftPressed()
    {
        _selectedDose = (_selectedDose + _selectableDoses.Length - 1) % _selectableDoses.Length;
        SetTexts();
        return false;
    }

    private bool MnthDwnPressed()
    {
        LogMessage("The Month Down Button was pressed. Theoretically, something would happen, but the programer was too lazy.");


        return false; //IMMER return false, da sonst Compilerfeheler//
    }

    private bool MnthUpPressed()
    {
        LogMessage("The Month Up Button was pressed. Theoretically, something would happen, but the programer was too lazy.");

        Module.HandlePass();

        return false;
    }

    private bool DateDwnPressed()
    {
        LogMessage("The Day Down Button was pressed. Theoretically, something would happen, but the programer was too lazy.");



        return false;
    }

    private bool DateUpPressed()
    {
        LogMessage("The Date Up Button was pressed. Theoretically, something would happen, but the programer was too lazy.");
        Module.HandlePass();
        LogMessage("You're Welcome. :P");


        return false;
    }

    private bool CaduceusPressed()
    {
        // Find the correct character from the Venn diagram
        var red = Bomb.GetSerialNumberNumbers().Last() % 2 == 0;
        var green = Bomb.GetBatteryCount() >= 2;
        var blue = Bomb.GetModuleNames().Count % 2 == 0;
        var yellow = Bomb.GetOnIndicators().Count() > Bomb.GetOffIndicators().Count();
        var orange = Bomb.GetTime() > _initialBombTime / 2;

        // TO DO!! Find character in Venn diagram!
        var character = 'A';//...

        // Starting from that disease, find the first one that has all three symptoms on the bomb
        var index = _diseases.IndexOf(d => d.Character == character);
        while (!_diseases[index].Symptoms.All(s => _selectableSymptoms.Contains(s)))
            index = (index + 1) % _diseases.Length;

        // Check treatment
        if (_selectableTreatments[_selectedTreatment] != _diseases[index].Treatment)
        {
            LogMessage("Wrong treatment selected. I expected {0}, but you gave me {1}.", _diseases[index].Treatment, _selectableTreatments[_selectedTreatment]);
            Module.HandleStrike();
            return false;
        }

        // Check dose
        if (_selectableDoses[_selectedDose] != CalculateCorrectDose())
        {
            LogMessage("Wrong dose selected. I expected {0}, but you gave me {1}.", CalculateCorrectDose(), _selectableDoses[_selectedDose]);
            Module.HandleStrike();
            return false;
        }

        // Check disease
        if (_selectableDiagnoses[_selectedDiagnosis] != _diseases[index].Disease)
        {
            LogMessage("Wrong disease/diagnosis selected. I expected {0}, but you gave me {1}.", _diseases[index].Disease, _selectableDiagnoses[_selectedDiagnosis]);
            Module.HandleStrike();
            return false;
        }

        // Check follow-up date
        if (false)//...
        {

        }

        // Everything correct!
        LogMessage("Module solved.");
        Module.HandlePass();

        return false;
    }

    void ActivateModule()
    {
    }

    void LogMessage(string message, params string[] parameters)
    {
        Debug.LogFormat("[Dr. Doctor #{0}] {1}", _moduleId, string.Format(message, parameters));
    }

    //#pragma warning disable 414
    //    private string TwitchHelpMessage = @"Hit the correct spots with “!{0} press bl mm tm tl”. (Locations are tl, tm, ml, mm, mr, bl, bm, br.)";
    //#pragma warning restore 414

    //    KMSelectable[] ProcessTwitchCommand(string command)
    //    {
    //    }
}
