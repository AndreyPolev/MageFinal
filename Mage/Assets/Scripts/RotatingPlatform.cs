using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public float RotateSpeed = 2f;
    private Vector3 _rotateDiretion;

    void Awake()
    {
        _rotateDiretion =  Vector3.up*RotateSpeed;
    }

    void FixedUpdate()
    {
        transform.Rotate(_rotateDiretion);
    }

    void OnCollisionStay(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.transform.RotateAround(transform.position, _rotateDiretion,_rotateDiretion.y);
        }
    }
}
