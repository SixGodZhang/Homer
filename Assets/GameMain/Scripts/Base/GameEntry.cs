using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Homer
{
    public partial class GameEntry : MonoBehaviour
    {
        void Start()
        {
            Log.Info("call GameEntry.Start()...");
            //Debug.Log("call GameEntry.Start()....");
            InitBuiltinComponents();
            InitCustomComponents();
        }
    }
}

