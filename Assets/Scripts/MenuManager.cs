using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	private void Start()
	{
		maxLevelReached = PlayerPrefs.GetInt("MaxLevel");
		SetSelectionPanel();
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

	public void LoadLevel(int levelID)
	{
		// Load scenes
	}
}
