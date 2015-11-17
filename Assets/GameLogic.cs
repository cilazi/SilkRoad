using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour {

    public Transform[] cups;
    public Transform showNumbers;

	// Use this for initialization
	void Start () {

        showStart = Time.time;
        BuildSequence();
	}
	
	// Update is called once per frame
	void Update () {
        if (!b_Ishide)
            ShowNumberAndHide();
        else
        {
            CheckDelay();
            //TestSwap();
        }
    }



    private float showStart;
    private bool b_Ishide = false;

    void ShowNumberAndHide()
    {
        if (Time.time - showStart > 2)
        {
            b_Ishide = true;
            showNumbers.gameObject.SetActive(false);
            lastFinished = Time.time;
        }
    }

    void swap(int i, int j)
    {
        cups[i].gameObject.GetComponent<CupLogic>().MoveTo(cups[j].position);
        cups[j].gameObject.GetComponent<CupLogic>().MoveTo(cups[i].position);
    }

    void TestSwap()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            swap(0, 1);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            swap(0, 2);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            swap(1, 2);
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            bool active = cups[0].gameObject.activeSelf;
            cups[0].gameObject.SetActive(!active);
        }
    }

    private List<int> Sequence=new List<int>();

    void BuildSequence()
    {
        Sequence.Add(1);
        Sequence.Add(2);
        Sequence.Add(3);
    }

    private float lastFinished;



    private void CheckDelay()
    {
        if (Time.time - lastFinished > delay)
        {
            lastFinished = Time.time;
            UseSequence();
        }
    }

    private bool b_NeedToSwap = false;
    private float delay = 1f;



    public void UseSequence()
    {

        if (Sequence.Count > 0)
        {
            lastFinished = Time.time;
            if (Sequence[0] == 1)
                swap(0, 1);
            else if (Sequence[0] == 2)
                swap(0, 2);
            else
                swap(1, 2);
            Sequence.RemoveAt(0);
        }
        b_NeedToSwap = false;
    }
}
