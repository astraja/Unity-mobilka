using System;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    [SerializeField] float _force = 5f;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _bulletPrefabStartPos;
    Camera _cam;
    GameObject _bullet;
    Rigidbody2D _bulletRb;
    LineRenderer _lineRenderer;
    Vector3 _tempPos;
    Vector3 _startPos;
    Vector3 _dir;
    bool _canBeMoved = true;
    bool _isDragging = false;

    void Start()
    {
        _cam = Camera.main;
        CreateNewBullet();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = _cam.ScreenPointToRay(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit && hit.collider.gameObject == _bullet)
                {
                    _isDragging = true;
                }
            }
            else if (touch.phase == TouchPhase.Moved && _isDragging)
            {
                _tempPos = _cam.ScreenToWorldPoint(touch.position);
                _tempPos.z = 0f;
                _bullet.transform.position = _tempPos;
                _lineRenderer.SetPosition(1, _bullet.transform.position);
            }
            else if (touch.phase == TouchPhase.Ended && _isDragging)
            {

                _isDragging = false;
                if (_canBeMoved)
                {
                    _bulletRb.gravityScale = 1f;
                    _dir = (_startPos - _tempPos);
                    _bulletRb.AddForce(_dir * _force, ForceMode2D.Impulse);
                    _canBeMoved = false;
                    Destroy(_bullet, 2f);
                    _lineRenderer.SetPosition(1, _startPos);
                }
            }
        }
    }

    public void CreateNewBullet()
    {

            _startPos = _bulletPrefabStartPos.transform.position;
            _bullet = Instantiate(_bulletPrefab, _startPos, Quaternion.identity);
            _bulletRb = _bullet.GetComponent<Rigidbody2D>();
            _bulletRb.linearVelocity = Vector2.zero;
            _bulletRb.gravityScale = 0f;
            _canBeMoved = true;
            _lineRenderer = _bullet.GetComponent<LineRenderer>();
            _lineRenderer.SetPosition(0, _startPos);
            _lineRenderer.SetPosition(1, _bullet.transform.position);

        
    }
}