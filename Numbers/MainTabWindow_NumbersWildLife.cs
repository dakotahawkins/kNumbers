﻿using System;
using System.Collections.Generic;
using System.Linq;
using Verse;
using RimWorld;

namespace Numbers
{
    public class MainTabWindow_NumbersWildLife : MainTabWindow_Numbers
    {
        public override void PostOpen()
        {
            pawnTableDef = NumbersDefOf.Numbers_WildAnimals;
            UpdateFilter();
            Notify_ResolutionChanged();
            base.PostOpen();
        }
    }
}