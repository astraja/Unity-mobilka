using System;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    public static event Action<int> OnBulletChange;

    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _bulletPrefabStartPos;
    [SerializeField] Transform _enemiesContainer;
    GameObject _bullet;
    int _bulletCount = 0;

    void Start()
    {
        _bulletCount = _enemiesContainer.childCount + 2;
        CreateNewBullet();
    }

    public void CreateNewBullet()
    {
        if (_bulletCount > 0)
        {
            _bullet = Instantiate(_bulletPrefab, _bulletPrefabStartPos.transform.position, Quaternion.identity);
            _bullet.GetComponent<Bullet>().Initialize(this);
            _bulletCount--;
            OnBulletChange?.Invoke(_bulletCount);
        }
    }
}