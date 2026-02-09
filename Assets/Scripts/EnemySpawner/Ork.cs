using UnityEngine;

public class Ork : Enemy
{
    [SerializeField] private OrkConfig _config;

    public void Initialize(OrkConfig config)
    {
        _config = config;
        Debug.Log($"Ork initialized. Damage: {_config.Damage}, Strength: {_config.Strength}");
    }
}
