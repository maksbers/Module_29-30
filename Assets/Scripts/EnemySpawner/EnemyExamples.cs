using UnityEngine;

public class EnemyExamples : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    [SerializeField] private OrkConfig[] _orkConfigs;
    [SerializeField] private DragonConfig[] _dragonConfigs;
    [SerializeField] private ElfConfig[] _elfConfigs;
    [SerializeField] private int _spawnCount = 3;

    private void Start()
    {
        if (_orkConfigs.Length > 0) SpawnMultiple(() => _spawner.Spawn(GetRandomConfig(_orkConfigs)));
        if (_dragonConfigs.Length > 0) SpawnMultiple(() => _spawner.Spawn(GetRandomConfig(_dragonConfigs)));
        if (_elfConfigs.Length > 0) SpawnMultiple(() => _spawner.Spawn(GetRandomConfig(_elfConfigs)));
    }

    private void SpawnMultiple(System.Action spawnAction)
    {
        for (int i = 0; i < _spawnCount; i++)
        {
            spawnAction.Invoke();
        }
    }

    private T GetRandomConfig<T>(T[] configs)
    {
        return configs[Random.Range(0, configs.Length)];
    }
}
