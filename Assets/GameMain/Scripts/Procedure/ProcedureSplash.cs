using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Homer
{
    public class ProcedureSplash:ProcedureBase
    {
        public override bool UseNativeDialog => true;

        private GameObject m_SplashCavas = null;

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            // 这里播放一个Splash 动画
            if (m_SplashCavas == null)
            {
                m_SplashCavas = FindGameObjectUtility.FindGameObject("Splash");
                if (m_SplashCavas != null)
                {
                    m_SplashCavas.SetActive(true);
                    return;
                }
            }

            // TODO 三种模式需要处理, 这里只处理了编辑器模式
            if (GameEntry.Base.EditorResourceMode && VideoPlay.isEndVideo)
            {
                // 编辑器模式
                Log.Info("Editor resource mode detected.");
                m_SplashCavas.SetActive(false);

                ChangeState<ProcedureSelectServer>(procedureOwner);
            }
        }
    }
}

/**
 * Splash动画制作过程:
 * Splash设置路径: Edit/Project Settings/Player/Splash Image/Splash Screen/Show Splash Screen - Unity Personal 无法禁用Unity的Splash
 * 此路径下的其它设置说明:
 * Splash Style : Unity 品牌的风格
 * Animation: 
 *      Static            不应用动画。
 *      Dolly            徽标和背景可以变焦以创建视觉推拉变焦效果。此为默认值。
 *      Custom        配置背景和徽标变焦以实现修改后的推拉变焦效果。
 * Logos: 设置Splash Sprite
 **/
