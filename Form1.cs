using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace İmanCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Bu yazılımın tüm hakları GPL lisansı altında korunmaktadır.

        private void Save_As()
        {
            SaveFileDialog sf = new SaveFileDialog();
            if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.CSharp)
                sf.Filter = "C# Dosyası|*.cs|Tüm Dosyalar|*.*";
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.HTML)
                sf.Filter = "HTML Dosyası|*.html|Tüm Dosyalar|*.*";
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.JS)
                sf.Filter = "Javascript Dosyası|*.js|Tüm Dosyalar|*.*";
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.Lua)
                sf.Filter = "Lua Dosyası|*.lua|Tüm Dosyalar|*.*";
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.PHP)
                sf.Filter = "PHP Dosyası|*.php|Tüm Dosyalar|*.*";
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.VB)
                sf.Filter = "VB Dosyası|*.vb|Tüm Dosyalar|*.*";
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.XML)
                sf.Filter = "XML Dosyası|*.xml|Tüm Dosyalar|*.*";
            else
                sf.Filter = "Tüm Dosyalar|*.*";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sf.FileName);
                sw.Write(fastColoredTextBox1.Text);
                sw.Close();
            }
        }

        private void fkaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save_As();
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Bütün Yazıları siler
            fastColoredTextBox1.Text = "";
        }

        string filepath, filename;

        private void OpenDlg() 
        {

            //openfiledialog oluşturma
            OpenFileDialog of = new OpenFileDialog();
            //Dosya filtreleme
            if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.CSharp)
                of.Filter = "C# Dosyası|*.cs|Tüm Dosyalar|*.*";
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.HTML)
                of.Filter = "HTML Dosyası|*.html|Tüm Dosyalar|*.*";
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.JS)
                of.Filter = "Javascript Dosyası|*.js|Tüm Dosyalar|*.*";
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.Lua)
                of.Filter = "Lua Dosyası|*.lua|Tüm Dosyalar|*.*";
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.PHP)
                of.Filter = "PHP Dosyası|*.php|Tüm Dosyalar|*.*";
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.VB)
                of.Filter = "VB Dosyası|*.vb|Tüm Dosyalar|*.*";
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.XML)
                of.Filter = "XML Dosyası|*.xml|Tüm Dosyalar|*.*";
            else
                of.Filter = "Tüm Dosyalar|*.*";

            if (of.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(of.FileName);            
                this.Text = "İman Code Editor - " + of.SafeFileName;
                filename = of.SafeFileName;
                filepath = of.FileName;
                FileInfo ff = new FileInfo(of.FileName);
                if(ff.Extension == ".cs")
                {
                    fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.CSharp;
                }
                else if (ff.Extension == ".html")
                {
                    fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.HTML;
                }
                else if (ff.Extension == ".Js")
                {
                    fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.JS;
                }
                else if (ff.Extension == ".lua")
                {
                    fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Lua;
                }
                else if (ff.Extension == ".php")
                {
                    fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.PHP;
                }
                else if (ff.Extension == ".vb")
                {
                    fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.VB;
                }
                else if (ff.Extension == ".xml")
                {
                    fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.XML;
                }
                fastColoredTextBox1.Text = sr.ReadToEnd();
                sr.Close();
            } 
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDlg();
        }

        private void farklıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filepath);
                sw.Write(fastColoredTextBox1.Text);
                sw.Close();
            }
            catch
            {
                Save_As();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Paste();
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Copy();
        }

        private void arkaPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                fastColoredTextBox1.BackColor = cd.Color;
            }
        }

        private void yazıRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                fastColoredTextBox1.ForeColor = cd.Color;
            }
        }

        private void yazıFontuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                fastColoredTextBox1.Font = fd.Font;
            }
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fkaydetToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Save_As();
        }

        private void geriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Undo();
        }

        private void yenidenYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Redo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void hepsiniSeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.SelectAll();
        }

        private void cUtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Cut();
        }

        private void kopyalaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Copy();
        }

        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Paste();
        }

        private void araToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.FindForm();
        }

        private void gitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.ShowGoToDialog();
        }

        private void yanidenYerleştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.ShowReplaceDialog();
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.CSharp;
        }

        private void vBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.VB;
        }

        private void hTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.HTML;
        }

        private void pHPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.PHP;
        }

        private void jSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.JS;
        }

        private void sQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.SQL;
        }

        private void lUAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Lua;
        }

        private void çalıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.HTML)
            {
                HTMLPreview h = new HTMLPreview(fastColoredTextBox1.Text);
                h.Show();
            }
            else
            {
                MessageBox.Show("Bu Dosya Çalıştırılamaz", "İşlem Geçersiz", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
  

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu Yazılım İman Soft Yöneticisi Faruk IŞIK ve Furkan DEMİRCAN Tarafından Tasarlanmıştır.", "Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
                                       
