using UnityEngine;

public class Reloader : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerSource.Instanse.LevelChanger.SceneReload();
        }
    }
}
