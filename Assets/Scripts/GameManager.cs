using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    int _enemiesTotal = 0;
    int _enemiesLeft = 0;

    int _activeScene;
    int _allScenesCount;

    void Start()
    {
        _activeScene = SceneManager.GetActiveScene().buildIndex;
        _allScenesCount = SceneManager.sceneCountInBuildSettings;
    }


    public void SetEnemiesTotal(int enemiesTotal)
    {
        _enemiesTotal = enemiesTotal;
    }

    public void OnBulletUpdate(int bulletsLeft)
    {
        if (bulletsLeft ==0)
        {
            SceneManager.LoadScene(_activeScene);
        }
    }

    public void OnEnemyUpdate(int enemiesLeft)
    {
        if (enemiesLeft == 0) 
        {
            if (_allScenesCount > _activeScene + 1)
            {
                SceneManager.LoadScene(++_activeScene);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }


}