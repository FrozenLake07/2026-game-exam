
using UnityEngine;

public class Initialization : MonoBehaviour
{
    PlayerDefinition pd;
    // Start is called before the first frame update
    void Awake()
    {
        Vector2 Atfirst = new Vector2(10,10);
        transform.position = Atfirst;
        pd = GetComponent<PlayerDefinition>();
        pd.hp = pd.PlayerHP;
    }


}
