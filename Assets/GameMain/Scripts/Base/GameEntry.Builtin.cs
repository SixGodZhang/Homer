using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Homer
{
    public partial class GameEntry : MonoBehaviour
    {
        /// <summary>
        /// 游戏基础组件
        /// </summary>
        public static BaseComponent Base { get; private set; }

        /// <summary>
        /// 配置组件
        /// </summary>
        public static ConfigComponent Config { get; private set; }

        /// <summary>
        /// 数据节点组件
        /// </summary>
        public static DataNodeComponent DataNode { get; private set; }

        /// <summary>
        /// 数据表节点组件
        /// </summary>
        public static DataTableComponent DataTable { get; private set; }

        /// <summary>
        /// 调试组件
        /// </summary>
        public static DebuggerComponent Debugger { get; private set; }

        /// <summary>
        /// 下载组件
        /// </summary>
        public static DownloadComponent Download { get; private set; }

        /// <summary>
        /// 实体组件
        /// </summary>
        public static EntityComponent Entity { get; private set; }

        /// <summary>
        /// 事件组件
        /// </summary>
        public static EventComponent Event { get; private set; }

		/// <summary>
        /// 文件系統組件
        /// </summary>
        public static FileSystemComponent FileSystem { get; private set; }

        /// <summary>
        /// 有限状态机组件
        /// </summary>
        public static FsmComponent Fsm { get; private set; }

        /// <summary>
        /// 本地化组件
        /// </summary>
        public static LocalizationComponent Localization { get; private set; }

        /// <summary>
        /// 网络组件
        /// </summary>
        public static NetworkComponent Network { get; private set; }

        /// <summary>
        /// 对象池组件
        /// </summary>
        public static ObjectPoolComponent ObjectPool { get; private set; }

        /// <summary>
        /// 流程组件
        /// </summary>
        public static ProcedureComponent Procedure { get; private set; }

        /// <summary>
        /// 资源组件
        /// </summary>
        public static ResourceComponent Resource { get; private set; }

		/// <summary>
        /// 场景组件
        /// </summary>
        public static SceneComponent Scene { get; private set; }

		/// <summary>
        /// 配置组件
        /// </summary>
		public static SettingComponent Setting { get; private set; }

		/// <summary>
        /// 声音组件
        /// </summary>
		public static SoundComponent Sound { get; private set; }

		/// <summary>
        /// UI组件
        /// </summary>
		public static UIComponent UI { get; private set; }

		/// <summary>
        /// 网络组件
        /// </summary>
		public static WebRequestComponent WebRequest { get; private set; }

        private static void InitBuiltinComponents()
        {
            Base = UnityGameFramework.Runtime.GameEntry.GetComponent<BaseComponent>();
            Config = UnityGameFramework.Runtime.GameEntry.GetComponent<ConfigComponent>();
            DataNode = UnityGameFramework.Runtime.GameEntry.GetComponent<DataNodeComponent>();
            DataTable = UnityGameFramework.Runtime.GameEntry.GetComponent<DataTableComponent>();
            Debugger = UnityGameFramework.Runtime.GameEntry.GetComponent<DebuggerComponent>();
            Download = UnityGameFramework.Runtime.GameEntry.GetComponent<DownloadComponent>();
            Entity = UnityGameFramework.Runtime.GameEntry.GetComponent<EntityComponent>();
            Event = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>();
            FileSystem = UnityGameFramework.Runtime.GameEntry.GetComponent<FileSystemComponent>();
            Fsm = UnityGameFramework.Runtime.GameEntry.GetComponent<FsmComponent>();
            Localization = UnityGameFramework.Runtime.GameEntry.GetComponent<LocalizationComponent>();
            Network = UnityGameFramework.Runtime.GameEntry.GetComponent<NetworkComponent>();
            ObjectPool = UnityGameFramework.Runtime.GameEntry.GetComponent<ObjectPoolComponent>();
            Procedure = UnityGameFramework.Runtime.GameEntry.GetComponent<ProcedureComponent>();
            Resource = UnityGameFramework.Runtime.GameEntry.GetComponent<ResourceComponent>();
            Setting = UnityGameFramework.Runtime.GameEntry.GetComponent<SettingComponent>();
            Scene = UnityGameFramework.Runtime.GameEntry.GetComponent<SceneComponent>();
            Sound = UnityGameFramework.Runtime.GameEntry.GetComponent<SoundComponent>();
            UI = UnityGameFramework.Runtime.GameEntry.GetComponent<UIComponent>();
            WebRequest = UnityGameFramework.Runtime.GameEntry.GetComponent<WebRequestComponent>();
        }
    }
}
