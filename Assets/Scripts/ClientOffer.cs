using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientOffer : Slot
{
    [SerializeField] GameObject holderPrefab;

    private void Start()
    {
        GameObject holder = Instantiate(holderPrefab);
        holder.transform.SetParent(transform);
    }

    public void CheckIfEmpty()
    {
        bool containsItem = false;
       foreach(Transform child in transform)
        {
            if (child.GetComponent<ItemHolder>() != null) containsItem = true;
        }

        if (!containsItem)
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        ItemHolder.ItemDropped += CheckIfEmpty;
    }
    private void OnDisable()
    {
        ItemHolder.ItemDropped -= CheckIfEmpty;
    }
}
