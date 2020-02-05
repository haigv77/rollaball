using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AsyncTask : MonoBehaviour
{
    public Button parallelButton, raceButton;
    public Text textTask1, textTask2, textResult;
    public InputField inputTask1, inputTask2;

    private Coroutine coroutine1, coroutine2;

    // Start is called before the first frame update
    void Start()
    {
        parallelButton.onClick.AddListener(Task1OnClick);
        raceButton.onClick.AddListener(Task1OnClick);

        inputTask1.text = "10";
        inputTask2.text = "20";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Task1OnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button 1!");
        coroutine1 = StartCoroutine(PerformGridCalculations());
    }

    void Task2OnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button 2!");
        coroutine2 = StartCoroutine(PerformGridCalculations2());
    }

    IEnumerator PerformGridCalculations()
    {
        int t1 = Int32.Parse(inputTask1.text);
        int t2 = Int32.Parse(inputTask2.text);

        int max = t1 > t2 ? t1 : t2;

        for (int i = 0; i < max; ++i)
        {
            if (i <= t1)
                textTask1.text = i + "/" + t1;
            if (i <= t2)
                textTask2.text = i + "/" + t2;

            yield return new WaitForSeconds(0.5f);
        }

        textResult.text = "Finish 2 tasks";
    }

    IEnumerator PerformGridCalculations2()
    {
        int t1 = Int32.Parse(inputTask1.text);
        int t2 = Int32.Parse(inputTask2.text);

        int max = t1 > t2 ? t1 : t2;

        for (int i = 0; i < max; ++i)
        {
            if (i > t1) {
                textResult.text = "Finish task 1";
                StopCoroutine(coroutine2);
            } else {
                textTask1.text = i + "/" + t1;
            }

            if (i > t2) {
                textResult.text = "Finish task 2";
                StopCoroutine(coroutine2);
            } else {
                textTask2.text = i + "/" + t2;
            }

            yield return new WaitForSeconds(0.5f);
        }    
    }
}
