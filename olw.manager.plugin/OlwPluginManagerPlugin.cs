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
using OpenLiveWriter.Api;

namespace olw.manager.plugin {
	[OpenLiveWriter.Api.WriterPlugin ( "9aa348c5-64e5-4a91-b4a9-744a3b0482db", "OLW Plugin Manager", 
		Description = "Manage OLW Plugins", 
		ImagePath = "Images.olwpm.png", 
		HasEditableOptions = false )]
	[InsertableContentSource( "OLW Plugin Manager" )]
	public class OlwPluginManagerPlugin : ContentSource {
		public OlwPluginManagerPlugin ( ) {

		}

		public override void Initialize ( IProperties pluginOptions ) {
			base.Initialize ( pluginOptions );
		}

		public override DialogResult CreateContent ( IWin32Window dialogOwner, ref string content ) {
			var m = new Main ( );
			m.ShowDialog ( dialogOwner );
			return DialogResult.Cancel;
		}
	}
}
