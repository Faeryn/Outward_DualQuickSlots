using DualQuickSlots.Extensions;
using HarmonyLib;

namespace DualQuickSlots.Patches {
	
	[HarmonyPatch(typeof(CharacterQuickSlotManager))]
	public class CharacterQuickSlotManagerPatches {
		[HarmonyPatch(nameof(CharacterQuickSlotManager.SetQuickSlot)), HarmonyPrefix]
		public static bool QuickSlot_SetQuickSlot_Prefix(CharacterQuickSlotManager __instance, int _index, Item _item, bool _forceQuickSlot) {
			QuickSlot quickSlot = __instance.GetQuickSlot(_index);
			if (quickSlot.CanHaveOffHandItem() && _item.IsLeftHandEquipment()) {
				quickSlot.SetOffHandItem(_item);
				return false;
			} else {
				quickSlot.RemoveOffHandItem();
				return true;
			}
		}

	}
}