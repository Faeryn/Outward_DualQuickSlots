using DualQuickSlots.Extensions;
using HarmonyLib;

namespace DualQuickSlots.Patches {
	[HarmonyPatch(typeof(Character))]
	public static class CharacterPatches {
		
		[HarmonyPatch(nameof(Character.CastDone)), HarmonyPostfix]
		public static void Character_CastDone_Postfix(Character __instance) {
			Item nextItem = __instance.GetNextQueuedItem();
			if (nextItem) {
				nextItem.TryQuickSlotUse();
			}
		}
	}
}