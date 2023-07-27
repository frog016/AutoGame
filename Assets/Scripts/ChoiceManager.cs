using System.Collections;
using System.Collections.Generic;
using Cutsceens;
using UnityEngine;

public class ChoiceManager : MonoBehaviour
{
    public static Level CurrentLevel { get; set; } = Level.City;
    public static Car CurrentCar { get; set; } = Car.Sedan;
    public static Gamemode CurrentGamemode { get; set; } = Gamemode.WithGoal;
    
    public static CutsceenName CurrentCutscene { get; set; }
}

public enum Level
{
    City
}

public enum Car
{
    Sedan,
    Offroad,
    Jeep
}

public enum Gamemode
{
    WithGoal,
    Infinite
}

