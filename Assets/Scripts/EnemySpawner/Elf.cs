using UnityEngine;

public class Elf : Enemy
{
    [SerializeField] private ElfConfig _config;

    public void Initialize(ElfConfig config)
    {
        _config = config;
        Debug.Log($"Elf initialized. Damage: {_config.Damage}, Agility: {_config.Agility}, Strength: {_config.Strength}");
    }
}
