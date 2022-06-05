using System.Runtime.CompilerServices;

namespace DualQuickSlots.Extensions {
	public static class QuickSlotExtensions {
		
		private static ConditionalWeakTable<QuickSlot, Item> OffHandItems = new ConditionalWeakTable<QuickSlot, Item>();

		public static bool TryGetOffHandItem(this QuickSlot quickSlot, out Item offHandItem) {
			return OffHandItems.TryGetValue(quickSlot, out offHandItem);
		}

		public static bool CanHaveOffHandItem(this QuickSlot quickSlot) {
			Item itemInSlot = quickSlot.ActiveItem;
			return itemInSlot!=null && itemInSlot.IsOneHandedWeapon();
		}
		
		public static void SetOffHandItem(this QuickSlot quickSlot, Item offHandItem) {
			OffHandItems.Remove(quickSlot);
			OffHandItems.Add(quickSlot, offHandItem);
		}

		public static void RemoveOffHandItem(this QuickSlot quickSlot) {
			OffHandItems.Remove(quickSlot);
		}
	}
}