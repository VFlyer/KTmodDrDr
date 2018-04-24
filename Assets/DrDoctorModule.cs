using System;
using DrDoctor;
using System.Collections.Generic;
using System.Linq;
using BlindAlley;
using UnityEngine;
using Rnd = UnityEngine.Random;
using System.Text.RegularExpressions;
using System.Collections;

/// <summary>
/// On the Subject of Dr. Doctor
/// Created by ligio90
/// </summary>
public class DrDoctorModule : MonoBehaviour
{
    public KMBombInfo Bomb;
    public KMBombModule Module;
    public KMAudio Audio;

    //Here's the list of all KMSelectables
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
    //End of the List

    public TextMesh SympText;
    public TextMesh DrugText;
    public TextMesh DoseText;
    public TextMesh DiagnoseText;
    public TextMesh DateText;
    public TextMesh MnthText;

    private static int _moduleIdCounter = 1;
    private int _moduleId;

    private static DiseaseInfo[] _diseases = new DiseaseInfo[]
    {
        new DiseaseInfo { Character = 'A', Disease = "Alztimer's",              Symptoms = new[] { "Fever", "Chills", "Dizziness" },                       Treatment = "Minecraftazol"    },
        new DiseaseInfo { Character = 'B', Disease = "Braintenance",            Symptoms = new[] { "Headache", "Sleepiness", "Thirstiness" },              Treatment = "Gr-Theta Autazine"},
        new DiseaseInfo { Character = 'C', Disease = "Color allergy",           Symptoms = new[] { "Bloating", "Cough", "Diarrhea" },                      Treatment = "Tears of Tar"     },
        new DiseaseInfo { Character = 'D', Disease = "Detonession",             Symptoms = new[] { "Dizziness", "Fatigue", "Fever" },                      Treatment = "Residentevele"    },
        new DiseaseInfo { Character = 'E', Disease = "Emojilepsy",              Symptoms = new[] { "Headache", "Muscle Cramp", "Nausea" },                 Treatment = "Vitamin PUBG-12"  },
        new DiseaseInfo { Character = 'F', Disease = "Foot and Morse",          Symptoms = new[] { "Throat irritation", "Constipation", "Foot swelling" }, Treatment = "Fortinite"        },
        new DiseaseInfo { Character = 'G', Disease = "Gout of Life",            Symptoms = new[] { "Hallucination", "Cold Hands", "Excessive Crying" },    Treatment = "Scrapmechanol"    },
        new DiseaseInfo { Character = 'H', Disease = "HRV",                     Symptoms = new[] { "Gas", "Numbness", "Loss of Smell" },                   Treatment = "Freddi-5"         },
        new DiseaseInfo { Character = 'I', Disease = "Indicitis",               Symptoms = new[] { "Bloating", "Fever", "Hallucination" },                 Treatment = "Forestamine"      },
        new DiseaseInfo { Character = 'J', Disease = "Jaundry",                 Symptoms = new[] { "Disappearance of the Ears", "Fever", "Shortness of Breath" }, Treatment = "λ-3"       },
        new DiseaseInfo { Character = 'K', Disease = "Keypad stones",           Symptoms = new[] { "Headache", "Sleepiness", "Fever" },                    Treatment = "Crushed Candy"    },
        new DiseaseInfo { Character = 'L', Disease = "Legomania",               Symptoms = new[] { "Cough", "Excessive Crying", "Muscle Cramp" },          Treatment = "Supermariobromine"},
        new DiseaseInfo { Character = 'M', Disease = "Microcontusion",          Symptoms = new[] { "Fever", "Chills", "Dizziness" },                       Treatment = "Q-Bertamin"       },
        new DiseaseInfo { Character = 'N', Disease = "Narcolization",           Symptoms = new[] { "Numbness", "Constipation", "Fatigue" },                Treatment = "Vitamin Wii"      },
        new DiseaseInfo { Character = 'O', Disease = "OCd",                     Symptoms = new[] { "Sleepiness", "Dizziness", "Thirstiness" },             Treatment = "Astrodrosodale"   },
        new DiseaseInfo { Character = 'P', Disease = "Piekinson’s",             Symptoms = new[] { "Sleepiness", "Cold Hands", "Thirstiness" },            Treatment = "Adlez DNA Knil"   },
        new DiseaseInfo { Character = 'Q', Disease = "Quackgrounds",            Symptoms = new[] { "Chills", "Loss of Smell", "Throat irritation" },       Treatment = "Nearwhisper"      },
        new DiseaseInfo { Character = 'R', Disease = "Royal Flu",               Symptoms = new[] { "Thirstiness", "Fever", "Headache" },                   Treatment = "Warcraftazol"     },
        new DiseaseInfo { Character = 'S', Disease = "Seizure Siphor",          Symptoms = new[] { "Constipation", "Bloating", "Hallucination" },          Treatment = "Leega Ledgins"    },
        new DiseaseInfo { Character = 'T', Disease = "Tetrinus",                Symptoms = new[] { "Hallucination", "Cold Hands", "Dizziness" },           Treatment = "No-Mercy"         },
        new DiseaseInfo { Character = 'U', Disease = "Urinary LEDs",            Symptoms = new[] { "Chills", "Nausea", "Numbness" },                       Treatment = "Assassine Cream"  },
        new DiseaseInfo { Character = 'V', Disease = "Verticode",               Symptoms = new[] { "Loss of smell", "Cold Hands", "Sleepiness" },          Treatment = "Cupcakes"         },
        new DiseaseInfo { Character = 'W', Disease = "Widgeting",               Symptoms = new[] { "Thirstiness", "Cough", "Fatigue" },                    Treatment = "GLa-doze"         },
        new DiseaseInfo { Character = 'X', Disease = "XMAs",                    Symptoms = new[] { "Diarrhea", "Sleepiness", "Foot swelling" },            Treatment = "Ball of Cootie"   },
        new DiseaseInfo { Character = 'Y', Disease = "Yes-no infection",        Symptoms = new[] { "Gas", "Throat irritation", "Muscle Cramp" },           Treatment = "War-Med"          },
        new DiseaseInfo { Character = 'Z', Disease = "Zooties",                 Symptoms = new[] { "Muscle Cramp", "Constipation", "Sleepiness" },         Treatment = "CS-Go Lotion"     },
        new DiseaseInfo { Character = '1', Disease = "Chronic Talk",            Symptoms = new[] { "Throat irritation", "Cough", "Foot swelling" },        Treatment = "Red Ded"          },
        new DiseaseInfo { Character = '2', Disease = "Jukepox",                 Symptoms = new[] { "Sleepiness", "Headache", "Dizziness" },                Treatment = "Solid Gear Metal" },
        new DiseaseInfo { Character = '3', Disease = "Neurolysis",              Symptoms = new[] { "Foot swelling", "Excessive Crying", "Nausea" },        Treatment = "Vitamin BEAM"     },
        new DiseaseInfo { Character = '4', Disease = "Perspective Loss",        Symptoms = new[] { "Sleepiness", "Bloating", "Dizziness" },                Treatment = "Waldohol"         },
        new DiseaseInfo { Character = '5', Disease = "Orientitis",              Symptoms = new[] { "Gas", "Numbness", "Loss of smell" },                   Treatment = "Semtex"           },
        new DiseaseInfo { Character = '6', Disease = "Huntington’s disease",    Symptoms = new[] { "Cold Hands", "Sleepiness", "Throat irritation" },      Treatment = "Tetrisine"        },
    };
    private static CorrectDates[] _dates = new CorrectDates[]
    {
        new CorrectDates { Day = 13, Month = 1 },
        new CorrectDates { Day = 30, Month = 1 },
        new CorrectDates { Day = 14, Month = 2 },
        new CorrectDates { Day = 1, Month = 3 },
        new CorrectDates { Day = 1, Month = 4 },
        new CorrectDates { Day = 4, Month = 4 },
        new CorrectDates { Day = 12, Month = 4 },
        new CorrectDates { Day = 30, Month = 4 },
        new CorrectDates { Day = 11, Month = 5 },
        new CorrectDates { Day = 27, Month = 5 },
        new CorrectDates { Day = 5, Month = 6 },
        new CorrectDates { Day = 25, Month = 6 },
        new CorrectDates { Day = 16, Month = 7 },
        new CorrectDates { Day = 27, Month = 7 },
        new CorrectDates { Day = 28, Month = 7 },
        new CorrectDates { Day = 4, Month = 7 },
        new CorrectDates { Day = 2, Month = 8 },
        new CorrectDates { Day = 20, Month = 8 },
        new CorrectDates { Day = 1, Month = 9 },
        new CorrectDates { Day = 2, Month = 9 },
        new CorrectDates { Day = 4, Month = 9 },
        new CorrectDates { Day = 11, Month = 9 },
        new CorrectDates { Day = 2, Month = 10 },
        new CorrectDates { Day = 16, Month = 10 },
        new CorrectDates { Day = 11, Month = 11 },
        new CorrectDates { Day = 13, Month = 11 },
        new CorrectDates { Day = 20, Month = 11 },
        new CorrectDates { Day = 7, Month = 12 },
        new CorrectDates { Day = 18, Month = 12 },
    };

    private string[] _selectableSymptoms;
    private string[] _selectableDiagnoses;
    private string[] _selectableTreatments;
    private string[] _selectableDoses;

    private int _selectedSymptom;
    private int _selectedDiagnosis;
    private int _selectedTreatment;
    private int _selectedDose;
    private int _selectedDate;
    private int _selectedMonth;
    private bool _isSolved;
    private float _halfBombTime;

    const string rules = "AFDPEOMZBGLQHRM1CJKUNYX5ITV3S246";

    void Start()
    {
        _moduleId = _moduleIdCounter++;
        _isSolved = false;
        _halfBombTime = Bomb.GetTime() / 2;

        var numIterations = 0;
        tryAgain:
        numIterations++;

        var selectableDiseases = _diseases.ToList().Shuffle().Take(3).ToArray();
        _selectableSymptoms = _diseases.SelectMany(d => d.Symptoms).Distinct().ToList().Shuffle().Take(5).ToArray();
        _selectableDiagnoses = selectableDiseases.Select(d => d.Disease).ToArray();

        var answer1 = CalculateAnswer(false);
        var answer2 = CalculateAnswer(true);

        if (answer1 == null || answer2 == null)
        {
            if (numIterations > 1000)
            {
                Debug.LogFormat("[Dr. Doctor #{0}] Possible bug in the module. Press the Caduceus to solve.", _moduleId);
                SympText.text = "Just";
                DiagnoseText.text = "press";
                DrugText.text = "the";
                DoseText.text = "Caduceus";
                Caduceus.OnInteract = delegate { Module.HandlePass(); return false; };
                return;
            }
            goto tryAgain;
        }

        var definiteTreatments = selectableDiseases.Select(d => d.Treatment);
        _selectableTreatments = definiteTreatments.Concat(new[] { "Cyanide" }).Distinct().Concat(_diseases.Select(d => d.Treatment).Except(definiteTreatments).ToList().Shuffle()).Take(5).ToArray().Shuffle();
        var selectableDoses = new HashSet<string>(answer1.Doses.Concat(answer2.Doses).Concat(new[] { "420g" }));
        while (selectableDoses.Count < 5)
            selectableDoses.Add(Rnd.Range(1, 1000) + "mg");
        _selectableDoses = selectableDoses.ToArray().Shuffle();

        _selectedMonth = Rnd.Range(1, 13);
        _selectedDate = Rnd.Range(1, 32);

        var numSolvable = Bomb.GetSolvableModuleNames().Count;
        LogMessage("Solution before half of the bomb time has passed:");
        LogMessage("Diagnosis: {0}, Treatment: {1}, Follow-up date: {2}/{3}", answer1.Diagnosis, answer1.Treatment, answer1.Day, answer1.Month);
        LogMessage("Dosis per number of solved modules: {0}", string.Join(", ", answer1.Doses.Select((d, ix) => string.Format("{0}={1}", ix, d)).ToArray()));
        LogMessage("Solution after half of the bomb time has passed:");
        LogMessage("Diagnosis: {0}, Treatment: {1}, Follow-up date: {2}/{3}", answer2.Diagnosis, answer2.Treatment, answer2.Day, answer2.Month);
        LogMessage("Dosis per number of solved modules: {0}", string.Join(", ", answer2.Doses.Select((d, ix) => string.Format("{0}={1}", ix, d)).ToArray()));

        Caduceus.OnInteract += CaduceusPressed;
        DateUp.OnInteract += MakeButtonPressHandler(DateUp, () => { _selectedDate = _selectedDate % 31 + 1; });
        DateDwn.OnInteract += MakeButtonPressHandler(DateDwn, () => { _selectedDate = (_selectedDate + 29) % 31 + 1; });
        MnthUp.OnInteract += MakeButtonPressHandler(MnthUp, () => { _selectedMonth = _selectedMonth % 12 + 1; });
        MnthDwn.OnInteract += MakeButtonPressHandler(MnthDwn, () => { _selectedMonth = (_selectedMonth + 10) % 12 + 1; });
        DoseLeft.OnInteract += MakeButtonPressHandler(DoseLeft, () => { _selectedDose = (_selectedDose + _selectableDoses.Length - 1) % _selectableDoses.Length; });
        DoseRight.OnInteract += MakeButtonPressHandler(DoseRight, () => { _selectedDose = (_selectedDose + 1) % _selectableDoses.Length; });
        DiagnoseLeft.OnInteract += MakeButtonPressHandler(DiagnoseLeft, () => { _selectedDiagnosis = (_selectedDiagnosis + _selectableDiagnoses.Length - 1) % _selectableDiagnoses.Length; });
        DiagnoseRight.OnInteract += MakeButtonPressHandler(DiagnoseRight, () => { _selectedDiagnosis = (_selectedDiagnosis + 1) % _selectableDiagnoses.Length; });
        DrugLeft.OnInteract += MakeButtonPressHandler(DrugLeft, () => { _selectedTreatment = (_selectedTreatment + _selectableTreatments.Length - 1) % _selectableTreatments.Length; });
        DrugRight.OnInteract += MakeButtonPressHandler(DrugRight, () => { _selectedTreatment = (_selectedTreatment + 1) % _selectableTreatments.Length; });
        SympLeft.OnInteract += MakeButtonPressHandler(SympLeft, () => { _selectedSymptom = (_selectedSymptom + _selectableSymptoms.Length - 1) % _selectableSymptoms.Length; });
        SympRight.OnInteract += MakeButtonPressHandler(SympRight, () => { _selectedSymptom = (_selectedSymptom + 1) % _selectableSymptoms.Length; });

        SetTexts();
    }

    private void SetTexts()
    {
        SympText.text = _selectableSymptoms[_selectedSymptom];
        SympText.transform.localScale = new Vector3(SympText.text == "Disappearance of the Ears" ? .02f : .027777777777777f, .1666667f, 25f);
        DiagnoseText.text = _selectableDiagnoses[_selectedDiagnosis];
        DoseText.text = _selectableDoses[_selectedDose];
        DrugText.text = _selectableTreatments[_selectedTreatment];
        DateText.text = _selectedDate.ToString();
        MnthText.text = _selectedMonth.ToString();
    }

    private string CalculateCorrectDose(int numSolved)
    {
        if (Bomb.GetSolvableModuleNames().Contains("Forget Me Not") && (Bomb.GetBatteryHolderCount() == 3) && (Bomb.GetBatteryCount() == 3) && (Bomb.GetOnIndicators().Contains("FRK") && Bomb.GetOffIndicators().Contains("TRN")))
            return "420g";

        string dose;
        if (Bomb.GetOnIndicators().Contains("FRQ"))
        {
            if (new[] { 2, 3, 5, 7 }.Contains(Bomb.GetSerialNumberNumbers().Last()))
                dose = "2g";
            else
                dose = (Bomb.GetPorts().Distinct().Count() + Bomb.GetModuleNames().Count()) + "mg";
        }
        else
        {
            if (_selectableSymptoms.Contains("Fever"))
                dose = ((numSolved * (Bomb.GetSolvableModuleNames().Count() - numSolved)).ToString() + "mg");
            else
            {
                if (Bomb.GetModuleNames().Contains("The iPhone"))
                    dose = ((Bomb.GetSerialNumberNumbers().First() * Bomb.GetSerialNumberNumbers().Last()).ToString() + "mg");
                else
                    dose = Bomb.GetIndicators().Sum(ind => ind.Sum(l => l - 'A' + 1)) + "mg";
            }
        }

        var m = Regex.Match(dose, @"^(\d{3,})\dmg$");
        if (m.Success)
            return m.Groups[1].Value + "g";
        if (dose == "0mg")
            return "1mg";
        return dose;
    }

    private KMSelectable.OnInteractHandler MakeButtonPressHandler(KMSelectable button, Action action)
    {
        return delegate
        {
            button.AddInteractionPunch();
            Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, button.transform);
            if (!_isSolved)
            {
                action();
                SetTexts();
            }
            return false;
        };
    }

    private bool CaduceusPressed()
    {
        Caduceus.AddInteractionPunch();
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Caduceus.transform);

        if (_isSolved)
            return false;

        var answer = CalculateAnswer(_halfBombTime <= Bomb.GetTime());

        // Check treatment
        if (_selectableTreatments[_selectedTreatment] != answer.Treatment)
        {
            LogMessage("Wrong treatment selected. I expected {0}, but you gave me {1}.", answer.Treatment, _selectableTreatments[_selectedTreatment]);
            Module.HandleStrike();
            return false;
        }

        // Check dose
        var numSolved = Bomb.GetSolvedModuleNames().Count;
        if (_selectableDoses[_selectedDose] != answer.Doses[numSolved])
        {
            LogMessage("Wrong dose selected. We have {0} solved modules, so I expected {1}, but you gave me {2}.", numSolved, answer.Doses[numSolved], _selectableDoses[_selectedDose]);
            Module.HandleStrike();
            return false;
        }

        // Check disease
        if (_selectableDiagnoses[_selectedDiagnosis] != answer.Diagnosis)
        {
            LogMessage("Wrong disease/diagnosis selected. I expected {0}, but you gave me {1}.", answer.Diagnosis, _selectableDiagnoses[_selectedDiagnosis]);
            Module.HandleStrike();
            return false;
        }

        // Check follow-up date
        if (_selectedDate != answer.Day || _selectedMonth != answer.Month)
        {
            LogMessage("Wrong follow-up date selected. I expected {0}/{1}, but you gave me {2}/{3}.", answer.Day, answer.Month, _selectedDate, _selectedMonth);
            Module.HandleStrike();
            return false;
        }

        // Everything correct!
        LogMessage("Module solved.");
        Module.HandlePass();
        _isSolved = true;

        return false;
    }

    private Answer CalculateAnswer(bool halfTimePassed)
    {
        var rule = 0;

        // Red: Last Digit of SN even
        if (Bomb.GetSerialNumberNumbers().Last() % 2 == 0)
        {
            rule += 8;
        }
        // Orange: More than half the bombs time is left
        if (halfTimePassed)
        {
            rule += 16;
        }
        // Yellow: More Lit than Unlit
        if (Bomb.GetOnIndicators().Count() > Bomb.GetOffIndicators().Count())
        {
            rule += 2;
        }
        // Green: 2 or more Batteries
        if (Bomb.GetBatteryCount() >= 2)
        {
            rule += 4;
        }
        // Blue: Even number of modules.
        if (Bomb.GetModuleNames().Count() % 2 == 0)
        {
            rule += 1;
        }

        // Starting from that disease, find the first one that has all three symptoms on the bomb
        var tentativeIndex = _diseases.IndexOf(d => d.Character == rules[rule]);
        var index = -1;
        for (int i = 0; i < _diseases.Length; i++)
        {
            var ri = (tentativeIndex + i) % _diseases.Length;
            if (Array.IndexOf(_selectableDiagnoses, _diseases[ri].Disease) != -1 && _diseases[ri].Symptoms.All(s => _selectableSymptoms.Contains(s)))
                index = ri;
        }
        if (index == -1)
            return null;

        // Check follow-up date
        CorrectDates correctDate = null;
        int? nearestDistance = null;
        var today = DateTime.Now.Date;
        var todayInYear = new CorrectDates { Day = today.Day, Month = today.Month }.DayInYear(DateTime.IsLeapYear(today.Year));

        for (int i = 0; i < _dates.Length; i++)
        {
            var dayInPrevYear = _dates[i].DayInYear(DateTime.IsLeapYear(today.Year - 1)) - (DateTime.IsLeapYear(today.Year - 1) ? 366 : 365);
            var dayInThisYear = _dates[i].DayInYear(DateTime.IsLeapYear(today.Year));
            var dayInNextYear = _dates[i].DayInYear(DateTime.IsLeapYear(today.Year + 1)) + (DateTime.IsLeapYear(today.Year) ? 366 : 365);

            foreach (var day in new[] { dayInPrevYear, dayInThisYear, dayInNextYear })
            {
                if (nearestDistance == null || Math.Abs(day - todayInYear) <= nearestDistance.Value)
                {
                    nearestDistance = Math.Abs(day - todayInYear);
                    correctDate = _dates[i];
                }
            }
        }

        return new Answer
        {
            Day = correctDate.Day,
            Month = correctDate.Month,
            Diagnosis = _diseases[index].Disease,
            Doses = Enumerable.Range(0, Bomb.GetSolvableModuleNames().Count).Select(numSolved => CalculateCorrectDose(numSolved)).ToArray(),
            Treatment = Bomb.GetSolvableModuleNames().Contains("Forget Me Not") && (Bomb.GetBatteryHolderCount() == 3) && (Bomb.GetBatteryCount() == 3) && (Bomb.GetOnIndicators().Contains("FRK") && Bomb.GetOffIndicators().Contains("TRN"))
                ? "Cyanide"
                : _diseases[index].Treatment
        };
    }

    void LogMessage(string message, params object[] parameters)
    {
        Debug.LogFormat("[Dr. Doctor #{0}] {1}", _moduleId, string.Format(message, parameters));
    }

#pragma warning disable 414
    private string TwitchHelpMessage = @"Use “!{0} cycle symptoms diagnoses treatments doses” to cycle any combination of screens or “!{0} cycle” to cycle all of them. Submit the correct solution with “!{0} treat <disease>,<treatment>,<dose>,<day>,<month>”.";
#pragma warning restore 414

    private class CycleInfo
    {
        public KMSelectable Right;
        public string[] Values;
    }

    IEnumerator ProcessTwitchCommand(string command)
    {
        command = command.ToLowerInvariant().Trim();

        if (command.StartsWith("cycle ") || command == "cycle")
        {
            var symp = new CycleInfo { Right = SympRight, Values = _selectableSymptoms };
            var diag = new CycleInfo { Right = DiagnoseRight, Values = _selectableDiagnoses };
            var drug = new CycleInfo { Right = DrugRight, Values = _selectableTreatments };
            var dose = new CycleInfo { Right = DoseRight, Values = _selectableDoses };
            var cyclers = new Dictionary<string, CycleInfo>
            {
                { "symptom", symp },
                { "symptoms", symp },
                { "s", symp },
                { "disease", diag },
                { "diseases", diag },
                { "diagnosis", diag },
                { "diagnoses", diag },
                { "di", diag },
                { "treatment", drug },
                { "treatments", drug },
                { "drug", drug },
                { "drugs", drug },
                { "t", drug },
                { "dosis", dose },
                { "doses", dose },
                { "d", dose }
            };

            var pieces = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var cycle = pieces.Length == 1 ? new[] { symp, diag, drug, dose } : pieces.Skip(1).Select(p => cyclers.ContainsKey(p) ? cyclers[p] : null).ToArray();
            if (cycle.Any(c => c == null))
            {
                yield return string.Format("sendtochaterror I don’t know what “{0}” is. You can cycle these things: {1}", string.Join(", ", cyclers.Keys.ToArray()));
                yield break;
            }
            yield return null;
            foreach (var cyc in cycle)
            {
                for (int i = 0; i < cyc.Values.Length; i++)
                {
                    cyc.Right.OnInteract();
                    yield return new WaitForSeconds(1.2f);
                }
                yield return new WaitForSeconds(.5f);
            }
            yield break;
        }
        else if (command.StartsWith("submit ") || command.StartsWith("treat ") || command.StartsWith("answer "))
        {
            var pieces = command.Substring(command.IndexOf(' ') + 1).Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (pieces.Length != 5)
            {
                yield return "sendtochaterror I need 5 items: disease, treatment, dose, day, and month of the follow-up appointment.";
                yield break;
            }
            yield return null;

            var found = false;
            foreach (var obj in trySubmit(_selectableDiagnoses.Length, DiagnoseRight, () => _selectableDiagnoses[_selectedDiagnosis], pieces[0], "disease", _diseases.Any(d => d.Disease.StartsWith(pieces[0], StringComparison.InvariantCultureIgnoreCase)), () => { found = true; }))
                yield return obj;
            if (!found)
                yield break;

            found = false;
            foreach (var obj in trySubmit(_selectableTreatments.Length, DrugRight, () => _selectableTreatments[_selectedTreatment], pieces[1], "treatment", _diseases.Any(d => d.Treatment.StartsWith(pieces[1], StringComparison.InvariantCultureIgnoreCase)), () => { found = true; }))
                yield return obj;
            if (!found)
                yield break;

            found = false;
            foreach (var obj in trySubmit(_selectableDoses.Length, DoseRight, () => _selectableDoses[_selectedDose], pieces[2], "dose", Regex.IsMatch(pieces[2], @"^\s*\d+\s*m?g\s*$", RegexOptions.IgnoreCase), () => { found = true; }))
                yield return obj;
            if (!found)
                yield break;

            int day, month;
            if (!int.TryParse(pieces[3], out day) || day < 1 || day > 31 || !int.TryParse(pieces[4], out month) || month < 1 || month > 12)
            {
                yield return string.Format("sendtochaterror I’m sorry, on what planet is {0}/{1} a valid date for a follow-up appointment?", pieces[3], pieces[4]);
                yield break;
            }

            while (_selectedDate != day)
            {
                DateUp.OnInteract();
                yield return new WaitForSeconds(.1f);
            }
            while (_selectedMonth != month)
            {
                MnthUp.OnInteract();
                yield return new WaitForSeconds(.1f);
            }

            Caduceus.OnInteract();
        }
    }

    private IEnumerable<object> trySubmit(int items, KMSelectable rightButton, Func<string> getSelection, string input, string thing, bool isValid, Action found)
    {
        for (int i = 0; i < items; i++)
        {
            if (getSelection().StartsWith(input, StringComparison.InvariantCultureIgnoreCase))
            {
                found();
                yield break;
            }
            rightButton.OnInteract();
            yield return new WaitForSeconds(.1f);
        }
        if (isValid)
        {
            yield return string.Format("sendtochaterror The {0} “{1}” isn’t on the module.", thing, input);
            yield return "unsubmittablepenalty";
        }
        else
            yield return string.Format("sendtochaterror I don’t know a {0} called “{1}”.", thing, input);
    }
}
