using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet BulletTemplate;
    [SerializeField] private int poolSize;
    private List<Bullet> _bulletPool = new List<Bullet>();
    private Bullet bulletToGet;
    [SerializeField] private int maxBulletsInScene;

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            var newBullet = Instantiate(BulletTemplate, transform.position, Quaternion.identity);
            newBullet.gameObject.SetActive(false);
            _bulletPool.Add(newBullet);
        }
    }
    private bool PoolActiveSelfCheck()
    {
        var ActiveBullets = _bulletPool.FindAll(b=>b.gameObject.activeSelf);
       if( ActiveBullets.Count != 0 && ActiveBullets.Count > maxBulletsInScene)
        {
            return false;
        }
       return true;
    }
    public Bullet GetBulletFromPool(Vector3 position, Quaternion rotation)
    {
        if (_bulletPool.Count > 0 && PoolActiveSelfCheck())
        {
            bulletToGet = _bulletPool[Random.Range(0, _bulletPool.Count)];
            bulletToGet.transform.position = position;
            bulletToGet.transform.rotation = rotation;
            bulletToGet.Rigidbody.velocity = Vector3.zero;
            bulletToGet.gameObject.SetActive(true);
        }
        else
        {
            bulletToGet = Instantiate(BulletTemplate, transform.position, Quaternion.identity);
            _bulletPool.Add(bulletToGet);
        }
        return bulletToGet;
    }
}
