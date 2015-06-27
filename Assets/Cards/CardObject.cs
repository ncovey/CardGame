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
using UnityEngine;

namespace CardGame
{
	public class CardObject : MonoBehaviour
	{
		protected Card m_card = new Card();
		protected Vector2 m_position = new Vector2 (0, 0);
		protected GameObject m_obj;

		public Card cardReference { get { return m_card; } set { m_card = value; } }

		public Vector2 Position 
		{ 
			get { return m_position; }
			set 
			{ 
				m_position = value;
				gameObject.GetComponent<Transform>().position = m_position;
			}
		}

		public Card.eSuit Suit {  
			get { return m_card.Suit; }
			set {
				m_card.Suit = value;
				SetTexture();
			}
			
		}
		public Card.eValue Value	
		{ 
			get { return m_card.Value; }
			set {
				m_card.Value = value;
				SetTexture();
			}
		}

		public GameObject gameObject { get { return m_obj; } set { m_obj = value; } }

		public CardObject ()
		{

		}

		void Start()
		{
			//			Renderer rend = gameObject.GetComponent<Renderer>();
			//			rend.material.SetTexture("_MainTex", (Texture)Resources.Load ("king_of_spades"));
		}
		
		protected string SetTexture() {
			
			string texture_name = Card.GetName(m_card.Suit, m_card.Value);
			texture_name.Replace(" ", "_");
			
			Renderer rend = gameObject.GetComponent<Renderer>();
			rend.material.SetTexture("_MainTex", (Texture)Resources.Load (texture_name));
			return texture_name;
		}

		
		public void SetSuitAndValue(Card.eSuit suit, Card.eValue val)
		{
			m_card.Suit = suit;
			m_card.Value = val;
			SetTexture();
		}

	}
}

