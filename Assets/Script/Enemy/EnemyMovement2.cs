
using UnityEngine;


public class EnemyMovement2 : MonoBehaviour
{
    GameObject player;
    GameObject attack;
    Rigidbody2D rb;
    EnemyDefinition ef;
    [SerializeField] private float stopdis;
    [SerializeField] private int force;
    [SerializeField] private float setwaittime;
    [SerializeField] private float eyesight;
    GameObject pl;
    int flag=0;
    float setkeeptime = 3f;//追击时长
    float keeptime;
    float waittime;//弹开冷却期
    float setclock=1f;//换向计时器
    float clock;

    float Undamagedtime;
    float hittime;
    bool flash;
    Color oricolor;
    Vector3 tar = Vector3.zero;
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
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ef = GetComponent<EnemyDefinition>();
        player = GameObject.FindGameObjectWithTag("Player");
        oricolor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hittime > 0)
        {
            flash = true;
            hittime -= Time.deltaTime;
            if(flash)
            {
                GetComponent<SpriteRenderer>().color = Color.white;
                flash= false;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = oricolor;
                flash = true;
            }
        } 
        else GetComponent<SpriteRenderer>().color = oricolor;
        if (Undamagedtime>0)
        {
            Undamagedtime -= Time.deltaTime;
        }
        if (waittime > 0)
        {
            waittime -= Time.deltaTime;
            return;
        }
        float dis2 = (player.transform.position.x - rb.position.x) * (player.transform.position.x - rb.position.x) + (player.transform.position.y - rb.position.y) * (player.transform.position.y - rb.position.y);
        if(dis2>eyesight*eyesight&&flag==0)
        {

            if (clock<= 0)
            {
                rb.velocity = Vector2.zero;
                float x = Random.Range(-1f, 1f);
                float y = Random.Range(-1f, 1f);
                tar = new Vector3(x, y, 0).normalized;
                clock = setclock;
            }
            else clock -= Time.deltaTime;
            rb.velocity = tar * ef.Speed; 

        }
        else if (dis2 > eyesight *eyesight && flag == 1)
        { 
            Vector2 target = new Vector2(player.transform.position.x - rb.position.x, player.transform.position.y - rb.position.y).normalized;
            rb.velocity = target * ef.Speed;
            keeptime -= Time.deltaTime;
            if (keeptime <= 0)
            {
                flag = 0;
                return;
            }
        }
        else if (dis2 >= stopdis * stopdis)
        {
            clock = 0;
            flag = 1;
            keeptime = setkeeptime;
            Vector2 target = new Vector2(player.transform.position.x - rb.position.x, player.transform.position.y - rb.position.y).normalized;
            rb.velocity = target * ef.Speed;
        }
        //else rb.velocity = Vector2.zero;
        //Debug.Log(flag);
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
