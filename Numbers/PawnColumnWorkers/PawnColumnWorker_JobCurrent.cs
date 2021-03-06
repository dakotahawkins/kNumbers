﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using UnityEngine;
using Verse;

namespace Numbers
{
    public class PawnColumnWorker_JobCurrent : PawnColumnWorker_Text
    {
        protected override string GetTextFor(Pawn pawn)
        {
            if (!Numbers_Settings.showMoreInfoThanVanilla && !(pawn.Faction == Faction.OfPlayer || pawn.HostFaction == Faction.OfPlayer) && !pawn.InMentalState)
                return null;

            if (pawn.jobs.curDriver != null)
            {
                string text = pawn.jobs.curDriver.GetReport().CapitalizeFirst();
                GenText.SetTextSizeToFit(text, new Rect(0f, 0f, Mathf.CeilToInt(Text.CalcSize(this.def.LabelCap).x), base.GetMinCellHeight(pawn)));

                return text;
            }
            return null;
        }

        protected override string GetTip(Pawn pawn) => this.GetTextFor(pawn);

        public override int Compare(Pawn a, Pawn b) => (a.jobs?.curDriver.GetReport()[0] ?? 0).CompareTo(b.jobs?.curDriver.GetReport()[0] ?? 0);

        public override int GetMinWidth(PawnTable table) => Mathf.Max(base.GetMinWidth(table), 200);

        public override int GetMinHeaderHeight(PawnTable table) => Mathf.CeilToInt(Text.CalcSize(this.def.LabelCap.WordWrapAt(this.GetMinWidth(table))).y);
    }
}
