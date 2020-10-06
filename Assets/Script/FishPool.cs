using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishPool : MonoBehaviour {

	// Use this for initialization
	private int m_RandomType;
	private Vector3 m_RandomPos;
	FishScript.FishDir m_RandomDir;
	private float m_Time = 0;
	private float m_TimeCD = 1f;

	uint m_CurrentFishCount =0;
	uint m_MaxFishCount = 25;
	//public GameObject ranPre;
 [SerializeField] private Text m_ScoreTxt;
	//public Text m_ScoreTxt;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (m_CurrentFishCount > m_MaxFishCount)
			return;
		m_Time += Time.deltaTime;
		if(m_Time>=m_TimeCD)
		{
			//generate a fish at randompostition
			m_RandomType = Random.Range(1,7);
			GameObject ranPre = Resources.Load<GameObject> ("Prefabs/Fish" + m_RandomType);
			m_RandomPos = new Vector3 (Random.Range (-9f, 9f), Random.Range (-4f, 6f), 0);
			m_RandomDir = Random.value > 0.5f ? FishScript.FishDir.Right : FishScript.FishDir.Left;
			FishScript f = FishScript.SpawnOneFish (m_RandomPos, ranPre, m_RandomDir);
			f.m_Del += YuJian;//add method YuJian on the delegate 
			m_CurrentFishCount++;
		}
		
	}
	private uint m_Score=0;
	private void YuJian()
{
	m_CurrentFishCount--;
	m_Score += 5;
	m_ScoreTxt.text = "Score:<color=yellow><b> "+ m_Score  +" </b></color>";
	}
}
