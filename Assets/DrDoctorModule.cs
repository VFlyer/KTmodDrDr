using System;
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

    private static int _moduleIdCounter = 1;
    private int _moduleId;

    private bool _isCaduceusShown;
    private bool _exploded = false;

    void Start()
    {
        _moduleId = _moduleIdCounter++;

        Module.OnActivate += ActivateModule;
        Caduceus.OnInteract += CaduceusPressed;
        DateUp.OnInteract += DateUpPressed;
        DateDwn.OnInteract += DateDwnPressed;
        MnthUp.OnInteract += MnthUpPressed;
        MnthDwn.OnInteract += MnthDwnPressed;

    }

    private bool MnthDwnPressed()
    {
        LogMessage("The Month Down Button was pressed. Theoretically, something would happen, but the programer was too lazy.");


        return false; //IMMER return false, da sonst Compilerfeheler//
    }

    private bool MnthUpPressed()
    {
        LogMessage("The Month Up Button was pressed. Theoretically, something would happen, but the programer was too lazy.");



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
        LogMessage("You clicked on the wrong button aka. the caduceus. You're welcome!");
        Module.HandleStrike();
        if (!_exploded)
        {

            LogMessage("Bomb no Broke yet lul");
        };



        return false;
    }


    void ActivateModule()
    {
    }

    void LogMessage(string message)
    {
        Debug.LogFormat("[Dr. Doctor #{0}] {1}", _moduleId, message);
    }

    //#pragma warning disable 414
    //    private string TwitchHelpMessage = @"Hit the correct spots with “!{0} press bl mm tm tl”. (Locations are tl, tm, ml, mm, mr, bl, bm, br.)";
    //#pragma warning restore 414

    //    KMSelectable[] ProcessTwitchCommand(string command)
    //    {
    //    }
}
