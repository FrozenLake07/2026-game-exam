
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StateMonitor : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    PlayerDefinition pd;
    float angertime;
    int tempDa;
    int tempSp;
    bool angerflag = true;
    int tempstrength;
    int tempheart;
    int tempshoe;
    public int bscnt;

    float bstime;

    void Awake()
    {
        player = GetComponent<GameObject>();
        pd = GetComponent<PlayerDefinition>();
    }
    void angerclock()
    {
        angertime -= Time.deltaTime;
        if (angertime < 0&&!angerflag)
        {
            angerflag = true;
            pd.PlayerDamage = tempDa;
            pd.PlayerSpeed = tempSp;
            pd.Anger = false;
        }
    }

    void bsclock()
    {
        bstime-= Time.deltaTime;
        if(bstime<0&& GetComponent<SpriteRenderer>().color == new Color32(0xFF, 0x00, 0x99, 0xFF))
        {
            GetComponent<SpriteRenderer>().color = Color.grey;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        angerclock();
        bsclock();
        if(pd.hp<=0)
        {
            SceneManager.LoadScene(2);
        }
        if(pd.Anger)
        {
            //pd.Anger = false;
            if (angertime <= 0) angertime = 30f;
            if (angerflag)
            {
                angerflag = false;
                tempDa = pd.PlayerDamage;
                tempSp = pd.PlayerSpeed;
                pd.PlayerDamage *= 2;
                pd.PlayerSpeed += 3;
            }
        }
        else
        {
            if (pd.Strength > tempstrength)
            {
                pd.PlayerDamage += (pd.Strength - tempstrength) * 50;
                tempstrength = pd.Strength;
            }
            if (pd.FastShoe > tempshoe)
            {
                pd.PlayerSpeed += pd.FastShoe - tempshoe;
                tempshoe = pd.FastShoe;
            }
        }
        if(pd.StrongHeart > tempheart)
            {
            pd.PlayerHP += (pd.StrongHeart - tempheart) * 5;
            pd.hp += (pd.StrongHeart - tempheart) * 5;
            tempheart = pd.StrongHeart;
        }
        if (pd.BloodSucking!=0&&bscnt>=100-pd.BloodSucking*20)
        {
            bscnt -= 100 - pd.BloodSucking * 20;
            pd.hp++;
            GetComponent<SpriteRenderer>().color = new Color32(0xFF, 0x00, 0x99, 0xFF);
            bstime = 0.5f;
            if (pd.hp > pd.PlayerHP) pd.hp = pd.PlayerHP;
        }
        
    }
}
