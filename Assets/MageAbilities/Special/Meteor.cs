﻿
using Assets._Scripts.Characters.Abstract.Interfaces;
using Assets._Scripts.Conditions;
using System.Collections.Generic;

namespace Assets._Scripts.Abilities.Characters.MageAbilities.Special
{
    internal class Meteor : IAbility
    {
        public string Name { get; private set; } = "Meteor";

        public float BaseDamage { get; private set; } = 15f;

        public int ManaCost { get; private set; } = 10;

        public int StaminaCost { get; private set; } = 0;

        public float CooldownTime { get; private set; } = 45f;

        public float Range { get; private set; } = 6f;

        public bool IsRanged { get; private set; } = true;

        public float CastingTime { get; private set; } = 0.5f;

        public float HitAngle { get; } = default(float);

        public bool OnCooldown { get; } = default(bool);

        public List<KeyValuePair<IConditions, float>> Conditions { get; } = new List<KeyValuePair<IConditions, float>>()
                                                        {
                                                            new KeyValuePair<IConditions, float>(new Stun(), 5f)
                                                        };
    }
}