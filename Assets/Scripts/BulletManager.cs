using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] UiManager _uiManager;
    [SerializeField] GameManager _gameManager;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _bulletPrefabStartPos;
    int _bulletsCreated = 0;

    void Start()
    {
        CreateNewBullet();
    }

    public void CreateNewBullet()
    {
        GameObject _bullet = Instantiate(_bulletPrefab, _bulletPrefabStartPos.transform.position, Quaternion.identity, transform);
        _bulletsCreated++;
        _uiManager.OnBulletUpdate(_bulletsCreated);

    }

    public void OnBulletDestroy()
    {
        _gameManager.OnBulletUpdate(_bulletsCreated);
        CreateNewBullet();
    }
}
