using System;
using UnityEngine;

[Serializable]
public class DragonConfig
{
    [field: SerializeField] public int Damage { get; private set; } = 300;
    [field: SerializeField] public int Magic { get; private set; } = 50;
    [field: SerializeField] public int Strength { get; private set; } = 200;
}
