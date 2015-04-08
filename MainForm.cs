//==============================================================
// Language Editor for Forex Strategy Builder
// Copyright © Miroslav Popov. All rights reserved.
//==============================================================
// THIS CODE IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE.
//==============================================================

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Language_Editor
{
    public partial class MainForm : Form
    {
        private const int TextBoxesMinimumHeight = 45;
        private const int Border = 5;
        private readonly TranslationManager translationManager;
        private TextBox[] altTextBoxes;
        private TextBox[] engTextBoxes;
        private bool isProgramChange;
        private bool isTranslationChanged;
        private int phrases;
        private int textBoxes = 5;

        public MainForm()
        {
            InitializeComponent();
            translationManager = new TranslationManager();
            translationManager.ExecutionError += TranslationManager_ExecutionError;
        }

        private void PnlEditor_Resize(object sender, EventArgs e)
        {
            DisposeTextBoxes();
            CreateTextBoxes();
            SetScrollBar();
            SetTextBoxes();
            SetTextBoxesStyle();
            ValidateGoNext();
        }

        private void SetScrollBar()
        {
            if (phrases == 0) return;

            if (phrases <= textBoxes)
            {
                vScrollBar.Enabled = false;
                vScrollBar.Value = 0;
            }
            else
            {
                var max = Math.Min(phrases, textBoxes);
                vScrollBar.Enabled = true;
                vScrollBar.SmallChange = 1;
                vScrollBar.LargeChange = (max/2);
                vScrollBar.Maximum = phrases - textBoxes + vScrollBar.LargeChange - 1;
                vScrollBar.Value = 0;
            }
        }

        private void CreateTextBoxes()
        {
            textBoxes = pnlEditor.Height/TextBoxesMinimumHeight;

            engTextBoxes = new TextBox[textBoxes];
            altTextBoxes = new TextBox[textBoxes];

            var tbxWidth = (pnlEditor.ClientSize.Width - 4*Border - vScrollBar.Width)/2;
            var tbxHeight = (pnlEditor.ClientSize.Height - (textBoxes + 1)*Border)/textBoxes;

            for (var i = 0; i < textBoxes; i++)
            {
                const int xMain = Border;
                var yMain = i*tbxHeight + (i + 1)*Border;
                var xAlt = 2*Border + tbxWidth;
                var yAlt = i*tbxHeight + (i + 1)*Border;

                engTextBoxes[i] = new TextBox
                {
                    Multiline = true,
                    Size = new Size(tbxWidth, tbxHeight),
                    Location = new Point(xMain, yMain),
                    Parent = pnlEditor,
                    ReadOnly = true,
                    Tag = -1
                };
                engTextBoxes[i].MouseWheel += TextBox_MouseWheel;

                altTextBoxes[i] = new TextBox
                {
                    Multiline = true,
                    Size = new Size(tbxWidth, tbxHeight),
                    Location = new Point(xAlt, yAlt),
                    Parent = pnlEditor,
                    Tag = i
                };
                altTextBoxes[i].MouseWheel += TextBox_MouseWheel;
                altTextBoxes[i].TextChanged += TextBox_TextChanged;
            }
        }

        private void DisposeTextBoxes()
        {
            if (engTextBoxes == null || engTextBoxes.Length < 1)
                return;

            foreach (var textBox in engTextBoxes)
            {
                textBox.MouseWheel -= TextBox_MouseWheel;
                textBox.TextChanged -= TextBox_TextChanged;
                textBox.Parent = null;
                textBox.Dispose();
            }
            foreach (var textBox in altTextBoxes)
            {
                textBox.MouseWheel -= TextBox_MouseWheel;
                textBox.Parent = null;
                textBox.Dispose();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DisposeTextBoxes();
            CreateTextBoxes();
            SetScrollBar();
            vScrollBar.Focus();

            itmExportAlt.Enabled = false;
            itmExportEng.Enabled = false;
            itmExportNewEnglish.Enabled = false;
            itmImportAlt.Enabled = false;
            itmAddNewPhrases.Enabled = false;
        }

        private void SetTextBoxes()
        {
            var group = cbxGroups.Text;
            if (String.IsNullOrEmpty(group) ||
                !translationManager.Translation.ContainsKey(group))
                return;

            phrases = translationManager.Translation[group].Count;
            var asMain = translationManager.Translation[group].Keys.ToArray();
            var asAlt = translationManager.Translation[group].Values.ToArray();

            isProgramChange = true;
            var max = Math.Min(textBoxes, phrases);
            for (var i = 0; i < max; i++)
            {
                var index = vScrollBar.Value + i;
                engTextBoxes[i].Text = asMain[index];
                altTextBoxes[i].Text = asAlt[index];
                engTextBoxes[i].Enabled = true;
                altTextBoxes[i].Enabled = true;
            }
            for (var i = max; i < textBoxes; i++)
            {
                engTextBoxes[i].Text = String.Empty;
                altTextBoxes[i].Text = String.Empty;
                engTextBoxes[i].Enabled = false;
                altTextBoxes[i].Enabled = false;
            }

            isProgramChange = false;

            lblPhrases.Text = phrases.ToString();
            altTextBoxes[0].Focus();
        }

        private void TextBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!vScrollBar.Enabled) return;
            if (e.Delta < 0 && vScrollBar.Value < vScrollBar.Maximum - vScrollBar.LargeChange + 1)
                vScrollBar.Value++;
            else if (e.Delta > 0 && vScrollBar.Value > 0)
                vScrollBar.Value--;
            else
                return;

            SetTextBoxes();
            SetTextBoxesStyle();
            ValidateGoNext();
        }

        private void ValidateGoNext()
        {
            var group = cbxGroups.Text;
            if (string.IsNullOrEmpty(group) ||
                !translationManager.Translation.ContainsKey(group))
                return;

            var count = translationManager.Translation[group].Count;
            var asMain = translationManager.Translation[group].Keys.ToArray();
            var asAlt = translationManager.Translation[group].Values.ToArray();

            btnNext.Enabled = false;
            var notTranslated = 0;
            for (var i = 0; i < count; i++)
            {
                if (asMain[i] == asAlt[i] ||
                    String.IsNullOrEmpty(asAlt[i]) && !String.IsNullOrEmpty(asMain[i]))
                {
                    btnNext.Enabled = true;
                    notTranslated++;
                }
            }

            lblNotTranslated.Text = notTranslated.ToString();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (isProgramChange) return;
            var group = cbxGroups.Text;
            if (String.IsNullOrEmpty(group) ||
                !translationManager.Translation.ContainsKey(group))
                return;
            var i = (int) ((TextBox) sender).Tag;
            translationManager.Translation[group][engTextBoxes[i].Text] = altTextBoxes[i].Text;
            isTranslationChanged = true;
            ValidateGoNext();
            SetTextBoxesStyle();
            SetFormText();
        }

        private void SetTextBoxesStyle()
        {
            for (var i = 0; i < textBoxes; i++)
            {
                altTextBoxes[i].BackColor = Color.White;
                if (engTextBoxes[i].Text == altTextBoxes[i].Text ||
                    String.IsNullOrEmpty(altTextBoxes[i].Text))
                    if (!String.IsNullOrEmpty(engTextBoxes[i].Text))
                        altTextBoxes[i].BackColor = Color.Yellow;
            }
        }

        private void GroupChanged()
        {
            var group = cbxGroups.Text;
            if (String.IsNullOrEmpty(group) ||
                !translationManager.Translation.ContainsKey(group))
                return;

            phrases = translationManager.Translation[group].Count;

            SetScrollBar();
            SetTextBoxes();
            SetTextBoxesStyle();
            ValidateGoNext();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            if (isTranslationChanged)
            {
                var messageResult = ShowNotSavedMessage();
                if (messageResult == DialogResult.Cancel)
                    return;
                if (messageResult == DialogResult.Yes)
                    SaveTranslation();
            }

            openFileDialog.DefaultExt = "xml";
            openFileDialog.Filter = "Language file|*.xml";
            var result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK) return;
            var path = openFileDialog.FileName;
            if (String.IsNullOrEmpty(path)) return;

            translationManager.LoadTranslation(path);

            if (translationManager.Translation == null) return;

            cbxGroups.Items.Clear();
            foreach (var group in translationManager.Translation.Keys)
                cbxGroups.Items.Add(group);
            cbxGroups.SelectedIndex = 0;

            itmExportAlt.Enabled = true;
            itmExportEng.Enabled = true;
            itmExportNewEnglish.Enabled = true;
            itmImportAlt.Enabled = true;
            itmAddNewPhrases.Enabled = true;

            SetFormText();
        }

        private static DialogResult ShowNotSavedMessage()
        {
            return MessageBox.Show("Current translation is changed." +
                                   Environment.NewLine + "Do you want to save the language file?",
                "Translation Changed", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
        }

        private void SaveTranslation()
        {
            var xdoc = translationManager.CreateLangFile(translationManager.Translation);
            translationManager.SaveTranslation(xdoc, translationManager.LangFilePath);
            isTranslationChanged = false;
            SetFormText();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveTranslation();
        }

        private void Groups_TextChanged(object sender, EventArgs e)
        {
            GroupChanged();
        }

        private void Groups_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupChanged();
        }

        private void ScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            SetTextBoxes();
            SetTextBoxesStyle();
            ValidateGoNext();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isTranslationChanged) return;
            var messageResult = ShowNotSavedMessage();
            if (messageResult == DialogResult.Cancel)
                e.Cancel = true;
            else if (messageResult == DialogResult.Yes)
                SaveTranslation();
        }

        private void SearchPhrase(string phrase)
        {
            phrase = phrase.ToLower();
            var group = cbxGroups.Text;
            if (String.IsNullOrEmpty(group) ||
                !translationManager.Translation.ContainsKey(group))
                return;

            var count = translationManager.Translation[group].Count;
            var asMain = translationManager.Translation[group].Keys.ToArray();
            var asAlt = translationManager.Translation[group].Values.ToArray();

            for (var i = vScrollBar.Value + 1; i < count; i++)
            {
                if (asMain[i].ToLower().Contains(phrase) ||
                    asAlt[i].ToLower().Contains(phrase))
                {
                    NavigateToNextMatch(i);
                    return;
                }
            }

            for (var i = 0; i < vScrollBar.Value + 1; i++)
            {
                if (asMain[i].ToLower().Contains(phrase) ||
                    asAlt[i].ToLower().Contains(phrase))
                {
                    NavigateToNextMatch(i);
                    return;
                }
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            var group = cbxGroups.Text;
            if (String.IsNullOrEmpty(group) ||
                !translationManager.Translation.ContainsKey(group))
                return;

            var count = translationManager.Translation[group].Count;
            var asMain = translationManager.Translation[group].Keys.ToArray();
            var asAlt = translationManager.Translation[group].Values.ToArray();

            for (var i = vScrollBar.Value + 1; i < count; i++)
            {
                if (asMain[i] == asAlt[i] || String.IsNullOrEmpty(asAlt[i]))
                {
                    NavigateToNextMatch(i);
                    return;
                }
            }

            for (var i = 0; i < vScrollBar.Value + 1; i++)
            {
                if (asMain[i] == asAlt[i] || String.IsNullOrEmpty(asAlt[i]))
                {
                    NavigateToNextMatch(i);
                    return;
                }
            }
        }

        private void NavigateToNextMatch(int i)
        {
            vScrollBar.Value = Math.Min(i, phrases - textBoxes);
            SetTextBoxes();
            SetTextBoxesStyle();
        }

        private void TbxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                if (!String.IsNullOrEmpty(tbxSearch.Text))
                    SearchPhrase(tbxSearch.Text);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxSearch.Text))
                SearchPhrase(tbxSearch.Text);
        }

        private void ItmExportEng_Click(object sender, EventArgs e)
        {
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "Text file|*.txt";
            var result = saveFileDialog.ShowDialog();
            if (result == DialogResult.Cancel) return;
            var path = saveFileDialog.FileName;
            if (String.IsNullOrEmpty(path)) return;
            translationManager.ExportEnglishPhrases(path);
        }

        private void ItmExportAlt_Click(object sender, EventArgs e)
        {
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "Text file|*.txt";
            var result = saveFileDialog.ShowDialog();
            if (result == DialogResult.Cancel) return;
            var path = saveFileDialog.FileName;
            if (String.IsNullOrEmpty(path)) return;
            translationManager.ExportAlternativePhrases(path);
        }

        private void ItmImportAlt_Click(object sender, EventArgs e)
        {
            var path = GetTxtFilePath();
            if (String.IsNullOrEmpty(path)) return;
            translationManager.ImportAlternativeTextFile(path);
            GroupChanged();
            SetFormText();
        }

        private string GetTxtFilePath()
        {
            openFileDialog.DefaultExt = "txt";
            openFileDialog.Filter = "Text file|*.txt";
            var result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK) return String.Empty;
            return openFileDialog.FileName;
        }

        private void ItmExportNewEnglish_Click(object sender, EventArgs e)
        {
            saveFileDialog.DefaultExt = "xml";
            saveFileDialog.Filter = "Language file|*.xml";
            var result = saveFileDialog.ShowDialog();
            if (result == DialogResult.Cancel) return;
            var path = saveFileDialog.FileName;
            if (String.IsNullOrEmpty(path)) return;
            translationManager.ExportNewEnglishPhrases(path);
        }

        private void SetFormText()
        {
            const string name = "Language Editor";
            var lang = String.IsNullOrEmpty(translationManager.LangFilePath)
                ? String.Empty
                : " - " + Path.GetFileNameWithoutExtension(translationManager.LangFilePath);
            var star = isTranslationChanged ? "*" : String.Empty;
            Text = name + lang + star;
        }

        private void TranslationManager_ExecutionError(object sender, ExecutionErrorEventArgs e)
        {
            MessageBox.Show(e.ErrorMessage, "Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ItmSupportForum_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("http://forexsb.com/forum/");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void ItmAbout_Click(object sender, EventArgs e)
        {
            var about = new AboutBox();
            about.ShowDialog();
        }

        private void ItmAddNewPhrases_Click(object sender, EventArgs e)
        {
            var group = cbxGroups.Text;
            if (String.IsNullOrEmpty(group) ||
                !translationManager.Translation.ContainsKey(group))
                return;

            var path = GetTxtFilePath();
            if (String.IsNullOrEmpty(path)) return;
            translationManager.ImportNewPhrasesFromTextFile(path, group);
            isTranslationChanged = true;
            GroupChanged();
            SetFormText();
        }
    }
}