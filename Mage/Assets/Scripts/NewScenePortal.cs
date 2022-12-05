using UnityEngine;

public class NewScenePortal : MonoBehaviour
{
    public string NewSceneName;
    private float _coinOnLevel;

    void Start(){
        _coinOnLevel = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    void OnTriggerEnter(Collider other)
    {
        float _coinsLeft = _coinOnLevel - PlayerSource.Instanse.Coin;
        if(other.CompareTag("Player")&& _coinsLeft == 0)
        {
            PlayerSource.Instanse.LevelChanger.ChangeScene(NewSceneName);
        }
    }
}
