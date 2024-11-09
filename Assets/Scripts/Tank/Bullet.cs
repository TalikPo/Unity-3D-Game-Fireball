using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour 
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float bounceForce;
    [SerializeField] private float bounceRadius;

    public Rigidbody Rigidbody => _rigidbody;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Block block))
        {
            block.Destroy();
            gameObject.SetActive(false);
        }
        if (other.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            _rigidbody.velocity = Vector3.zero;
            var randomVectorRight = new Vector3(Random.Range(10,10), 0, 0);
            var bounceDirection = transform.position - randomVectorRight;
            _rigidbody.AddExplosionForce(bounceForce, bounceDirection, bounceRadius);
        }
    }


}
