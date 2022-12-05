using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform EndPoint;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.position = EndPoint.position;
        }
    }
}
