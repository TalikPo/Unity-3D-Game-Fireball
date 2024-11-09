using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private Transform bulleteSpawnPoint;
    [SerializeField] private float shootForce;
    [SerializeField] private float reloadTime;
    private float timeAfterShoot;

    void Update()
    {
        timeAfterShoot += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (timeAfterShoot > reloadTime)
            {
                var newBullet = bulletPool.GetBulletFromPool(bulleteSpawnPoint.position, Quaternion.identity);
                newBullet.Rigidbody.AddForce(Vector3.left * shootForce, ForceMode.Impulse);
                timeAfterShoot = 0f;
            }
        }
    }
}
