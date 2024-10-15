using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static event Action OnBulletDestroy;
    static int _bulletCount = 0;
    [SerializeField] float _force = 5f;
    Camera _cam;
    Rigidbody2D _rb;
    LineRenderer _lineRenderer;
    Vector3 _tempPos;
    Vector3 _startPos;
    Vector3 _dir;
    bool _canBeMoved = true;
    bool _isDragging = false;
    Thrower _thrower;

    public void Initialize(Thrower thrower)
    {
        _thrower = thrower;
    }

    private void Start()
    {
        _cam = Camera.main;
        _rb = GetComponent<Rigidbody2D>();
        _startPos = transform.position;
        _lineRenderer = transform.gameObject.GetComponent<LineRenderer>();
        _lineRenderer.SetPosition(0, _startPos);
        _lineRenderer.SetPosition(1, _startPos);
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
                if (hit && hit.collider.gameObject == transform.gameObject)
                {
                    _isDragging = true;
                }
            }
            else if (touch.phase == TouchPhase.Moved && _isDragging)
            {
                _tempPos = _cam.ScreenToWorldPoint(touch.position);
                _tempPos.z = 0f;
                transform.position = _tempPos;
                _lineRenderer.SetPosition(1, transform.position);
            }
            else if (touch.phase == TouchPhase.Ended && _isDragging)
            {

                _isDragging = false;
                if (_canBeMoved)
                {
                    _rb.gravityScale = 1f;
                    _dir = (_startPos - _tempPos);
                    _rb.AddForce(_dir * _force, ForceMode2D.Impulse);
                    _canBeMoved = false;
                    _lineRenderer.SetPosition(1, _startPos);
                    StartCoroutine(DestroyIt(2));
                }
            }
        }
    }

    public IEnumerator DestroyIt(int sec)
    {
        yield return new WaitForSeconds(sec);
        OnBulletDestroy?.Invoke();
        _thrower.CreateNewBullet();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);
        StartCoroutine(DestroyIt(0));
    }
}
