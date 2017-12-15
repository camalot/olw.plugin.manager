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


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Camalot.Common.Extensions;
using Microsoft.Win32;
using MoreLinq;
namespace olw.plugin.manager {
	public partial class Main : Form {
		private PluginManager PluginManager { get; set; }

		public Main ( ) {
			InitializeComponent ( );

			ReInitialize ( );
		}

		private void ReInitialize() {
			pluginList.Items.Clear ( );
			propertyGrid.SelectedObject = null;
			PluginManager = new PluginManager ( );

			var plugins = PluginManager.GetPlugins ( );
			foreach ( var plugin in plugins ) {
				foreach ( var p in plugin.Plugins ( ) ) {
					pluginList.SmallImageList.Images.Add ( p.ImagePath, p.Image );
					var imageIndex = pluginList.SmallImageList.Images.Count - 1;

					var lvi = new PluginListViewItem ( plugin, p );
					lvi.ImageIndex = imageIndex;
					pluginList.Items.Add ( lvi );
				}
			}
		}

		private void addPlugin_Click ( object sender, EventArgs e ) {
			using ( var ofd = new OpenFileDialog ( ) ) {
				ofd.Title = "Select Plugin to Install";
				ofd.Multiselect = false;
				ofd.Filter = "OLW Plugins|*plugin.dll|Libraries|*.dll|All Files|*.*";

				ofd.FilterIndex = 0;
				if ( ofd.ShowDialog ( this ) == DialogResult.OK ) {
					var file = ofd.FileName;
					var fname = Path.GetFileNameWithoutExtension ( file );
					var pfi = new PluginFileInfo ( ) {
						Name = fname,
						Enabled = true,
						File = new FileInfo ( file ),
						IsAppLocal = false
					};
					PluginManager.Add ( pfi );
					ReInitialize ( );
				}
			}
		}

		private void deletePlugin_Click ( object sender, EventArgs e ) {
			if ( pluginList.SelectedItems.Count == 0 ) {
				return;
			}
			var olvi = pluginList.SelectedItems[0] as PluginListViewItem;
			PluginManager.Remove ( olvi.PluginFile );
			ReInitialize ( );
		}

		private void disablePlugin_Click ( object sender, EventArgs e ) {
			if ( pluginList.SelectedItems.Count == 0 ) {
				return;
			}
			var olvi = pluginList.SelectedItems[0] as PluginListViewItem;
			PluginManager.Disable ( olvi.PluginFile );
			ReInitialize ( );
		}

		private void enablePlugin_Click ( object sender, EventArgs e ) {
			if ( pluginList.SelectedItems.Count == 0 ) {
				return;
			}
			var olvi = pluginList.SelectedItems[0] as PluginListViewItem;
			PluginManager.Enable ( olvi.PluginFile );
			ReInitialize ( );
		}

		private void pluginList_ItemSelectionChanged ( object sender, ListViewItemSelectionChangedEventArgs e ) {
			if ( e.Item == null || !e.IsSelected || e.ItemIndex == -1 ) {
				propertyGrid.SelectedObject = null;
				SetToolBarItemsState ( false, false, false );

				return;
			}

			var olvi = e.Item as PluginListViewItem;
			propertyGrid.SelectedObject = new PropertyGridPluginObject ( olvi.PluginFile, olvi.PluginInfo );

			SetToolBarItemsState ( true, olvi.PluginFile.Enabled, olvi.PluginFile.IsAppLocal );
		}

		private void SetToolBarItemsState ( bool selected, bool enabled, bool local ) {
			deletePlugin.Enabled = selected && !local;
			enablePlugin.Enabled = !enabled;
			disablePlugin.Enabled = enabled;
			enablePlugin.Visible = !enabled && selected;
			disablePlugin.Visible = enabled;
		}

	}
}
