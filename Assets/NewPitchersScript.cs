using UnityEngine;
using System.Collections;

public class NewPitchersScript : MonoBehaviour {

    public Rigidbody ballPrefab;
    private Rigidbody ballClone;
    private int pitchSpeed = 1430;
    private GameObject other;
    private bool started = false;
    private float randomWait;
    private float animationWaitTime;
    private int pitchRandomizer;
    public string perfectPitch = "Curve Ball Practice"; //Can choose from "Perfect", "No", or "Curve Ball Practice"
    public int regularPitchSpeed = 1430;
    public float howMuchAngularDrag = 3.5f;
    public float howMuchAngularVelocity;



    public GameObject m_PitcherPlayer = null;

    bool bEnd = true;

    // Use this for initialization
    void Start()
    {
        m_PitcherPlayer.animation["idle"].wrapMode = WrapMode.Loop;
        m_PitcherPlayer.animation.Play("idle");
        animationWaitTime = m_PitcherPlayer.animation["shoot"].length;
        Debug.Log(animationWaitTime);
    }

    // Update is called once per frame
    void Update()
    {
        randomWait = Random.Range(2f, 3f);
        if (started == false && Input.GetKeyDown(KeyCode.S))
        {
            if (bEnd)
            {
                bEnd = false;
                StartCoroutine("PlayAni", "shoot");
                
            }
            //StartCoroutine("Pitch");
            started = true;
        }
    }


    IEnumerator PlayAni(string name)
    {
        while (true)
        {
            m_PitcherPlayer.animation.Play(name);
            yield return new WaitForSeconds(1f);
            ballClone = Instantiate(ballPrefab) as Rigidbody;
            pitchRandomizer = Random.Range(1,6);
            if (perfectPitch == "No")
            {
                if (pitchRandomizer == 2)
                {
                    pitchSpeed = 1200;
                }
                else if (pitchRandomizer == 4)
                {
                    pitchSpeed = 1700;
                }
                else pitchSpeed = regularPitchSpeed;
            }
            else if (perfectPitch == "Curve Ball Practice")
            {
                pitchSpeed = regularPitchSpeed + 50;
                ballClone.angularDrag = howMuchAngularDrag;
                ballClone.angularVelocity = new Vector3(howMuchAngularVelocity, howMuchAngularVelocity, howMuchAngularVelocity);
            }
            else pitchSpeed = regularPitchSpeed;
            ballClone.AddForce(transform.right * -pitchSpeed);
            yield return new WaitForSeconds(m_PitcherPlayer.animation[name].length);
            m_PitcherPlayer.animation.Play("idle");
            yield return new WaitForSeconds(randomWait);
            bEnd = true;
            //Destroy(ballClone.gameObject);
        }
    }
}
