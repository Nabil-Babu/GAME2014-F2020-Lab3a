using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed = 10; 
    public float verticalBoundary = 5;
    public BulletManager bulletManager;

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    void _Move()
    {
        transform.Translate(new Vector3(0,speed*Time.deltaTime,0));
    }

    private void _CheckBounds()
    {
        if(transform.position.y > verticalBoundary)
        {
            bulletManager.ReturnBullet(this.gameObject); 
        }
    }
}
