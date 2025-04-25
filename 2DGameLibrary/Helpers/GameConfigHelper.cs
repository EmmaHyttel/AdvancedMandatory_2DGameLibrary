using GameLibrary.Enums;
using GameLibrary.Records;
using System.Xml;

namespace GameLibrary.Helpers
{
    public static class GameConfigHelper
    {
        public static GameConfig GetGameConfig()
        {
            XmlDocument configDocGame = new XmlDocument();
            string path = Environment.GetEnvironmentVariable("gameConfig");
            configDocGame.Load(path);

            int maxX = 0;
            int maxY = 0;
            GameLevel level = GameLevel.Normal;

            XmlNode? XMaxXML = configDocGame.DocumentElement.SelectSingleNode("MaxX");
            if (XMaxXML != null)
            {
                string maxXTxt = XMaxXML.InnerText.Trim();
                maxX = Convert.ToInt32(maxXTxt);
            }

            XmlNode? YMaxXML = configDocGame.DocumentElement.SelectSingleNode("MaxY");
            if (YMaxXML != null)
            {
                string maxYTxt = YMaxXML.InnerText.Trim();
                maxY = Convert.ToInt32(maxYTxt);
            }

            XmlNode? LevelXML = configDocGame.DocumentElement.SelectSingleNode("GameLevel");
            if (LevelXML != null)
            {
                string levelTxt = LevelXML.InnerText.Trim();

                if (!Enum.TryParse(levelTxt, true, out level)) // forsøg på at konvertere level fra string til Enum, samt gøres case-insensitive
                {
                    Console.WriteLine($"{levelTxt} is not a valid GameLavel. Level is now: {level}");
                }
            }

            XmlNode? ImNullXml = configDocGame.DocumentElement.SelectSingleNode("IamNull");
            if (ImNullXml == null || ImNullXml.Attributes["xsi:nil"]?.Value == "true")
            {
                Console.WriteLine("i am null");
            }
            else
            {
                Console.WriteLine("text::" + ImNullXml.InnerText.Trim() + "::");
            }

            Console.WriteLine("Max X is " + maxX + " and Max Y is" + maxY + " the Level is " + level);

            return new GameConfig
            {
                MaxX = maxX,
                MaxY = maxY,
                GameLevel = level
            };
        }
    }
}
