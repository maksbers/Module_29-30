using System;
using UnityEngine;

[Serializable]
public class ElfConfig
{
    [field: SerializeField] public int Damage { get; private set; } = 5;
    [field: SerializeField] public int Agility { get; private set; } = 60;
    [field: SerializeField] public int Strength { get; private set; } = 10;
}
