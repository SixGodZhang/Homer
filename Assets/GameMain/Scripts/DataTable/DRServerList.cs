using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityGameFramework.Runtime;

namespace Homer
{
    public class DRServerList:DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 服务器Id
        /// </summary>
        public override int Id => m_Id;

        /// <summary>
        /// 服务器名字
        /// </summary>
        public string ServerName { get; private set; }

        /// <summary>
        /// 服务器语言
        /// </summary>
        public string ServerLanguage { get; private set; }

        public override bool ParseDataRow(string dataRowString, object userData)
        {
            string[] columnStrings = dataRowString.Split(DataTableExtension.DataSplitSeparators);
            for (int i = 0; i < columnStrings.Length; i++)
            {
                columnStrings[i] = columnStrings[i].Trim(DataTableExtension.DataTrimSeparators);
            }

            int index = 0;
            index++;
            m_Id = int.Parse(columnStrings[index++]);
            index++;
            ServerName = columnStrings[index++];
            ServerLanguage = columnStrings[index++];
            GeneratePropertyArray();
            return true;
        }

        public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
        {
            using (MemoryStream memoryStream = new MemoryStream(dataRowBytes, startIndex, length, false))
            {
                using (BinaryReader binaryReader = new BinaryReader(memoryStream, Encoding.UTF8))
                {
                    m_Id = binaryReader.Read7BitEncodedInt32();
                    ServerName = binaryReader.ReadString();
                    ServerLanguage = binaryReader.ReadString();
                }
            }

            GeneratePropertyArray();
            return true;
        }

        private void GeneratePropertyArray()
        {
            
        }
    }
}
