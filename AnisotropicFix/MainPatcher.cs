using System;
using Harmony;
using UnityEngine;

namespace AnisotropicFix
{
	// Token: 0x02000002 RID: 2
	public class MainPatcher
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static void Patch()
		{
			try
			{
				MainPatcher.harmony = HarmonyInstance.Create("com.whotnt.subnautica.anisotropicfix.mod");
				MainPatcher.harmony.Patch(AccessTools.Method(typeof(MainCameraControl), "Awake", null, null), null, new HarmonyMethod(typeof(MainPatcher).GetMethod("MCC_Awake_Postfix")), null);
			}
			catch (Exception ex)
			{
				Debug.Log("Error with Anisotropic Fix patching: " + ex.Message);
			}
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020D4 File Offset: 0x000002D4
		public static void MCC_Awake_Postfix()
		{
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
		}

		// Token: 0x04000001 RID: 1
		private static HarmonyInstance harmony;
	}
}
