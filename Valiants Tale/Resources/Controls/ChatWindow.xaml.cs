using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Valiants_Tale.Resources.Data;

namespace Valiants_Tale.Resources.Controls
{
    /// <summary>
    /// Logika interakcji dla klasy ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : UserControl
    {
        List<string> Text = new List<string>();
        public string BoxName { get { return ChatName.Content.ToString(); } set { ChatName.Content = value; } }
        public ChatWindow()
        {
            InitializeComponent();
        }
        public void UpdateMemory(int amt)
        {
            Text.Capacity = amt;
            Text.TrimExcess();
            Update();
        }
        public void AddMemory(string memory)
        {
            Text.Insert(0, memory);
            Text.TrimExcess();
            Update();
        }
        void Update()
        {
            string newText = "";
            for(int i = Text.Count - 1; i > 0; i--)
            {
                newText += Text[i] + "\r\n";
            }
            newText += Text[0];
            ChatText.Text = newText;
        }
    }
}
