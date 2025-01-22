using UnityEngine;

public struct Stat
{
    public StatsEnum stat;
    public int value;

    public Stat(StatsEnum stat, int val)
    {
        this.stat = stat;
        this.value = val;
    }
}
public class PlayerStats
{
    public Stat Endurance;
    public Stat Force;
    public Stat Wisdom;
    public Stat Agility;

    public PlayerStats()
    {
        Endurance = new Stat(StatsEnum.Endurance, 9);
        Force = new Stat(StatsEnum.Force, 9);
        Wisdom = new Stat(StatsEnum.Wisdom, 9);
        Agility = new Stat(StatsEnum.Agility, 9);
    }


    public void RaiseStat (StatsEnum stat)
    {
        switch(stat)
        {
            case StatsEnum.Endurance:
                Endurance.value++;
                break;
            case StatsEnum.Force:
                Force.value++;
                break;
            case StatsEnum.Wisdom:
                Wisdom.value++;
                break;
            case StatsEnum.Agility:
                Agility.value++;
                break;
        }
    }
}
