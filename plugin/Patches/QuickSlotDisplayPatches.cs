using DualQuickSlots.Extensions;
using HarmonyLib;
using UnityEngine;

namespace DualQuickSlots.Patches {
	[HarmonyPatch(typeof(QuickSlotDisplay))]
	public static class QuickSlotDisplayPatches {

		[HarmonyPatch(nameof(QuickSlotDisplay.Update)), HarmonyPrefix]
		public static void QuickSlotDisplay_Update_Prefix(QuickSlotDisplay __instance) {
			if (!__instance.m_characterUI.IsInputReady) {
				return;
			}

			if (__instance.m_refQuickSlot != null && __instance.RefSlotID % 2 == Time.frameCount % 2) {
				if (__instance.m_lastItem != __instance.m_refQuickSlot.ActiveItem || __instance.m_refreshRequired) {
					__instance.UpdateOffHandItemDisplay();
				}
			}
		}
	}
}