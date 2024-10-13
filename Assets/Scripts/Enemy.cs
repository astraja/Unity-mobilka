using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action OnEnemyKill;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            OnEnemyKill?.Invoke();
            Destroy(gameObject);
        }
    }
}