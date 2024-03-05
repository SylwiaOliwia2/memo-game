using System.Collections.Generic;
using Unity.Collections;
using System.Linq;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    public Clickable myPrefab;
    public List<Clickable> generatedCards;
    public List<Clickable> shuffledCards;
    public int amountToGenerate;
    
    [SerializeField] protected List<Sprite> imageSet;
    public List<int> siblingIndex => new List<int>(imageSet.Count * 2);
    
    void Awake()
    {
        int cardCounter = 0;
        foreach (Sprite img in imageSet) 
        {
            if (cardCounter >= amountToGenerate)
                break;
            Clickable p1 = Instantiate(myPrefab, transform);
            Clickable p2 = Instantiate(myPrefab, transform);
            p1.cardImage = img;
            p2.cardImage = img;
            generatedCards.Add(p1);
            generatedCards.Add(p2);
            cardCounter += 2;
        }
         // shuffle 
        shuffledCards = generatedCards.OrderBy( x => Random.value ).ToList( );
        int newSiblingIndex = 0;
        foreach(Clickable card in shuffledCards)
        {
            card.transform.SetSiblingIndex(newSiblingIndex);
            newSiblingIndex++;
        }
    }
}
