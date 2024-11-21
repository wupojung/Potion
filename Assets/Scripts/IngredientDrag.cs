using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IngredientDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    private RectTransform _rectTransform;
    private Vector2 _originalRectPosition;

    private GameObject _cache;

    public int score;
    
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _originalRectPosition = _rectTransform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
   
        
        // 確認一下是否有放在鍋子內部
        if (_cache != null)
        {
            GameDB.score += this.score;
            gameObject.SetActive(false); //hide
        }
        
        _rectTransform.position = _originalRectPosition;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "MixArea")
        {
            _cache = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "MixArea")
        {
            _cache = null;
        }
    }
}
