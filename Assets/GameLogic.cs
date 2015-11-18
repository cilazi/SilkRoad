using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour {

    public Transform[] cups;
    //public Transform showNumbers;
    public Transform[] numbers;

    public Transform UI_Win;
    public Transform UI_Lose;

	// Use this for initialization
	void Start () {

        showStart = Time.time;
        BuildSequence();
	}
	
	// Update is called once per frame
	void Update () {

        ShowNumberAndHide();

        CheckDelay();
            //TestSwap();
  

        PlayGame();
    }

    private int curPointer = 0;

    private bool win = false;
    private bool lose = false;

    void PlayGame()
    {
        if (!b_GameStart)
            return;
        if (Input.GetMouseButtonUp(0))
        {

            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D h = Physics2D.OverlapPoint(ray);
            if (h != null)
            {
                if (h.gameObject.name == "lose")
                    Application.LoadLevel(Application.loadedLevel);
                if (h.gameObject.transform == cups[curPointer])
                {
                    numbers[curPointer].gameObject.SetActive(true);
                    curPointer++;
                    if (curPointer > 2)
                    {


                        Winned();
                    }
                }
                else
                {


                    Lost();
                }
            }
        }
    }

    void Winned()
    {
        win = true;
        Debug.Log("Win");
        UI_Win.gameObject.SetActive(true);
    }

    void Lost()
    {
        lose = true;
        Debug.Log("Lose");
        for (int i = 0; i < 3; i++)
            numbers[i].gameObject.SetActive(true);
        UI_Lose.gameObject.SetActive(true);
    }

    private float showStart;
    private bool b_Ishide = false;

    void ShowNumberAndHide()
    {
        if (b_Ishide)
            return;
        if (Time.time - showStart > 2)
        {
            b_Ishide = true;
            for (int i = 0; i < 3; i++)
                numbers[i].gameObject.SetActive(false);
            lastFinished = Time.time;
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
        if (!b_Ishide)
            return;
        if (Time.time - lastFinished > delay)
        {
            lastFinished = Time.time;
            UseSequence();
        }
    }

    private bool b_NeedToSwap = false;
    private float delay = 1f;

    private bool b_GameStart = false;

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
        else
            b_GameStart = true;
        b_NeedToSwap = false;
    }


    void swap(int i, int j)
    {
        cups[i].gameObject.GetComponent<CupLogic>().MoveTo(cups[j].position);
        cups[j].gameObject.GetComponent<CupLogic>().MoveTo(cups[i].position);
    }
}
