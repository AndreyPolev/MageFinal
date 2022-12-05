using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool _inPause;
    public GameObject Menu;

    public void Pause()
    {
        Time.timeScale = 0;
        Menu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        Menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ChangePauseStatus()
    {
        if(_inPause)
        {
            Resume();
            
        }else
        {
            Pause();
        }
        
        _inPause = !_inPause;
        PlayerSource.Instanse.SetPause(_inPause);
    }
    
    void Update()
    {
       if(Input.GetKeyUp(KeyCode.Escape))
       {
        ChangePauseStatus();
       } 
    }
}
