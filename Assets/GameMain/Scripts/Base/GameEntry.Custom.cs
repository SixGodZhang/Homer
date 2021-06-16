using UnityEngine;

namespace Homer
{
    public partial class GameEntry:MonoBehaviour
    {
		public static BuiltinDataComponent BuiltinData { get; private set; }

		private static void InitCustomComponents()
        {
            BuiltinData = UnityGameFramework.Runtime.GameEntry.GetComponent<BuiltinDataComponent>();
        }
    }
}
