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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace olw.manager.plugin {
	class PropertyGridPluginObject {
		public PropertyGridPluginObject ( PluginFileInfo pfi, PluginFileInfoData pfid ) {
			PluginFileInfo = pfi;
			PluginFileInfoData = pfid;
		}

		public PropertyGridPluginObject ( ) {

		}

		private PluginFileInfo PluginFileInfo { get; set; }
		private PluginFileInfoData PluginFileInfoData { get; set; }


		public string Id => PluginFileInfoData.Id;
		[Description("Name of the plugin.")]
		[DisplayName("(Name)")]
		public string Name => PluginFileInfoData.Name;
		[Description("This is the name of the plugin in the registry, or the name of the library name.")]
		public string ReferenceName => PluginFileInfo.Name;
		[Description("The publisher url.")]
		public string PublisherUrl => PluginFileInfoData.PublisherUrl;
		[Description("The display image for the plugin.")]
		public Image Image => PluginFileInfoData.Image;
		[Description("The description of the plugin.")]
		public string Description => PluginFileInfoData.Description;
		[Description("The full path of the plugin library.")]
		public string File => PluginFileInfo.File.FullName;
		[Description("Is the plugin currently in a folder/location that will be picked up by OLW.")]
		public bool Enabled => PluginFileInfo.Enabled;
		[Description("This indicates if the plugin is local to the OLW install directory, or if it is defined in the registry.")]
		public bool IsInAppDirectory => PluginFileInfo.IsAppLocal;
	}
}
