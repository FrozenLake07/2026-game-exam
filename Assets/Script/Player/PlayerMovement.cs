
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerDefinition pd;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
        pd = GetComponent<PlayerDefinition>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        float Player_Speed = pd.PlayerSpeed;

        Vector2 movement2 = new Vector2(x, y).normalized;

        Vector2 location = rb.position;
        rb.MovePosition(location + (movement2*Player_Speed * Time.fixedDeltaTime));
    }
}
