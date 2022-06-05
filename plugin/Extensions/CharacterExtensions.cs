using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DualQuickSlots.Extensions {
	public static class CharacterExtensions {

		private static ConditionalWeakTable<Character, Queue<Item>> QueuedItems = new ConditionalWeakTable<Character, Queue<Item>>();

		public static void EnqueueItemUse(this Character character, Item item) {
			if (!QueuedItems.TryGetValue(character, out Queue<Item> queue)) {
				queue = new Queue<Item>();
				QueuedItems.Add(character, queue);
			}
			
			queue.Enqueue(item);
		}
		
		public static Item GetNextQueuedItem(this Character character) {
			if (!QueuedItems.TryGetValue(character, out Queue<Item> queue)) {
				return null;
			}

			Item nextItem = null;
			while (queue.Count > 0 && !nextItem) {
				nextItem = queue.Dequeue(); // Find the next item
			}
			
			if (queue.Count == 0) {
				QueuedItems.Remove(character);
			}

			return nextItem;
		}
	}
}