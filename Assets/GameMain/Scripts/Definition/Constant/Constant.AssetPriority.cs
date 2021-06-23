using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homer
{
    public static partial class Constant
    {
		/// <summary>
        /// 资源加载优先级
        /// </summary>
		public static class AssetPriority
        {
            /// <summary>
            /// 数据表
            /// </summary>
            public const int DataTableAsset = 100;
            /// <summary>
            /// 场景
            /// </summary>
            public const int SceneAsset = 0;
            /// <summary>
            /// mp3
            /// </summary>
            public const int MusicAsset = 20;
        }
    }
}
