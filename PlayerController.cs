using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TMP_Text Score;
    public GameObject ScoreObj, GameOverObj, dark, restartButton, exitButton, pauseButton;

    private int score;

    private bool CanAddScore = true;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        m2();

        if (CanAddScore)
        {
            StartCoroutine(scoreAdd());
        }
    }

    void m3()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 finalMousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 4f));
            if (finalMousePos.x - 0.1f > transform.position.x && transform.position.x < 2.4f)  
            {
                transform.position = transform.position + new Vector3(5,0,0) * Time.deltaTime;
            }
            else if (finalMousePos.x + 0.1f < transform.position.x && transform.position.x > -2.4f) 
            {
                transform.position = transform.position - new Vector3(5, 0, 0) * Time.deltaTime;
            }
        }
    }

    void m2()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = touch.position;
            Vector3 finalTouchPos= Camera.main.ScreenToWorldPoint(new Vector3(touchPos.x, touchPos.y, 4f));
            if (finalTouchPos.x - 0.1f > transform.position.x && transform.position.x < 2.4f)
            {
                transform.position = transform.position + new Vector3(5, 0, 0) * Time.deltaTime;
            }
            else if (finalTouchPos.x + 0.1f < transform.position.x && transform.position.x > -2.4f)
            {
                transform.position = transform.position - new Vector3(5, 0, 0) * Time.deltaTime;
            }
        }

    }

    void m1()
    {
        if (transform.position.x > -2.4)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.position = transform.position - new Vector3(5, 0, 0) * Time.deltaTime;
            }
        }
        if (transform.position.x < 2.4)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.position = transform.position + new Vector3(5, 0, 0) * Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            Time.timeScale = 0;
            GameOverObj.SetActive(true);
            dark.SetActive(true);
            ScoreObj.transform.localPosition += new Vector3(50, -90, 0);
            ScoreObj.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
            restartButton.SetActive(true);
            exitButton.SetActive(true);
            pauseButton.SetActive(false);
        }
    }

    private IEnumerator scoreAdd()
    {
        CanAddScore = false;
        yield return new WaitForSeconds(0.3f);
        score = score + 1;
        Score.text = score.ToString();
        CanAddScore = true;
    }
}
