using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float RotateSpeed = 15f;

    void Update()
    {
       transform.Rotate(Vector3.up*RotateSpeed*Time.deltaTime); 
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerSource.Instanse.TakeCoin(1);
            Destroy(gameObject);
        }      
        
    }
}
