using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Card card;
    public BoxCollider2D thisCard;
    public bool isMouseOver;
    void Start()
    {
        thisCard = gameObject.GetComponent<BoxCollider2D>();
    }
    void OnMouseOver()
    {
        isMouseOver = true;
    }
    void OnMouseExit()
    {
        isMouseOver = false;
    }
}


public enum CardSprite
{
    MAN,
    WOMAN,
    QUEEN,
    KNIGHT,
    NIGHTKING


}

