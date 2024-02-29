using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using DG.Tweening;
using System;


public class Clickable : MonoBehaviour, IPointerClickHandler 
{

    public bool isReversed = false;
    public bool isMatched = false;

    [SerializeField] protected Sprite coverImage;

    public Sprite cardImage;

    [SerializeField] protected UnityEngine.UI.Image imageRenderer;

    void Awake(){
        imageRenderer.sprite = coverImage;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (!isReversed)
        {
            if (Managers.GameState.reversed_not_matched_cards.Count <2)
            {
                reverseCard();
            }

            if (Managers.GameState.reversed_not_matched_cards.Count == 2)
            {
                Clickable card_reveresed_1 = Managers.GameState.reversed_not_matched_cards[0];
                Clickable card_reveresed_2 = Managers.GameState.reversed_not_matched_cards[1];
                if (card_reveresed_1.cardImage == card_reveresed_2.cardImage)
                {
                    markPairAsMatched(card_reveresed_1, card_reveresed_2);
                }
                else {
                    DOTween.Sequence().AppendInterval(2.5f).OnComplete(
                        ()=>{
                            revertCardsToPreviousState(card_reveresed_1, card_reveresed_2);
                            // coś tu się psuje.
                        }
                    );
                }
            }
        }
    }

    public void reverseCard(){
        this.isReversed = !this.isReversed;
        Managers.GameState.reversed_cards += 1;
        Managers.GameState.reversed_not_matched_cards.Add(this);
        imageRenderer.sprite = cardImage;
        Debug.Log(this.name + " reversed: " + this.isReversed);
        Debug.Log("Managers state for reverseCard(revresed):" + Managers.GameState.reversed_cards);
    }

    public void markPairAsMatched(Clickable card_reveresed_1, Clickable card_reveresed_2){
        card_reveresed_1.isMatched = true;
        card_reveresed_2.isMatched = true;
        Managers.GameState.matched_cards += 2;
        Managers.GameState.reversed_not_matched_cards.Clear();
        Debug.Log("Managers state markPairAsMatched (matched):" + Managers.GameState.reversed_cards);
        Debug.Log("Managers state markPairAsMatched (revresed):" + Managers.GameState.matched_cards);
    }

    public void revertCardsToPreviousState(Clickable card_reveresed_1, Clickable card_reveresed_2) {
        Managers.GameState.reversed_not_matched_cards.Clear();
        Managers.GameState.reversed_cards -= 2;
        card_reveresed_1.isReversed = false;
        card_reveresed_2.isReversed = false;
        card_reveresed_1.imageRenderer.sprite = card_reveresed_1.coverImage;
        card_reveresed_2.imageRenderer.sprite = card_reveresed_2.coverImage;
        Debug.Log("Managers state revertCardsToPreviousState (revresed):" + Managers.GameState.reversed_cards);
        Debug.Log("Managers state revertCardsToPreviousState (matched):" + Managers.GameState.matched_cards);
    }
}
