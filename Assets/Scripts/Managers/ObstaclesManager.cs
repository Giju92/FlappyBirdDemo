using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Keeps a pool of obstacles and spawn them at run time
/// </summary>
public class ObstaclesManager : BaseObserver
{
    [SerializeField]
    Obstacle obstaclePrefab;

    [SerializeField]
    Transform spawnPoint;

    BaseObjectPool objectPool;

    Coroutine spawnObstacleCoroutine;

    protected override void Initialize()
    {
        base.Initialize();
        objectPool = gameObject.AddComponent<BaseObjectPool>();
        objectPool.SetBaseObjectPool(
            () => Instantiate(obstaclePrefab, transform),
            (t) => t.Reset());
    }
    
    protected override void OnStartEvent()
    {
        base.OnStartEvent();
        StopSpawnerCoroutine();
        spawnObstacleCoroutine = StartCoroutine(SpawnObstacle());
    }

    protected override void OnEndEvent()
    {
        base.OnEndEvent();
        StopSpawnerCoroutine();
    }

    private void StopSpawnerCoroutine()
    {
        if (spawnObstacleCoroutine != null)
        {
            StopCoroutine(spawnObstacleCoroutine);
        }

        spawnObstacleCoroutine = null;
    }

    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            // get an obstacle
            //var o = Instantiate(obstaclePrefab, transform);
            var o = objectPool.Get() as Obstacle;

            // set a position
            o.transform.SetParent(spawnPoint);
            o.ResetPositionWithVerticalDisplacement(Random.Range(GameConstant.MIN_OBSTACLE_HEIGHT, GameConstant.MAX_OBSTACLE_HEIGHT));

            // enable it
            o.Enable();
        }
    }
}
