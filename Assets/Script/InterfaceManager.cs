using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject card;
    ///UI icons
    public Image kingdomHealth;
    public Image kingdomMoney;
    public Image kingdomPower;

    ///UI impact icons
    public Image kingdomHealthImpact;
    public Image kingdomMoneyImpact;
    public Image kingdomPowerImpact;

    void Update()
    {
        ///UI icons
        kingdomHealth.fillAmount = (float)GameManager.kingdomHealth / GameManager.maxValue;
        kingdomPower.fillAmount = (float)GameManager.kingdomPower / GameManager.maxValue;
        kingdomMoney.fillAmount = (float)GameManager.kingdomMoney / GameManager.maxValue;
        //Left
        if(card.transform.position.x < -0.5f)
        {
            if(gameManager.currentCard.kMoneyLeft !=0)
            {
                kingdomMoneyImpact.transform.localScale = new Vector3(1,1,0);
            }
            if(gameManager.currentCard.kPowerLeft !=0)
            {
                kingdomPowerImpact.transform.localScale = new Vector3(1,1,0);
            }
            if(gameManager.currentCard.kHealthLeft !=0)
            {
                kingdomHealthImpact.transform.localScale = new Vector3(1,1,0);
            }

        }
        ///Right
        else if(card.transform.position.x > 0.5f)
        {
            if(gameManager.currentCard.kMoneyRight !=0)
            {
                kingdomMoneyImpact.transform.localScale = new Vector3(1,1,0);
            }
            if(gameManager.currentCard.kPowerRight !=0)
            {
                kingdomPowerImpact.transform.localScale = new Vector3(1,1,0);
            }
            if(gameManager.currentCard.kHealthRight !=0)
            {
                kingdomHealthImpact.transform.localScale = new Vector3(1,1,0);
            }

        }
        ///middle
        else
        {
            kingdomHealthImpact.transform.localScale = new Vector3(0,0,0);
            kingdomMoneyImpact.transform.localScale = new Vector3(0,0,0);
            kingdomPowerImpact.transform.localScale = new Vector3(0,0,0);
        }

    }
}
