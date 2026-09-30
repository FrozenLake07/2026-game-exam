
using UnityEngine;

public class EnemyMovement3 : MonoBehaviour
{
    GameObject player;
    GameObject pl;
    GameObject[] arrow;
    Rigidbody2D rb;
    EnemyDefinition ef;
    [SerializeField] private float stopdis;
    [SerializeField] private int force;
    [SerializeField] private float setwaittime;
    float Undamagedtime;
    float waittime;
    float hittime;
    bool flash=false;
    [SerializeField] private float Setshoottime = 3f;
    float shoottime;
    //float timer;
    Color oricolor;
    // Start is called before the first frame update
    void Back(Collision2D collision)
    {
        rb.velocity = Vector2.zero;
        Vector2 n = Vector2.zero;
        foreach (ContactPoint2D c in collision.contacts) n += c.normal;
        if (n == Vector2.zero) return;
        rb.velocity = n.normalized * force;
        waittime = setwaittime;
    }
    void Hited()
    {
        player.GetComponent<StateMonitor>().bscnt++;
        hittime = 0.2f;
        ef.HP -= player.GetComponent<PlayerDefinition>().PlayerDamage;
        Undamagedtime = player.GetComponent<PlayerDefinition>().lastingtime;
    }

    void Ins(float angle)
    {
        var t = Instantiate(arrow[0], transform.position, Quaternion.Euler(0f, 0f, angle));
        t.GetComponent<EnemyDefinition>().Damage += pl.GetComponent<GameManager>().exDa;
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ef = GetComponent<EnemyDefinition>();
        player = GameObject.FindGameObjectWithTag("Player");
        oricolor = GetComponent<SpriteRenderer>().color;
        arrow = Resources.LoadAll<GameObject>("arrow");
        pl = GameObject.FindGameObjectWithTag("PublicDefinition");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 target = new Vector2(player.transform.position.x - rb.position.x, player.transform.position.y - rb.position.y).normalized;
        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        shoottime -=Time.deltaTime;
        //timer -= Time.deltaTime;
        if (hittime > 0)
        { 
            flash = true;
            hittime -= Time.deltaTime;
            if (flash)
            {
                GetComponent<SpriteRenderer>().color = Color.white;
                flash = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = oricolor;
                flash = true;
            }
            //timer = 0.15f;
        }
        else GetComponent<SpriteRenderer>().color = oricolor;
        if (Undamagedtime > 0)
        {
            Undamagedtime -= Time.deltaTime;
        }
        if (waittime > 0)
        {
            waittime -= Time.deltaTime;
            return;
        }
        float dis2 = (player.transform.position.x - rb.position.x) * (player.transform.position.x - rb.position.x) + (player.transform.position.y - rb.position.y) * (player.transform.position.y - rb.position.y);
        if (dis2 >= stopdis * stopdis)
        {
            rb.velocity = target * ef.Speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
            if (shoottime<0)
            {
                Ins(angle);
                shoottime = Setshoottime;
            }

        }
        //else rb.velocity = Vector2.zero;
        rb.MoveRotation(angle);

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (waittime > 0) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            Back(collision);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Attack"))
        {
            if (Undamagedtime > 0) return;
            else Hited();
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (waittime > 0) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            Back(collision);
        }
        if (collision.gameObject.CompareTag("Attack"))
        {
            if (Undamagedtime > 0) return;
            else Hited();
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Attack"))
        {
            if (Undamagedtime > 0) return;
            else Hited();
        }
    }
}
