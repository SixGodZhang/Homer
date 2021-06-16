using UnityEngine;
using System.Collections;
using UnityGameFramework.Runtime;
using GameFramework;

namespace Homer
{
    public class BuiltinDataComponent : GameFrameworkComponent
    {
        [SerializeField]
        private TextAsset m_BuildInfoTextAsset = null;

        private BuildInfo m_BuildInfo = null;
        public BuildInfo BuildInfo
        {
            get { return m_BuildInfo; }
        }

        public void InitBuildInfo()
        {
            if (m_BuildInfoTextAsset == null || string.IsNullOrEmpty(m_BuildInfoTextAsset.text))
            {
                Log.Error("Build info can not be found or empty.");
                return;
            }

            m_BuildInfo = Utility.Json.ToObject<BuildInfo>(m_BuildInfoTextAsset.text);
            if (m_BuildInfo == null)
            {
                Log.Error("Parse build info failure.");
                return;
            }

            // test
            Log.Info("Init Build Info success !");
        }
    }
}

