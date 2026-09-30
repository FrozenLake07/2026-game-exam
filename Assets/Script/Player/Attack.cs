
using UnityEngine;

public class Attack : MonoBehaviour
{
    private GameObject player;
    Rigidbody2D rb;
    EnemyDefinition ef;
    PlayerDefinition pd;
    float resttime;
    float last;

    float clock;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ef = GetComponent<EnemyDefinition>();
        pd = GetComponent<PlayerDefinition>();
        GetComponent<SpriteRenderer>().enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        resttime = player.GetComponent<PlayerDefinition>().cd;
        //clock = player.GetComponent<PlayerDefinition>().lastingtime;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 target = player.transform.position;
        transform.position = target;
        if (resttime > 0)
        {
            resttime -= Time.deltaTime;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
            if (last > 0)
            {
                last -= Time.deltaTime;
            }
            else
            {
                GetComponent<SpriteRenderer>().enabled = false;
                last = player.GetComponent<PlayerDefinition>().lastingtime;
                resttime = player.GetComponent<PlayerDefinition>().cd;
            }
        }
        if (clock > 0) clock -= Time.deltaTime;
    }
    //void OnTriggerEnter2D(Collider2D other)
    //{
     //   if (resttime > 0) return;
     //   if (!other.gameObject.CompareTag("Enemy")) return;
      //  if (last > 0)
      //  {
       //     Debug.Log("test");
       //     GameObject enemy = other.gameObject;
        //    enemy.GetComponent<EnemyDefinition>().HP -= player.GetComponent<PlayerDefinition>().PlayerDamage;
       //     resttime = player.GetComponent<PlayerDefinition>().cd;
            //clock = player.GetComponent<PlayerDefinition>().lastingtime;
        //    GetComponent<SpriteRenderer>().enabled = false;
      // }
    //}
}
