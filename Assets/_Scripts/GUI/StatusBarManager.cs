﻿using Assets._Scripts.Characters.Abstract.Interfaces;
using Assets._Scripts.Player;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ICharacterClass))]
public class StatusBarManager : MonoBehaviour
{
    private ICharacterClass characterClass;

    private Canvas statusBarCanvas;

    private Transform playerTransform;

    [SerializeField] private Image healthBarFillImage;
    [SerializeField] private Image manaBarFillImage;
    [SerializeField] private Image staminaBarFillImage;

    [SerializeField]
    private List<Image> conditionStatusImagesList;

    private Quaternion startingStatusbarRotation;

    private void Awake()
    {
        characterClass = GetComponentInParent<ICharacterClass>();
        statusBarCanvas = GetComponent<Canvas>();
        playerTransform = GetComponentInParent<Transform>();
    }

    private void Start ()
    {
        SetStartingBarValues();
        PlayerStatisticManager.OnHealthValueChange += PlayerStatisticManager_OnHealthValueChange;
        PlayerStatisticManager.OnManaValueChange += PlayerStatisticManager_OnManaValueChange;
        PlayerStatisticManager.OnStaminaValueChange += PlayerStatisticManager_OnStaminaValueChange; 
    }

    private void LateUpdate()
    {
        statusBarCanvas.transform.rotation = Quaternion.Euler(new Vector3(90f, Mathf.Abs(playerTransform.rotation.y), 0f));       
    }

    private void PlayerStatisticManager_OnStaminaValueChange()
    {
        staminaBarFillImage.fillAmount = characterClass.GetCurrentStamina() / characterClass.GetMaximumStamina();
    }

    private void PlayerStatisticManager_OnManaValueChange()
    {
        manaBarFillImage.fillAmount = characterClass.GetCurrentMana() / characterClass.GetMaximumMana();
    }

    private void PlayerStatisticManager_OnHealthValueChange()
    {
        healthBarFillImage.fillAmount = characterClass.GetCurrentHealth() / characterClass.GetMaximumHealth();
    }

    private void SetStartingBarValues()
    {
        // "1" is the maximum value for image slider
        float fullFillAmount = 1f;

        healthBarFillImage.fillAmount = fullFillAmount;
        manaBarFillImage.fillAmount = fullFillAmount;
        staminaBarFillImage.fillAmount = fullFillAmount;
    }
}