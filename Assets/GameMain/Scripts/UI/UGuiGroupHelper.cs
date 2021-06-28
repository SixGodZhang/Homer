using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace Homer
{
    public class UGuiGroupHelper : UIGroupHelperBase
    {
        public const int DepthFactor = 10000;

        private int m_Depth = 0;
        private Canvas m_CachedCavas = null;

        /// <summary>
        /// 设置界面组的深度
        /// </summary>
        /// <param name="depth"></param>
        public override void SetDepth(int depth)
        {
            m_Depth = depth;
            m_CachedCavas.overrideSorting = true;
            m_CachedCavas.sortingOrder = DepthFactor * depth;
        }

        private void Awake()
        {
            m_CachedCavas = gameObject.GetOrAddComponent<Canvas>();
            gameObject.GetOrAddComponent<GraphicRaycaster>();
        }

        private void Start()
        {
            m_CachedCavas.overrideSorting = true;
            m_CachedCavas.sortingOrder = DepthFactor * m_Depth;

            RectTransform transform = GetComponent<RectTransform>();
            transform.anchorMin = Vector2.zero;
            transform.anchorMax = Vector2.one;
            transform.anchoredPosition = Vector2.zero;
            transform.sizeDelta = Vector2.zero;
        }
    }
}
