using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    public float maxSpeed = 4;
    public float fireRate = 0.1f; 
    public GameObject bullet;
    public float horizontalBoundary = 2; 
    public BulletManager bulletManager;
    private Rigidbody2D _rigidbody2D;
    private bool firing = false;
    private Vector3 touchesEnd;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        touchesEnd = new Vector3();
    }

    void Update()
    {
       Move();
       CheckBounds();
       StartCoroutine(FireBullet());
    }

    private void Move()
    {
         // float direction = 0.0f;

         foreach(Touch touch in Input.touches)
         {
            Vector3 worldTouch = Camera.main.ScreenToWorldPoint(touch.position);
            // if(worldTouch.x > transform.position.x)
            // {
            //     direction = 1.0f;
            // }

            // if(worldTouch.x < transform.position.x)
            // {
            //     direction = -1.0f;
            // }

            touchesEnd = worldTouch;
         }

        //  if(Input.GetAxis("Horizontal") >= 0.1f)
        //  {
        //      direction = 1.0f;
        //  } 

        //  if(Input.GetAxis("Horizontal") <= -0.1f)
        //  {
        //      direction = -1.0f;
        //  }

        //  Vector2 nVelocity = _rigidbody2D.velocity + new Vector2(direction * speed, 0.0f);
        //  _rigidbody2D.velocity = Vector2.ClampMagnitude(nVelocity, maxSpeed);
        //  _rigidbody2D.velocity *= 0.99f;

         if (touchesEnd.x != 0)
         {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, touchesEnd.x, 0.1f),transform.position.y,0);
         }
    }

    private void CheckBounds()
    {
        if(transform.position.x <= -horizontalBoundary)
        {
            transform.position = new Vector3(-horizontalBoundary, transform.position.y, transform.position.z);
        }
        if(transform.position.x >= horizontalBoundary)
        {
            transform.position = new Vector3(horizontalBoundary, transform.position.y, transform.position.z);
        }
    }

    IEnumerator FireBullet()
    {
        if(!firing)
        {
            bulletManager.GetBullet(transform.position);
            firing = true; 
            yield return new WaitForSeconds(fireRate);
            firing = false;
        }
    }
    
}
