using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GenericButton : MonoBehaviour, IPointerEnterHandler , IPointerExitHandler{
    [SerializeField] protected UnityEvent OnClick, OnSelect, OnDeselect;
    public UnityEvent OnClick_Get => OnClick;
    public UnityEvent OnSelect_Get => OnSelect;
    public UnityEvent OnDeselect_Get => OnDeselect;
    public virtual void Click() {
        OnClick?.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        //throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData) {
        //throw new System.NotImplementedException();
    }
}
