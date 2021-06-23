using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using GameFramework.Localization;
using System;

namespace Homer
{
    public class ProcedureLaunch : ProcedureBase
    {
        public override bool UseNativeDialog
        {
            get
            {
                return true;
            }
        }

        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);

            // 读取配置
            GameEntry.BuiltinData.InitBuildInfo();

            // 变体配置: 根据使用的语言, 通知底层加载对应的资源变体
            // InitCurrentVariant();

            // 声音配置：根据用户配置数据, 设置即将使用的声音选项
            InitSoundSettings();

            // 语言设置
            InitLanguageSettings();

            // 默认字典: 加载默认字典文件 Assets/GameMain/Configs/DefaultDictionary.xml
            // 此字典文件记录了资源更新前使用的各种语言的字符串
            GameEntry.BuiltinData.InitDefaultDictionary();

            // 加载指定数据表
            // test
            InitDataTables();
        }

        private void InitDataTables()
        {
            string[] DataTableNames = new string[]
            {
                "Music", // 音乐表
                //"Scene", // 场景表
            };

            
            foreach (string dataTableName in DataTableNames)
            {
                LoadDataTable(dataTableName);
            }

        }

        // test
        // 加载指定数据表
        public void LoadDataTable(string dataTableName)
        {
            string dataTableAssetName = AssetUtility.GetDataTableAsset(dataTableName, false);
            GameEntry.DataTable.LoadDataTable(dataTableName, dataTableAssetName, this);
        }

        private void InitSoundSettings()
        {
            // TODO
            //GameEntry.Sound.Mute("Music", GameEntry.Setting.GetBool(Constant.Setting.MusicMuted, false));
            GameEntry.Sound.SetVolume("Music", GameEntry.Setting.GetFloat(Constant.Setting.MusicVolume, 0.3f));
        }

        private void InitCurrentVariant()
        {
            if (GameEntry.Base.EditorResourceMode)
            {
                // 编辑器资源模式不使用 AssetBundle, 也就没有变体了
                return;
            }

            // TODO 资源模块可以先暂时不用做
            string currentVariant = null;
            switch(GameEntry.Localization.Language)
            {
                case Language.English:
                    currentVariant = "en-us";
                    break;
                case Language.ChineseSimplified:
                    currentVariant = "zh-cn";
                    break;
                case Language.ChineseTraditional:
                    currentVariant = "zh-tw";
                    break;
                case Language.Korean:
                    currentVariant = "ko-kr";
                    break;

                default:
                    currentVariant = "zh-cn";
                    break;
            }

            GameEntry.Resource.SetCurrentVariant(currentVariant);
            Log.Info("Init current variant complete.");
        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            // 运行一帧即切换到 Splash 展示流程
            // ChangeState<Produ>
            // GameEntry.Config.GetInt("Scene.Splash")
            // 0 表示 Splash.unity
            // 1 表示MainCity.unity
            procedureOwner.SetData<VarInt32>("NextSceneId", 1);
            ChangeState<ProcedureChangeScene>(procedureOwner);
        }

        private void InitLanguageSettings()
        {
            if (GameEntry.Base.EditorResourceMode && GameEntry.Base.EditorLanguage != Language.Unspecified)
            {
                // 编辑器资源模式 直接使用 Inspector 上设置的语言
                return;
            }

            Language language = GameEntry.Localization.Language;
            if (GameEntry.Setting.HasSetting(Constant.Setting.Language))
            {
                try
                {
                    string languageString = GameEntry.Setting.GetString(Constant.Setting.Language);
                    language = (Language)Enum.Parse(typeof(Language), languageString);
                }
                catch
                {

                }
            }

            if(language != Language.English 
                && language != Language.ChineseSimplified
                && language != Language.ChineseTraditional
                && language != Language.Korean)
            {
                // 若是暂不支持的语言， 则使用英语
                language = Language.English;
                GameEntry.Setting.SetString(Constant.Setting.Language, language.ToString());
                GameEntry.Setting.Save();
            }

            GameEntry.Localization.Language = language;
            Log.Info("Init language settings complete, current language id {0}", language.ToString());
        }
    }
}
