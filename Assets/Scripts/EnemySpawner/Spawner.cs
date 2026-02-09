using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Ork _orkPrefab;
    [SerializeField] private Dragon _dragonPrefab;
    [SerializeField] private Elf _elfPrefab;
    [SerializeField] private float _spawnRadius = 10f;

    public void Spawn(EnemyConfig config)
    {
        switch (config)
        {
            case OrkConfig orkConfig:
                Ork ork = Instantiate(_orkPrefab, GetRandomPosition(), Quaternion.identity);
                ork.Initialize(orkConfig);
                break;
                
            case DragonConfig dragonConfig:
                Dragon dragon = Instantiate(_dragonPrefab, GetRandomPosition(), Quaternion.identity);
                dragon.Initialize(dragonConfig);
                break;
                
            case ElfConfig elfConfig:
                Elf elf = Instantiate(_elfPrefab, GetRandomPosition(), Quaternion.identity);
                elf.Initialize(elfConfig);
                break;
                
            default:
                throw new System.ArgumentException($"Unknown config type: {config.GetType().Name}");
        }
    }
    
    private Vector3 GetRandomPosition()
    {
        Vector2 randomPoint = Random.insideUnitCircle * _spawnRadius;
        return transform.position + new Vector3(randomPoint.x, 0, randomPoint.y);
    }
}
