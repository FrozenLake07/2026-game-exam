
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{

    public Text finalscore;

    void FixedUpdate()
    {
        finalscore.text = $"最终分数：{PublicDefinition.score}";
    }
}
