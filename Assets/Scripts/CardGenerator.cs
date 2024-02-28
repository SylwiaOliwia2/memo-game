using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    public Clickable myPrefab;
    public List<Clickable> generatedCards;
    
    [SerializeField] protected List<Sprite> imageSet; 
    
    void Awake()
    {
        // list(range(5))
        foreach (Sprite img in imageSet) 
        {
            Clickable p1 = Instantiate(myPrefab, transform);
            Clickable p2 = Instantiate(myPrefab, transform);
            p1.cardImage = img;
            p2.cardImage = img;
            generatedCards.Add(p1);
            generatedCards.Add(p2);
            // shuffle the list/ the occurence, make nice allignment
        }
    }
}
