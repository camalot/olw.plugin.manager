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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Extensions;
using Microsoft.Win32;

namespace olw.manager.plugin {
	internal class InstallInfo {
		public InstallInfo ( ) {
			using ( var r = Registry.CurrentUser.OpenSubKey(Constants.OLW_INSTALL_REGISTRY_PATH)) {
				r.Require ( "Open Live Writer install not found." );

				this.Icon = r.GetValue ( "DisplayIcon" ) as string;
				this.InstallLocation = new DirectoryInfo ( r.GetValue ( "InstallLocation" ) as string );
				this.Version = r.GetValue ( "DisplayVersion" ) as string;
				this.Name = r.GetValue ( "DisplayName" ) as string;
			}
		}
		public string Icon { get; set; }
		public string Name { get; set; }
		public string Version { get; set; }
		public DirectoryInfo InstallLocation { get; set; }

		public DirectoryInfo PluginFolder
		{
			get
			{
				return new DirectoryInfo ( Path.Combine ( InstallLocation.FullName, $"app-{Version}\\Plugins" ) );
			}
		}

		public DirectoryInfo DisabledPluginFolder
		{
			get
			{
				return new DirectoryInfo ( Path.Combine ( InstallLocation.FullName, $"app-{Version}\\PluginsDisabled" ) );
			}
		}
	}
}
