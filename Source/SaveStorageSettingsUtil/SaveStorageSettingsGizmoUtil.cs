using System;
using System.Collections.Generic;
using System.Reflection;
using Verse;

namespace SaveStorageSettingsUtil
{
    // Token: 0x02000002 RID: 2
    public static class SaveStorageSettingsGizmoUtil
    {
        // Token: 0x04000001 RID: 1
        private static Assembly saveStateAssembly;

        // Token: 0x04000002 RID: 2
        private static bool initialized;

        // Token: 0x17000001 RID: 1
        // (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        private static bool Exists
        {
            get
            {
                if (initialized)
                {
                    return saveStateAssembly != null;
                }

                foreach (var modContentPack in LoadedModManager.RunningMods)
                {
                    foreach (var assembly in modContentPack.assemblies.loadedAssemblies)
                    {
                        if (!assembly.GetName().Name.Equals("SaveStorageSettings") ||
                            assembly.GetType("SaveStorageSettings.GizmoUtil") == null)
                        {
                            continue;
                        }

                        initialized = true;
                        saveStateAssembly = assembly;
                        break;
                    }

                    if (initialized)
                    {
                        break;
                    }
                }

                initialized = true;

                return saveStateAssembly != null;
            }
        }

        // Token: 0x06000002 RID: 2 RVA: 0x00002128 File Offset: 0x00000328
        public static IEnumerable<Gizmo> AddSaveLoadGizmos(IEnumerable<Gizmo> gizmos, SaveTypeEnum saveTypeEnum,
            ThingFilter thingFilter, int groupKey = 987767552)
        {
            return AddSaveLoadGizmos(gizmos, saveTypeEnum.ToString(), thingFilter);
        }

        // Token: 0x06000003 RID: 3 RVA: 0x00002143 File Offset: 0x00000343
        public static List<Gizmo> AddSaveLoadGizmos(List<Gizmo> gizmos, SaveTypeEnum saveTypeEnum,
            ThingFilter thingFilter, int groupKey = 987767552)
        {
            return AddSaveLoadGizmos(gizmos, saveTypeEnum.ToString(), thingFilter);
        }

        // Token: 0x06000004 RID: 4 RVA: 0x00002160 File Offset: 0x00000360
        public static IEnumerable<Gizmo> AddSaveLoadGizmos(IEnumerable<Gizmo> gizmos, string storageTypeName,
            ThingFilter thingFilter, int groupKey = 987767552)
        {
            var gizmos2 = gizmos != null ? new List<Gizmo>(gizmos) : new List<Gizmo>(2);

            return AddSaveLoadGizmos(gizmos2, storageTypeName, thingFilter);
        }

        // Token: 0x06000005 RID: 5 RVA: 0x00002190 File Offset: 0x00000390
        private static List<Gizmo> AddSaveLoadGizmos(List<Gizmo> gizmos, string storageTypeName,
            ThingFilter thingFilter,
            int groupKey = 987767552)
        {
            try
            {
                if (Exists)
                {
                    saveStateAssembly.GetType("SaveStorageSettings.GizmoUtil")
                        .GetMethod("AddSaveLoadGizmos", BindingFlags.Static | BindingFlags.Public)
                        ?.Invoke(null,
                            new object[]
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
                Log.Warning(string.Concat(ex.GetType().Name, " ", ex.Message, "\n", ex.StackTrace));
            }

            return gizmos;
        }
    }
}