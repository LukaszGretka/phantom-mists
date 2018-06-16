﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Scripts.Abilities
{
    public interface IAbility
    {
        string Name { get;}

        float BaseDamage { get; }

        int ManaCost { get; }

        int StaminaCost { get; }

        float Cooldown { get; }

        float Range { get; }

        bool IsRanged { get; }
    }
}