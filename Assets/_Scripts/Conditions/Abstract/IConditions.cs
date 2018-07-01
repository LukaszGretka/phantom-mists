﻿using Assets._Scripts.Conditions.Abstract;
using Assets._Scripts.Conditions.Enum;
using System;
using System.Collections;

namespace Assets._Scripts.Characters.Abstract.Interfaces
{
    public interface ICondition
    {
        string Name { get; }

        float DurationTime { get; }
        
        ConditionEffectType EffectType { get; }

        IConditionImplementation ConditionImplementation { get;}
    }
}
