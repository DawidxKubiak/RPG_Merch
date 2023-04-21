using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class Slot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        bool canDrop = true;

        if (transform.childCount > 0)
        {
            foreach (Transform child in transform)
            {
                if (child.GetComponent<TextMeshProUGUI>() == null)
                {
                    canDrop = false;
                    break;
                }
            }
        }

        if (canDrop)
        {
            GameObject dropped = eventData.pointerDrag;
            ItemHolder holder = dropped.GetComponent<ItemHolder>();
            holder.parentAfterDrag = transform;

            StartSpecialAction(holder.GetItem());
        }
    }

    public virtual void StartSpecialAction(Item item)
    {

    }
}
