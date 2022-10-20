using System.Collections.Generic;
using RimWorld;
using SaveStorageSettingsUtil;
using Verse;

namespace DisplayCases;

public class Building_Display_Case : Building_Storage
{
    public override IEnumerable<Gizmo> GetGizmos()
    {
        var gizmos = base.GetGizmos();
        return SaveStorageSettingsGizmoUtil.AddSaveLoadGizmos(gizmos, "DisplayCases", settings.filter);
    }
}