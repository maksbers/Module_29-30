using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Ork _orkPrefab;
    [SerializeField] private Dragon _dragonPrefab;
    [SerializeField] private Elf _elfPrefab;
    [SerializeField] private float _spawnRadius = 10f;

    public void Spawn(OrkConfig config)
    {
        SpawnInternal(_orkPrefab, config);
    }

    public void Spawn(DragonConfig config)
    {
        SpawnInternal(_dragonPrefab, config);
    }

    public void Spawn(ElfConfig config)
    {
        SpawnInternal(_elfPrefab, config);
    }

    private void SpawnInternal<TEnemy, TConfig>(TEnemy prefab, TConfig config)
        where TEnemy : MonoBehaviour, IInitializable<TConfig>
    {
        TEnemy enemy = Instantiate(prefab, GetRandomPosition(), Quaternion.identity);
        enemy.Initialize(config);
    }

    private Vector3 GetRandomPosition()
    {
        Vector2 randomPoint = Random.insideUnitCircle * _spawnRadius;
        return transform.position + new Vector3(randomPoint.x, 0, randomPoint.y);
    }
}
