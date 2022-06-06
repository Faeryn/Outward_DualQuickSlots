using System.Collections.Generic;
using DualQuickSlots.Extensions;
using SideLoader.SaveData;

namespace DualQuickSlots {
	public class DualQuickSlotsSaveExtension : PlayerSaveExtension {

		public List<(int slotID, string itemUID)> offHandItems = new List<(int, string)>();
		
		public override void Save(Character character, bool isWorldHost) {
			offHandItems.Clear();
			foreach (QuickSlot quickSlot in character.QuickSlotMngr.m_quickSlots) {
				if (quickSlot.TryGetOffHandItem(out Item offHandItem)) {
					offHandItems.Add((quickSlot.Index, offHandItem.UID));
				}
			}
		}
		
		public override void ApplyLoadedSave(Character character, bool isWorldHost) {
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