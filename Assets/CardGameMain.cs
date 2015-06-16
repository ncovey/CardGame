using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace CardGame
{
	public class CardGameMain : MonoBehaviour 
	{
//		public Card card;

		protected List<Card> m_DeckOfCards;
		protected List<CardObject> m_CardObjects;
		//protected CardObject m_cardObj;
		protected int m_numCards = 0;
		//protected GameObject m_gameObj;
		protected CardGameManager m_cardgameMan = new CardGameManager(4); // 4 players

		// Use this for initialization

		void Start () 
		{
			Random.seed = System.DateTime.Now.Millisecond;
			m_CardObjects = new List<CardObject>();

			RebuildDeck();



		}
		
		// Update is called once per frame
		void Update () 
		{
			if (Input.GetKeyUp(KeyCode.Mouse0) && m_DeckOfCards.Count > 0)
			{
				var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				int idx = Random.Range (0, m_DeckOfCards.Count);

				GameObject obj = new GameObject();
				m_CardObjects.Add(obj.AddComponent<CardObject>());
				m_CardObjects[m_CardObjects.Count-1].gameObject = (GameObject)(Instantiate(Resources.Load<GameObject>("Card")));
                m_CardObjects[m_CardObjects.Count - 1].gameObject.AddComponent<CardObject>();
                m_CardObjects[m_CardObjects.Count-1].cardReference = m_DeckOfCards[idx];

				m_CardObjects[m_CardObjects.Count-1].SetSuitValue( (Card.eSuit) Random.Range (1, 5), (Card.eValue) Random.Range (1, 14) );
				m_CardObjects[m_CardObjects.Count-1].Position = new Vector2(pos.x, pos.y);

				m_CardObjects[m_CardObjects.Count-1].gameObject.gameObject.GetComponent<Renderer>().sortingOrder = (int)(m_numCards - m_DeckOfCards.Count);

				m_DeckOfCards.RemoveAt(idx);
				Destroy(obj);

			}

			if (Input.GetKeyUp(KeyCode.Mouse1))
			{
				RebuildDeck();
				foreach (CardObject c in m_CardObjects)
				{
					Destroy(c.gameObject);
				}
				m_CardObjects.RemoveRange(0, m_CardObjects.Count);
			}
		}

		void RebuildDeck()
		{
			m_numCards = 0;
			m_DeckOfCards = new List<Card>(52);
			m_DeckOfCards.Capacity = 52;
			for (int iSuit = 1; iSuit < 5; iSuit++)
			{
				for (int iValue = 1; iValue < 14; iValue++)
				{
					int idx = (((iSuit-1)*13)+(iValue-1));
					m_DeckOfCards.Add (new Card());
					m_DeckOfCards[idx].Suit = (Card.eSuit)iSuit;
					m_DeckOfCards[idx].Value = (Card.eValue)iValue;
					m_numCards++;
				}
			}
		}

	}

}
