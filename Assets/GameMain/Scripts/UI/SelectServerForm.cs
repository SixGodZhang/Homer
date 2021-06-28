
using GameFramework.DataTable;
using GameFramework.Localization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace Homer
{
    // 这里有个规则
    // 服务器 和 语言 对应关系为 多对多
    public class SelectServerForm:UGuiForm
    {
        [SerializeField]
        private Button m_LoginButton = null;

        [SerializeField]
        private Button m_AButton = null;

        [SerializeField]
        private Button m_DButton = null;

        [SerializeField]
        private Text m_CurServerName = null;

        [SerializeField]
        private Text m_StartGame = null;

        private ProcedureSelectServer m_ProcedureSelectServer = null;
        /// <summary>
        /// 服务器数据表
        /// </summary>
        private Dictionary<int, DRServerList> drServerDictionary = null;
        /// <summary>
        /// 当前服务器编号. 1默认为中国
        /// </summary>
        private int CurServerId = 0;
        

        #region 界面公共接口
        /// <summary>
        /// 点击开始游戏
        /// </summary>
        public void OnStartButtonClick()
        {
            m_ProcedureSelectServer.EnsureSelectServer();
        }

        /// <summary>
        /// 选择服务器
        /// </summary>
        public void OnSelectServerButtonClick(int addon)
        {
            CurServerId = Mathf.Min(Mathf.Max(1, CurServerId + addon), drServerDictionary.Values.Last().Id);
            // 处理语言
            SetLanguageBySelectServer(CurServerId);
            // 加载默认的字典
            LanguageUtility.LoadLanguageDictionary("Default");
            StartCoroutine(UpdateForm());
        }

        /// <summary>
        /// 更新界面
        /// </summary>
        /// <returns></returns>
        private IEnumerator UpdateForm()
        {
            yield return new WaitForEndOfFrame();

            // 处理界面
            m_CurServerName.text = GameEntry.Localization.GetString("Server.Name");
            m_StartGame.text = GameEntry.Localization.GetString("Game.Start");
            m_DButton.interactable = m_DButton.enabled = CurServerId != drServerDictionary.Values.Last().Id;
            m_AButton.interactable = m_AButton.enabled = CurServerId != drServerDictionary.Values.First().Id;
        }

        #endregion

        private void SetLanguageBySelectServer(int serverID)
        {
            DRServerList curSelectServer = null;
            drServerDictionary.TryGetValue(serverID, out curSelectServer);
            if (curSelectServer == null)
            {
                Log.Error("cur selected is not exist!");
                return;
            }

            Language curSelectedLanguage = Language.English;
            bool isSuccess = Enum.TryParse<Language>(curSelectServer.ServerLanguage, out curSelectedLanguage);
            if (!isSuccess)
            {
                Log.Error("Not Found Language:{0}", curSelectedLanguage);
                return;
            }

            LanguageUtility.SetGameLanguage(curSelectedLanguage);
        }

#if UNITY_2017_3_OR_NEWER
        protected override void OnInit(object userData)
#else
        protected internal override void OnInit(object userData)
#endif
        {
            base.OnInit(userData);
            OnInitServerList();
            OnSelectServerButtonClick(1);
        }

        /// <summary>
        /// 初始化服务器列表
        /// </summary>
        private void OnInitServerList()
        {
            IDataTable<DRServerList> dtServerList = GameEntry.DataTable.GetDataTable<DRServerList>();
            DRServerList[] drServerList = dtServerList.GetAllDataRows();
            if (drServerList.Length == 0)
            {
                Log.Warning("Can not load serverlist!");
                return;
            }

            // 转为字典
            drServerDictionary = dtServerList.ToDictionary(row => row.Id, row => row);
        }

#if UNITY_2017_3_OR_NEWER
        protected override void OnOpen(object userData)
#else
        protected internal override void OnOpen(object userData)
#endif
        {
            base.OnOpen(userData);
            m_ProcedureSelectServer = (ProcedureSelectServer)userData;
            if(m_ProcedureSelectServer == null)
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
