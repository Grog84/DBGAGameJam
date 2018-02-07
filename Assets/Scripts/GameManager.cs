using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
	public GameObject pausePanel;
	public GameObject gamePanel;
	public Image blackImage; // Black image used for fade effect
	public float startGameFadeAlpha;
	public float startLevelFadeAlpha;
	public float endLevelFadeAlpha;
	public float fadeDuration;

	private void Start()
	{
		Fade(startGameFadeAlpha, fadeDuration);
		StartCoroutine(WaitForFade());
		gamePanel.SetActive(true);
		pausePanel.SetActive(false);
	}

	private void Update()
	{

	}

	public void StartNewLevel()
	{
		Fade(startLevelFadeAlpha, fadeDuration);
	}

	public void EndLevel()
	{
		blackImage.gameObject.SetActive(true);
		Fade(endLevelFadeAlpha, fadeDuration);
	}

	public void PauseGame()
	{
		gamePanel.SetActive(false);
		pausePanel.SetActive(true);
		Time.timeScale = 0;
	}

	public void ResumeGame()
	{
		pausePanel.SetActive(false);
		gamePanel.SetActive(true);
		Time.timeScale = 1;
	}

	public void Fade(float alpha, float duration)
	{
		blackImage.DOFade(alpha, duration);
	}

	IEnumerator WaitForFade()
	{
		yield return new WaitForSeconds(1f);
		blackImage.gameObject.SetActive(false);
	}
}
