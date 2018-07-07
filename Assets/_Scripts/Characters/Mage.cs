﻿using Assets._Scripts.Abilities;
using Assets._Scripts.Abilities.Abstract;
using Assets._Scripts.Abilities.Characters.MageAbilities;
using Assets._Scripts.Abilities.Characters.MageAbilities.Logic;
using Assets._Scripts.Abilities.Characters.MageAbilities.Special;
using Assets._Scripts.Characters.Abstract;
using Assets._Scripts.Characters.Abstract.Interfaces;
using Assets._Scripts.Player;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Scripts.Characters
{
    [RequireComponent(typeof(PlayerAbilitiesController))]
    internal class Mage : RangedCharacterClass, ICharacterClass
    {
        private void Awake()
        {
            base.SetMaximumHealth(inspectorHealth);
            base.SetMaximumMana(inspectorMana);
            base.SetMaximumStamina(inspectorStamina);
            base.SetAttackRange(inspectorAttackRange);
            base.SetHealthRegeneration(inspectorHealthRegeneration);
            base.SetManaRegeneration(inspectorManaRegeneration);
            base.SetBaseMovementSpeed(inspectorMovementSpeed);
            base.SetBasicStatistics();

            base.SetBasicStatistics();

            base.SetFirstDefaultAbility(new IceArmor());
            base.SetSecondDefaultAbility(new MagicMissile());
            base.SetFirstSpecialAbility(new LightingLeap());
            base.SetSecondSpecialAbility(new MagneticWave());
            base.SetThirdSpecialAbility(new Meteor());
        }

        public IAbilityImplementation GetAbilityImplementation()
        {
            return new MageAbilitiesLogic();
        }

        public new void SetCurrentHealth(float changedHealth)
        {
            base.SetCurrentHealth(changedHealth);
        }

        public new void SetCurrentMovementSpeed(float movementSpeed)
        {
            base.SetCurrentMovementSpeed(movementSpeed);
        }

        public new void SetCurrentStamina(float stamina)
        {
            base.SetCurrentStamina(stamina);
        }

        public new void SetCurrentMana(float mana)
        {
            base.SetCurrentMana(mana);
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

        public float GetCurrentHealth()
        {
            return CurrentHealth;
        }

        public float GetCurrentMana()
        {
            return CurrentMana;
        }

        public float GetCurrentStamina()
        {
            return CurrentStamina;
        }

        public float GetHealthRegeneration()
        {
            return HealthRegeneration;
        }

        public float GetManaRegeneration()
        {
            return ManaRegeneration;
        }

        public float GetStaminaRegeneration()
        {
            return StaminaRegeneration;
        }

        public float GetAttackRange()
        {
            return DefaultAttackRange;
        }

        public float GetCurrentMovementSpeed()
        {
            return CurrentMovementSpeed;
        }

        public float GetBaseMovementSpeed()
        {
            return BasicMovementSpeed;
        }

        public float GetMaximumHealth()
        {
            return MaximumHealth;
        }

        public float GetMaximumMana()
        {
            return MaximumMana;
        }

        public float GetMaximumStamina()
        {
            return MaximumStamina;
        }

        public Vector3 GetCurrentPossition()
        {
            return transform.position;
        }

        public void SetCurrentPossition(Vector3 possition)
        {
            transform.position = possition;
        }

        public new void ApplyConditionEffect(ICondition condition)
        {
            base.ApplyConditionEffect(condition);
        }

        public new void RemoveConditionEffect(ICondition condition)
        {
            base.RemoveConditionEffect(condition);
        }

        public new void RemoveLastConditionEffect()
        {
            base.RemoveLastConditionEffect();
        }

        public new bool CheckIfContainsCondition(ICondition condition)
        {
            return base.CheckIfContainsCondition(condition);
        }
    }
}
