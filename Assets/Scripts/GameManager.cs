using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event Action<int,int,int> OnStatsChange;
    [SerializeField] Transform _enemiesContainer;
    int _bulletCount;
    int _enemyCount = 0;
    int _enemyKilled = 0;
    int _activeScene;
    int _allScenesCount;

    void AddEnemyKilled()
    {
        _enemyKilled++;
        CheckGameState();
        ChangeUi();
    }

    void ChangeUi()
    {
        OnStatsChange?.Invoke(_enemyKilled, _enemyCount, _bulletCount);
    }

    void CheckGameState()
    {
        if (_enemyCount == _enemyKilled)
        {
            if(_allScenesCount - _activeScene > 1)
            {
                SceneManager.LoadScene(++_activeScene);
            }
        }

        if (_bulletCount == 0)
        {
            SceneManager.LoadScene(0);
        }
    }


    void Start()
    {
        _enemyCount = _enemiesContainer.childCount;
        _bulletCount = _enemyCount + 1;
        _activeScene = SceneManager.GetActiveScene().buildIndex;
        _allScenesCount = SceneManager.sceneCountInBuildSettings;
        ChangeUi();
    }
    
    void BulletDestroy()
    {
        _bulletCount--;
        ChangeUi();
        CheckGameState();
        //Create new bullet
    }

    void Update()
    {
        
    }

    private void OnEnable()
    {
        Enemy.OnEnemyKill += AddEnemyKilled;
        Bullet.OnBulletDestroy += BulletDestroy;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyKill -= AddEnemyKilled;
        Bullet.OnBulletDestroy -= BulletDestroy;
    }
}
