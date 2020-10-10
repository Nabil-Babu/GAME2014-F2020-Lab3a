using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public GameObject bullet;
    public int maxBullets; 
    // Start is called before the first frame update
    private Queue<GameObject> _bulletPool;

    void Start()
    {
        _GenerateBullets();
    }

    private void _GenerateBullets()
    {
        _bulletPool = new Queue<GameObject>();
        for (int count = 0; count < maxBullets; count++)
        {
            GameObject tempBullet = Instantiate(bullet);
            tempBullet.SetActive(false);
            tempBullet.transform.parent = transform;
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
