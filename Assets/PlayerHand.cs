//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame
{
	public class PlayerHand
	{
		List<Card> m_cards = new List<Card>();

		public List<Card> cards
		{
			get { return m_cards; }
			set { m_cards = value; }
		}

		// returns null if empty
		public Card this[int idx]
		{
			get { return m_cards.Count > 0 ? m_cards[idx] : null; }
			set 
			{ 
				if (m_cards.Count != 0)
					m_cards[idx] = value; 
			}
		}

		public PlayerHand ()
		{
		}

		public void AddCard(Card card)
		{
			m_cards.Add(card);
		}

		public bool HasCard(Card card)
		{
			foreach ( Card c in m_cards )
			{
				if ( c.Suit == card.Suit && c.Value == card.Value )
					return true;
			}
			return false;
		}

		public bool empty()
		{
			return m_cards.Count == 0;
		}

		public int size()
		{
			return m_cards.Count;
		}

	}
}

