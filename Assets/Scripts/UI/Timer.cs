using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cutsceens;

public class Timer : MonoBehaviour
{
	[SerializeField] public float timeRemaining;
	[SerializeField] private Text timeText;
	[SerializeField] private CutsceenLoadArguments cutsceenLoader;
	public bool timeIsRunning = true;
	
    // Start is called before the first frame update
    void Start()
    {
        timeIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeIsRunning) 
		{
			if (timeRemaining >= 0) 
			{
				timeRemaining -= Time.deltaTime;
				DisplayTime(timeRemaining);
			}
			else
			{
				cutsceenLoader.LoadCutsceenArgs(CutsceenName.BrokeCar, CutsceenLoadArguments.CutsceenState.End);
				SceneManager.LoadScene("CutscenePlayer");
			}
		}
		
    }
	
	private void DisplayTime(float timeToDisplay)
	{
		timeToDisplay += 1;
		var minutes = Mathf.FloorToInt(timeToDisplay / 60);
		var seconds = Mathf.FloorToInt(timeToDisplay % 60);
		timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
	}
}
