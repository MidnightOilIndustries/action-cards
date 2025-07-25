using UnityEngine;
using System.Collections.Generic;

public class HandManager : MonoBehaviour
{
    public GameObject card; // Prefab for the card
    public Transform handTransform; // Transform where the cards will be displayed
    public int maxHandSize = 10; // Maximum number of cards in hand
    private List<GameObject> hand = new List<GameObject>();

    public void Start()
    {
        DrawCard();
        DrawCard();
        DrawCard();
    }

        void Update()
    {
        // Draw a card when the "K" key is pressed
        if (Input.GetKeyDown(KeyCode.K))
        {
            DrawCard();
        }
    }

    // Method to draw a card
    public void DrawCard()
    {
        if (hand.Count < maxHandSize)
        {
            GameObject newCard = Instantiate(card, handTransform);
            hand.Add(newCard);
            ArrangeCards();
        }
    }

    // Method to arrange cards in hand
    private void ArrangeCards()
    {
        float cardSpacing = -50f / hand.Count * 3; // Adjust spacing as needed
        float angleStep = 10f; // Angle between each card
        float startAngle = -angleStep * (hand.Count - 1) / 2; // Center the fan
        float yOffsetFactor = 5f; // Factor to control the downward offset

        for (int i = 0; i < hand.Count; i++)
        {
            float angle = startAngle + i * angleStep;
            float xOffset = (i - (hand.Count - 1) / 2f) * cardSpacing; // Center the hand
            float yOffset = Mathf.Abs(i - (hand.Count - 1) / 2f) * yOffsetFactor; // Downward offset
            hand[i].transform.localPosition = new Vector3(xOffset, -yOffset, 0);
            hand[i].transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
    }
}