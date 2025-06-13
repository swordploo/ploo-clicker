using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace plooClicker
{
    public static class SettingsService
    {
        private static readonly string _filePath = Path.Combine(Application.StartupPath, "settings.xml");

        public static void SaveSettings(AppSettings settings)
        {
            using (var writer = new StreamWriter(_filePath))
            {
                var serializer = new XmlSerializer(typeof(AppSettings));
                serializer.Serialize(writer, settings);
            }
        }

        public static AppSettings LoadSettings()
        {
            if (!File.Exists(_filePath))
            {
                var defaultSettings = new AppSettings();
                SaveSettings(defaultSettings);
                return defaultSettings;
            }
            try
            {
                using (var reader = new StreamReader(_filePath))
                {
                    var serializer = new XmlSerializer(typeof(AppSettings));
                    return (AppSettings)serializer.Deserialize(reader);
                }
            }
            catch
            {
                var defaultSettings = new AppSettings();
                SaveSettings(defaultSettings);
                return defaultSettings;
            }
        }
    }
}