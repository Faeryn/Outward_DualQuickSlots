using UnityEngine;

namespace DualQuickSlots.Extensions {
	public static class QuickSlotPanelExtensions {
		
		public static QuickSlotDisplay AddNewQuickSlotDisplay(this QuickSlotPanel quickSlotPanel, int refSlotID) {
			if (EditorQuickSlotDisplayPlacer.m_quickSlotPrefab == null) {
				EditorQuickSlotDisplayPlacer.m_quickSlotPrefab = Resources.Load<QuickSlotDisplay>(EditorQuickSlotDisplayPlacer.PATH_TO_PREFAB);
			}
			QuickSlotDisplay quickSlotDisplay = Object.Instantiate<QuickSlotDisplay>(EditorQuickSlotDisplayPlacer.m_quickSlotPrefab, quickSlotPanel.transform);
			quickSlotDisplay.transform.ResetRectTrans();
			quickSlotDisplay.RefSlotID = refSlotID;
			quickSlotPanel.InitializeQuickSlotDisplays();
			return quickSlotDisplay;
		}
		
		public static void RemoveQuickSlot(this QuickSlotPanel quickSlotPanel, int refSlotID) {
			foreach (QuickSlotDisplay quickSlotDisplay in quickSlotPanel.m_quickSlotDisplays) {
				if (quickSlotDisplay.RefSlotID == refSlotID) {}
			}
		}
		
	}
}