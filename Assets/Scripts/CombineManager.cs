using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class CombineManager : MonoBehaviour
{
    [SerializeField] GameObject slot1, slot2, slot3;
    [SerializeField] GameObject holderPrefab;

    public void Combine()
    {
        Item item1 = slot1.transform.GetChild(0).GetComponent<ItemHolder>().GetItem();
        Item item2 = slot2.transform.GetChild(0).GetComponent<ItemHolder>().GetItem();

        GameObject newItem = Instantiate(holderPrefab, slot3.transform);

        Item item = new Item(CreateNewStatList(item1.GetStats(), item2.GetStats()));

        newItem.GetComponent<ItemHolder>().SetItem(item);
        newItem.GetComponent<ItemHolder>().Display();

        Destroy(slot1.transform.GetChild(0).gameObject);
        Destroy(slot2.transform.GetChild(0).gameObject);
    }

    public List<Stat> CreateNewStatList(List<Stat> list1, List<Stat> list2)
    {
        var combinedList = list1.Concat(list2).GroupBy(stat => stat.elemental).Select(group => group.OrderByDescending(stat => stat.amount).First());
        return combinedList.ToList();
    }
}
