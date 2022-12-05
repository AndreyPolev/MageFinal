using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Куда и на сколько дваигать платформу")]
    public Vector3 TranslationLocation = new Vector3(0,0,5);

    [Header("Скорость движения")]
    [Range(0.1f,50)]    [SerializeField]    private float Speed = 1f;

    [Header("Пауза между движением")]
    [SerializeField]    private float _pause = 1f;

    private float _way;
    private bool _playerOnPlatform;

    void Start()
    {
        _way = 0;
        StartCoroutine(MovingRouting());
    }
    private IEnumerator MovingRouting()
    {
        Vector3 _stepDiretcion;
        
        while(true)
        {
            _stepDiretcion = TranslationLocation.normalized * Speed*Time.fixedDeltaTime;
            transform.Translate(_stepDiretcion,Space.World);
            if(_playerOnPlatform)
            {
                PlayerSource.Instanse.MovingWithPlatform(_stepDiretcion);
            }
            
            _way +=_stepDiretcion.magnitude;

            if(_way >= TranslationLocation.magnitude)
            {
                _way = 0;
                TranslationLocation *=-1;
                yield return new WaitForSeconds(_pause);
            }else
            {
                yield return new WaitForEndOfFrame();
            }

        }
    }

    void OnCollisionStay(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _playerOnPlatform = true;
        }
    }

    void OnCollisionExit(Collision other){
        if(other.gameObject.CompareTag("Player"))
        {
            _playerOnPlatform = false;
        }
    }
}
