
using UnityEngine;
using UnityEngine.UI;

public class UICtrl : MonoBehaviour
{
    PublicDefinition pl;
    PlayerDefinition pd;
    GameObject player;

    public Text HPUI;
    public Text KilledUI;
    public Text TimeUI;
    public Text ScoreUI;
    public Text FPSUI;
    string min;
    string sec;
    // Start is called before the first frame update
    void Awake()
    {
        pl = GetComponent<PublicDefinition>();
        player = GameObject.FindGameObjectWithTag("Player");
        pd=player.GetComponent<PlayerDefinition>();
    }

    // Update is called once per frame
    void TimeFixed()
    {
        if(pl.time_min<10)
        {
            min = "0" + pl.time_min.ToString();
        }
        else min= pl.time_min.ToString();
        if (pl.time_sec< 10)
        {
            sec = "0" + pl.time_sec.ToString();
        }
        else sec = pl.time_sec.ToString();
    }
    void FixedUpdate()
    {
        HPUI.text = $"{pd.hp}/{pd.PlayerHP}";
        KilledUI.text = $"击杀：{pl.killed}";
        TimeFixed();
        TimeUI.text = $"时间：{min}:{sec}";
        ScoreUI.text = $"分数：{PublicDefinition.score}";
        FPSUI.text = $"FPS：{Mathf.Round(pl.FPS)}";
    }
}
