using UnityEngine;

public class Throw : MonoBehaviour
{
    [SerializeField] float force = 5f;
    [SerializeField] Bullet Bullet;
    Camera cam;
    Rigidbody2D rb;

    Vector3 tempPos;
    Vector3 dir;
    Vector3 startPos;
    bool canBeMoved = true;
    bool isDragging = false;

    void Awake()
    {
        rb = Bullet.transform.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        cam = Camera.main;
        startPos = Bullet.transform.position;
        ResetPosition();
    }



    private void Update()
    {
        if(Input.touchCount==2 || Input.GetMouseButtonDown(1))
        {
            ResetPosition();
        }
            
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = cam.ScreenPointToRay(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit && hit.collider.gameObject == Bullet.gameObject)
                {
                    isDragging = true;
                }
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                tempPos = cam.ScreenToWorldPoint(touch.position);
                tempPos.z = 0f;
                Bullet.transform.position = tempPos;
            }
            else if (touch.phase == TouchPhase.Ended && isDragging)
            {
 
                isDragging = false;
                if (canBeMoved)
                {
                    rb.gravityScale = 1f;
                    dir = (startPos - tempPos);
                    rb.AddForce(dir * force, ForceMode2D.Impulse);
                    canBeMoved = false;
                }
            }
        }
    }

    public void ResetPosition()
    {
        Bullet.transform.position = startPos;
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0f;  // Wyłącz grawitację po resecie
        canBeMoved = true;
    }
}
