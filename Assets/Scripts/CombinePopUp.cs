using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CombinePopUp : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] GameObject panel;

    bool visible = false;

    private void Start()
    {
        panel.transform.DOScale(Vector3.zero, 0f);
    }

    public void ChangeVisibility()
    {
        visible = !visible;
        if (visible)
        {
            panel.transform.DOScale(Vector3.one,.5f);         
        }

        if (!visible)
        {
            panel.transform.DOScale(Vector3.zero, .5f);
        }      
    }

   
}
