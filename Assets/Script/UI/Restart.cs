
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
  public void GameRestart()
  {
        PublicDefinition.score = 0;
        SceneManager.LoadScene(1);
    }
}
