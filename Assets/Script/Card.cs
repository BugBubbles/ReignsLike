using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Card : ScriptableObject
{
    ///Basic card values
    public int cardID;
    public string cardName;
    public CardSprite sprite;
    public string Dialogue;
    public string leftQuote;
    public string rightQuote;
    ///Impact values
    public int nextCardID;
    ///left
    public int kPowerLeft;
    public int kMoneyLeft;
    public int kHealthLeft;
    public int nextCardLeft;
    ///right
    public int kPowerRight;
    public int kMoneyRight;
    public int kHealthRight;
    public int nextCardRight;


    public void Left()
    {
        Debug.Log(cardName + "swiped left");
        ///Appending the values
        GameManager.kingdomHealth += kHealthLeft;
        GameManager.kingdomPower += kPowerLeft;
        GameManager.kingdomMoney += kMoneyLeft;
        ///
        nextCardID = nextCardLeft;
    }
    public void Right()
    {
        Debug.Log(cardName + "swiped right");
        ///Appending the values
        GameManager.kingdomHealth += kHealthRight;
        GameManager.kingdomPower += kPowerRight;
        GameManager.kingdomMoney += kMoneyRight;
        nextCardID = nextCardRight;

    }


}

