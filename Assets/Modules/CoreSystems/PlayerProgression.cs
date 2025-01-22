using UnityEngine;

public class PlayerProgression
{
    const int BASE_XP = 12;

    int level;
    public float experience;
    float experienceToNextLevel;
    int levelCap;
    public int statPoints;


    public PlayerProgression(int levelcap)
    {
        level = 1;
        levelCap = levelcap;
        experience = 0;
        statPoints = 0;

    }

    public float CalculateProgressValues()
    {
        var xpRequiredForCurrentLevel = XpGrowth(level);
        var xpRequiredForNextLevel = XpGrowth(level + 1);
        var totalXpForNextLevel = experienceToNextLevel - xpRequiredForCurrentLevel;
        var currentProgressXp = experience - xpRequiredForCurrentLevel;
        var progressValue = (currentProgressXp / totalXpForNextLevel) * 100;
        progressValue = Mathf.Clamp(progressValue, 0, 100);
        return progressValue;

    }
    private float XpGrowth(int currentlevel)
    {
        return BASE_XP * Mathf.Pow(currentlevel, 2.1f) - BASE_XP;
    }

    public void LevelUp()
    {
        if (level < levelCap)
        {
            if (experience >= XpGrowth(level + 1))
            {
                level++;
                statPoints++;
            }
            if (level >= 2)
            {
                var nextLevel = XpGrowth(level + 1);
                experienceToNextLevel = nextLevel - experience;
            }
            else
            {
                experienceToNextLevel = XpGrowth(2);
            }
        }

    }

    public void UseStatPoint()
    {
        if (statPoints > 0)
        {
            statPoints--;
        }
    }

    public void PrintAllValues()
    {
        Debug.Log("Level: " + level);
        Debug.Log("Experience: " + experience);
        Debug.Log("Experience to next level: " + experienceToNextLevel);
        Debug.Log("Stat Points: " + statPoints);
    }


    public void GainExperience(float value)
    {
        experience += value;
        LevelUp();
    }

}
