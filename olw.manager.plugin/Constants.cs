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

namespace olw.manager.plugin {
	internal static class Constants {
		public static string ENABLED_PLUGIN_REGISTRY_PATH = @"Software\OpenLiveWriter\PluginAssemblies";
		public static string DISABLED_PLUGIN_REGISTRY_PATH = @"Software\OpenLiveWriter\DisabledPluginAssemblies";

		public static string OLW_INSTALL_REGISTRY_PATH = @"Software\Microsoft\Windows\CurrentVersion\Uninstall\OpenLiveWriter";

	}
}
