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

			if (item.OwnerCharacter != __instance.m_owner) {
				return;
			}
			
			if (__instance.ActiveItem.IsEquipped == item.IsEquipped) {
				item.EnqueueQuickSlotUse();
			}
		}

		[HarmonyPatch(nameof(QuickSlot.ToSaveData)), HarmonyPostfix]
		public static void QuickSlot_ToSaveData_Postfix(QuickSlot __instance, ref string __result) {
			if (!__instance.TryGetOffHandItem(out Item item)) {
				return;
			}
			__result = __result + item.UID + ";";
		}

		[HarmonyPatch(nameof(QuickSlot.LoadSaveData)), HarmonyPrefix]
		public static void QuickSlot_LoadSaveData_Prefix(QuickSlot __instance, string _saveData) {
			string[] saveData = _saveData.Split(';');
			if (saveData.Length < 5) {
				return;
			}
			string offHandItemUID = saveData[4];
			if (!string.IsNullOrEmpty(offHandItemUID)) {
				__instance.SetOffHandItem(ItemManager.Instance.GetItem(offHandItemUID));
			}
		}

	}

}