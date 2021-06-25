
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Homer
{
    public class SelectServerForm:UGuiForm
    {
        [SerializeField]
        private GameObject m_LoginButton = null;

        private ProcedureSelectServer m_ProcedureSelectServer = null;

#if UNITY_2017_3_OR_NEWER
        protected override void OnOpen(object userData)
#else
        protected internal override void OnOpen(object userData)
#endif
        {
            base.OnOpen(userData);
            m_ProcedureSelectServer = (ProcedureSelectServer)userData;
            if(m_ProcedureSelectServer!= null)
            {
                Log.Warning("ProcedureSelectServer is invalid when open SelectServerForm.");
                return;
            }
        }

#if UNITY_2017_3_OR_NEWER
        protected override void OnClose(bool isShutdown, object userData)
#else
        protected internal override void OnClose(bool isShutdown, object userData)
#endif
        {
            m_ProcedureSelectServer = null;
            base.OnClose(isShutdown, userData);
        }
    }
}
