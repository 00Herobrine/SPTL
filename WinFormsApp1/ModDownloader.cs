﻿using SPTLauncher.Constructors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1;

namespace SPTLauncher
{
    public partial class ModDownloader : Form
    {
        private ModManager modManager;
        public static ModDownloader form;
        private int page = 1;
        public ModDownloader()
        {
            InitializeComponent();
            modManager ??= new ModManager();
            form = this;
        }

        private void ModDownloader_Load(object sender, EventArgs e)
        {

        }

        public void AddMod(ModDownload mod)
        {
            modList.Items.Add(mod);
        }

        private async void modList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modList.SelectedIndex == modList.Items.Count - 1)
            {
                page++;
                await modManager.WebRequestMods(page);
            }
            LoadMod(GetSelectedModDownload());
        }

        public ModDownload GetSelectedModDownload()
        {
            return (ModDownload)modList.SelectedItem;
        }

        public void LoadMod(ModDownload mod)
        {
            ModName.Text = mod.name;
            Author.Text = $"Author: {mod.author}";
            AkiVersion.Text = $"Version: {mod.AkiVersion}";
            ModImage.ImageLocation = mod.imageURL;
            Description.Text = mod.description;
            lastUpdated.Text = $"Updated: {mod.lastUpdated}";
            Downloads.Text = $"Downloads: {mod.downloads.Split(" ")[0]}";
            Rating.Text = $"Rating: {mod.stars}/5";
            Ratings.Text = $"Ratings: {mod.ratings}";
            Reviews.Text = $"Reviews: {mod.reviews}";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (GetSelectedModDownload() == null) return;
            Process.Start("explorer", GetSelectedModDownload().URL);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            page++;
            await modManager.WebRequestMods(page);
            //modManager.WebRequestMods(page++);
        }

        private void DownloadModButton_Click(object sender, EventArgs e)
        {
            ModDownload mod = GetSelectedModDownload();
            if (mod == null) return;
            Form1.form.log($"Downloading mod {mod.name}");
            _ = mod.Download();
        }
    }
}