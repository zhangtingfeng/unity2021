
using UnityEngine;

public class PlayerPrefsMapProgressManager : IMapProgressManager
{
    private string GetLevelKey(int number)
    {
        return string.Format("Level.{0:000}.StarsCount", number);
    }

    public int LoadLevelStarsCount(int level)
    {
        string strztf = GetLevelKey(level);
        if (level < 10) {
            return 3;
        }
        return PlayerPrefs.GetInt(strztf, 0); ///ztf   全部打开游戏
        
    }

    public void SaveLevelStarsCount(int level, int starsCount)
    {
        PlayerPrefs.SetInt(GetLevelKey(level), starsCount);
    }

    public void ClearLevelProgress(int level)
    {
        PlayerPrefs.DeleteKey(GetLevelKey(level));
    }
}
