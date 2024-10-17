using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject _explosionPrefab;
    EnemiesManager _enemiesManager;
    private void Awake()
    {
        _enemiesManager = transform.parent.GetComponent<EnemiesManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            GameObject expl = Instantiate(_explosionPrefab, transform.position, transform.rotation);
            Destroy(expl, 1);
            _enemiesManager.OnEnemyKill();
            Destroy(gameObject);
        }
    }
}