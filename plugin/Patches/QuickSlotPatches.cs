using DualQuickSlots.Extensions;
using HarmonyLib;

namespace DualQuickSlots.Patches {
	
	[HarmonyPatch(typeof(QuickSlot))]
	public static class QuickSlotPatches {

		[HarmonyPatch(nameof(QuickSlot.Activate)), HarmonyPostfix]
		public static void QuickSlot_Activate_Postfix(QuickSlot __instance) {
			if (!__instance.TryGetOffHandItem(out Item item)) {
				return;
			}

			if (__instance.ActiveItem.IsEquipped == item.IsEquipped) {
				item.EnqueueQuickSlotUse();
			}
		}

	}

}