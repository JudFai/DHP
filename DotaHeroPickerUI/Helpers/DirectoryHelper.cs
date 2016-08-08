using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPickerUI.Helpers
{
    static class DirectoryHelper
    {
        /// <summary>
        /// Создаёт дерево папок из пути, если его не существует
        /// </summary>
        /// <param name="path">Путь с именем файла</param>
        public static void CreateDirectory(string path)
        {
            var directoryPath = path.Substring(0, path.LastIndexOf(Path.GetFileName(path), StringComparison.Ordinal));
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
        }
    }
}
