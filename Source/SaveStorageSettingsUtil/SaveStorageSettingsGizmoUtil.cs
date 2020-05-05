using System;
using System.Collections.Generic;
using System.Reflection;
using Verse;

namespace SaveStorageSettingsUtil
{
	// Token: 0x02000002 RID: 2
	public static class SaveStorageSettingsGizmoUtil
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static bool Exists
		{
			get
			{
				if (!SaveStorageSettingsGizmoUtil.initialized)
				{
					foreach (ModContentPack modContentPack in LoadedModManager.RunningMods)
					{
						foreach (Assembly assembly in modContentPack.assemblies.loadedAssemblies)
						{
							if (assembly.GetName().Name.Equals("SaveStorageSettings") && assembly.GetType("SaveStorageSettings.GizmoUtil") != null)
							{
								SaveStorageSettingsGizmoUtil.initialized = true;
								SaveStorageSettingsGizmoUtil.saveStateAssembly = assembly;
								break;
							}
						}
						if (SaveStorageSettingsGizmoUtil.initialized)
						{
							break;
						}
					}
					SaveStorageSettingsGizmoUtil.initialized = true;
				}
				return SaveStorageSettingsGizmoUtil.saveStateAssembly != null;
			}
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002128 File Offset: 0x00000328
		public static IEnumerable<Gizmo> AddSaveLoadGizmos(IEnumerable<Gizmo> gizmos, SaveTypeEnum saveTypeEnum, ThingFilter thingFilter, int groupKey = 987767552)
		{
			return SaveStorageSettingsGizmoUtil.AddSaveLoadGizmos(gizmos, saveTypeEnum.ToString(), thingFilter, 987767552);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002143 File Offset: 0x00000343
		public static List<Gizmo> AddSaveLoadGizmos(List<Gizmo> gizmos, SaveTypeEnum saveTypeEnum, ThingFilter thingFilter, int groupKey = 987767552)
		{
			return SaveStorageSettingsGizmoUtil.AddSaveLoadGizmos(gizmos, saveTypeEnum.ToString(), thingFilter, 987767552);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002160 File Offset: 0x00000360
		public static IEnumerable<Gizmo> AddSaveLoadGizmos(IEnumerable<Gizmo> gizmos, string storageTypeName, ThingFilter thingFilter, int groupKey = 987767552)
		{
			List<Gizmo> gizmos2;
			if (gizmos != null)
			{
				gizmos2 = new List<Gizmo>(gizmos);
			}
			else
			{
				gizmos2 = new List<Gizmo>(2);
			}
			return SaveStorageSettingsGizmoUtil.AddSaveLoadGizmos(gizmos2, storageTypeName, thingFilter, 987767552);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002190 File Offset: 0x00000390
		public static List<Gizmo> AddSaveLoadGizmos(List<Gizmo> gizmos, string storageTypeName, ThingFilter thingFilter, int groupKey = 987767552)
		{
			try
			{
				if (SaveStorageSettingsGizmoUtil.Exists)
				{
					SaveStorageSettingsGizmoUtil.saveStateAssembly.GetType("SaveStorageSettings.GizmoUtil").GetMethod("AddSaveLoadGizmos", BindingFlags.Static | BindingFlags.Public).Invoke(null, new object[]
					{
						gizmos,
						storageTypeName,
						thingFilter,
						groupKey
					});
				}
			}
			catch (Exception ex)
			{
				Log.Warning(string.Concat(new string[]
				{
					ex.GetType().Name,
					" ",
					ex.Message,
					"\n",
					ex.StackTrace
				}));
			}
			return gizmos;
		}

		// Token: 0x04000001 RID: 1
		private static Assembly saveStateAssembly;

		// Token: 0x04000002 RID: 2
		private static bool initialized;
	}
}
