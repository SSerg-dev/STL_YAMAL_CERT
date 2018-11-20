﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SmartQA.Util
{
    public class Encryptor3DES
    {
        private readonly byte[] key;
        TripleDESCryptoServiceProvider desProvider;

        public Encryptor3DES(byte[] key)
        {
            this.key = key;
            desProvider = new TripleDESCryptoServiceProvider();
            desProvider.Key = this.key;
            desProvider.Padding = PaddingMode.ISO10126;
            desProvider.Mode = CipherMode.ECB;
        }
        public byte[] encrypt(byte[] data)
        {
            ICryptoTransform cTrans = desProvider.CreateEncryptor();
            var result = cTrans.TransformFinalBlock(data, 0, data.Length);
            return result;
        }
        public byte[] decrypt(byte[] data)
        {
            ICryptoTransform cTrans = desProvider.CreateDecryptor();
            var result = cTrans.TransformFinalBlock(data, 0, data.Length);
            return result;
        }
    }
}
