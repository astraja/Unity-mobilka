using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _force = 5f;
    BulletManager _bulletManager;
    Camera _cam;
    Rigidbody2D _rb;
    LineRenderer _lineRenderer;
    Vector3 _tempPos;
    Vector3 _startPos;
    Vector3 _dir;
    bool _canBeMoved = true;
    bool _isDragging = false;

    private void Awake()
    {
        _bulletManager = transform.parent.GetComponent<BulletManager>();
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

    public IEnumerator DestroyIt(float sec)
    {
        yield return new WaitForSeconds(sec);
        _bulletManager.OnBulletDestroy();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);
        StartCoroutine(DestroyIt(0.1f));
    }
}
