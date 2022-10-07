using System.Collections;
using UnityEngine;

public class EnemySpawner : ObjectsPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private PathKeeper _pathKeeper;

    private void Start()
    {
        InitializePool(_template);
        StartCoroutine(OnSpawn());
    }

    private void Spawn()
    {
        if(TryGetObject(out GameObject stickman))
        {
            stickman.transform.position = _spawnPoint.position;
            
            if(stickman.TryGetComponent(out StickmanPathFollower follower))
                follower.InitializePathKeeper(_pathKeeper);

            stickman.SetActive(true);
        }
    }

    private IEnumerator OnSpawn()
    {
        var waitingTime = new WaitForSeconds(EnemyDifficulty.SpawnTime);
        int spawnCount = Mathf.RoundToInt(EnemyDifficulty.SpawnCount);

        if (spawnCount <= 0)
            spawnCount = 1;

        while(true)
        {
            for(int i = 0; i < spawnCount; i++)
                Spawn();

            yield return waitingTime;
        }
    }

}
