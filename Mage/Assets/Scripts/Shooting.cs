using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform ShootPoint;
    public Transform TargetLook;
    public GameObject Bullet;

    public void Shoot()
    {
        Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
    }
    
    void Update()
    {
        ShootPoint.LookAt(TargetLook);
    }
}
