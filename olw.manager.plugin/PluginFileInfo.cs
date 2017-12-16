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
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Extensions;

namespace olw.manager.plugin {

	internal class PluginFileInfo {
		public string Name { get; set; }
		public FileInfo File { get; set; }
		public bool Enabled { get; set; }

		public bool IsAppLocal { get; set; }

		public IEnumerable<PluginFileInfoData> Plugins ( ) {
			var items = new List<PluginFileInfoData> ( );
			var pass = Assembly.LoadFile ( this.File.FullName );
			var types = pass.GetTypes ( ).Where ( m => m.HasAttribute<OpenLiveWriter.Api.WriterPluginAttribute> ( ) );
			foreach ( var type in types ) {
				var data = type.GetCustomAttribute<OpenLiveWriter.Api.WriterPluginAttribute> ( );
				var imageKey = $"{type.Namespace}.{data.ImagePath}";

				items.Add ( new PluginFileInfoData {
					Id = data.Id,
					Name = data.Name,
					ImagePath = imageKey,
					Description = data.Description,
					PublisherUrl = data.PublisherUrl,
					Image = new Bitmap ( pass.GetManifestResourceStream ( imageKey ) )
				} );
			}
			return items;
		}

	}
	internal class PluginFileInfoData {
		public string ImagePath { get; set; }
		public string Name { get; set; }
		public string Id { get; set; }
		public string Description { get; set; }
		public string PublisherUrl { get; set; }
		public Image Image { get; set; }
	}
}
