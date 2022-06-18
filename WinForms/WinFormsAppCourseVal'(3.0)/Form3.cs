using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        List<Func<string>> _delegates;
        string _result = "Метод не выбран";

        public Form3()
        {
            InitializeComponent();
        }
        public Form3(List<Func<string>> l):this()
        {
            _delegates = l;
            foreach(var i in _delegates)
            {
                comboBox1.Items.Add(i.Method.Name);
            }

        }


        internal string GetResult()
        {
            return _result;

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index=comboBox1.SelectedIndex;
            if(index!=-1)
            {
                _result=_delegates[index]();
            }
            Close();
        }
    }
}
