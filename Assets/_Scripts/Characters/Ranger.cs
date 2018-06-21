﻿using Assets._Scripts.Abilities;
using Assets._Scripts.Abilities.Abstract;
using Assets._Scripts.Abilities.Characters.RangerAbilities;
using Assets._Scripts.Abilities.Characters.RangerAbilities.Logic;
using Assets._Scripts.Abilities.Characters.RangerAbilities.Special;
using Assets._Scripts.Characters.Abstract;
using Assets._Scripts.Characters.Abstract.Interfaces;
using Assets._Scripts.Player;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Scripts.Characters
{
    [RequireComponent(typeof(PlayerAbilitiesController))]
    internal class Ranger : RangedCharacterClass, ICharacterClass
    {
        private void Awake()
        {
            base.SetMaximumHealth(inspectorHealth);
            base.SetMaximumMana(inspectorMana);
            base.SetMaximumStamina(inspectorStamina);
            base.SetAttackRange(inspectorAttackRange);

            base.SetBasicStatistics();

            base.SetFirstDefaultAbility(new Shoot());
            base.SetSecondDefaultAbility(new Dodge());
            base.SetFirstSpecialAbility(new PoisonArrow());
            base.SetSecondSpecialAbility(new PenetratingShot());
            base.SetThirdSpecialAbility(new Barrage());
        }

        public new List<IAbility> GetCharacterAbilitiesList()
        {
            return base.GetCharacterAbilitiesList();
        }

        public new IAbility GetFirstDefaultAbility()
        {
            return base.GetFirstDefaultAbility();
        }

        public new IAbility GetSecondDefaultAbility()
        {
            return base.GetSecondDefaultAbility();
        }

        public new IAbility GetFirstSpecialAbility()
        {
            return base.GetFirstSpecialAbility();
        }

        public new IAbility GetSecondSpecialAbility()
        {
            return base.GetSecondSpecialAbility();
        }

        public new IAbility GetThirdSpecialAbility()
        {
            return base.GetThirdSpecialAbility();
        }

        int ICharacterClass.GetCurrentHealth()
        {
            return CurrentHealth;
        }

        int ICharacterClass.GetCurrentMana()
        {
            return CurrentMana;
        }

        int ICharacterClass.GetCurrentStamina()
        {
            return CurrentStamina;
        }

        public float GetAttackRange()
        {
            return DefaultAttackRange;
        }

        public int GetMaximumHealth()
        {
            return MaximumHealth;
        }

        public int GetMaximumMana()
        {
            return MaximumMana;
        }

        public int GetMaximumStamina()
        {
            return MaximumStamina;
        }

        public void GetFirstDefaultAbilityImplementation()
        {
            throw new System.NotImplementedException();
        }

        public Action GetSecondDefaultAbilityImplementation()
        {
            throw new System.NotImplementedException();
        }

        public Action GetFirstSpecialAbilityImplementation()
        {
            throw new System.NotImplementedException();
        }

        public Action GetSecondSpecialAbilityImplementation()
        {
            throw new System.NotImplementedException();
        }

        public Action GetThirdSpecialAbilityImplementation()
        {
            throw new System.NotImplementedException();
        }

        public Action GetAbilityImplementation()
        {
            throw new NotImplementedException();
        }

        IAbilityImplementation ICharacterClass.GetAbilityImplementation()
        {
            //TODO check if it dont couse high memory usage (it's should't but still..)
            return new RangerAbilitiesLogic();
        }
    }
}

