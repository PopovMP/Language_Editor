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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Language_Editor
{
    public class TranslationManager
    {
        public Dictionary<string, Dictionary<string, string>> Translation { get; set; }
        public string LangFilePath { get; set; }
        public event EventHandler<ExecutionErrorEventArgs> ExecutionError;

        public void LoadTranslation(string path)
        {
            try
            {
                var xdoc = XDocument.Load(path);
                Translation = ParseLangFile(xdoc);
                LangFilePath = path;
            }
            catch (Exception e)
            {
                OnExecutionError(String.Format("Loading language file: {0}", e.Message));
            }
        }

        public void SaveTranslation(XDocument xdoc, string path)
        {
            try
            {
                xdoc.Save(path);
            }
            catch (Exception e)
            {
                OnExecutionError(String.Format("Saving language file: {0}", e.Message));
            }
        }

        private Dictionary<string, Dictionary<string, string>> ParseLangFile(XDocument xdoc)
        {
            var trans = new Dictionary<string, Dictionary<string, string>>();
            try
            {
                var xGroups = xdoc.Element("groups");
                if (xGroups != null)
                    xGroups.Elements().ToList().ForEach(group =>
                    {
                        var groupName = group.Name.ToString();
                        trans.Add(groupName, new Dictionary<string, string>());
                        group.Elements().ToList().ForEach(xPhrase =>
                        {
                            var eng = xPhrase.Element("eng").Value;
                            var alt = xPhrase.Element("alt").Value;
                            if (!trans[groupName].ContainsKey(eng))
                                trans[groupName].Add(eng, alt);
                        });
                    });
            }
            catch (Exception e)
            {
                OnExecutionError(String.Format("Parsing language file: {0}", e.Message));
            }
            return trans;
        }

        public XDocument CreateLangFile(Dictionary<string, Dictionary<string, string>> data)
        {
            return new XDocument(new XDeclaration("1.0", "utf-8", null),
                new XElement("groups", data.Select(group =>
                    new XElement(group.Key, group.Value.Select(phrase =>
                        new XElement("phrase",
                            new XElement("eng", phrase.Key),
                            new XElement("alt", phrase.Value)
                            ))))));
        }

        private XDocument CreateEnglishFile(Dictionary<string, Dictionary<string, string>> data)
        {
            return new XDocument(new XDeclaration("1.0", "utf-8", null),
                new XElement("groups", data.Select(group =>
                    new XElement(group.Key, group.Value.Select(phrase =>
                        new XElement("phrase",
                            new XElement("eng", phrase.Key),
                            new XElement("alt", phrase.Key)
                            ))))));
        }

        public void ExportEnglishPhrases(string path)
        {
            var sb = new StringBuilder();
            foreach (var phrases in Translation.Values)
                foreach (var phrase in phrases.Keys)
                    sb.AppendLine(phrase);
            var stream = File.CreateText(path);
            stream.Write(sb.ToString());
            stream.Flush();
            stream.Close();
        }

        public void ExportAlternativePhrases(string path)
        {
            var sb = new StringBuilder();
            foreach (var phrases in Translation.Values)
                foreach (var phrase in phrases.Values)
                    sb.AppendLine(phrase);
            var stream = File.CreateText(path);
            stream.Write(sb.ToString());
            stream.Flush();
            stream.Close();
        }

        public void ExportNewEnglishPhrases(string path)
        {
            var xdoc = CreateEnglishFile(Translation);
            SaveTranslation(xdoc, path);
        }

        public void ImportAlternativeTextFile(string path)
        {
            try
            {
                var reader = File.OpenText(path);
                var text = reader.ReadToEnd();
                reader.Close();
                var phrasesList = text.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
                var p = 0;

                var translation = new Dictionary<string, Dictionary<string, string>>();
                foreach (var groups in Translation)
                {
                    var group = groups.Value.Values.ToDictionary(phrase => phrase, phrase => phrasesList[p++]);
                    translation.Add(groups.Key, group);
                }
                Translation = translation;
            }
            catch (Exception e)
            {
                OnExecutionError(String.Format("Importing language file: {0}", e.Message));
            }
        }

        protected virtual void OnExecutionError(string message)
        {
            var handler = ExecutionError;
            if (handler != null) handler(this, new ExecutionErrorEventArgs(message));
        }

        public void ImportNewPhrasesFromTextFile(string path, string group)
        {
            try
            {
                var reader = File.OpenText(path);
                var text = reader.ReadToEnd();
                reader.Close();
                var phrasesList = text.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);

                foreach (var phrase in phrasesList)
                    if (!Translation[group].ContainsKey(phrase))
                        Translation[group].Add(phrase, phrase);
            }
            catch (Exception e)
            {
                OnExecutionError(String.Format("Add new phrases: {0}", e.Message));
            }
        }

        public bool ImportNewPhrasesFromLangFile(string path)
        {
            var changed = false;
            var xdoc = XDocument.Load(path);
            var lang = ParseLangFile(xdoc);

            foreach (var groupDict in lang)
            {
                var group = groupDict.Key;
                if (!Translation.ContainsKey(group))
                    Translation.Add(group, new Dictionary<string, string>());
                foreach (var phrase in groupDict.Value)
                    if (!Translation[group].ContainsKey(phrase.Key))
                    {
                        Translation[group].Add(phrase.Key, phrase.Key);
                        changed = true;
                    }
            }

            return changed;
        }
    }
}