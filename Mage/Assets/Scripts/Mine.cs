using UnityEngine;

public class Mine : MonoBehaviour
{
    public GameObject BoomPrefab;
    public float Damage;
    public float AnimationLength = 1.9f;
    public float ExplosionForce = 500f;
    void OnTriggerEnter(Collider other)
    {
        PlayerSource player = other.GetComponent<PlayerSource>();
        if(player !=null)
        {
            player.TakeDamage(Damage);

            Destroy(Instantiate(BoomPrefab, transform.position,BoomPrefab.transform.rotation),AnimationLength);

            other.GetComponent<Rigidbody>().AddExplosionForce(ExplosionForce,transform.position,6f,2f);

            Destroy(gameObject);
        }
    }
}
