﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using UnityEngine;
using Verse;

namespace Numbers
{
    public class PawnColumnWorker_TameChance : PawnColumnWorker_Text
    {
        public override int Compare(Pawn a, Pawn b) => GetValue(a).CompareTo(GetValue(b));

        protected override string GetTextFor(Pawn pawn) => pawn.AnimalOrWildMan() ? GetValue(pawn).ToStringPercent() : string.Empty;

        private float GetValue(Pawn pawn) => pawn.AnimalOrWildMan() ? TameChanceFactorCurve_Wildness.Evaluate(pawn.RaceProps.wildness) : 0;

        //RimWorld.InteractionWorker_RecruitAttempt.TameChanceFactorCurve_Wildness is private, so I copy-pasted the simple thing.
        // Updaters beware: this is likely to be outdated. Verify.

#if DEBUG
        [Obsolete]
#endif
        private static readonly SimpleCurve TameChanceFactorCurve_Wildness = new SimpleCurve
        {
            new CurvePoint(1f, 0f),
            new CurvePoint(0.5f, 1f),
            new CurvePoint(0f, 2f),
        };
    }
}
