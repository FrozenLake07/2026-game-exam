
using UnityEngine;

public class BloodBottle : MonoBehaviour
{
    // Start is called before the first frame update
    float existtime = 60;
    GameObject player;
    GameObject pl;
    [SerializeField] int level;
    Color oricolor;
    float timer;
    bool flash=false;
    //public int weight = 50;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pl = GameObject.FindGameObjectWithTag("PublicDefinition");
        oricolor = GetComponent<SpriteRenderer>().color;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        existtime -= Time.deltaTime;
        timer-= Time.deltaTime;
        if (existtime <= 5f&&timer<=0)
        {
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
            timer = 0.1f;
        }
        if (existtime <= 0f) Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {

            player.GetComponent<PlayerDefinition>().hp += level * 2;
            if (player.GetComponent<PlayerDefinition>().hp > player.GetComponent<PlayerDefinition>().PlayerHP) player.GetComponent<PlayerDefinition>().hp = player.GetComponent<PlayerDefinition>().PlayerHP;
            Destroy(gameObject);
        }
    }
}
