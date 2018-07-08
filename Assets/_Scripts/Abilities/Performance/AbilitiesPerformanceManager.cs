﻿using Assets._Scripts.Abilities.Abstract;
using Assets._Scripts.Characters.Abstract.Interfaces;
using Assets._Scripts.OutputMessages;
using Assets._Scripts.Player;
using System;
using System.Collections;
using UnityEngine;

namespace Assets._Scripts.Abilities.Performance
{
    internal class AbilitiesPerformanceManager: MonoBehaviour, IAbilityPerformance 
    {
        private ICharacterClass characterClass;
        private static IEnumerator castAbilityCoroutine;

        private void Awake()
        {
            characterClass = GetComponent<ICharacterClass>();
        }

        public void CastFirstDefaultAbility()
        {
            StartCastingAbility(characterClass.GetFirstDefaultAbility(), 
                () => { characterClass.GetAbilityImplementation().FirstDefaultAbilityImplementation(); });
        }

        public void CastSecondDefaultAbility()
        {
            StartCastingAbility(characterClass.GetSecondDefaultAbility(), 
                () => { characterClass.GetAbilityImplementation().SecondDefaultAbilityImplementation(); });
        }

        public void CastFirstSpecialAbility()
        {
            StartCastingAbility(characterClass.GetFirstSpecialAbility(), 
                () => { characterClass.GetAbilityImplementation().FirstSpecialAbilityImplementation(); });
        }

        public void CastSecondSpecialAbility()
        {
            StartCastingAbility(characterClass.GetSecondSpecialAbility(), 
                () => { characterClass.GetAbilityImplementation().SecondSpecialAbilityImplementation(); });
        }

        public void CastThirdSpecialAbility()
        {
            StartCastingAbility(characterClass.GetThirdSpecialAbility(), 
                () => { characterClass.GetAbilityImplementation().ThirdSpecialAbilityImplementation(); });
        }

        private void StartCastingAbility(IAbility ability, Action AbilityAction)
        {
            //TODO this method (or coroutine) should implement response for situation such as interupt, canceled by user etc.
            if (PerformAbilityValidation(characterClass, ability).State == AbilityResultState.ReadyToCast)
            {
                characterClass.SubstractMana(ability.ManaCost);
                characterClass.SubstractStamina(ability.StaminaCost);
                castAbilityCoroutine = CastAbilityCoroutine(ability, AbilityAction);
                StartCoroutine(castAbilityCoroutine);
            }
        }

        private IEnumerator CastAbilityCoroutine(IAbility ability, Action abilityCastAction)
        {
            //TODO check if ability was interupter
            yield return new WaitForSeconds(ability.CastingTime);

            Debug.Log("End casting after " + ability.CastingTime + " sec. Executed ability: " + ability.Name);
            abilityCastAction.Invoke();
        }

        /// <summary>
        /// Check is character is able to cast a ability
        /// </summary>
        /// <param name="characterClass">Character class (attached to gameobject)</param>
        /// <param name="ability">Ability which is going to be cast</param>
        /// <returns></returns>
        private AbilityCastResult PerformAbilityValidation(ICharacterClass characterClass, IAbility ability)
        {
            AbilityCastResult abilityCastResult = BuildAbilityCastResult(PlayerOutputMessages.AbilityCastSuccessful, ability, AbilityResultState.ReadyToCast);

            if (characterClass.CheckIfEnoughMana(ability))
            {
                abilityCastResult = BuildAbilityCastResult(PlayerOutputMessages.NotEnoughMana, ability, AbilityResultState.NotEnoughMana);
            }

            if (characterClass.CheckIfEnoughStamina(ability))
            {
                abilityCastResult = BuildAbilityCastResult(PlayerOutputMessages.NotEnoughStamina, ability, AbilityResultState.NotEnoughStamina);
            }

            if (ability.OnCooldown)
            {
                abilityCastResult =  BuildAbilityCastResult(PlayerOutputMessages.AbilityOnCooldown, ability, AbilityResultState.OnCooldown);
            }

            return abilityCastResult;
        }

        private AbilityCastResult BuildAbilityCastResult(string message, IAbility ability, AbilityResultState state)
        {
            return new AbilityCastResult()
            {
                Ability = ability,
                Message = message,
                State = state,
            };
        }
    }
}
