using System;
using System.Collections.Generic;
using RimWorld;
using SaveStorageSettingsUtil;
using Verse;

namespace DisplayCases
{
	// Token: 0x02000004 RID: 4
	public class Building_Display_Case : Building_Storage, IStoreSettingsParent
	{
		// Token: 0x06000007 RID: 7 RVA: 0x0000219C File Offset: 0x0000039C
		public override IEnumerable<Gizmo> GetGizmos()
		{
			IEnumerable<Gizmo> gizmos = base.GetGizmos();
			return SaveStorageSettingsGizmoUtil.AddSaveLoadGizmos(gizmos, "DisplayCases", this.settings.filter, 987767552);
		}
	}
}
