using UnityEngine;

public static class SettingsManager
{
    public static int CurrentBalance
    {
        get => PlayerPrefs.GetInt(nameof(CurrentBalance));
        set => PlayerPrefs.SetInt(nameof(CurrentBalance), value);
    }
    
    public static bool IsMusicEnabled
    {
        get => PlayerPrefs.GetInt(nameof(IsMusicEnabled)) == 1;
        set => PlayerPrefs.SetInt(nameof(IsMusicEnabled), value ? 1 : 0);
    }
    
    public static bool IsSoundsEnabled
    {
        get => PlayerPrefs.GetInt(nameof(IsSoundsEnabled)) == 1;
        set => PlayerPrefs.SetInt(nameof(IsSoundsEnabled), value ? 1 : 0);
    }
}
