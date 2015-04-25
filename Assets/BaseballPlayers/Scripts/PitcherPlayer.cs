using UnityEngine;
using System.Collections;

public class PitcherPlayer : MonoBehaviour {

	public GameObject m_PitcherPlayer=null;

	bool bEnd=true;

	// Use this for initialization
	void Start () {
		m_PitcherPlayer.animation["idle"].wrapMode=WrapMode.Loop;
		m_PitcherPlayer.animation.Play("idle");
	}
	
	// Update is called once per frame
	void Update () {
		if (bEnd) {
			if (Input.GetKeyDown(KeyCode.A)) {
				bEnd=false;
				StartCoroutine("PlayAni","shoot");
			}
		}
	}

	IEnumerator PlayAni(string name) {
		m_PitcherPlayer.animation.Play(name);
		yield return new WaitForSeconds(m_PitcherPlayer.animation[name].length);
		m_PitcherPlayer.animation.Play("idle");
		bEnd=true;
	}
}
