
using UnityEngine;

public class BSUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UI1;
    public GameObject UI2;
    public GameObject UI3;
    GameObject player;
    // Update is called once per frame
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        if (player.GetComponent<PlayerDefinition>().BloodSucking == 1)
        {
            UI1.SetActive(true);
        }
        if (player.GetComponent<PlayerDefinition>().BloodSucking == 2)
        {
            UI2.SetActive(true);
        }
        if (player.GetComponent<PlayerDefinition>().BloodSucking == 3)
        {
            UI3.SetActive(true);
        }

    }
}
