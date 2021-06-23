﻿using GameFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homer
{
    public static class AssetUtility
    {
        /// <summary>
        /// 获取场景资源
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetSceneAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/Scenes/{0}.unity", assetName);
        }

        /// <summary>
        /// 获取mp3资源
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetMusicAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/Music/{0}.mp3", assetName);
        }

        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="fromBytes"></param>
        /// <returns></returns>
        public static string GetDataTableAsset(string assetName, bool fromBytes)
        {
            return Utility.Text.Format("Assets/GameMain/DataTables/{0}.{1}", assetName, fromBytes ? "bytes" : "txt");
        }


    }
}
