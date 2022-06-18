using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }

        List<ICurse> _elements;
        public Form1()
        {
            InitializeComponent();
            _elements = new List<ICurse>();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_add_Click_1(object sender, EventArgs e)
        {
            switch (comboBox_type.SelectedIndex)
            {
                case 0:
                    {
                        var tmp_class = new River();
                        _elements.Add(tmp_class);
                        listBox_objects.Items.Add(tmp_class);
                    }
                    break;

                case 1:
                    {
                        var tmp_class = new DryDye();
                        _elements.Add(tmp_class);
                        listBox_objects.Items.Add(tmp_class);
                    }
                    break;

                case 2:
                    {
                        var tmp_class = new ActionMovie();
                        _elements.Add(tmp_class);
                        listBox_objects.Items.Add(tmp_class);
                    }
                    break;

                case 3:
                    {
                        var tmp_class = new Comedy();
                        _elements.Add(tmp_class);
                        listBox_objects.Items.Add(tmp_class);
                    }
                    break;

                case 4:
                    {
                        var tmp_class = new Horror();
                        _elements.Add(tmp_class);
                        listBox_objects.Items.Add(tmp_class);
                    }
                    break;

                case 5:
                    {
                        var tmp_class = new Multiks();
                        _elements.Add(tmp_class);
                        listBox_objects.Items.Add(tmp_class);
                    }
                    break;
            }
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            int index = listBox_objects.SelectedIndex;
            if (index != -1)
            {
                _elements.RemoveAt(index);
                listBox_objects.Items.RemoveAt(index);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int index = listBox_objects.SelectedIndex;
            if (index != -1)
            {
                var lst = _elements[index].GenerateDelegateList();
                Form3 form = new Form3(lst);
                form.ShowDialog();
                textBox_console.AppendText(form.GetResult() + Environment.NewLine);
                listBox_objects.Items[index] = _elements[index].ToString();
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog fileDialog = new SaveFileDialog())
            {
                fileDialog.Filter = "('.') (*.dat)|*.dat";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = fileDialog.FileName;
                    using (BinaryWriter sr = new BinaryWriter(File.Open(filePath, FileMode.Create)))
                    {
                        string Ident = "qwert";
                        sr.Write(Ident);
                        foreach (var obj in _elements)
                        {
                            var b = obj.GetByteArray();
                            sr.Write(b.Length);
                            sr.Write(b);
                        }
                    }
                }
            }
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            {
                using (OpenFileDialog fileDialog = new OpenFileDialog())
                {
                    fileDialog.Filter = "Loaded (*.dat)|*.dat";
                    if (fileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = fileDialog.FileName;
                        using (BinaryReader sr = new BinaryReader(File.Open(filePath, FileMode.Open)))
                        {
                            var Ident = sr.ReadString();
                            if (Ident == "qwert")
                            {
                                _elements.Clear();
                                listBox_objects.Items.Clear();
                                while (sr.BaseStream.Position != sr.BaseStream.Length)
                                {
                                    var arsize = sr.ReadInt32();
                                    var byteArray = sr.ReadBytes(arsize);
                                    var res = ByteArrayToObject(byteArray);
                                    _elements.Add(res as ICurse);
                                    listBox_objects.Items.Add(res.ToString());

                                }
                            }
                            else textBox_console.AppendText("Неверный формат файла" + Environment.NewLine);


                        }
                    }
                }
            }
        }
    }
}