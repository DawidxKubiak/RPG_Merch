using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    private List<Stat> stats = new List<Stat>();

    public Item()
    {
        int numStats = Random.Range(1, 4); 

        for (int i = 0; i < numStats; i++)
        {
            Stat newStat = GenerateRandomStat();

            bool contains = false;

            foreach(Stat stat in stats)
            {
                if(stat.elemental == newStat.elemental)
                {
                    contains = true;
                }
            }

            if(!contains) stats.Add(newStat);
        }
    }

    public Item(List<Stat> stats)
    {
        this.stats = stats;
    }

    private Stat GenerateRandomStat()
    {
        Elemental randomElemental = (Elemental)Random.Range(0, 4);

        int randomAmount = Random.Range(1, 16);
        int tier = RandomToTier(randomAmount);

        Stat stat = new Stat(randomElemental, tier);
        return stat;
    }

    public int RandomToTier(int randomAmount)
    {
        int tier = 0;
        if (randomAmount >= 1) tier = 1;
        if (randomAmount >= 6) tier = 2;
        if (randomAmount >= 10) tier = 3;
        if (randomAmount >= 13) tier = 4;
        if (randomAmount == 15) tier = 5;

        return tier;
    }

    public List<Stat> GetStats()
    {
        return stats;
    }
}