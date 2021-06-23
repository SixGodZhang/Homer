using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Homer
{
    public static class FindGameObjectUtility
    {
        /// <summary>
        /// 查找场景中指定的GameObject（包含未激活的GameObject）
        /// </summary>
        /// <param name="objName"></param>
        /// <returns></returns>
        public static GameObject FindGameObject(string objName)
        {
            GameObject retGameObject = null;
            var all = Resources.FindObjectsOfTypeAll<GameObject>();
            foreach (var item in all)
            {
                if (item.name == objName)
                {
                    retGameObject = item;
                }
            }

            return retGameObject;
        }
    }
}
