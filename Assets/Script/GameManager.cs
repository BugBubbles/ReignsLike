using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    ///kingdom
    public static int kingdomHealth;
    public static int kingdomMoney;
    public static int kingdomPower;
    public static int maxValue = 100;
    public int minValue = 0;

    ///gameobject
    public GameObject cardGameObject;
    public CardController mainCardController;
    public SpriteRenderer cardSpriteRenderer;
    public ResourceManager resourceManager;
    public Vector2 defaultPositionCard;
    ///tweaking variables
    public float fMovingSpeed =1.0f;
    public float fRotatingSpeed;
    public float fSideMargin;
    public float fSideTrigger;
    public Color textColor;
    public Color actionBackgroundColor;
    public float fTransparency = 0.7f;
    public float fRotationCoefficient;
    ///UI
    public  TMP_Text display;
    public TMP_Text Quote;
    public TMP_Text characterName;
    public SpriteRenderer actionBackground;
    public TMP_Text dialogue;
    ///Card variables
    public int nextCardnumber;
    private string leftQuote;
    private string rightQuote;
    public Card currentCard;
    public Card testCard;
    ///Substituting the card
    public bool isSubstituting = false;
    public Vector3 cardRotation; ///default one
    public Vector3 currentRotation; ///the current
    public Vector3 initRotation; ///initial rotation of the card


    // Start is called before the first frame update
    void Start()
    {
        LoadCard(testCard);
    }

    // Update is called once per frame
    void Update()
    {
        ///kingdom values
        

        ///text fade
        textColor.a = Mathf.Min(Mathf.Abs(cardGameObject.transform.position.x/2),1);
        actionBackgroundColor.a = Mathf.Min(Mathf.Abs(cardGameObject.transform.position.x/5),fTransparency);

        Quote.color = textColor;
        actionBackground.color = actionBackgroundColor;

        if(cardGameObject.transform.position.x >fSideMargin)
        {

            ///display.alpha = Mathf.Min(cardGameObject.transform.position.x,1);
            ///cardSpriteRenderer.color = Color.green;
            if(cardGameObject.transform.position.x > fSideTrigger)
            {
                if(Input.GetMouseButtonUp(0))
                {
                    currentCard.Right();
                    NewCard();
                }
            }
            Quote.text = rightQuote;
        }
        else if(cardGameObject.transform.position.x < -fSideMargin)
        {
            ///display.alpha = Mathf.Min(-cardGameObject.transform.position.x,1);
            ///cardSpriteRenderer.color = Color.red;
            if(cardGameObject.transform.position.x < -fSideTrigger)
            {
                if(Input.GetMouseButtonUp(0))
                {
                    currentCard.Left();
                    NewCard();
                }
            }
            Quote.text = leftQuote;

        }
        else
        {
            cardSpriteRenderer.color = Color.white;
        }

        if(Input.GetMouseButton(0) && mainCardController.isMouseOver == true)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cardGameObject.transform.position = pos;
            ///cardRotate when move
            cardGameObject.transform.eulerAngles = new Vector3(0,0,cardGameObject.transform.position.x * fRotationCoefficient);
        }
        else
        {
            if(!isSubstituting)
            {
                cardGameObject.transform.position = Vector2.MoveTowards(cardGameObject.transform.position,defaultPositionCard,fMovingSpeed*Time.deltaTime );
                cardGameObject.transform.eulerAngles = new Vector3(0,0,0);
            }
            else if(isSubstituting)
            {
                cardGameObject.transform.eulerAngles = Vector2.MoveTowards(cardGameObject.transform.eulerAngles,cardRotation,fRotatingSpeed*Time.deltaTime );
            }
                ///Make Quote a = 0 when change card
                textColor.a = 0;
                Quote.color = textColor;
                actionBackgroundColor.a = 0;
                actionBackground.color = actionBackgroundColor;

        }

        if(cardGameObject.transform.eulerAngles == cardRotation)
        {
            isSubstituting = false;
        }




    }

    public void LoadCard(Card card)
    {
        cardSpriteRenderer.sprite = resourceManager.sprites[(int)card.sprite];
        dialogue.text = card.Dialogue;
        leftQuote = card.leftQuote;
        rightQuote = card.rightQuote;
        currentCard = card;
        ///reset card position
        cardGameObject.transform.position = defaultPositionCard;
        cardGameObject.transform.eulerAngles = new Vector3(0,0,0);

        ///Initialize of the substitution
        cardGameObject.transform.eulerAngles = initRotation;
        isSubstituting = true;
    }
    public void NewCard()
    {
        nextCardnumber = currentCard.nextCardID;
        LoadCard(resourceManager.cards[nextCardnumber]);

    }


}
