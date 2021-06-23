using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homer
{
    public class ProcedurePreload:ProcedureBase
    {
        public override bool UseNativeDialog => true;

        /// <summary>
        /// 需要加载的表
        /// </summary>
        public static readonly string[] DataTableNames = new string[]
        {
            "Music",
            "Scene", 
            "Sound",
        };

        
    }
}
