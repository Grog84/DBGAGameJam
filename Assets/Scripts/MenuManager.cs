using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
	//public Animator corgiAnimator;
	//public Animator fabbroNataleAnimator;
	//public Animator hatPeasantAnimator;


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
			levelTwoButtonDisabled.SetActive(false);
			levelThreeButtonDisabled.SetActive(false);
		}
		else if (maxLevelReached == 3)
		{
			levelTwoButtonDisabled.SetActive(false);
			levelThreeButtonDisabled.SetActive(false);
			levelFourButtonDisabled.SetActive(false);
		}
		else if (maxLevelReached == 4)
		{
			levelTwoButtonDisabled.SetActive(false);
			levelThreeButtonDisabled.SetActive(false);
			levelFourButtonDisabled.SetActive(false);
			levelFiveButtonDisabled.SetActive(false);
		}
		else if (maxLevelReached == 5)
		{
			levelTwoButtonDisabled.SetActive(false);
			levelThreeButtonDisabled.SetActive(false);
			levelFourButtonDisabled.SetActive(false);
			levelFiveButtonDisabled.SetActive(false);
			levelSixButtonDisabled.SetActive(false);
		}
		else if (maxLevelReached == 6)
		{
			levelTwoButtonDisabled.SetActive(false);
			levelThreeButtonDisabled.SetActive(false);
			levelFourButtonDisabled.SetActive(false);
			levelFiveButtonDisabled.SetActive(false);
			levelSixButtonDisabled.SetActive(false);
			levelSevenButtonDisabled.SetActive(false);
		}
		else if (maxLevelReached == 7)
		{
			levelTwoButtonDisabled.SetActive(false);
			levelThreeButtonDisabled.SetActive(false);
			levelFourButtonDisabled.SetActive(false);
			levelFiveButtonDisabled.SetActive(false);
			levelSixButtonDisabled.SetActive(false);
			levelSevenButtonDisabled.SetActive(false);
			levelEightButtonDisabled.SetActive(false);
		}
		else if (maxLevelReached == 8)
		{
			levelTwoButtonDisabled.SetActive(false);
			levelThreeButtonDisabled.SetActive(false);
			levelFourButtonDisabled.SetActive(false);
			levelFiveButtonDisabled.SetActive(false);
			levelSixButtonDisabled.SetActive(false);
			levelSevenButtonDisabled.SetActive(false);
			levelEightButtonDisabled.SetActive(false);
			levelNineButtonDisabled.SetActive(false);
		}
		else if (maxLevelReached == 9)
		{
			levelTwoButtonDisabled.SetActive(false);
			levelThreeButtonDisabled.SetActive(false);
			levelFourButtonDisabled.SetActive(false);
			levelFiveButtonDisabled.SetActive(false);
			levelSixButtonDisabled.SetActive(false);
			levelSevenButtonDisabled.SetActive(false);
			levelEightButtonDisabled.SetActive(false);
			levelNineButtonDisabled.SetActive(false);
			levelTenButtonDisabled.SetActive(false);
		}
	}

	public void UpdateMenu(int level)
	{
		if (level == 0)
		{
			backgroundAnimator.SetFloat("LevelProgression", 0);
			//corgiAnimator.Play("CorgiAnimation");
			//fabbroNataleAnimator.Play("FabbroNataleAnimation");
			//hatPeasantAnimator.Play("HatPeasantAnimation");
		}
		if (level <= 2)
		{
			backgroundAnimator.SetFloat("LevelProgression", 1);
		}
		if (level <= 4)
		{
			backgroundAnimator.SetFloat("LevelProgression", 2);
		}
		if (level <= 6)
		{
			backgroundAnimator.SetFloat("LevelProgression", 3);
		}

	}

	public void LoadLevel(int levelID)
	{
		if (levelID == 1)
		{
			SceneManager.LoadScene("Livello_01Official");
		}
		if (levelID == 2)
		{
			SceneManager.LoadScene("Livello_02Official 1");
		}
		if (levelID == 3)
		{
			SceneManager.LoadScene("Livello_03Official");
		}
		if (levelID == 4)
		{
			SceneManager.LoadScene("Livello_04Official 2");
		}
		if (levelID == 5)
		{
			SceneManager.LoadScene("Livello_05Official");
		}
        if (levelID == 6)
        {
            SceneManager.LoadScene("Livello_06Official 2");
        }
        if (levelID == 7)
        {
            SceneManager.LoadScene("Livello_07Official");
        }
        if (levelID == 8)
		{
            SceneManager.LoadScene("Livello_08Official");
        }
		if (levelID == 9)
		{
			// Da settare
		}
		if (levelID == 10)
		{
			// Da settare
		}
	}
}
