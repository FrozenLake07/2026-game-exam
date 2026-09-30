using UnityEngine;

public class EnemyMovement31 : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    EnemyDefinition ef;
    [SerializeField] private float stopdis;
    [SerializeField] private int force;
    [SerializeField] private float setwaittime;
    float Undamagedtime;
    float waittime;
    float hittime;
    bool flash;
    Vector2 target;
    Color oricolor;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ef = GetComponent<EnemyDefinition>();
        player = GameObject.FindGameObjectWithTag("Player");
        oricolor = GetComponent<SpriteRenderer>().color;
        target= new Vector2(player.transform.position.x - rb.position.x, player.transform.position.y - rb.position.y).normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dis2 = (player.transform.position.x - rb.position.x) * (player.transform.position.x - rb.position.x) + (player.transform.position.y - rb.position.y) * (player.transform.position.y - rb.position.y);
        if (dis2 >= stopdis * stopdis)
        {
            rb.velocity = target * ef.Speed;
        }
        //else rb.velocity = Vector2.zero;

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Destroy(gameObject);
        
    }

}
