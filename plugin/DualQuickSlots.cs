using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using SideLoader;

namespace DualQuickSlots {
	[BepInDependency(SL.GUID, BepInDependency.DependencyFlags.HardDependency)]
	[BepInPlugin(GUID, NAME, VERSION)]
	public class DualQuickSlots : BaseUnityPlugin {
		public const string GUID = "faeryn.dualquickslots";
		public const string NAME = "DualQuickSlots";
		public const string VERSION = "0.5.0";
		internal static ManualLogSource Log;

		internal void Awake() {
			Log = this.Logger;
			Log.LogMessage($"Starting {NAME} {VERSION}");
			new Harmony(GUID).PatchAll();
		}
	}
}