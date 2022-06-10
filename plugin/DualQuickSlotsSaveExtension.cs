using System.Collections.Generic;
using DualQuickSlots.Extensions;
using SideLoader.SaveData;

namespace DualQuickSlots {
	public class DualQuickSlotsSaveExtension : PlayerSaveExtension {
		// TODO Remove on the next major version change

		public List<(int slotID, string itemUID)> offHandItems = new List<(int, string)>();
		
		public override void Save(Character character, bool isWorldHost) {
			// This is deprecated, we use QuickSlot.ToSaveData patch to save the offhand item
			offHandItems.Clear();
		}
		
		public override void ApplyLoadedSave(Character character, bool isWorldHost) {
			// This is here to migrate previous saves to the new save method
			CharacterQuickSlotManager manager = character.QuickSlotMngr;
			foreach ((int slotID, string itemUID) slot in offHandItems) {
				QuickSlot quickSlot = manager.GetQuickSlot(slot.slotID);
				if (quickSlot) {
					quickSlot.SetOffHandItem(ItemManager.Instance.GetItem(slot.itemUID));
				}
			}
		}
	}
}