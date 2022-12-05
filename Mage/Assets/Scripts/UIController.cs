using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text TextHP;
    public Text TextPoints;

    public void UpdateHP(string hp)
    {
        if(TextHP != null)
        {
            TextHP.text = hp;
        }
    }

    public void UpdateCoins(string coins)
    {
        if(TextPoints != null)
        {
            TextPoints.text = coins;
        }
    }
}
