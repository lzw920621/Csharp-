﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 文件锁的实现
{
    interface IDecrypter
    {
        void SingleDecrypt(string path);

        void MultiDecrypt(string path);
    }
}
