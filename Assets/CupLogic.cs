using UnityEngine;
using System.Collections;

public class CupLogic : MonoBehaviour
{
    public Transform m_GameLogic;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!arrived)
            Move();
    }


    private Vector3 dest;
    private bool arrived=true;
    private float m_Speed = 10f;
    private Vector3 direct;

    public void MoveTo(Vector3 pos)
    {
        arrived = false;
        dest = new Vector3(pos.x, pos.y, pos.z);
        direct = dest - transform.position;
    }

    void Move()
    {
        if (arrived)
            return;

        Vector3 differ = transform.position - dest;

        if (differ.magnitude<0.1)
        {
            arrived = true;
            transform.position = dest;
            return;
        }

        transform.Translate(direct.normalized * Time.deltaTime * m_Speed, Space.World);
    }
}
