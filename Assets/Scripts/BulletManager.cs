using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] UiManager _uiManager;
    [SerializeField] GameManager _gameManager;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _bulletPrefabStartPos;
    [SerializeField] Transform _enemiesFolder;
    int _bulletsLeft = 0;

    void Start()
    {
        _bulletsLeft = _enemiesFolder.childCount + 1;
        CreateNewBullet();
    }

    public void CreateNewBullet()
    {
        GameObject _bullet = Instantiate(_bulletPrefab, _bulletPrefabStartPos.transform.position, Quaternion.identity, transform);
        _bulletsLeft--;
        _uiManager.OnBulletUpdate(_bulletsLeft);
    }

    public void OnBulletDestroy()
    {
        _gameManager.OnBulletUpdate(_bulletsLeft);
        CreateNewBullet();
    }
}
