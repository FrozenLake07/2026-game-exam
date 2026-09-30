
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    PublicDefinition pd;
    EnemyDefinition ef;
    public int exHP;
    public int exDa;
    public int exSc;
    float time;
    int temp;
    void clock()
    {
        time += Time.deltaTime;
        if(time>=1f)
        {
            pd.time_sec++;
            time -= 1f;
        }
        if(pd.time_sec==60)
        {
            pd.time_sec -= 60;
            pd.time_min++;
        }
    }
    void stronger()
    {
        if (pd.time_min != temp&&pd.time_min%3==0)
        {
            exDa += 1;
        }
        if (pd.time_min!=temp)
        {
            temp = pd.time_min;
            exHP+= 50;
            exSc += 1;

        }
        
    }
    void Awake()
    {
        pd=GetComponent<PublicDefinition>();
        ef=GetComponent<EnemyDefinition>();
    }

    // Update is called once per frame
    void FixedUpdate()

    {
        pd.FPS = 1f / Time.smoothDeltaTime;
        clock();
        stronger();
    }
}
