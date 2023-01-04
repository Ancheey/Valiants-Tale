using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Valiants_Tale.Resources.Access
{
    internal class ChatManager
    {
        private static ChatManager instance;
        public static ChatManager Instance 
        { 
            get {
                if (instance == null)
                {
                    instance = new ChatManager();
                }
                return instance; 
            }
            private set { }
        }

        public void WriteVocal(string text)
        {
            MainWindow.ui.VocalChat.AddMemory(text);
        }
        public void WriteAction(string text)
        {
            MainWindow.ui.ActionChat.AddMemory(text);
        }
        public void WriteMind(string text)
        {
            MainWindow.ui.MindChat.AddMemory(text);
        }

    }
}
