using UnityEngine;
using System.Collections;

namespace Homer
{
    public class BuildInfo
    {
        /// <summary>
        /// 游戏版本
        /// </summary>
        public string GameVersion { get; set; }
        /// <summary>
        /// 内服版本
        /// </summary>
        public int InternalGameVersion { get; set; }
        /// <summary>
        /// 检测版本URL
        /// </summary>
        public string CheckVersionUrl { get; set; }
    }
}

