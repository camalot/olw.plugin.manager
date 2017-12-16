/*

Copyright 2017 Ryan Conrad

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at:

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.


*/

namespace olw.manager.plugin {
	partial class Main {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose ( bool disposing ) {
			if ( disposing && ( components != null ) ) {
				components.Dispose ( );
			}
			base.Dispose ( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ( ) {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.pluginList = new System.Windows.Forms.ListView();
			this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.enabledColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.propertyGrid = new System.Windows.Forms.PropertyGrid();
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.addPlugin = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.enablePlugin = new System.Windows.Forms.ToolStripButton();
			this.disablePlugin = new System.Windows.Forms.ToolStripButton();
			this.deletePlugin = new System.Windows.Forms.ToolStripButton();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pluginList
			// 
			this.pluginList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.enabledColumn});
			this.pluginList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pluginList.FullRowSelect = true;
			this.pluginList.GridLines = true;
			this.pluginList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.pluginList.HideSelection = false;
			this.pluginList.LargeImageList = this.imageList;
			this.pluginList.Location = new System.Drawing.Point(0, 0);
			this.pluginList.MultiSelect = false;
			this.pluginList.Name = "pluginList";
			this.pluginList.ShowGroups = false;
			this.pluginList.Size = new System.Drawing.Size(339, 484);
			this.pluginList.SmallImageList = this.imageList;
			this.pluginList.StateImageList = this.imageList;
			this.pluginList.TabIndex = 0;
			this.pluginList.UseCompatibleStateImageBehavior = false;
			this.pluginList.View = System.Windows.Forms.View.Details;
			this.pluginList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.pluginList_ItemSelectionChanged);
			// 
			// nameColumn
			// 
			this.nameColumn.Text = "Name";
			this.nameColumn.Width = 270;
			// 
			// enabledColumn
			// 
			this.enabledColumn.Text = "Enabled";
			// 
			// imageList
			// 
			this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// propertyGrid
			// 
			this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyGrid.Location = new System.Drawing.Point(0, 5);
			this.propertyGrid.Name = "propertyGrid";
			this.propertyGrid.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
			this.propertyGrid.Size = new System.Drawing.Size(422, 507);
			this.propertyGrid.TabIndex = 1;
			this.propertyGrid.ToolbarVisible = false;
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.BottomToolStripPanel
			// 
			this.toolStripContainer1.BottomToolStripPanel.Enabled = false;
			this.toolStripContainer1.BottomToolStripPanelVisible = false;
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.Controls.Add(this.pluginList);
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(339, 484);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// toolStripContainer1.LeftToolStripPanel
			// 
			this.toolStripContainer1.LeftToolStripPanel.Enabled = false;
			this.toolStripContainer1.LeftToolStripPanelVisible = false;
			this.toolStripContainer1.Location = new System.Drawing.Point(5, 5);
			this.toolStripContainer1.Name = "toolStripContainer1";
			// 
			// toolStripContainer1.RightToolStripPanel
			// 
			this.toolStripContainer1.RightToolStripPanel.Enabled = false;
			this.toolStripContainer1.RightToolStripPanelVisible = false;
			this.toolStripContainer1.Size = new System.Drawing.Size(339, 507);
			this.toolStripContainer1.TabIndex = 2;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPlugin,
            this.toolStripSeparator1,
            this.enablePlugin,
            this.disablePlugin,
            this.deletePlugin});
			this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip1.Size = new System.Drawing.Size(339, 23);
			this.toolStrip1.Stretch = true;
			this.toolStrip1.TabIndex = 0;
			// 
			// addPlugin
			// 
			this.addPlugin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.addPlugin.Image = global::olw.manager.plugin.Properties.Resources.folderadd;
			this.addPlugin.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.addPlugin.Name = "addPlugin";
			this.addPlugin.Size = new System.Drawing.Size(23, 20);
			this.addPlugin.Text = "Add Plugin";
			this.addPlugin.Click += new System.EventHandler(this.addPlugin_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
			// 
			// enablePlugin
			// 
			this.enablePlugin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.enablePlugin.Image = global::olw.manager.plugin.Properties.Resources.play;
			this.enablePlugin.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.enablePlugin.Name = "enablePlugin";
			this.enablePlugin.Size = new System.Drawing.Size(23, 20);
			this.enablePlugin.Text = "Enable Plugin";
			this.enablePlugin.Visible = false;
			this.enablePlugin.Click += new System.EventHandler ( this.enablePlugin_Click );
			// 
			// disablePlugin
			// 
			this.disablePlugin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.disablePlugin.Enabled = false;
			this.disablePlugin.Image = global::olw.manager.plugin.Properties.Resources.pause;
			this.disablePlugin.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.disablePlugin.Name = "disablePlugin";
			this.disablePlugin.Size = new System.Drawing.Size(23, 20);
			this.disablePlugin.Text = "Disable Plugin";
			this.disablePlugin.Click += new System.EventHandler(this.disablePlugin_Click);
			// 
			// deletePlugin
			// 
			this.deletePlugin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.deletePlugin.Enabled = false;
			this.deletePlugin.Image = global::olw.manager.plugin.Properties.Resources.delete;
			this.deletePlugin.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.deletePlugin.Name = "deletePlugin";
			this.deletePlugin.Size = new System.Drawing.Size(23, 20);
			this.deletePlugin.Text = "Remove Plugin";
			this.deletePlugin.Click += new System.EventHandler(this.deletePlugin_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.toolStripContainer1);
			this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.propertyGrid);
			this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
			this.splitContainer1.Size = new System.Drawing.Size(775, 517);
			this.splitContainer1.SplitterDistance = 344;
			this.splitContainer1.TabIndex = 3;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(775, 517);
			this.Controls.Add(this.splitContainer1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(791, 556);
			this.Name = "Main";
			this.Text = "OLW Plugin Manager";
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView pluginList;
		private System.Windows.Forms.PropertyGrid propertyGrid;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ColumnHeader nameColumn;
		private System.Windows.Forms.ColumnHeader enabledColumn;
		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton addPlugin;
		private System.Windows.Forms.ToolStripButton deletePlugin;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton enablePlugin;
		private System.Windows.Forms.ToolStripButton disablePlugin;
	}
}

