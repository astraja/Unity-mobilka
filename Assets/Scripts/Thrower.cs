using System;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    [SerializeField] float force = 5f;
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] Transform BulletPrefabStartPos;
    Camera cam;
    GameObject bullet;
    Rigidbody2D bulletRb;

    Vector3 tempPos;
    Vector3 startPos;
    Vector3 dir;
    bool canBeMoved = true;
    bool isDragging = false;

    public static event Action OnThrow;


    void Start()
    {
        cam = Camera.main;
        CreateNewBullet();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = cam.ScreenPointToRay(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit && hit.collider.gameObject == bullet)
                {
                    isDragging = true;
                }
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                tempPos = cam.ScreenToWorldPoint(touch.position);
                tempPos.z = 0f;
                bullet.transform.position = tempPos;
            }
            else if (touch.phase == TouchPhase.Ended && isDragging)
            {

                isDragging = false;
                if (canBeMoved)
                {
                    bulletRb.gravityScale = 1f;
                    dir = (startPos - tempPos);
                    bulletRb.AddForce(dir * force, ForceMode2D.Impulse);
                    canBeMoved = false;
                    OnThrow?.Invoke();
                    Destroy(bullet, 1.5f);
                }
            }
        }
    }

    public void CreateNewBullet()
    {
        startPos = BulletPrefabStartPos.transform.position;
        bullet = Instantiate(BulletPrefab, startPos, Quaternion.identity);
        bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.linearVelocity = Vector2.zero;
        bulletRb.gravityScale = 0f;
        canBeMoved = true;
    }
}