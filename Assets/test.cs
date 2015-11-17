using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    private Transform dest;
    private bool arrived;
    private float m_Speed = 50f;

    public void MoveTo(Transform destination)
    {
        arrived = false;
        dest = destination;
    }

    void Move()
    {
        if (transform == dest)
        {
            arrived = true;
            return;
        }
        Vector3 direct = dest.position - transform.position;
        transform.Translate(direct.normalized*Time.deltaTime*m_Speed);
    }
}
