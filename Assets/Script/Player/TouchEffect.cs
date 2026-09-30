
using UnityEngine;


public class TouchEffect : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerDefinition pd;
    [SerializeField] private float SetUndamagedTime = 0.3f;

    [SerializeField] private float Setflashtime = 0.1f;
    float flashtime;
    bool flash;
    float UndamagedTime;

    Color FlashColor;
    void Hited()
    {
        FlashOn(Color.red);
        
    }
    void Defence()
    {
        FlashOn(Color.blue);
    }

    void FlashOn(Color C)
    {
        FlashColor = C;
        flash = true;
        flashtime = Setflashtime;
        GetComponent<SpriteRenderer>().color = C;
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pd = GetComponent<PlayerDefinition>();
    }
    void FixedUpdate()
    {
        if (UndamagedTime > 0)
        {
            UndamagedTime -= Time.fixedDeltaTime;

            flashtime -= Time.fixedDeltaTime;
            if (flashtime <= 0f)                            
            {
                flashtime = Setflashtime;
                flash = !flash;
                GetComponent<SpriteRenderer>().color = flash ? FlashColor: Color.grey;
            }
        }
        else GetComponent<SpriteRenderer>().color = Color.grey;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (UndamagedTime > 0) return;
        if (!collision.gameObject.CompareTag("Enemy")) return;
        GameObject Enemy = collision.gameObject;
        if(pd.Defence)
        {
            pd.Defence = false;
            Defence();
        }
        else
        {
            pd.hp -= Enemy.GetComponent<EnemyDefinition>().Damage;

            Hited();
        }
        //Debug.Log(pd.PlayerHP);
        UndamagedTime = SetUndamagedTime;
    }
}
