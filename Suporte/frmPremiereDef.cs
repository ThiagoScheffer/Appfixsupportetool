using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;

namespace Suporte
{
    public partial class frmPremiereDef : Form
    {
        private const double Fps29 = 29.97;
        private const double Fps24 = 23.976;
        private string value;
        private string _dialogmode;
        private readonly string _programx86 = Environment.GetEnvironmentVariable("PROGRAMFILES(X86)") ??
                                              Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

        readonly string _programfiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        private static readonly string LightRoomExeDir = cEditor.GetLightRoomExePath();
        private readonly XmlDocument _document = new XmlDocument();
        static readonly string TempXml = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Adobe\Premiere Pro\tempdef.xml";
        /*
         * System.IO.FileNotFoundException: Could not find file 'C:\Users\EncryptorX\AppData\Roaming\Adobe\Premiere Pro\tempdef.xml'.
            File name: 'C:\Users\EncryptorX\AppData\Roaming\Adobe\Premiere Pro\tempdef.xml'
               at System.IO.__Error.WinIOError(Int32 errorCode, String maybeFullPath)
         */

        //Start All
        public frmPremiereDef()
        {
            InitializeComponent();
        }
        //FORM LOAD
        private void frmPremiereDef_Load(object sender, EventArgs e)
        {

            //LoadApenas Modulos do Premiere se ele existe
            if (Program.PPInstalled)
            {
                //Carregar MEdiaFolder
                MediaCacheInfoLoad();
                XmlDefLoad();
                CreatePresetCheckboxes();
            }
            if (Program.LTInstalled)
            {
                //LoadSuportePrefs();
                LoadLightRoomDefs();
                LoadCkbxModuleStatus();
            }
            //Desabilita Forms se que não existem.
            DisableButtons();
            
            lblstatus.Text = "Configurações Carregadas !";
            //MessageBox.Show(Environment.GetEnvironmentVariable("PROGRAMFILES(X86)") ?? Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
        }

        private void btnSaveApply_Click(object sender, EventArgs e)
        {
            lblstatus.Text = "Salvando alterações...";

            if (Program.PPInstalled)
            {
                #region XML

                //C:\Users\EncryptorX\AppData\Roaming\Adobe\Premiere Pro\6.0\Adobe Premiere Pro Prefs
                //Default Saves
                //SameAsProject - MyDocuments
                string deffile = cEditor.GetPremiereDefFile();
                //string tempXml = @"C:\Users\" + username + @"\AppData\Roaming\Adobe\Premiere Pro\tempdef.xml";

                //Criar um Arquivo Temporário
                if (File.Exists(deffile))
                    File.Move(deffile, TempXml);


                _document.Load(TempXml);

                //XmlElement cElement = document.CreateElement("MZ.Prefs.Export.UseFrameBlending");
                XmlNode node = _document.SelectSingleNode("PremiereData/Preferences/Properties");

                if (node != null)
                {
                    node.SelectSingleNode("./BE.Prefs.ScratchDisks.FirstDVDEncodingFolder").InnerText =
                        tbxEncoding.Text;
                    node.SelectSingleNode("./BE.Prefs.ScratchDisks.FirstAudioPreviewFolder").InnerText =
                        tbxAudioPrev.Text;
                    node.SelectSingleNode("./BE.Prefs.ScratchDisks.FirstVideoPreviewFolder").InnerText =
                        tbxVideoPrev.Text;
                    node.SelectSingleNode("./BE.Prefs.ScratchDisks.FirstAudioCaptureFolder").InnerText =
                        tbxAudioCap.Text;
                    node.SelectSingleNode("./BE.Prefs.ScratchDisks.FirstVideoCaptureFolder").InnerText =
                        tbxVideoCap.Text;


                    node.SelectSingleNode("./BE.Prefs.AutoSave.DoSave").InnerText = chkbxAutoSave.CheckState ==
                                                                                    CheckState.Checked
                                                                                        ? "true"
                                                                                        : "false";
                    node.SelectSingleNode("./BE.Prefs.General.DefaultScaleToFrameSize").InnerText =chkboxScaleFrameSize.CheckState == CheckState.Checked ? "true" : "false";
                    node.SelectSingleNode("./BE.Prefs.General.PlayWorkareaAfterPreviewRender").InnerText = chkboxScaleFrameSize.CheckState == CheckState.Checked ? "true" : "false";
                    node.SelectSingleNode("./ML.Prefs.Capture.AbortOnDroppedFrames").InnerText =
                        chkbxAbortOnDroppedFrames.CheckState == CheckState.Checked ? "true" : "false";
                    node.SelectSingleNode("./ML.Prefs.Capture.ReportOnDroppedFrames").InnerText =
                        chkbxReportOnDroppedFrames.CheckState == CheckState.Checked ? "true" : "false";
                    node.SelectSingleNode("./BE.Prefs.StillImages.ScaleToProject").InnerText =
                        chkbxStillScaleToProject.CheckState == CheckState.Checked ? "true" : "false";
                    node.SelectSingleNode("./BE.Prefs.Audio.Scrubbing").InnerText = chkbxAudioScrub.CheckState ==
                                                                                    CheckState.Checked
                                                                                        ? "true"
                                                                                        : "false";

                    if (node.SelectSingleNode("./MZ.Prefs.Export.Media.Path") == null)
                        node.InsertAfter(_document.CreateElement("MZ.Prefs.Export.Media.Path"), node.FirstChild);
                    node.SelectSingleNode("./MZ.Prefs.Export.Media.Path").InnerText = tbxExportPath.Text;

                    if (node.SelectSingleNode("./MZ.Prefs.Export.UseFrameBlending") == null)
                        node.InsertAfter(_document.CreateElement("MZ.Prefs.Export.UseFrameBlending"),
                                            node.FirstChild);
                    node.SelectSingleNode("./MZ.Prefs.Export.UseFrameBlending").InnerText =
                        chkbxFrameBlending.CheckState ==
                        CheckState.Checked
                            ? "true"
                            : "false";

                    if (node.SelectSingleNode("./MZ.Prefs.Export.MaximumRenderQuality") == null)
                        node.InsertAfter(_document.CreateElement("MZ.Prefs.Export.MaximumRenderQuality"),
                                            node.FirstChild);
                    node.SelectSingleNode("./MZ.Prefs.Export.MaximumRenderQuality").InnerText =
                        chkbxMaxQuality.CheckState == CheckState.Checked ? "true" : "false";

                    if (node.SelectSingleNode("./MZ.Prefs.Export.UsePreviewFiles") == null)
                        node.InsertAfter(_document.CreateElement("MZ.Prefs.Export.UsePreviewFiles"), node.FirstChild);
                    node.SelectSingleNode("./MZ.Prefs.Export.UsePreviewFiles").InnerText =
                        chkbxUsePreviews.CheckState ==
                        CheckState.Checked
                            ? "true"
                            : "false";

                    node.SelectSingleNode("./BE.Prefs.AutoSave.Interval").InnerText =
                        numInterval.Value.ToString(CultureInfo.InvariantCulture);
                    node.SelectSingleNode("./BE.Prefs.AutoSave.MaxProjectVersions").InnerText =
                        numProj.Value.ToString(CultureInfo.InvariantCulture);
                    node.SelectSingleNode("./BE.Prefs.StillImages.Duration").InnerText =
                        numStillDuration.Value.ToString(CultureInfo.InvariantCulture);
                }

                //Salvar
                _document.Save(TempXml);
                //Restaura Definiçoes
                if (File.Exists(TempXml))
                    File.Move(TempXml, deffile);

                #endregion

            }
            if (Program.LTInstalled)
            {
                SaveLightRoomDefs();
                SaveModulosStatus();
            }
            //SalvarSuportePref();
            Close();
        }


        #region FUNÇÕES PRINCIPAIS

        private void numStillDuration_ValueChanged(object sender, EventArgs e)
        {
            lblStillCalcule.Text =
                (Math.Round(Math.Round(numStillDuration.Value / (decimal)Fps24, 3, MidpointRounding.AwayFromZero)) +
                 " ~Min@24fps \n" +
                 (Math.Round(numStillDuration.Value / (decimal)Fps29, 2, MidpointRounding.AwayFromZero)).ToString(
                     CultureInfo.InvariantCulture) +
                 " ~Min@29fps");
        }

        private void LightRoomActionRegOpenClose(string ltvalue)
        {
            //HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\AutoplayHandlers\Handlers\Lightroom4BetaAutoPlayHandler64
            RegistryKey RegLTAction =
                Registry.CurrentUser.CreateSubKey(
                    @"Software\Microsoft\Windows\CurrentVersion\Explorer\AutoplayHandlers\Handlers\Lightroom4BetaAutoPlayHandler64");
            //Criar System KEY
            if (RegLTAction != null)
            {
                RegLTAction.SetValue("InvokeProgID", ltvalue);
                // MessageBox.Show(RegLTAction.GetValue("InvokeProgID").ToString());
                RegLTAction.Close();
            }
        }

        #endregion

        //HKEY_CURRENT_USER\Software\Adobe\Common CS6\Media Cache 
        //DatabasePath ->  H:\teste\ -- DATABASE - metadata
        //FolderPath -> H:\teste -- Media Cache Files - lixos

        #region FUNÇOES DE LOAD

        private void LoadSuportePrefs()
        {
            try
            {
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(@"Software\Adobe\CentraldeSuporte");
                if (registryKey == null)
                    return;
                LTCacheSetting.Value = int.Parse(registryKey.GetValue("LTCacheSize").ToString());
                PrmCacheSetting.Value = int.Parse(registryKey.GetValue("PrmCacheSize").ToString());
                PrmPrevSetting.Value = int.Parse(registryKey.GetValue("PrmPrevSize").ToString());
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
        //CARREGA O STATUS DOS CHKBX MODULOS
        private void LoadCkbxModuleStatus()
        {
            if (LightRoomExeDir == null)
            {
                ckbxWeb.Enabled = false;
                ckbxSlideShow.Enabled = false;
                ckbxPrint.Enabled = false;
                ckbxMultiMonitor.Enabled = false;
                ckbxMap.Enabled = false;
                ckbxLayout.Enabled = false;
                ckbxBook.Enabled = false;
                return;
            }
            string exepath = _programfiles + @"\Adobe" + cUtils.DefFileExtractString(LightRoomExeDir, "Adobe", "\\Lightroom.exe");

            if (!Directory.Exists(exepath))
                return;
            string disablePath = exepath + "\\DISABLE";
            if (!Directory.Exists(disablePath))
                Directory.CreateDirectory(disablePath);
            if (!File.Exists(exepath + "\\Slideshow.lrmodule"))
            {
                ckbxSlideShow.Enabled = false;
                ckbxMultiMonitor.Enabled = false;
            }

            //WEB
            ckbxWeb.CheckState = File.Exists(exepath + "\\Web.lrmodule") ? CheckState.Unchecked : CheckState.Checked;
            //SLIDE
            ckbxSlideShow.CheckState = File.Exists(exepath + "\\Slideshow.lrmodule") ? CheckState.Unchecked : CheckState.Checked;
            //PRINT
            ckbxPrint.CheckState = File.Exists(exepath + "\\Print.lrmodule") ? CheckState.Unchecked : CheckState.Checked;
            //MONITOR
            ckbxMultiMonitor.CheckState = File.Exists(exepath + "\\MultipleMonitor.lrmodule") ? CheckState.Unchecked : CheckState.Checked;
            //Location
            ckbxMap.CheckState = File.Exists(exepath + "\\Location.lrmodule") ? CheckState.Unchecked : CheckState.Checked;
            //LAYOUT
            ckbxLayout.CheckState = File.Exists(exepath + "\\Layout.lrmodule") ? CheckState.Unchecked : CheckState.Checked;
            //BOOK
            ckbxBook.CheckState = File.Exists(exepath + "\\Book.lrmodule") ? CheckState.Unchecked : CheckState.Checked;

        }

        //HKEY_CURRENT_USER\Software\Adobe\Common 7.0\Media Cache
        private void MediaCacheInfoLoad()
        {
            lblstatus.Text = "Loading Cache Registry...";
            tbxMediaCache.Text = cEditor.GetMediaCacheDir();
       }

        private void XmlDefLoad()
        {
            lblstatus.Text = @"Carregando arquivo...";
            //C:\Users\EncryptorX\AppData\Roaming\Adobe\Premiere Pro\6.0\Adobe Premiere Pro Prefs
            string defile = cEditor.GetPremiereDefFile();
            //string tempXml = @"C:\Users\" + username + @"\AppData\Roaming\Adobe\Premiere Pro\tempdef.xml";
            try
            {
                //Limpar XML file se existir
                if (File.Exists(TempXml))
                    File.Delete(TempXml);

                //Criar um Arquivo Temporário
                if (File.Exists(defile))
                    File.Move(defile, TempXml);

                _document.Load(TempXml);
            }
            catch (Exception)
            {
                return;
            }
            //MessageBox.Show(tempXml + "\n" + defile);
            XmlNode node = _document.SelectSingleNode("PremiereData/Preferences/Properties");
            try
            {
                if (node != null)
                {
                    tbxEncoding.Text = node.SelectSingleNode("./BE.Prefs.ScratchDisks.FirstDVDEncodingFolder").InnerText;
                    tbxAudioPrev.Text =
                        node.SelectSingleNode("./BE.Prefs.ScratchDisks.FirstAudioPreviewFolder").InnerText;
                    tbxVideoPrev.Text =
                        node.SelectSingleNode("./BE.Prefs.ScratchDisks.FirstVideoPreviewFolder").InnerText;
                    tbxAudioCap.Text =
                        node.SelectSingleNode("./BE.Prefs.ScratchDisks.FirstAudioCaptureFolder").InnerText;
                    tbxVideoCap.Text =
                        node.SelectSingleNode("./BE.Prefs.ScratchDisks.FirstVideoCaptureFolder").InnerText;

                    chkbxAutoSave.CheckState = node.SelectSingleNode("./BE.Prefs.AutoSave.DoSave").InnerText == "true"
                                                   ? CheckState.Checked
                                                   : CheckState.Unchecked;
                    chkboxScaleFrameSize.CheckState = node.SelectSingleNode("./BE.Prefs.General.DefaultScaleToFrameSize").InnerText == "true"? CheckState.Checked: CheckState.Unchecked;
                    chkbxPlayPreview.CheckState = node.SelectSingleNode("./BE.Prefs.General.PlayWorkareaAfterPreviewRender").InnerText == "true" ? CheckState.Checked : CheckState.Unchecked;
                    chkbxAbortOnDroppedFrames.CheckState =
                        node.SelectSingleNode("./ML.Prefs.Capture.AbortOnDroppedFrames").InnerText == "true"
                            ? CheckState.Checked
                            : CheckState.Unchecked;
                    chkbxReportOnDroppedFrames.CheckState =
                        node.SelectSingleNode("./ML.Prefs.Capture.ReportOnDroppedFrames").InnerText == "true"
                            ? CheckState.Checked
                            : CheckState.Unchecked;
                    chkbxStillScaleToProject.CheckState =
                        node.SelectSingleNode("./BE.Prefs.StillImages.ScaleToProject").InnerText == "true"
                            ? CheckState.Checked
                            : CheckState.Unchecked;
                    chkbxAudioScrub.CheckState = node.SelectSingleNode("./BE.Prefs.Audio.Scrubbing").InnerText == "true"
                                                     ? CheckState.Checked
                                                     : CheckState.Unchecked;

                    if (node.SelectSingleNode("./MZ.Prefs.Export.Media.Path") != null)
                        tbxExportPath.Text = node.SelectSingleNode("./MZ.Prefs.Export.Media.Path").InnerText;
                    if (node.SelectSingleNode("./MZ.Prefs.Export.UsePreviewFiles") != null)
                        chkbxUsePreviews.CheckState =
                            node.SelectSingleNode("./MZ.Prefs.Export.UsePreviewFiles").InnerText == "true"
                                ? CheckState.Checked
                                : CheckState.Unchecked;
                    if (node.SelectSingleNode("./MZ.Prefs.Export.UseFrameBlending") != null)
                        chkbxFrameBlending.CheckState =
                            node.SelectSingleNode("./MZ.Prefs.Export.UseFrameBlending").InnerText == "true"
                                ? CheckState.Checked
                                : CheckState.Unchecked;
                    if (node.SelectSingleNode("./MZ.Prefs.Export.MaximumRenderQuality") != null)
                        chkbxMaxQuality.CheckState =
                            node.SelectSingleNode("./MZ.Prefs.Export.MaximumRenderQuality").InnerText == "true"
                                ? CheckState.Checked
                                : CheckState.Unchecked;

                    numInterval.Value =
                        Convert.ToDecimal(node.SelectSingleNode("./BE.Prefs.AutoSave.Interval").InnerText);
                    numProj.Value =
                        Convert.ToDecimal(node.SelectSingleNode("./BE.Prefs.AutoSave.MaxProjectVersions").InnerText);
                    //Reparar Numero 125.000000000000000000000000
                    if (Math.Round(Convert.ToDecimal(node.SelectSingleNode("./BE.Prefs.StillImages.Duration").InnerText.TrimEnd('0')), 3,MidpointRounding.AwayFromZero) == 125)
                    {
                        numStillDuration.Value = 125;
                    }
                    else
                        numStillDuration.Value =
                            Math.Round(
                                Convert.ToDecimal(node.SelectSingleNode("./BE.Prefs.StillImages.Duration").InnerText), 3,
                                MidpointRounding.AwayFromZero);

                    //Round FPS
                    lblStillCalcule.Text =
                        (Math.Round(Math.Round(numStillDuration.Value / (decimal)Fps24, 3, MidpointRounding.AwayFromZero)) +
                         " ~Min@24fps \n" +
                         (Math.Round(numStillDuration.Value / (decimal)Fps29, 3, MidpointRounding.AwayFromZero)).ToString
                             (CultureInfo.InvariantCulture).TrimEnd('0') + " ~Min@29fps");
                }
            }
            catch (Exception)
            {
                string DefFileBak = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Adobe\Premiere Pro\BackupDef.bak";
                string Deffile = cEditor.GetPremiereDefFile();
                if(File.Exists(DefFileBak))
                File.Copy(DefFileBak, Deffile, true);
                MessageBox.Show(@"Definições não existentes ou estão corrompidas! Reparo realizado..tente agora.");
                Close();
                return;
            }
            //Restaura Definiçoes
            if (File.Exists(TempXml))
                File.Move(TempXml, defile);
        }

        //CARREGA DEFINIÇOES DO LT
        private void LoadLightRoomDefs()
        {
            string LTdefsfile = cEditor.GetLightroomDefFile();

            if (LTdefsfile != null)
            {
                string[] prefsLines = File.ReadAllLines(LTdefsfile);
                foreach (string line in prefsLines)
                {
                    //memoryCardDetectionAction = "ImportBehavior_DoNothing",
                    if (line.Contains("memoryCardDetectionAction"))
                    {
                        //memoryCardDetectionAction = "ImportBehavior_ShowImportDialog",
                        _dialogmode = cUtils.ExtractStringwithQuotationMark(line, "= \"", "\",");
                        chkbxDialogo.CheckState = _dialogmode == "ImportBehavior_ShowImportDialog" ? CheckState.Checked : CheckState.Unchecked;
                    }

                    if (line.Contains("noSplashScreenOnStartup"))
                    {
                        value = string.Empty;
                        value = cUtils.ExtractStringwithQuotationMark(line, "= ", ",");
                        chkbxSplashscreen.CheckState = value == "true" ? CheckState.Checked : CheckState.Unchecked;
                    }

                    if (line.Contains("AgNavigator_showPhotosOnMouseOver"))
                    {
                        value = string.Empty;
                        value = cUtils.ExtractStringwithQuotationMark(line, "= ", ",");
                        if (value == "true") chkbxShowPicMouseOver.CheckState = CheckState.Checked;
                        else chkbxShowPicMouseOver.CheckState = CheckState.Unchecked;
                        //MessageBox.Show(line + value);
                    }
                    if (line.Contains("AgLibrary_showLoupeInfo"))
                    {
                        value = string.Empty;
                        value = cUtils.ExtractStringwithQuotationMark(line, "= ", ",");
                        chkbxLoupeInfo.CheckState = value == "true" ? CheckState.Checked : CheckState.Unchecked;
                    }
                    //2023
                    //useAutoBahn = true,
                    if (line.Contains("useAutoBahn"))//GPU processor
                    {
                        value = string.Empty;
                        value = cUtils.ExtractStringwithQuotationMark(line, "= ", ",");
                        chkbxuseAutoBahn.CheckState = value == "true" ? CheckState.Checked : CheckState.Unchecked;
                    }

                    if (line.Contains("useGPUCompute"))//GPU processor AI ?
                    {
                        value = string.Empty;
                        value = cUtils.ExtractStringwithQuotationMark(line, "= ", ",");
                        chkbxuseGPUCompute.CheckState = value == "true" ? CheckState.Checked : CheckState.Unchecked;
                    }

                    if (line.Contains("useGPUForExport"))//GPU processor exporting
                    {
                        value = string.Empty;
                        value = cUtils.ExtractStringwithQuotationMark(line, "= ", ",");
                        chkbxuseGPUForExport.CheckState = value == "true" ? CheckState.Checked : CheckState.Unchecked;
                    }
                }
            }
            else
            {
                groupBox7.Enabled = false;
                //chkbxSplashscreen.Enabled = false;
                //chkbxDialogo.Enabled = false;
                //chkbxShowPicMouseOver.Enabled = false;
                //chkbxLoupeInfo.Enabled = false;
            }
        }



        private void DisableButtons()
        {
            if (Directory.Exists(_programx86 + @"\Adobe\Adobe Premiere Pro CS4"))
                btnCudaPatch.Enabled = false;
            if (!Program.LTInstalled)
                grpbxLightRoom.Enabled = false;
            
            if (Program.PPInstalled) return;
            grpbxCachesInfo.Enabled = false;
            grpbxPrefPremiere.Enabled = false;
            grpbxPresets.Enabled = false;
            grpbxPatches.Enabled = false;
            grpbxExportarInfo.Enabled = false;
        }

        #endregion

        #region SALVAR ALTERAÇÕES

        private void SalvarSuportePref()
        {
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(@"Software\Adobe\CentraldeSuporte",true);
            registryKey.SetValue("LTCacheSize",LTCacheSetting.Value);
            registryKey.SetValue("PrmCacheSize",PrmCacheSetting.Value);
            registryKey.SetValue("PrmPrevSize",PrmPrevSetting.Value);
        }
        private void SaveLightRoomDefs()
        {
            string LTdefsfile = cEditor.GetLightroomDefFile();
            //File.WriteAllText("Path", Regex.Replace(File.ReadAllText("Path"), "[Pattern]", "Replacement"));

            if (LTdefsfile == null) return;
            switch (chkbxDialogo.CheckState)
            {
                case CheckState.Checked:
                    cUtils.ReplaceInFile(LTdefsfile, "ImportBehavior_DoNothing", "ImportBehavior_ShowImportDialog");
                    LightRoomActionRegOpenClose("Adobe.AdobeLightroom64");
                    break;
                default:
                    cUtils.ReplaceInFile(LTdefsfile, "ImportBehavior_ShowImportDialog", "ImportBehavior_DoNothing");
                    LightRoomActionRegOpenClose("Adobe.AdobeLightroom64off");
                    break;
            }
            string splashScreenSet = chkbxSplashscreen.CheckState == CheckState.Checked
                                         ? "noSplashScreenOnStartup = true"
                                         : "noSplashScreenOnStartup = false";
            string splashscreenvalue = splashScreenSet == "noSplashScreenOnStartup = true"
                                           ? "noSplashScreenOnStartup = false"
                                           : "noSplashScreenOnStartup = true";
            cUtils.ReplaceLineString(LTdefsfile, splashScreenSet, splashscreenvalue);

            //Se estivar marcado procure o inverso.
            string showPhotosCurrentValue = chkbxShowPicMouseOver.CheckState == CheckState.Checked
                                                ? "AgNavigator_showPhotosOnMouseOver = false"
                                                : "AgNavigator_showPhotosOnMouseOver = true";

            string ReplaceshowPhotoValue = showPhotosCurrentValue == "AgNavigator_showPhotosOnMouseOver = false"
                                               ? "AgNavigator_showPhotosOnMouseOver = true"
                                               : "AgNavigator_showPhotosOnMouseOver = false";
            // MessageBox.Show(showPhotosCurrentValue + "\n" + ReplaceshowPhotoValue);
            cUtils.ReplaceLineString(LTdefsfile, showPhotosCurrentValue, ReplaceshowPhotoValue);

            string showLoupeSet = chkbxLoupeInfo.CheckState == CheckState.Checked
                                      ? "AgLibrary_showLoupeInfo = false"
                                      : "AgLibrary_showLoupeInfo = true";
            string showLoupeValue = showLoupeSet == "AgLibrary_showLoupeInfo = true"
                                        ? "AgLibrary_showLoupeInfo = false"
                                        : "AgLibrary_showLoupeInfo = true";

            cUtils.ReplaceLineString(LTdefsfile, showLoupeSet, showLoupeValue);

            //2023

            string useAutoBahnSet = chkbxuseAutoBahn.CheckState == CheckState.Checked
                                                ? "useAutoBahn = false"
                                                : "useAutoBahn = true";

            string useAutoBahnValue = useAutoBahnSet == "useAutoBahn = true"
                                        ? "useAutoBahn = false"
                                        : "useAutoBahn = true";

            cUtils.ReplaceLineString(LTdefsfile, useAutoBahnSet, useAutoBahnValue);


            string useGPUComputeSet = chkbxuseGPUCompute.CheckState == CheckState.Checked
                                               ? "useGPUCompute = false"
                                               : "useGPUCompute = true";

            string useGPUComputeValue = useGPUComputeSet == "useGPUCompute = true"
                                        ? "useGPUCompute = false"
                                        : "useGPUCompute = true";

            cUtils.ReplaceLineString(LTdefsfile, useGPUComputeSet, useGPUComputeValue);


            string useGPUForExportSet = chkbxuseGPUForExport.CheckState == CheckState.Checked
                                               ? "useGPUForExport = false"
                                               : "useGPUForExport = true";

            string useGPUForExportValue = showLoupeSet == "useGPUForExport = true"
                                        ? "useGPUForExport = false"
                                        : "useGPUForExport = true";

            cUtils.ReplaceLineString(LTdefsfile, useGPUForExportSet, useGPUForExportValue);
        }

        private void SaveModulosStatus()
        {   //ArgumentException: parsing "(?<=\\Adobe\)(.*?)(?=\\lightroom.exe)" - Not enough )'s.
            //C:\Program Files\Adobe\Adobe Photoshop Lightroom 4.4\Lightroom.exe
            //Extr retorna = \Adobe Photoshop Lightroom 4.4
            if (LightRoomExeDir == null)
                return;

            string exepath = _programfiles + @"\Adobe" + cUtils.DefFileExtractString(LightRoomExeDir, "Adobe", "\\Lightroom.exe");
            if (!Directory.Exists(exepath))
                return;

            string disablePath = exepath + "\\DISABLE";

            if (!Directory.Exists(disablePath))
                Directory.CreateDirectory(disablePath);
            //WEB
            if (File.Exists(exepath + "\\Web.lrmodule") && ckbxWeb.CheckState == CheckState.Checked)
                File.Move(exepath + "\\Web.lrmodule", disablePath + "\\Web.lrmodule");
            else if (File.Exists(disablePath + "\\Web.lrmodule") && ckbxWeb.CheckState == CheckState.Unchecked)
                File.Move(disablePath + "\\Web.lrmodule", exepath + "\\Web.lrmodule");

            //SLIDE
            if (File.Exists(exepath + "\\Slideshow.lrmodule") && ckbxSlideShow.CheckState == CheckState.Checked)
                File.Move(exepath + "\\Slideshow.lrmodule", disablePath + "\\Slideshow.lrmodule");
            else if (File.Exists(disablePath + "\\Slideshow.lrmodule") && ckbxSlideShow.CheckState == CheckState.Unchecked)
                File.Move(disablePath + "\\Slideshow.lrmodule", exepath + "\\Slideshow.lrmodule");
            //PRINT
            if (File.Exists(exepath + "\\Print.lrmodule") && ckbxPrint.CheckState == CheckState.Checked)
                File.Move(exepath + "\\Print.lrmodule", disablePath + "\\Print.lrmodule");
            else if (File.Exists(disablePath + "\\Print.lrmodule") && ckbxPrint.CheckState == CheckState.Unchecked)
                File.Move(disablePath + "\\Print.lrmodule", exepath + "\\Print.lrmodule");
            //MONITOR
            if (File.Exists(exepath + "\\MultipleMonitor.lrmodule") && ckbxMultiMonitor.CheckState == CheckState.Checked)
                File.Move(exepath + "\\MultipleMonitor.lrmodule", disablePath + "\\MultipleMonitor.lrmodule");
            else if (File.Exists(disablePath + "\\MultipleMonitor.lrmodule") && ckbxMultiMonitor.CheckState == CheckState.Unchecked)
                File.Move(disablePath + "\\MultipleMonitor.lrmodule", exepath + "\\MultipleMonitor.lrmodule");
            //MAP
            if (File.Exists(exepath + "\\Location.lrmodule") && ckbxMap.CheckState == CheckState.Checked)
                File.Move(exepath + "\\Location.lrmodule", disablePath + "\\Location.lrmodule");
            else if (File.Exists(disablePath + "\\Location.lrmodule") && ckbxMap.CheckState == CheckState.Unchecked)
                File.Move(disablePath + "\\Location.lrmodule", exepath + "\\Location.lrmodule");
            //LAYOUT
            if (File.Exists(exepath + "\\Layout.lrmodule") && ckbxLayout.CheckState == CheckState.Checked)
                File.Move(exepath + "\\Layout.lrmodule", disablePath + "\\Layout.lrmodule");
            else if (File.Exists(disablePath + "\\Layout.lrmodule") && ckbxLayout.CheckState == CheckState.Unchecked)
                File.Move(disablePath + "\\Layout.lrmodule", exepath + "\\Layout.lrmodule");
            //BOOK
            if (File.Exists(exepath + "\\Book.lrmodule") && ckbxBook.CheckState == CheckState.Checked)
                File.Move(exepath + "\\Book.lrmodule", disablePath + "\\Book.lrmodule");
            else if (File.Exists(disablePath + "\\Book.lrmodule") && ckbxBook.CheckState == CheckState.Unchecked)
                File.Move(disablePath + "\\Book.lrmodule", exepath + "\\Book.lrmodule");
        }

        #endregion

        #region PresetsLoaders

        private void CreatePresetCheckboxes()
        {
            string presetsdir = "";
           
            if (Directory.Exists(CRegistros.LoadAdobeInfoFromReg("premierepath")+ "Settings\\SequencePresets"))
            {
                presetsdir = CRegistros.LoadAdobeInfoFromReg("premierepath") + "Settings\\SequencePresets";
            }

            //presetsdir = @"C:\Windows\Help";
            if (!Directory.Exists(presetsdir))
                return;
            var dirinfo = new DirectoryInfo(presetsdir);
            checkedListBox1.Items.AddRange(dirinfo.GetDirectories());
        }

        private void CreateNotUsedPresets()
        {
            string presetsdir = "";
            string backupdir = "";

            if (Directory.Exists(CRegistros.LoadAdobeInfoFromReg("premierepath") + "Settings\\SequencePresets"))
            {
                presetsdir = CRegistros.LoadAdobeInfoFromReg("premierepath") + "Settings\\SequencePresets";
                backupdir = CRegistros.LoadAdobeInfoFromReg("premierepath") + "Settings\\Backup";
            }
         

            if (!Directory.Exists(presetsdir))
                return;
            if (!Directory.Exists(backupdir))
                Directory.CreateDirectory(backupdir);
            //directoryInfo.Name +"\\"+checkedItem == Help\Checkedlist
            //directoryInfo.Fullname +"\\"+checkedItem == C:\Windows\Help\Checkedlist
            //Path.GetFileName(presetsdir + "\\" + checkedItem) = Folder Name
            foreach (var checkedItem in checkedListBox1.CheckedItems)
            {
                if (checkedListBox1.GetItemCheckState(checkedListBox1.Items.IndexOf(checkedItem)) == CheckState.Checked)
                {
                    if (Path.GetFileName(presetsdir + "\\" + checkedItem) == checkedItem.ToString())
                    {
                        //MessageBox.Show( Path.GetFileName(presetsdir + "\\" + checkedItem));
                        if (Directory.Exists(presetsdir + "\\" + checkedItem))
                            Directory.Move(presetsdir + "\\" + checkedItem, backupdir + "\\" + checkedItem);
                    }
                }
            }
            checkedListBox1.Items.Clear();
            CreatePresetCheckboxes();
        }

        private void ResetPresetsFromBackup()
        {
            string presetsdir = "";
            string backupdir = "";

            if (Directory.Exists(CRegistros.LoadAdobeInfoFromReg("premierepath") + "Settings\\SequencePresets"))
            {
                presetsdir = CRegistros.LoadAdobeInfoFromReg("premierepath") + "Settings\\SequencePresets";
                backupdir = CRegistros.LoadAdobeInfoFromReg("premierepath") + "Settings\\Backup";
            }

            if (!Directory.Exists(backupdir))
                return;

            if (Directory.Exists(backupdir))
                foreach (var folders in Directory.GetDirectories(backupdir))
                {
                    string namedirs = Path.GetFileName(folders);
                    Directory.Move(folders, presetsdir + "\\" + namedirs);
                    //MessageBox.Show(folders + "\n" + presetsdir + "\n"+ teste);
                }
            checkedListBox1.Items.Clear();
            CreatePresetCheckboxes();
        }

        #endregion

        #region SelectPath

        private void btnMediaCache_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog localsalvar = new FolderBrowserDialog();

            if (localsalvar.ShowDialog() == DialogResult.OK)
            {
                tbxMediaCache.Text = localsalvar.SelectedPath;
                CRegistros.WriteUseStaticCacheDir(true);//Ativa o uso do diretorio estatico
                cEditor.WriteMediaCacheDirtoCommonKey(tbxMediaCache.Text);//Registrar o caminho especificado e salvar no registro
                cEditor.WritePremiereStaticMediaCacheDir();//Inicia os novos registros fixos
            }
        }

        private void btnEncoding_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog localsalvar = new FolderBrowserDialog();

            if (localsalvar.ShowDialog() == DialogResult.OK)
            {
                tbxEncoding.Text = localsalvar.SelectedPath;
            }
        }

        private void btnVideoPrev_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog localsalvar = new FolderBrowserDialog();

            if (localsalvar.ShowDialog() == DialogResult.OK)
            {
                tbxVideoPrev.Text = localsalvar.SelectedPath;
            }
        }

        private void btnAudioPrev_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog localsalvar = new FolderBrowserDialog();

            if (localsalvar.ShowDialog() == DialogResult.OK)
            {
                tbxAudioPrev.Text = localsalvar.SelectedPath;
            }
        }

        private void btnVideoCap_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog localsalvar = new FolderBrowserDialog();

            if (localsalvar.ShowDialog() == DialogResult.OK)
            {
                tbxVideoCap.Text = localsalvar.SelectedPath;
            }
        }

        private void btnAudioCap_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog localsalvar = new FolderBrowserDialog();

            if (localsalvar.ShowDialog() == DialogResult.OK)
            {
                tbxAudioCap.Text = localsalvar.SelectedPath;
            }
        }

        private void btnSetExportPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog localsalvar = new FolderBrowserDialog();

            if (localsalvar.ShowDialog() == DialogResult.OK)
            {
                tbxExportPath.Text = localsalvar.SelectedPath;
            }
        }

        #endregion

        #region BUTTONLED

        private void btnMediaCache_MouseHover(object sender, EventArgs e)
        {
            btnMediaCacheLED.BackColor = Color.Olive;
        }

        private void btnEncoding_MouseHover(object sender, EventArgs e)
        {
            btnEncodingLED.BackColor = Color.Orange;
        }

        private void btnVideoPrev_MouseHover(object sender, EventArgs e)
        {
            btnVideoPrevLED.BackColor = Color.OrangeRed;
        }

        private void btnAudioPrev_MouseHover(object sender, EventArgs e)
        {
            btnAudioPrevLED.BackColor = Color.MediumPurple;
        }

        private void btnVideoCap_MouseHover(object sender, EventArgs e)
        {
            btnVideoCapLED.BackColor = Color.PowderBlue;
        }

        private void btnAudioCap_MouseHover(object sender, EventArgs e)
        {
            btnAudioCapLED.BackColor = Color.SaddleBrown;
        }

        private void btnExportMediaPath_MouseHover(object sender, EventArgs e)
        {
            btnSetExportPathLED.BackColor = Color.Moccasin;
        }

        private void ResetAll_MouseLeave(object sender, EventArgs e)
        {
            btnVideoPrevLED.BackColor = DefaultBackColor;
            btnAudioPrevLED.BackColor = DefaultBackColor;
            btnEncodingLED.BackColor = DefaultBackColor;
            btnMediaCacheLED.BackColor = DefaultBackColor;
            btnVideoCapLED.BackColor = DefaultBackColor;
            btnAudioCapLED.BackColor = DefaultBackColor;
            btnSetExportPathLED.BackColor = DefaultBackColor;
        }

        #endregion

        private void btnCudaPatch_Click(object sender, EventArgs e)
        {
            string cudatxtfile = "";
            string raytracefile = "";
            List<string> CudaGPUs = new List<string>
                {
                    "GeForce GT 240",
                    "GeForce GTX 260",
                    "GeForce GTX 275",
                    "GeForce GTX 280",
                    "GeForce GTX 285",
                    "GeForce GTX 295",
                    "GeForce GT 340",
                    "GeForce GT 430",
                    "GeForce GT 440",
                    "GeForce GTS 450",
                    "GeForce GTX 460",
                    "GeForce GTX 470",
                    "GeForce GTX 480",
                    "GeForce GT 520",
                    "GeForce GT 530",
                    "GeForce GT 545",
                    "GeForce GTX 550 Ti",
                    "GeForce GTX 560 Ti",
                    "GeForce GTX 560",
                    "GeForce GTX 570",
                    "GeForce GTX 580",
                    "GeForce GTX 590",
                    "GeForce GT 605",
                    "GeForce GT 610",
                    "GeForce GT 630",
                    "GeForce GT 640",
                    "GeForce GTX 650 Ti",
                    "GeForce GTX 660",
                    "GeForce GTX 660 Ti",
                    "GeForce GTX 670",
                    "GeForce GTX 680",
                    "GeForce GTX 690",
                    "GeForce GTX 760",
                    "GeForce GTX 770",
                    "GeForce GTX 970",
                    "GeForce GTX 960",
                    "GeForce GTX 980",
                    "Quadro 2000",
                    "Quadro 4000",
                    "Quadro CX",
                    "Quadro FX 4800",
                    "Quadro FX 5800",
                    "Quadro 5000",
                    "Quadro 6000",
                    "Tesla C2075"
                };
            try
            {
                if (File.Exists(@"C:\Program Files\Adobe\Adobe Premiere Pro CC 2015\cuda_supported_cards.txt"))
                {
                    File.Delete(@"C:\Program Files\Adobe\Adobe Premiere Pro CC 2015\cuda_supported_cards.txt");
                    File.Delete(
                        @"C:\Program Files\Adobe\Adobe After Effects CC 2015\Support Files\raytracer_supported_cards.txt");
                    raytracefile =
                        @"C:\Program Files\Adobe\Adobe After Effects CC 2015\Support Files\raytracer_supported_cards.txt";
                    cudatxtfile = @"C:\Program Files\Adobe\Adobe Premiere Pro CC 2015\cuda_supported_cards.txt";
                }
                if (File.Exists(@"C:\Program Files\Adobe\Adobe Premiere Pro CS6\cuda_supported_cards.txt"))
                {
                    File.Delete(@"C:\Program Files\Adobe\Adobe Premiere Pro CS6\cuda_supported_cards.txt");
                    File.Delete(
                        @"C:\Program Files\Adobe\Adobe After Effects CS6\Support Files\raytracer_supported_cards.txt");
                    raytracefile =
                        @"C:\Program Files\Adobe\Adobe After Effects CS6\Support Files\raytracer_supported_cards.txt";
                    cudatxtfile = @"C:\Program Files\Adobe\Adobe Premiere Pro CS6\cuda_supported_cards.txt";
                }
                if (File.Exists(@"C:\Program Files\Adobe\Adobe Premiere Pro CS5.5\cuda_supported_cards.txt"))
                {
                    File.Delete(@"C:\Program Files\Adobe\Adobe Premiere Pro CS5.5\cuda_supported_cards.txt");
                    File.Delete(
                        @"C:\Program Files\Adobe\Adobe After Effects CS5.5\Support Files\raytracer_supported_cards.txt");
                    raytracefile =
                        @"C:\Program Files\Adobe\Adobe After Effects CS5.5\Support Files\raytracer_supported_cards.txt";
                    cudatxtfile = @"C:\Program Files\Adobe\Adobe Premiere Pro CS5.5\cuda_supported_cards.txt";
                }
                if (File.Exists(@"C:\Program Files\Adobe\Adobe Premiere Pro CS5\cuda_supported_cards.txt"))
                {
                    File.Delete(@"C:\Program Files\Adobe\Adobe Premiere Pro CS5\cuda_supported_cards.txt");
                    File.Delete(
                        @"C:\Program Files\Adobe\Adobe After Effects CS5\Support Files\raytracer_supported_cards.txt");
                    raytracefile =
                        @"C:\Program Files\Adobe\Adobe After Effects CS5\Support Files\raytracer_supported_cards.txt";
                    cudatxtfile = @"C:\Program Files\Adobe\Adobe Premiere Pro CS5\cuda_supported_cards.txt";
                }

                using (StreamWriter outputfile = new StreamWriter(cudatxtfile, true))
                {
                    foreach (var cudaGpU in CudaGPUs)
                    {
                        outputfile.WriteLine(cudaGpU);
                    }
                }
                using (StreamWriter outputfile = new StreamWriter(raytracefile, true))
                {
                    foreach (var cudaGpU in CudaGPUs)
                    {
                        outputfile.WriteLine(cudaGpU);
                    }
                    MessageBox.Show(@"Arquivo 'Cuda' atualizado !");
                }
            }
            catch (Exception)
            {
               cUtils.LogEmailSend("Erro ao patchear Cuda");
            }
  
        }

        private void btnHidePresets_Click(object sender, EventArgs e)
        {
            CreateNotUsedPresets();
        }

        private void btnRestorePresets_Click(object sender, EventArgs e)
        {
            ResetPresetsFromBackup();
        }


    }
}