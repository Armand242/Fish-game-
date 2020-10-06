using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	[SerializeField] private float m_Speed = 1f;
	Rigidbody2D m_Rigid;
	void Awake () {
		m_Rigid = GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Start () {
		m_Rigid.AddForce (transform.up * m_Speed);
		Destroy (gameObject, 2f);
		
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Fish") {
			Destroy (gameObject);
			collision.gameObject.GetComponent<FishScript> ().TakeDamaged (50f);
		}
	}
}
