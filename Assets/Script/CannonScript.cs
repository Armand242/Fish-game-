using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour {

	// Use this for initialization
	Transform m_Gun;
	[SerializeField] private Transform m_FirePos;
	//public GameObject firePrefab;
	void Start () {
		m_Gun = transform.Find("Gun");
		
	}
	
	// Update is called once per frame
	void Update () {
		//get the mouse position on the Screen to 3D position
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//Calculate the vector3 and the angle between y axis and this vector3
		Vector3 TargetDir = mousePos - m_Gun.position;
		float angle = Vector2.Angle (Vector3.up, TargetDir);
		//change the Gun shoot direction
		m_Gun.eulerAngles = Vector3.forward * angle;
		m_Gun.eulerAngles = Vector3.forward * Mathf.Clamp (angle, 0, 100f);
		if (mousePos.x > 0) {
			m_Gun.eulerAngles = -Vector3.forward * angle;
			m_Gun.eulerAngles = Vector3.forward * Mathf.Clamp (-angle, -100f, 0f);
		}

		if(Input.GetMouseButtonDown(0)|| Input.GetKeyDown(KeyCode.Space))
		{
			GameObject firePrefab = Resources.Load<GameObject> ("Prefabs/Fire");
			Instantiate (firePrefab, m_FirePos.position, m_FirePos.rotation);

		}
		if (Input.GetKey (KeyCode.Escape))
			Application.Quit ();
	}
}
