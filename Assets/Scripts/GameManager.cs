using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
	private bool isPaused = false;

	public Image blackImage; // Black image used for fade effect
	public float fadeDuration;

	private void Start()
	{
		FadeFromBlack();
	}

	private void Update()
	{
		// Input provvisorio
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			PauseGame();
		}
	}

	public void PauseGame()
	{
		if (isPaused)
		{
			Time.timeScale = 1;
			isPaused = false;
		}
		else
		{
			Time.timeScale = 0;
			isPaused = true;
		}
	}

	public void FadeFromBlack()
	{
		blackImage.DOFade(0, fadeDuration);
	}

	public void FadeToBlack()
	{
		blackImage.DOFade(1, fadeDuration);
	}
}
