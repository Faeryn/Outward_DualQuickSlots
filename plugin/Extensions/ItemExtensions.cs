namespace DualQuickSlots.Extensions {
	public static class ItemExtensions {
		
		private static Weapon.WeaponType[] OneHandedWeaponTypes = {
			Weapon.WeaponType.Sword_1H,
			Weapon.WeaponType.Axe_1H,
			Weapon.WeaponType.Mace_1H
		};
		
		public static bool IsOneHandedWeapon(this Item item) {
			Weapon weapon = item as Weapon;
			if (weapon == null) {
				return false;
			}
			return OneHandedWeaponTypes.Contains(weapon.Type);
		}
		
		public static bool IsRightHandEquipment(this Item item) {
			Equipment equipment = item as Equipment;
			if (equipment == null) {
				return false;
			}
			return equipment.EquipSlot == EquipmentSlot.EquipmentSlotIDs.RightHand;
		}
		
		public static bool IsLeftHandEquipment(this Item item) {
			Equipment equipment = item as Equipment;
			if (equipment == null) {
				return false;
			}
			return equipment.EquipSlot == EquipmentSlot.EquipmentSlotIDs.LeftHand;
		}

		public static void EnqueueQuickSlotUse(this Item item) {
			if (item.m_ownerCharacter && item.m_ownerCharacter.CurrentSpellCast!=Character.SpellCastType.NONE) {
				item.m_ownerCharacter.EnqueueItemUse(item);
			} else {
				item.QuickSlotUse();
			}
		}
	}
}