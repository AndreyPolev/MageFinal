using System.Collections;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public float BoostForce = 30f;

    void OnTriggerEnter(Collider other){
        Rigidbody _triggerBody = other.GetComponent<Rigidbody>();
        if(_triggerBody!=null){
            StartCoroutine(BoostPlayer(_triggerBody));
        }
    }
    
    IEnumerator BoostPlayer(Rigidbody triggerBody){
        float _power = BoostForce;
        while(_power>0){
            triggerBody.AddForce(transform.forward*_power*_power);
            _power-=0.5f;
            yield return new WaitForFixedUpdate();
        }
    }
}
