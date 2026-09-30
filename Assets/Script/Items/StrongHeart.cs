
using UnityEngine;

public class StrongHeart : MonoBehaviour
{
    // Start is called before the first frame update
    float existtime = 180;
    GameObject player;
    GameObject pl;
    [SerializeField] int level;
    Color oricolor;
    bool flash = false;
    float timer;
    //public int weight = 5;
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
        timer -= Time.deltaTime;
        if (existtime <= 10f &&timer<=0)
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
        if (player.GetComponent<PlayerDefinition>().StrongHeart >= 3)
        {
            player.GetComponent<PlayerDefinition>().StrongHeart = 3;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerDefinition>().StrongHeart++;
            //player.GetComponent<PlayerDefinition>().hp += 5;
            Destroy(gameObject);
        }
    }
}
