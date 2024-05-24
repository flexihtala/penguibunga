using System.Collections.Generic;
using UnityEngine;

public static class GameState
{
    public static bool IsOverGameWires;
    public static bool IsOverGameKeyboard;
    public static bool HaveCrowbar;
    public static bool IsNowTextDisplayed;
    public static Player ActivePlayer;

    public static Vector3 PlatformerSpawn = new(0 , 0, 0);
    public static HashSet<DialogFlagEnum> ChecksBool = new()
    {
        DialogFlagEnum.Ventilation,
        DialogFlagEnum.None
    };
}