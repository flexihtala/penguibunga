using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// review(24.05.2024): Стоит разместить в отдельном файле
public enum ItemName {Nail, Brick, Screwdriver, Crowbar}

public class Item : MonoBehaviour
{
    public Sprite sprite;
    public ItemName itemName;
}
