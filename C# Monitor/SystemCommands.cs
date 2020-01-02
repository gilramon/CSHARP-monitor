using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Spetrotec
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SystemCommands : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public string Opcode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Help { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SystemCommands()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
