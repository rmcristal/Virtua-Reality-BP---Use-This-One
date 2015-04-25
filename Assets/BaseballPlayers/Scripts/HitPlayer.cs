using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HitPlayer : MonoBehaviour {

	public GUIText m_HelpText=null;
	public GameObject m_HitPlayer=null;
	bool bEnd=true;
    public AudioClip hit;
    private int swingCountRemaining = 20;
    public Text swingsRemainingText;

	// Use this for initialization
	void Start () {
		m_HelpText.text=m_HelpText.text.Replace("\\","\n");
		m_HitPlayer.animation["idle"].wrapMode=WrapMode.Loop;
		m_HitPlayer.animation.Play("idle");
        
	}

	
	// Update is called once per frame
	void Update () {
		if (bEnd) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				bEnd=false;
				StartCoroutine("PlayAni","hit");
                swingCountRemaining -= 1;
                swingsRemainingText.text = ("Swings Remaining: " + swingCountRemaining);
                return;
			}
			
		}
	}
	
	IEnumerator PlayAni(string name) {
		m_HitPlayer.animation.Play(name);
		yield return new WaitForSeconds(m_HitPlayer.animation[name].length);
		m_HitPlayer.animation.Play("idle");
		bEnd=true;
	}

   void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(hit, new Vector3(0f, 1f, -14f));
        Debug.Log("There was at least a tip");

    }
    
}
