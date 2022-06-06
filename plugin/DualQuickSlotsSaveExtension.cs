using System.Collections.Generic;
using DualQuickSlots.Extensions;
using SideLoader.SaveData;

namespace DualQuickSlots {
	public class DualQuickSlotsSaveExtension : PlayerSaveExtension {

		public List<(int slotID, string itemUID)> offHandItems = new List<(int, string)>();
		
		public override void Save(Character character, bool isWorldHost) {
			DualQuickSlots.Log.LogInfo("Saving quickslots");
			offHandItems.Clear();
			foreach (QuickSlot quickSlot in character.QuickSlotMngr.m_quickSlots) {
				if (quickSlot.TryGetOffHandItem(out Item offHandItem)) {
					DualQuickSlots.Log.LogInfo("Saving="+(quickSlot.Index, offHandItem.UID));
					offHandItems.Add((quickSlot.Index, offHandItem.UID));
				}
			}
		}
		
		public override void ApplyLoadedSave(Character character, bool isWorldHost) {
			DualQuickSlots.Log.LogInfo("ApplyLoadedSave quickslots");
			CharacterQuickSlotManager manager = character.QuickSlotMngr;
			foreach ((int slotID, string itemUID) slot in offHandItems) {
				DualQuickSlots.Log.LogInfo("slot="+slot);
				QuickSlot quickSlot = manager.GetQuickSlot(slot.slotID);
				if (quickSlot) {
					DualQuickSlots.Log.LogInfo("quickSlot found");
					quickSlot.SetOffHandItem(ItemManager.Instance.GetItem(slot.itemUID));
				}
			}
		}
	}
}