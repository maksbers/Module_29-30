using UnityEngine;

public class Dragon : Enemy, IInitializable<DragonConfig>
{
    [SerializeField] private DragonConfig _config;

    public void Initialize(DragonConfig config)
    {
        _config = config;
        Debug.Log($"Dragon initialized. Damage: {_config.Damage}, Magic: {_config.Magic}, Strength: {_config.Strength}");
    }
}
