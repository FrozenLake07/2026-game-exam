
using UnityEngine;

public class DefenceUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UI;
    GameObject player;
    // Update is called once per frame
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        if (player.GetComponent<PlayerDefinition>().Defence)
        {
            UI.SetActive(true);
        }
        else
        {
            UI.SetActive(false);
        }

    }
}
