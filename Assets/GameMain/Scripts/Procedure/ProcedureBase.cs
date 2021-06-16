using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homer
{
    public abstract class ProcedureBase:GameFramework.Procedure.ProcedureBase
    {
        // 获取流程是否使用原生对话框
        public abstract bool UseNativeDialog
        {
            get;
        }
    }
}
