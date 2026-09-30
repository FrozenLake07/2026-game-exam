
using UnityEngine;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    EnemyDefinition ef;
    GameObject pl;
    GameObject[] prefab;
    int Fixed=900;//修正概率，把总掉落概率控在10%左右；严格10%应该是918
    int dead;
    int chosen=-1;

    void Awake()
    {
        ef = GetComponent<EnemyDefinition>();
        pl = GameObject.FindGameObjectWithTag("PublicDefinition");
        prefab = Resources.LoadAll<GameObject>("Items");
        weightlist();
    }

    void weightlist()
    {
        int sum = 0;
        int[] search = new int[prefab.Length + 1];
        for (int i=0;i<prefab.Length;i++)
        {
            search[i] = sum;
            sum += prefab[i].GetComponent<Weight>().weight;
        }
        search[prefab.Length] = sum ;
        //int totalWeight = sum;
        sum += Fixed;
        int temp = Random.Range(0, sum);
        for(int i=0;i<prefab.Length;i++)
        {
            if (temp < search[i+1])
            {
                chosen = i;
                break;
            }
        }
        //Debug.Log($"[掉落] 物品数={prefab.Length} 权重和={totalWeight} Fixed={Fixed} " +
         //     $"总掉率={(float)totalWeight / sum:P1} 本次={(chosen >= 0 ? prefab[chosen].name : "无")}");
    }
    void Ins()
    {
        if (chosen >= 0)
        {
            var t = Instantiate(prefab[chosen], transform.position, Quaternion.identity);
        }

    }
        // Update is called once per frame
        void FixedUpdate()
    {
        if(ef.HP<=0 && dead==0)
        {
            dead = 1;
            Ins();
            PublicDefinition.score += ef.Score;
            pl.GetComponent<PublicDefinition>().killed++;
            //Debug.Log($"击杀 +{ef.Score} 分，累计 {pl.GetComponent<PublicDefinition>().score} 分 / 共 {pl.GetComponent<PublicDefinition>().killed} 只");
            Destroy(gameObject);
        }
    }
}
