using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLUploader
{
    class GLEntry
    {
        private int GLCode;
        private string GLName;
        private int GLOrder;

        public GLEntry(string line)
        {
            string[] lineArr = line.Split(',');
            
            GLCode = int.Parse(lineArr[0]);
            GLName = lineArr[1];
            GLOrder = int.Parse(lineArr[2]);
        }       

        public string GetGLName()
        {
            return GLName;
        }

        public int GetGLCode()
        {
            return GLCode;
        }

        public int GetGLOrder()
        {
            return GLOrder;
        }


    }
}
