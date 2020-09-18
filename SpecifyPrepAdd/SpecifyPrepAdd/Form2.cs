/* This software was produced by 
 * The Florida Museum of Natural History c.2020
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 * 
 * This work is licensed under a 
 * Creative Commons Attribution-NonCommercial 4.0 International License.  
 * http://creativecommons.org/licenses/by-nc/4.0/
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SpecifyPrepAdd
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();

            richTextBox1.Text = SpecifyPrepAdd.Properties.Resources.HelpString;
        }
    }
}
