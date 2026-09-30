using System.Collections;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnAI : MonoBehaviour
{
    GameObject[] prefab;
    GameObject pl;
    GameObject player;
    Rigidbody2D rb;
    EnemyDefinition ef;
    [SerializeField] int SetEnemyNumber=10;
    int EnemyNumber;
    [SerializeField] float Setwaittime=0.5f;
    //int flag = 0;
    float waittime;
    float priwavetime;

    //int flag = 0;
    float setclock = 1f;
    float clock;
    float pause;
    Vector3 tar = Vector3.zero;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ef = GetComponent<EnemyDefinition>();
        pl = GameObject.FindGameObjectWithTag("PublicDefinition");
        prefab = Resources.LoadAll<GameObject>("Enemy");
        EnemyNumber= SetEnemyNumber;
        priwavetime = pl.GetComponent<PublicDefinition>().wavetime;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Move()
    {
        float x = Random.Range(0f, 20f);
        float y = Random.Range(0f, 20f);
        transform.position = new Vector3(x, y, 0);
        CameraAvoid();

    }
    void Ins()
    {
        int temp = Random.Range(1, 4);
        var t = Instantiate(prefab[temp-1], transform.position, Quaternion.identity);
        t.GetComponent<EnemyDefinition>().HP += pl.GetComponent<GameManager>().exHP;
        t.GetComponent<EnemyDefinition>().Damage += pl.GetComponent<GameManager>().exDa;
        t.GetComponent<EnemyDefinition>().Score += pl.GetComponent<GameManager>().exSc;
        EnemyNumber--;
    }
    void waveclock()
    {
        if(priwavetime>=0)
        {
            priwavetime -= Time.deltaTime;
        }
        else
        {
            priwavetime = pl.GetComponent<PublicDefinition>().wavetime;
            EnemyNumber = SetEnemyNumber + 5;
            SetEnemyNumber += 5;
        }
    }
    void CameraAvoid()
    {
        if (transform.position.y - player.transform.position.y<=5f&& transform.position.y - player.transform.position.y >= -5f)
        {
            Move();
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        waveclock();
        CameraAvoid();
        if(pause>0)
        {
            pause -= Time.deltaTime;
            return;
        }
        if (clock <= 0)
        {
            Move();
            clock = setclock;
        }
        else clock -= Time.deltaTime;
        if (waittime <= 0 && EnemyNumber > 0 )
        {
            Ins();
            waittime = Setwaittime;
        }
        else waittime -= Time.deltaTime;

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        pause = 0.02f;
        Move();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        pause = 0.02f;
        Move();
    }
}
