using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed = 7f;
    public float BulletLife = 5f;
    private Vector3 _lastPos;
    void Start()
    {
        _lastPos = transform.position;
        Destroy(gameObject,BulletLife);
    }

    void Update()
    {
        transform.Translate(Vector3.forward*BulletSpeed);
        RaycastHit hit;
        if(Physics.Linecast(_lastPos,transform.position, out hit))
        {
            Golem golem = hit.collider.GetComponent<Golem>();
            if(golem != null)
            {
                golem.TakeDamage(25f);
            }
            Destroy(gameObject);
        }
        _lastPos = transform.position;
    }
}
