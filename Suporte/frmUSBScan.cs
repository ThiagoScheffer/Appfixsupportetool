using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Suporte
{
    public partial class frmUSBScan : Form
    {
        private readonly FolderBrowserDialog _folderBrowser = new FolderBrowserDialog();//Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced
        readonly RegistryKey _registryKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", true);
        private int _foldercount = 0;
        private int _filecount = 0;
        //private int removidos = 0;
        private string _malware;
        private string _path;
        public frmUSBScan()
        {
            InitializeComponent();
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            tbxLog.Text = "Selecionando caminho...";
            if (_registryKey != null)
            {
                if (_registryKey.GetValue("Hidden").ToString() == "0" || _registryKey.GetValue("Hidden").ToString() == "2")
                    _registryKey.SetValue("Hidden", 1);
                _registryKey.Flush();
            }
            _folderBrowser.Description = "Selecionar pasta a reparar";
            if (_folderBrowser.ShowDialog() == DialogResult.OK)
            {
                _path = Path.GetFullPath(_folderBrowser.SelectedPath);
                tbxLog.Text += Environment.NewLine + "Caminho: " + Path.GetFullPath(_folderBrowser.SelectedPath);
                tbxLog.Text += Environment.NewLine + "Caminho localizado.";
            }
        }

        private void btnRepair_Click(object sender, EventArgs e)
        {
            _malware = "";
            _filecount = 0;
            _foldercount = 0;
            tbxLog.Text += Environment.NewLine + "Iniciando analise na unidade...";
            DirectoryInfo directory = new DirectoryInfo(_path);
           // tbxLog.Text += Environment.NewLine + "Reparando pastas e subpastas...";
            try
            {
                foreach (var Dir in directory.GetDirectories())
                {
                    try
                    {
                        if (Dir.Name == "System Volume Information" || Dir.Name == "$RECYCLE.BIN")
                            continue;
                        _foldercount++;
                        FileAttributes attributes = File.GetAttributes(Dir.FullName);
                        if ((attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                        { continue; }
                        Dir.Attributes = Dir.Attributes & ~FileAttributes.Hidden;
                        Dir.Attributes = Dir.Attributes & ~FileAttributes.Normal;
                        Dir.Attributes = Dir.Attributes & ~FileAttributes.System;
                    }
                    catch (Exception exception)
                    {
                        tbxLog.Text += Environment.NewLine + "erro na pasta -> " + exception;
                    }

                }
            }
            catch
            {

            }


            try
            {
                foreach (var file in DirRecursiveSearch(_path))
                {
                    try
                    {
                        FileInfo fileInfo = new FileInfo(file);

                        FileAttributes attributes = File.GetAttributes(file);

                        if (fileInfo.Extension == ".lnk")
                        {
                           // removidos++;
                            continue;
                        }
                        if (fileInfo.Extension == ".vbs")
                        {
                           // removidos++;
                            _malware = fileInfo.Name;
                            continue;
                        }
                        if (fileInfo.Extension == ".js")
                        {
                           // removidos++;
                            _malware = fileInfo.Name;
                            continue;
                        }
                        if (fileInfo.Extension == ".vbe")
                        {
                           // removidos++;
                            _malware = fileInfo.Name;
                            continue;
                        }
                        _filecount++;
                        if ((attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                        { continue; }
                        fileInfo.Attributes = fileInfo.Attributes & ~FileAttributes.System;
                        fileInfo.Attributes = fileInfo.Attributes & ~FileAttributes.Normal;
                        fileInfo.Attributes = fileInfo.Attributes & ~FileAttributes.Hidden;
                        fileInfo.Attributes = fileInfo.Attributes & ~FileAttributes.ReadOnly;


                    }
                    catch (Exception exception)
                    {
                        tbxLog.Text += Environment.NewLine + @"erro no arquivo -> " + exception;
                    }
                }
            }
            catch (Exception exception)
            {
                tbxLog.Text += Environment.NewLine + @"erro no arquivo -> " + exception;
            }
            if (_malware != null && _malware == "")
            {
                _malware = "Nenhum";
            }
            tbxLog.Text += Environment.NewLine + @"Resumo do Scan.";
            tbxLog.Text += Environment.NewLine + @"Total de pastas: " + _foldercount;
            tbxLog.Text += Environment.NewLine + @"Total de arquivos: " + _filecount;
            tbxLog.Text += Environment.NewLine + @"Malware -> " + _malware;

            if (_malware != null && _malware != "Nenhum")
            tbxLog.Text += Environment.NewLine + @"Encontrado(s) arquivos infectado(s). Informe o Técnico.";
        }
        List<string> DirRecursiveSearch(string sDir)
        {
            List<string> files = new List<string>();

            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    files.Add(f);
                }

                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.AddRange(DirRecursiveSearch(d));
                }
            }
            catch (Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }

            return files;
        }

        private void frmUSBScan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_registryKey.GetValue("Hidden").ToString() == "1")
                _registryKey.SetValue("Hidden", 0);
            _registryKey.Flush();
            _registryKey.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        
    }
}
