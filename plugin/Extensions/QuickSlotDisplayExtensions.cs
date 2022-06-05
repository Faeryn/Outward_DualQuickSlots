using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace DualQuickSlots.Extensions {
	public static class QuickSlotDisplayExtensions {
				
		private const float ItemDisplayScale = 0.5f;
		
		private static ConditionalWeakTable<QuickSlotDisplay, ItemDisplay> ItemDisplays = new ConditionalWeakTable<QuickSlotDisplay, ItemDisplay>();

		public static void UpdateOffHandItemDisplay(this QuickSlotDisplay quickSlot) {
			if (quickSlot.m_refQuickSlot.CanHaveOffHandItem()) {
				ItemDisplay itemDisplay = quickSlot.ShowOffHandItemDisplay();
				if (quickSlot.m_refQuickSlot.TryGetOffHandItem(out Item item)) {
					itemDisplay.SetReferencedItem(item);
				}
			} else {
				quickSlot.HideOffHandItemDisplay();
			}
		}
		
		public static void HideOffHandItemDisplay(this QuickSlotDisplay quickSlot) {
			if (ItemDisplays.TryGetValue(quickSlot, out ItemDisplay itemDisplay)) {
				itemDisplay.Hide();
			}
		}

		public static ItemDisplay ShowOffHandItemDisplay(this QuickSlotDisplay quickSlot) {
			if (ItemDisplays.TryGetValue(quickSlot, out ItemDisplay itemDisplay)) {
				itemDisplay.Show();
				return itemDisplay;
			}
			itemDisplay = Object.Instantiate(UIUtilities.ItemDisplayPrefab, quickSlot.transform);
			Object.Destroy(itemDisplay.GetComponent<ItemDisplayClick>());
			Object.Destroy(itemDisplay.GetComponent<ItemDisplayDrag>());
			Object.Destroy(itemDisplay.GetComponent<UISelectable>());
			Object.Destroy(itemDisplay.GetComponent<Button>());
			itemDisplay.m_sldDurability.gameObject.SetActive(true);
			Transform displayTransform = itemDisplay.transform;
			displayTransform.ResetLocal();
			displayTransform.localScale = new Vector3(ItemDisplayScale, ItemDisplayScale, ItemDisplayScale);
			Vector2 offsetMax = quickSlot.RectTransform.rect.max;
			displayTransform.localPosition = new Vector3(0, offsetMax.y + (itemDisplay.RectTransform.rect.height/2f) + (quickSlot.m_lblKeyboardInput ? quickSlot.m_lblKeyboardInput.preferredHeight + 5f : 5f), 0);
			itemDisplay.Clear();
			itemDisplay.Show();
			ItemDisplays.Add(quickSlot, itemDisplay);
			return itemDisplay;
		}
	}
}