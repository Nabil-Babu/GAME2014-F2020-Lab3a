using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject bullet;
    public int maxBullets; 
    // Start is called before the first frame update
    private Queue<GameObject> _bulletPool;

    void Start()
    {
        GenerateBullets();
    }

    void GenerateBullets()
    {
        _bulletPool = new Queue<GameObject>();
        for (int count = 0; count < maxBullets; count++)
        {
            GameObject tempBullet = Instantiate(bullet);
            tempBullet.SetActive(false);
            _bulletPool.Enqueue(tempBullet);
        }
    }

    public GameObject GetBullet(Vector3 position)
    {
        GameObject newBullet = _bulletPool.Dequeue();
        newBullet.SetActive(true);
        newBullet.transform.position = position;
        return newBullet;
    }

    public void ReturnBullet(GameObject returnedBullet)
    {
        returnedBullet.SetActive(false);
        _bulletPool.Enqueue(returnedBullet);
    }
}
