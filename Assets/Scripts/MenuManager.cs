using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
	private int maxLevelReached;
	private bool isSelectionPanelActive = false;
	public GameObject selectionPanel;

	public GameObject levelTwoButtonDisabled;
	public GameObject levelThreeButtonDisabled;
	public GameObject levelFourButtonDisabled;
	public GameObject levelFiveButtonDisabled;
	public GameObject levelSixButtonDisabled;
	public GameObject levelSevenButtonDisabled;
	public GameObject levelEightButtonDisabled;
	public GameObject levelNineButtonDisabled;
	public GameObject levelTenButtonDisabled;

	public Animator backgroundAnimator;
	public Animator corgiAnimator;
	public Animator fabbroNataleAnimator;
	public Animator hatPeasantAnimator;


	private void Start()
	{
		maxLevelReached = PlayerPrefs.GetInt("MaxLevel");
		SetSelectionPanel();
		UpdateMenu(maxLevelReached);
	}

	public void OpenLevelSelection()
	{
		if (isSelectionPanelActive)
		{
			selectionPanel.SetActive(false);
			isSelectionPanelActive = false;
		}
		else
		{
			selectionPanel.SetActive(true);
			isSelectionPanelActive = true;
		}
	}

	public void SetSelectionPanel()
	{
		if (maxLevelReached == 1)
		{
			levelTwoButtonDisabled.SetActive(false);
		}
		else if (maxLevelReached == 2)
		{
			levelThreeButtonDisabled.SetActive(false);
		}
		else if (maxLevelReached == 3)
		{
			levelFourButtonDisabled.SetActive(false);
		}
		else if (maxLevelReached == 4)
		{
			levelFiveButtonDisabled.SetActive(false);
		}
		else if (maxLevelReached == 5)
		{
			levelSixButtonDisabled.SetActive(false);
		}
		else if (maxLevelReached == 6)
		{
			levelSevenButtonDisabled.SetActive(false);
		}
		else if (maxLevelReached == 7)
		{
			levelEightButtonDisabled.SetActive(false);
		}
		else if (maxLevelReached == 8)
		{
			levelNineButtonDisabled.SetActive(false);
		}
		else if (maxLevelReached == 9)
		{
			levelTenButtonDisabled.SetActive(false);
		}
	}

	public void UpdateMenu(int level)
	{
		if (level == 0)
		{
			backgroundAnimator.SetFloat("LevelProgression", 0);
			corgiAnimator.Play("CorgiAnimation");
			fabbroNataleAnimator.Play("FabbroNataleAnimation");
			hatPeasantAnimator.Play("HatPeasantAnimation");
		}
		if (level == 1)
		{
			backgroundAnimator.SetFloat("LevelProgression", 1);
		}
		if (level == 2)
		{
			backgroundAnimator.SetFloat("LevelProgression", 2);
		}
		if (level == 3)
		{
			backgroundAnimator.SetFloat("LevelProgression", 3);
		}

	}

	public void LoadLevel(int levelID)
	{
		// Load scenes
	}
}
