using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;

namespace Homer
{
    public class ProcedureSelectServer : ProcedureBase
    {
        public override bool UseNativeDialog => false;

        private SelectServerForm m_SelectServerForm = null;
        private bool m_EnsureSelectServer = false;

        public void EnsureSelectServer()
        {
            m_EnsureSelectServer = true;
        }

        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);

            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

            m_EnsureSelectServer = false;
            GameEntry.UI.OpenUIForm(UIFormId.SelectServer, this);
        }

        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            m_SelectServerForm = (SelectServerForm)ne.UIForm.Logic;
        }

        protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
            if (m_SelectServerForm != null)
            {
                m_SelectServerForm.Close(isShutdown);
                m_SelectServerForm = null;
            }
        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if(m_EnsureSelectServer)
            {
                // 选择服务器之后, 切換到主场景
                procedureOwner.SetData<VarInt32>("NextSceneId", GameEntry.Config.GetInt("Scene.MainCity"));
                ChangeState<ProcedureChangeScene>(procedureOwner);
            }
        }
    }
}
