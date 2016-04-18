using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qaacGUI.cmdCodeGenerator
{
    class cmdCode
    {    
        private string filePath;
        private string profile;
        private string type;
        private string outputPath;
        private int kbps;
        private int qp;
        private bool isAutoALAC;

        // 采取默认参数 -V 91
        public cmdCode(string fp)
        {
            this.filePath = fp;           
        }
        
        // 完整的构造函数，备用
        public cmdCode(string fp, string profile, string type, int q, bool isAuto, string outputPath)
        {
            this.filePath = fp;
            this.type = type;
            if (string.Equals(type, "TVBR") == true)
            {
                this.qp = q;
            } else
            {
                this.kbps = q;
            }      
            this.isAutoALAC = isAuto;
            this.outputPath = outputPath;
        }

        // 读取文件名和先前构造好的参数对象(Job类调用)
        public cmdCode(string fp, cmdCode code)
        {
            this.filePath = fp;
            this.profile = code.profile;
            this.type = code.type;
            this.kbps = code.kbps;
            this.qp = code.qp;
            this.isAutoALAC = code.isAutoALAC;
            this.outputPath = code.outputPath;
        }
        
        // 仅读取参数，用于从GUI读取参数后存放(UI控制器调用)
        public cmdCode(string profile, string type, int q, bool isAuto, string outputPath)
        {
            this.profile = profile;
            this.type = type;
            if (string.Equals(type, "TVBR") == true)
            {
                this.qp = q;
            }
            else
            {
                this.kbps = q;
            }
            this.isAutoALAC = isAuto;
            this.outputPath = outputPath;
        }

        public void setFilePath(string fp)
        {
            this.filePath = fp;
        }

        public string cmdCodeGenerate()
        {
            string qaacPath = System.Windows.Forms.Application.StartupPath + "\\tools\\qaac\\qaac.exe";
            string ffmpegPath = System.Windows.Forms.Application.StartupPath + "\\tools\\ffmpeg\\ffmpeg.exe";

            string fp = this.filePath;
            
            //string code = "D:\\Coding\\Windows\\qaac_2.55\\x86\\qaac.exe " + "\"" + fp + "\"";  // 文件路径加上引号防止文件名中的空格影响运行

            
            string[] s = fp.Split(new char[] { '.' });
            string ext = s[s.Length - 1];

            string[] t = fp.Split(new char[] { '\\' });
            string fileName = t[t.Length - 1];

            string code = "\"" + ffmpegPath + "\"" + " -i " + "\"" + fp + "\"" + " -vn -sn -v 0 -c:a pcm_s16le -f wav pipe:|" + "\"" + qaacPath + "\"" + " - --ignorelength";
            
            if (this.isAutoALAC == true && this.losslessCheckByExtension(ext))
            {
                code += " -A";
            } else
            {
                if (string.Equals(this.profile, "HE-AAC"))
                {
                    code += " --he";
                }
                
                if (string.Equals(this.type, "TVBR"))
                {
                    code += " -V " + this.qp.ToString();
                }
                else if (string.Equals(this.type, "CVBR"))
                {
                    code += " -v " + this.kbps.ToString();
                }
                else if (string.Equals(this.type, "ABR"))
                {
                    code += " -a " + this.kbps.ToString();
                }
                else if (string.Equals(this.type, "CBR"))
                {
                    code += " -c " + this.kbps.ToString();
                }    
            }
            
            if (!String.IsNullOrWhiteSpace(this.outputPath))
            {
                code += " -o " + "\"" + this.outputPath + changeFileExtName(fileName, "m4a") + "\"";
            }
            //MessageBox.Show(code);
            return code;             
        }

        private bool losslessCheckByExtension(string extension)
        {
            string[] losslessExt = { "wav", "flac", "ape" };
            return this.multiStringEqualCheck(losslessExt, extension);
        }

        private bool multiStringEqualCheck(string[] targets, string source)
        {
            int len = targets.Length;
            for (int i = 0; i < len; i++)
            {
                if (string.Equals(targets[i], source))
                {
                    return true;
                }        
            }
            return false;
        }

        private string changeFileExtName(string originFp, string ext)
        {
            string[] s = originFp.Split(new char[] { '.' });
            int length = s.Length;
            s[length - 1] = ext;
            string finalFileName = "";
            for (int i = 0; i < length; i++)
            {
                finalFileName += s[i];
                if (i != length - 1)
                {
                    finalFileName += ".";
                }
            }
            return finalFileName;
        }
    }
}
