using UnityEngine;

public static class FrameRateSetup
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void Init()
    {
        QualitySettings.vSyncCount = 0;        
        Application.targetFrameRate = 60;      
    }
}
