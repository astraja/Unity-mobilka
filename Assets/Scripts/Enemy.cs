using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action OnEnemyKill;
    [SerializeField] GameObject _explosionPrefab;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            GameObject expl = Instantiate(_explosionPrefab, transform.position, transform.rotation);
            Destroy(expl, 1);
            OnEnemyKill?.Invoke();
            Destroy(gameObject);
        }
    }
}