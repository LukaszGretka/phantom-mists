﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class MainPanelLogic : MonoBehaviour
{
    [SerializeField] private GameObject CharacterSelectionPanel;
    [SerializeField] private GameObject GameSettingsPanel;
    [SerializeField] private GameObject ExitPanel;

    private List<GameObject> panelsList;
 
    private void Start()
    {
        panelsList = new List<GameObject>
        {
            CharacterSelectionPanel,
            GameSettingsPanel,
            ExitPanel
        };

        DisableAllPanels(); //hide every panel if it active
    }

    #region ButtonClicksMethods

    public void SearchMatchButtonClick()
    {
        if (CharacterSelection.SelectedCharacter == null)
        {
            SetPanelActive(CharacterSelectionPanel);
            Debug.Log("Need to select Hero first.");  //TODO add information to user to select one of characters
            return;
        }

        Debug.LogError("Matchmaking is not implemented yet");
    }

    public void TreningModeButtonClick()
    {
        SceneManager.LoadScene("TreningArena", LoadSceneMode.Single); //it should work in single player mode
    }

    public void CharacterSelectionButtonClick()
    {
        SetPanelActive(CharacterSelectionPanel);
    }

    public void SettingsButtonClick()
    {
        SetPanelActive(GameSettingsPanel);
    }

    public void ExitButtonClick()
    {       
        SetPanelActive(ExitPanel);     
    }

    public void ConfirmButtonClick()
    {
        Application.Quit();
        Debug.Log("Application closing");
    }

    public void DeclineButtonClick()
    {
        DisableAllPanels();
    }
    #endregion

    private void SetPanelActive(GameObject panel)
    {
        if (!panelsList.Contains(panel))
        {
            Debug.LogError("Panels list don't contains current panel: " + panel.name + 
                            ". Please add current panel to panelList");
            return;
        }

        panelsList.ForEach(x => x.SetActive(false));
        panelsList.Find(x => x.name == panel.name).SetActive(true);
    }

    private void DisableAllPanels()
    {
        panelsList.ForEach(x => x.SetActive(false));
    }
}
