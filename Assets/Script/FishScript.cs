using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour {

	// Use this for initialization
	//public GameObject expre;
	public enum FishDir
	{
		Right,
		Left
	}
	private static FishDir m_Dir;
	private float m_FishHP = 200f;
	Vector3 m_RandomTarget;
	void Start () {
		transform.localScale = m_Dir == FishDir.Left ? new Vector3 (-1, 1, 1) : new Vector3 (1, 1, 1);
		m_Dir = m_Dir;
		SetPosByDir ();
		
	}
	
	// Update is called once per frame
	void Update () {
		FishMoving ();
	}
	private void SetPosByDir()
	{
		m_RandomTarget = m_Dir == FishDir.Left ? new Vector3 (-9f, Random.Range (-4, 6f), 0) : new Vector3 (9f, Random.Range (-4, 6f), 0);
	}
	void FishMoving()
	{
		transform.position = Vector3.MoveTowards (transform.position, m_RandomTarget, 2 * Time.deltaTime);
		if (Vector3.Distance (transform.position, m_RandomTarget) < 0.9f) {
			m_Dir = m_Dir == FishDir.Left ? FishDir.Right : FishDir.Left;
			transform.localScale = m_Dir == FishDir.Left ? new Vector3 (-1, 1, 1) : new Vector3 (1, 1, 1);
			SetPosByDir ();

		}
	}

	public static FishScript SpawnOneFish(Vector3 pos, GameObject pre,FishDir dir)
	{
		GameObject oneFish = Instantiate (pre, pos, Quaternion.identity);
		m_Dir = dir;
		return oneFish.GetComponent<FishScript> ();
	}

	//delegate here:

    public delegate void FishDeathDelegate();//declare

	public FishDeathDelegate m_Del;//Instantiate
	public void TakeDamaged(float damage)
	{
		m_FishHP -= damage;
		if (m_FishHP <= 0) {
			Destroy (gameObject);
			GameObject expre = Resources.Load<GameObject> ("Prefabs/Explosion");
			GameObject ex = Instantiate (expre, transform.position, Quaternion.identity);
			Destroy (ex, 1.2f);
			  
			if(m_Del!=null)
			m_Del();//decreasing one fish

		}
	}
}
