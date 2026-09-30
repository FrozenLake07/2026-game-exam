using UnityEngine;
using UnityEngine.SceneManagement;
public class Stop : MonoBehaviour
{
    bool stopflag=false;
    [SerializeField] GameObject stop;
    public void Continue()
    {
        Time.timeScale = 1;
        stopflag = false;
        stop.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!stopflag)
            {
                Time.timeScale = 0;
                stop.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                stop.SetActive(false);
            }
            stopflag = !stopflag;
        }
    }
}
