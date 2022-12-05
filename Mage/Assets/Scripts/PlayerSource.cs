using UnityEngine;

public class PlayerSource : MonoBehaviour
{
    public float Coin {get;private set;}
    public bool Pause{get; private set;}
    public float Health = 100f;
    public static PlayerSource Instanse;
    public UIController UI;
    public LevelChanger LevelChanger;
    void Awake()
    {
        Instanse = this;
    }
    void Start()
    {
        if(UI != null)
        {
            UI.UpdateHP(Health+"");
            UI.UpdateCoins(Coin+"");
        }
    }

    public void TakeCoin(float count)
    {
        Coin+= count;
        UI.UpdateCoins(Coin+"");
    }
    
    public void TakeDamage(float Damage)
    {
        Health -=Damage;
        UI.UpdateHP(Health+"");
        if(Health<=0)
        {
            LevelChanger.SceneReload();
        }
    }

    public void MovingWithPlatform(Vector3 MoveDir)
    {
        transform.Translate(MoveDir, Space.World);
    }

    public void SetPause(bool enable)
    {
        Pause = enable;
    }
}
