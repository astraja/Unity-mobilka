using System;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    //public static event Action<int, int, int> OnStatsChange;
    //[SerializeField] Transform _enemiesContainer;
    //int _bulletCount = 0;
    //int _enemyCount = 0;
    //int _enemyKilled = 0;

    //private void Awake()
    //{
    //    _enemyCount = _enemiesContainer.childCount;
    //    _bulletCount = _enemyCount + 1;
    //}
    //void Start()
    //{

    //    OnStatsChange?.Invoke(_enemyKilled, _enemyCount, _bulletCount);
    //}

    //void UpdateBulletCount()
    //{
    //    _bulletCount--;
    //    OnStatsChange?.Invoke(_enemyKilled, _enemyCount, _bulletCount);
    //}

    //void UpdateEnemyKilled()
    //{
    //    _enemyKilled++;
    //    OnStatsChange?.Invoke(_enemyKilled, _enemyCount, _bulletCount);
    //}


    //private void OnEnable()
    //{
    //    Bullet.OnBulletDestroy += UpdateBulletCount;
    //    Enemy.OnEnemyKill += UpdateEnemyKilled;
    //    Thrower.OnZeroBulets += CheckGameStatus;
    //}



    //private void OnDisable()
    //{
    //    Bullet.OnBulletDestroy -= UpdateBulletCount;
    //    Enemy.OnEnemyKill -= UpdateEnemyKilled;
    //    Thrower.OnZeroBulets -= CheckGameStatus;
    //}

    //void Update()
    //{
        
    //}
}
