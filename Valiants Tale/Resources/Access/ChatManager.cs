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
        /// <summary>
        /// Writes a message in the Vocal chat channel
        /// </summary>
        /// <param name="text">Message to write out</param>
        public void WriteVocal(string text)
        {
            MainWindow.ui.VocalChat.AddMemory(text);
        }
        /// <summary>
        /// Writes a message in the Action chat channel
        /// </summary>
        /// <param name="text">Message to write out</param>
        public void WriteAction(string text)
        {
            MainWindow.ui.ActionChat.AddMemory(text);
        }
        /// <summary>
        /// Writes a message in the Mind chat channel
        /// </summary>
        /// <param name="text">Message to write out</param>
        public void WriteMind(string text)
        {
            MainWindow.ui.MindChat.AddMemory(text);
        }

    }
}
