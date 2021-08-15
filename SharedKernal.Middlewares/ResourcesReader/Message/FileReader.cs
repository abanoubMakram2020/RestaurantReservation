using Newtonsoft.Json;
using SharedKernal.Core.Common;
using SharedKernal.Core.Common.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SharedKernal.Middlewares.ResourcesReader.Message
{
    public abstract class FileReader
    {
        #region Vars
        private Dictionary<string, string> ResourceData { get; set; }
        #endregion

        public FileReader(ResourceEnum.LocalizationType localizationType)
        {
            LoadData(localizationType);
        }

        #region Load Data
        private void LoadData(ResourceEnum.LocalizationType localizationType)
        {
            string fileName = string.Format(localizationType.GetDescription(), System.Threading.Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName);
            var rootDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            ResourceData = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(Path.Combine(rootDir, "ResourceFiles", $"{fileName}.json")));
        }
        #endregion
        #region Get Data
        protected string GetKeyValue(string key) => ResourceData[key];
        #endregion
    }
}
