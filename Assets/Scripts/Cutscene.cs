using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
	public GameObject cutscene;
	public GameObject teamLogoFather;
	public GameObject gameLogoFather;
	public Image teamLogo;
	public Image gameLogo;

	private void Start()
	{
		
		StartCoroutine(WaitForVideoToEnd());
	}

	IEnumerator WaitForVideoToEnd()
	{
		yield return new WaitForSeconds(38f);
		cutscene.SetActive(false);
		teamLogoFather.SetActive(true);
		teamLogo.DOFade(1, 2f);
		StartCoroutine(WaitBetweenLogos());
	}

	IEnumerator WaitBetweenLogos()
	{
		yield return new WaitForSeconds(2f);
		gameLogoFather.SetActive(true);
		gameLogo.DOFade(1, 2f);
		StartCoroutine(WaitBeforeLoad());
	}

	IEnumerator WaitBeforeLoad()
	{
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene("GM_SelectionMenu");
	}
}
