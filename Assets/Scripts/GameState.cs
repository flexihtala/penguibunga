using System.Collections.Generic;
using UnityEngine;

public static class GameState
{
    public static bool IsOverGameWires;
    public static bool IsOverGameKeyboard;
    public static bool HaveCrowbar; // review(27.06.2024): HasCrowbar? А еще мб стоило честную инвентарную систему сделать?
    public static bool IsNowTextDisplayed;
    public static bool IsOpenKeyboardGame;
    public static bool CanOpenToiletDoor;
    public static Player ActivePlayer;

    public static Vector3 PlatformerSpawn = new(0 , 0, 0);
    public static HashSet<DialogFlagEnum> ChecksBool = new() // review(26.06.2024): Кмк более понятнее было бы ActivatedDialogs
    {
        DialogFlagEnum.Ventilation,
        DialogFlagEnum.None,
        DialogFlagEnum.Electrical,
        DialogFlagEnum.KeyboardForStupid
    };

    // review(26.06.2024): Да, удобно, но кмк GameState - это бизнес-логика, а она не должна зависеть от моделей View (звуки - это тоже View)
    // review(26.06.2024): Можно было бы завести enum под каждый стиль музыки и в классе создать дикт: enum -> AudioClip
    public static AudioClip CurrentMusic; 
}