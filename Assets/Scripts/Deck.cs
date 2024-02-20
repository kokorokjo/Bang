using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<GameObject> cards = new();
    public GameObject bangSpadeA;

    private void Start()
    {
        cards.Add(bangSpadeA);
        cards.Add(bangSpadeA);
        cards.Add(bangSpadeA);
        cards.Add(bangSpadeA);
        cards.Add(bangSpadeA);
        cards.Add(bangSpadeA);
        cards.Add(bangSpadeA);
        cards.Add(bangSpadeA);
        cards.Add(bangSpadeA);
    }
    
    
}
