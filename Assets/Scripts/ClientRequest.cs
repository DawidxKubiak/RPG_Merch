using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClientRequest : Slot
{
    [SerializeField] TextMeshProUGUI text;
    List<Stat> requestedStat = new List<Stat>();
    private void Start()
    {
        int numStats = Random.Range(1, 4);

        for (int i = 0; i < numStats; i++)
        {
            Stat newStat = GenerateRandomStat();

            bool contains = false;

            foreach (Stat stat in requestedStat)
            {
                if (stat.elemental == newStat.elemental)
                {
                    contains = true;
                }
            }

            if (!contains) requestedStat.Add(newStat);
        }

        Display();
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

    public bool CheckItem(Item item)
    {
        List<Stat> itemStats = item.GetStats();

        foreach (Stat stat in requestedStat)
        {
            bool contains = false;

            foreach(Stat s in itemStats)
            {
                if(stat.elemental == s.elemental)
                {
                    if(s.amount >= stat.amount)
                    {
                        contains = true;
                        break;
                    }
                }
            }
            if (!contains)
            {
                return false;
            }
        }

        CoinManager.instance.AddCoins(GenerateItemPrice());
      
        Destroy(gameObject);
        return true;
    }

    public void Display()
    {
        string textToDisplay = "";        

        foreach (Stat stat in requestedStat)
        {
            textToDisplay += $"{stat.elemental} {stat.amount} \n";
        }

        text.text = textToDisplay;
    }

    public override void StartSpecialAction(Item item)
    {
        CheckItem(item);
    }

    public int GenerateItemPrice()
    {
        int price = 0;
        foreach(Stat stat in requestedStat)
        {
            price += stat.amount;
        }

        return price;
    }
}
