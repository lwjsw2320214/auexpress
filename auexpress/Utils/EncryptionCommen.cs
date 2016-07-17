using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace auexpress.Utils
{
    public static class EncryptionCommen
    {
        /// <summary>
        /// 加密Key
        /// </summary>
        private static readonly string Default_Key = "A3F/DEI69+WCJS+JEOT/+5DYQW/68H1Y";

        private static readonly string Default_IV = "qwDX+Y/aPLw=";


        /// <summary>
        /// desc 加密运算
        /// </summary>
        /// <param name="value">加密的值</param>
        /// <returns></returns>
        public static string getEncryptString(string value) {

            using (SymmetricAlgorithm desCSP = new TripleDESCryptoServiceProvider())
            {
                desCSP.Key = Convert.FromBase64String(Default_Key);
                desCSP.IV = Convert.FromBase64String(Default_IV);    //指定加密的运算模式 
                desCSP.Mode = System.Security.Cryptography.CipherMode.ECB;    //获取或设置加密算法的填充模式 
                desCSP.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
                ICryptoTransform ctTrans = desCSP.CreateEncryptor(desCSP.Key, desCSP.IV);
                byte[] bytes = Encoding.UTF8.GetBytes(value);
                using (MemoryStream memStream = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(memStream, ctTrans, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(bytes, 0, bytes.Length);
                        csEncrypt.FlushFinalBlock();
                        csEncrypt.Close();
                    }
                    bytes = null; //清理内存
                    return Convert.ToBase64String(memStream.ToArray());
                }
            }

        }

    }
}
