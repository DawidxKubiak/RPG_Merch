using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using System;

public class ItemHolder : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] Item item;
    [SerializeField] TextMeshProUGUI text;

    public Transform parentAfterDrag;

    Image image;

    public static event Action ItemDropped;

    private void Start()
    {
        item = new Item();
        Display();

        image = GetComponent<Image>();
    }
    public Item GetItem()
    {
        return item;
    }

    public void Display()
    {
        string textToDisplay = "";

        List<Stat> stats = item.GetStats();

        foreach (Stat stat in stats)
        {
            textToDisplay += $"{stat.elemental} {stat.amount} \n";
        }

        text.text = textToDisplay;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;

        ItemDropped?.Invoke();
    }

    public void SetItem(Item item) 
    {
        this.item = item;
    }
}
