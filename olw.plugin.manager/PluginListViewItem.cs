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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace olw.plugin.manager {
	internal class PluginListViewItem : ListViewItem {
		public PluginListViewItem ( PluginFileInfo pfi, PluginFileInfoData pfid ) : base(pfid.Name, pfid.ImagePath) {
			this.ImageKey = pfid.ImagePath;
			this.SubItems.Add ( new ListViewItem.ListViewSubItem ( this, pfi.Enabled.ToString ( ) ) );
			PluginFile = pfi;
			PluginInfo = pfid;
		}

		public PluginFileInfo PluginFile { get; set; }
		public PluginFileInfoData PluginInfo { get; set; }
	}
}
