using UnityEngine;

public class AngerUI : MonoBehaviour
{
    public GameObject UI;          // Inspector 里拖"怒气提示"那个 UI 物体
    PlayerDefinition pd;

    void Awake()
    {
        if (UI == null)
        {
            Debug.LogError("AngerUI: 没有在 Inspector 里指定要开关的 UI 物体", this);
            enabled = false;                       // 只报错一次，不要每帧抛异常
            return;
        }

        var player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.LogError("AngerUI: 场景里找不到 Tag = Player 的物体", this);
            enabled = false;
            return;
        }

        pd = player.GetComponent<PlayerDefinition>();
        if (pd == null)
        {
            Debug.LogError("AngerUI: Player 身上没有 PlayerDefinition", this);
            enabled = false;
            return;
        }

        UI.SetActive(pd.Anger);                    // 开局先同步一次状态
    }

    void FixedUpdate()
    {
        UI.SetActive(pd.Anger);                    // 怒气期间显示，怒气失效后自动隐藏
    }
}
