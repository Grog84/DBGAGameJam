﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GameObject pausePanel;
	public GameObject gamePanel;
	public Image blackImage; // Black image used for fade effect
	public float startGameFadeAlpha;
	public float startLevelFadeAlpha;
	public float endLevelFadeAlpha;
	public float fadeDuration;
	public int levelNumber;

    public AudioEmitter lvlMusic;

	private void Start()
	{
		Fade(startGameFadeAlpha, fadeDuration);
		StartCoroutine(WaitForFade());
		gamePanel.SetActive(true);
		pausePanel.SetActive(false);
        // lvlMusic.PlaySound();

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
		SaveGameStatus();
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

	public void SaveGameStatus()
	{		
		PlayerPrefs.SetInt("MaxLevel", Mathf.Max(PlayerPrefs.GetInt("MaxLevel"), levelNumber));
	}

	public void ReloadScene()
	{
		var currentScene = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene(currentScene);
	}

	IEnumerator WaitForFade()
	{
		yield return new WaitForSeconds(1f);
		blackImage.gameObject.SetActive(false);
	}
}
