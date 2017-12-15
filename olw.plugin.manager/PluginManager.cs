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
using MoreLinq;

namespace olw.plugin.manager {
	internal class PluginManager {

		public PluginManager ( ) {
			Intialize ( );
		}
		private InstallInfo InstallInfo { get; set; }

		private void Intialize ( ) {
			InstallInfo = new InstallInfo ( );
			using ( var pluginRegistry = Registry.CurrentUser.OpenSubKey ( Constants.DISABLED_PLUGIN_REGISTRY_PATH ) ) {
				if ( pluginRegistry == null ) {
					Registry.CurrentUser.CreateSubKey ( Constants.DISABLED_PLUGIN_REGISTRY_PATH );
				}
			}

			if ( !InstallInfo.DisabledPluginFolder.Exists ) {
				InstallInfo.DisabledPluginFolder.Create ( );
			}
		}


		public IEnumerable<PluginFileInfo> GetPlugins ( ) {
			var plugins = new List<PluginFileInfo> ( );
			using ( var pluginRegistry = Registry.CurrentUser.OpenSubKey ( Constants.ENABLED_PLUGIN_REGISTRY_PATH ) ) {
				pluginRegistry.GetValueNames ( ).ForEach ( ( name ) => {
					var file = pluginRegistry.GetValue ( name ) as String;
					if ( !string.IsNullOrWhiteSpace ( file ) && File.Exists ( file ) ) {
						plugins.Add ( new PluginFileInfo {
							Name = name,
							File = new FileInfo ( file ),
							Enabled = true
						} );
					}
				} );
			}

			if ( InstallInfo.PluginFolder.Exists ) {
				var pluginFiles = InstallInfo.PluginFolder.GetFiles ( "*plugin.dll", SearchOption.TopDirectoryOnly );
				foreach ( var f in pluginFiles ) {
					plugins.Add ( new PluginFileInfo {
						Name = Path.GetFileNameWithoutExtension ( f.Name ),
						Enabled = true,
						File = f,
						IsAppLocal = true
					} );
				}
			}

			using ( var pluginRegistry = Registry.CurrentUser.OpenSubKey ( Constants.DISABLED_PLUGIN_REGISTRY_PATH ) ) {
				pluginRegistry.GetValueNames ( ).ForEach ( ( name ) => {
					var file = pluginRegistry.GetValue ( name ) as String;
					if ( !string.IsNullOrWhiteSpace ( file ) && File.Exists ( file ) ) {
						plugins.Add ( new PluginFileInfo {
							Name = name,
							File = new FileInfo ( file ),
							Enabled = false
						} );
					}
				} );
			}

			if ( InstallInfo.DisabledPluginFolder.Exists ) {
				var pluginFiles = InstallInfo.PluginFolder.GetFiles ( "*plugin.dll", SearchOption.TopDirectoryOnly );
				foreach ( var f in pluginFiles ) {
					plugins.Add ( new PluginFileInfo {
						Name = Path.GetFileNameWithoutExtension ( f.Name ),
						Enabled = false,
						File = f,
						IsAppLocal = true
					} );
				}
			}

			return plugins;
		}


		public void Disable ( PluginFileInfo pfi ) {
			if ( pfi.IsAppLocal ) {
				DisableLocal ( pfi );
			} else {
				DisableRegistry ( pfi );
			}
		}

		private void DisableLocal ( PluginFileInfo pfi ) {
			pfi.File.Require ( );
			if ( pfi.File.Exists ) {
				pfi.File.MoveTo ( Path.Combine ( InstallInfo.DisabledPluginFolder.FullName, pfi.File.Name ) );
			}
		}

		private void DisableRegistry ( PluginFileInfo pfi ) {
			pfi.Name.Require ( );
			pfi.File.Require ( );
			using ( var pluginRegistry = Registry.CurrentUser.OpenSubKey ( Constants.ENABLED_PLUGIN_REGISTRY_PATH,true ) ) {
				if ( pluginRegistry.GetValueNames ( ).Contains ( pfi.Name ) ) {
					pluginRegistry.DeleteValue ( pfi.Name );
				}
			}
			using ( var pluginRegistry = Registry.CurrentUser.OpenSubKey ( Constants.DISABLED_PLUGIN_REGISTRY_PATH, true ) ) {
				if ( !pluginRegistry.GetValueNames ( ).Contains ( pfi.Name ) ) {
					pluginRegistry.SetValue ( pfi.Name, pfi.File.FullName );
				}
			}
		}


		public void Enable ( PluginFileInfo pfi ) {
			if ( pfi.IsAppLocal ) {
				EnableLocal ( pfi );
			} else {
				EnableRegistry ( pfi );
			}
		}

		private void EnableLocal ( PluginFileInfo pfi ) {
			pfi.File.Require ( );
			if ( pfi.File.Exists ) {
				pfi.File.MoveTo ( Path.Combine ( InstallInfo.PluginFolder.FullName, pfi.File.Name ) );
			}
		}

		private void EnableRegistry ( PluginFileInfo pfi ) {
			pfi.Name.Require ( );
			pfi.File.Require ( );
			using ( var pluginRegistry = Registry.CurrentUser.OpenSubKey ( Constants.DISABLED_PLUGIN_REGISTRY_PATH, true ) ) {
				if ( pluginRegistry.GetValueNames ( ).Contains ( pfi.Name ) ) {
					pluginRegistry.DeleteValue ( pfi.Name );
				}
			}
			using ( var pluginRegistry = Registry.CurrentUser.OpenSubKey ( Constants.ENABLED_PLUGIN_REGISTRY_PATH, true ) ) {
				if ( !pluginRegistry.GetValueNames ( ).Contains ( pfi.Name ) ) {
					pluginRegistry.SetValue ( pfi.Name, pfi.File.FullName );
				}
			}
		}

		public void Add ( PluginFileInfo pfi ) {
			var key = pfi.Enabled ? Constants.ENABLED_PLUGIN_REGISTRY_PATH : Constants.DISABLED_PLUGIN_REGISTRY_PATH;
			using ( var pluginRegistry = Registry.CurrentUser.OpenSubKey ( key, true ) ) {
				if(pluginRegistry.GetValueNames().Contains(pfi.Name)) {
					// already exists? what to do here?
					return;
				} else {
					pluginRegistry.SetValue ( pfi.Name, pfi.File.FullName );
				}
			}
		}

		public void Remove ( PluginFileInfo pfi ) {
			if ( pfi.IsAppLocal ) {
				RemoveLocal ( pfi );
			} else {
				RemoveRegistry ( pfi );
			}
		}


		private void RemoveLocal ( PluginFileInfo pfi ) {
			// right now, not removing local (install dir plugins)
			return;
		}

		private void RemoveRegistry ( PluginFileInfo pfi ) {
			var key = pfi.Enabled ? Constants.ENABLED_PLUGIN_REGISTRY_PATH : Constants.DISABLED_PLUGIN_REGISTRY_PATH;
			using ( var pluginRegistry = Registry.CurrentUser.OpenSubKey ( key, true ) ) {
				if ( !pluginRegistry.GetValueNames ( ).Contains ( pfi.Name ) ) {
					// doesnt exist
					return;
				} else {
					pluginRegistry.DeleteValue ( pfi.Name );
				}
			}
		}


	}
}
