using GameFramework.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityGameFramework.Runtime;

namespace Homer
{
    
    public static class LanguageUtility
    {
        /// <summary>
        /// 设置游戏的语言
        /// </summary>
        /// <param name="lang"></param>
        public static void SetGameLanguage(Language lang)
        {
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

            // 语言强制切换成要设置的语言
            if (language != lang)
            {
                language = lang;
            }

            // 若是暂不支持的语言， 则使用英语
            if (language != Language.English
                && language != Language.ChineseSimplified
                && language != Language.ChineseTraditional
                )
            {
                language = Language.English;
            }

            GameEntry.Setting.SetString(Constant.Setting.Language, language.ToString());
            GameEntry.Setting.Save();

            GameEntry.Localization.Language = language;
            Log.Info("update language settings complete, current language id {0}", language.ToString());
        }

        /// <summary>
        /// 加载本地化对应的字典
        /// </summary>
        /// <param name="dictionaryName"></param>
        public static void LoadLanguageDictionary(string dictionaryName)
        {
            string dictinaryAssetName = AssetUtility.GetDictionaryAsset(dictionaryName, false);
            // "Assets/GameMain/Localization/ChineseSimplified/Dictionaries/Default.xml"
            GameEntry.Localization.ReadData(dictinaryAssetName, null);
        }
    }
}
