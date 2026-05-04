using Dysfunction.Data;
using Dysfunction.Model;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using static System.Formats.Asn1.AsnWriter;

namespace Dysfunction.Logic
{
    public class projectLogic
    {
        projectData projectData = new projectData();

        public void NewObject(projectModel objectProjectModel)
        {
            projectData.AddNew(objectProjectModel);
        }

        public List<projectModel> Consult()
        {
            List<projectModel> projectModels = projectData.ConsultBD();
            projectModels.Reverse();
            return projectModels;
        }

        public string deleteSpaces(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            // Eliminar el primer espacio (si existe)
            int primerEspacio = input.IndexOf(' ');
            if (primerEspacio >= 0)
            {
                string resultado = input.Remove(primerEspacio, 1);

                int segundoEspacio = resultado.IndexOf(' ', primerEspacio);
                if (segundoEspacio >= 0)
                {
                    resultado = resultado.Substring(0, segundoEspacio);
                }

                return resultado;
            }

            return input;
        }

        public void EditObject(projectModel objectProjectModel)
        {
            projectData.Edit(objectProjectModel);
        }

        public void Delete(projectModel objectProjectModel)
        {
            projectData.Delete(objectProjectModel);
        }

        public void DeleteSpecs(int year, string period, string code)
        {
            projectData.DeleteSpecs(year, period, code);
        }

        public void updateProject(projectModel updatedProject)
        {
            List<projectModel> projects = projectData.ConsultBD();
            var project = projects.FirstOrDefault(p => p.Period == updatedProject.Period && p.Code == updatedProject.Code && p.Project == updatedProject.Project);

            if (project != null)
            {
                project.Score = updatedProject.Score;
                projectData.Update(projects);
            }
        }

        public string GetShortenedFileName(string fileName)
        {
            const int maxLength = 12;

            if (fileName.Length > maxLength)
            {
                return fileName.Substring(0, maxLength) + "...";
            }

            return fileName;
        }

        public void SaveProMultiple(string project, string code, string period, int year, List<string> tempFilePaths)
        {
            string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Project", $"{code}_{deleteSpaces(period)}_{year}");
            Directory.CreateDirectory(targetDirectory);

            string fileNameBase = $"{project}_{code}_{deleteSpaces(period)}_{year}";

            if (tempFilePaths.Count == 0)
            {
                return; // No eliminar archivos si no hay nuevos archivos para copiar
            }

            List<string> toCopy = new List<string>();
            string tempDir = Path.GetTempPath();

            foreach (var path in tempFilePaths)
            {
                if (!File.Exists(path)) continue;

                if (Path.GetDirectoryName(path) == targetDirectory)
                {
                    // Existing file, create a temporary copy
                    string tempCopy = Path.Combine(tempDir, Guid.NewGuid().ToString() + Path.GetExtension(path));
                    try
                    {
                        File.Copy(path, tempCopy, true);
                        toCopy.Add(tempCopy);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error copying {path}: {ex.Message}");
                    }
                }
                else
                {
                    // New file
                    toCopy.Add(path);
                }
            }

            // Copy the files with incremental naming
            for (int i = 0; i < toCopy.Count; i++)
            {
                string tempFilePath = toCopy[i];
                if (!File.Exists(tempFilePath)) continue;

                string fileExtension = Path.GetExtension(tempFilePath).TrimStart('.');
                string newFileName = i == 0 ? $"{fileNameBase}.{fileExtension}" : $"{fileNameBase}_{i + 1}.{fileExtension}";
                string targetPath = Path.Combine(targetDirectory, newFileName);
                try
                {
                    File.Copy(tempFilePath, targetPath, true);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error copying to {targetPath}: {ex.Message}");
                }

                // Delete the temporary copy if it was created
                if (Path.GetDirectoryName(tempFilePath) == tempDir && File.Exists(tempFilePath))
                {
                    try
                    {
                        File.Delete(tempFilePath);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error deleting temp {tempFilePath}: {ex.Message}");
                    }
                }
            }
        }

        public bool ProjectExist(string project, string code, string period, int year)
        {
            string fileNameBase = $"{project}_{code}_{deleteSpaces(period)}_{year}";
            string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Project", $"{code}_{deleteSpaces(period)}_{year}");

            if (!Directory.Exists(targetDirectory))
                return false;

            string[] matchingFiles = Directory.GetFiles(targetDirectory, $"{fileNameBase}*.*");
            return matchingFiles.Length > 0;
        }
        public bool ProjectExist2(string project, string code, string period, int year)
        {
            string fileNameBase = $"{project}_{code}_{deleteSpaces(period)}_{year}_2";
            string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Project", $"{code}_{deleteSpaces(period)}_{year}");

            if (!Directory.Exists(targetDirectory))
                return false;

            string[] matchingFiles = Directory.GetFiles(targetDirectory, $"{fileNameBase}*.*");
            return matchingFiles.Length > 0;
        }


        public List<string> GetExistingProFiles(string project, string code, string period, int year)
        {
            string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Project", $"{code}_{deleteSpaces(period)}_{year}");
            if (!Directory.Exists(targetDirectory)) return new List<string>();

            string fileNameBase = $"{project}_{code}_{deleteSpaces(period)}_{year}";
            var files = Directory.GetFiles(targetDirectory, $"{fileNameBase}*.*")
                .OrderBy(f => GetFileSuffix(f, fileNameBase))
                .ToList();
            return files;
        }

        public void DeleteAllProsForPeriod(string period, int year)
        {
            string baseDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Project");
            if (Directory.Exists(baseDirectory))
            {
                // Buscar subcarpetas que coincidan con el patrón {code}_{period}_{year}
                string dirPattern = $"*_{deleteSpaces(period)}_{year}";
                foreach (var subDir in Directory.GetDirectories(baseDirectory, dirPattern))
                {
                    // Buscar archivos que coincidan con el patrón *_{period}_{year}*.* (incluye sufijos numéricos)
                    string filePattern = $"*_{deleteSpaces(period)}_{year}*.*";
                    string[] matchingFiles = Directory.GetFiles(subDir, filePattern);

                    foreach (string file in matchingFiles)
                    {
                        FileSystem.DeleteFile(file, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    }

                    // Elimina la subcarpeta si queda vacía
                    if (Directory.GetFiles(subDir).Length == 0 && Directory.GetDirectories(subDir).Length == 0)
                    {
                        Directory.Delete(subDir, false);
                    }
                }
            }
        }

        public void DeletePros(string code, string period, int year)
        {
            string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Project", $"{code}_{deleteSpaces(period)}_{year}");

            if (Directory.Exists(targetDirectory))
            {
                // Buscar archivos que coincidan con el patrón *_{code}_{period}_{year}*.* (incluye sufijos numéricos)
                string filePattern = $"*_{code}_{deleteSpaces(period)}_{year}*.*";
                string[] matchingFiles = Directory.GetFiles(targetDirectory, filePattern);

                foreach (string file in matchingFiles)
                {
                    if (File.Exists(file))
                    {
                        FileSystem.DeleteFile(file, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    }
                }

                // Elimina la subcarpeta si queda vacía
                if (Directory.GetFiles(targetDirectory).Length == 0 && Directory.GetDirectories(targetDirectory).Length == 0)
                {
                    Directory.Delete(targetDirectory, false);
                }
            }
        }

        public void DeleteProFile(string project, string code, string period, int year)
        {
            string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Project", $"{code}_{deleteSpaces(period)}_{year}");

            if (!Directory.Exists(targetDirectory))
                return;

            // Buscar archivos que coincidan con el patrón {project}_{code}_{period}_{year}*.* (incluye sufijos numéricos)
            string searchPattern = $"{project}_{code}_{deleteSpaces(period)}_{year}*.*";
            string[] files = Directory.GetFiles(targetDirectory, searchPattern);

            foreach (string file in files)
            {
                if (File.Exists(file))
                {
                    FileSystem.DeleteFile(file, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                }
            }

            // Elimina la subcarpeta si queda vacía
            if (Directory.Exists(targetDirectory) && Directory.GetFiles(targetDirectory).Length == 0 && Directory.GetDirectories(targetDirectory).Length == 0)
            {
                Directory.Delete(targetDirectory, false);
            }
        }

        public void SaveIndMultiple(string project, string code, string period, int year, List<string> tempFilePaths)
        {
            string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Indication", $"{code}_{deleteSpaces(period)}_{year}");
            Directory.CreateDirectory(targetDirectory);

            string fileNameBase = $"Indication_{project}_{code}_{deleteSpaces(period)}_{year}";

            if (tempFilePaths.Count == 0)
            {
                return; // No eliminar archivos si no hay nuevos archivos para copiar
            }

            List<string> toCopy = new List<string>();
            string tempDir = Path.GetTempPath();

            foreach (var path in tempFilePaths)
            {
                if (!File.Exists(path)) continue;

                if (Path.GetDirectoryName(path) == targetDirectory)
                {
                    // Existing file, create a temporary copy
                    string tempCopy = Path.Combine(tempDir, Guid.NewGuid().ToString() + Path.GetExtension(path));
                    try
                    {
                        File.Copy(path, tempCopy, true);
                        toCopy.Add(tempCopy);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error copying {path}: {ex.Message}");
                    }
                }
                else
                {
                    // New file
                    toCopy.Add(path);
                }
            }

            // Copy the files with incremental naming
            for (int i = 0; i < toCopy.Count; i++)
            {
                string tempFilePath = toCopy[i];
                if (!File.Exists(tempFilePath)) continue;

                string fileExtension = Path.GetExtension(tempFilePath).TrimStart('.');
                string newFileName = i == 0 ? $"{fileNameBase}.{fileExtension}" : $"{fileNameBase}_{i + 1}.{fileExtension}";
                string targetPath = Path.Combine(targetDirectory, newFileName);
                try
                {
                    File.Copy(tempFilePath, targetPath, true);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error copying to {targetPath}: {ex.Message}");
                }

                // Delete the temporary copy if it was created
                if (Path.GetDirectoryName(tempFilePath) == tempDir && File.Exists(tempFilePath))
                {
                    try
                    {
                        File.Delete(tempFilePath);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error deleting temp {tempFilePath}: {ex.Message}");
                    }
                }
            }
        }

        public bool IndicationExist(string project, string code, string period, int year)
        {
            string fileNameBase = $"Indication_{project}_{code}_{deleteSpaces(period)}_{year}";
            string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Indication", $"{code}_{deleteSpaces(period)}_{year}");

            if (!Directory.Exists(targetDirectory))
                return false;

            string[] matchingFiles = Directory.GetFiles(targetDirectory, $"{fileNameBase}*.*");
            return matchingFiles.Length > 0;
        }
        public bool IndicationExist2(string project, string code, string period, int year)
        {
            string fileNameBase = $"Indication_{project}_{code}_{deleteSpaces(period)}_{year}_2";
            string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Indication", $"{code}_{deleteSpaces(period)}_{year}");

            if (!Directory.Exists(targetDirectory))
                return false;

            string[] matchingFiles = Directory.GetFiles(targetDirectory, $"{fileNameBase}*.*");
            return matchingFiles.Length > 0;
        }

        public List<string> GetExistingIndFiles(string project, string code, string period, int year)
        {
            string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Indication", $"{code}_{deleteSpaces(period)}_{year}");
            if (!Directory.Exists(targetDirectory)) return new List<string>();

            string fileNameBase = $"Indication_{project}_{code}_{deleteSpaces(period)}_{year}";
            var files = Directory.GetFiles(targetDirectory, $"{fileNameBase}*.*")
                .OrderBy(f => GetFileSuffix(f, fileNameBase))
                .ToList();
            return files;
        }

        public void DeleteAllIndsForPeriod(string period, int year)
        {
            string baseDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Indication");
            if (Directory.Exists(baseDirectory))
            {
                // Buscar subcarpetas que coincidan con el patrón {code}_{period}_{year}
                string dirPattern = $"*_{deleteSpaces(period)}_{year}";
                foreach (var subDir in Directory.GetDirectories(baseDirectory, dirPattern))
                {
                    // Buscar archivos que coincidan con el patrón *_{period}_{year}*.* (incluye sufijos numéricos)
                    string filePattern = $"*_{deleteSpaces(period)}_{year}*.*";
                    string[] matchingFiles = Directory.GetFiles(subDir, filePattern);

                    foreach (string file in matchingFiles)
                    {
                        FileSystem.DeleteFile(file, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    }

                    // Elimina la subcarpeta si queda vacía
                    if (Directory.GetFiles(subDir).Length == 0 && Directory.GetDirectories(subDir).Length == 0)
                    {
                        Directory.Delete(subDir, false);
                    }
                }
            }
        }

        public void DeleteInds(string code, string period, int year)
        {
            string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Indication", $"{code}_{deleteSpaces(period)}_{year}");

            if (Directory.Exists(targetDirectory))
            {
                // Buscar archivos que coincidan con el patrón *_{code}_{period}_{year}*.* (incluye sufijos numéricos)
                string filePattern = $"*_{code}_{deleteSpaces(period)}_{year}*.*";
                string[] matchingFiles = Directory.GetFiles(targetDirectory, filePattern);

                foreach (string file in matchingFiles)
                {
                    if (File.Exists(file))
                    {
                        FileSystem.DeleteFile(file, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    }
                }

                // Elimina la subcarpeta si queda vacía
                if (Directory.GetFiles(targetDirectory).Length == 0 && Directory.GetDirectories(targetDirectory).Length == 0)
                {
                    Directory.Delete(targetDirectory, false);
                }
            }
        }

        public void DeleteIndFile(string project, string code, string period, int year)
        {
            string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Indication", $"{code}_{deleteSpaces(period)}_{year}");

            if (!Directory.Exists(targetDirectory))
                return;

            // Buscar archivos que coincidan con el patrón {project}_{code}_{period}_{year}*.* (incluye sufijos numéricos)
            string searchPattern = $"Indication_{project}_{code}_{deleteSpaces(period)}_{year}*.*";
            string[] files = Directory.GetFiles(targetDirectory, searchPattern);

            foreach (string file in files)
            {
                if (File.Exists(file))
                {
                    FileSystem.DeleteFile(file, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                }
            }

            // Elimina la subcarpeta si queda vacía
            if (Directory.Exists(targetDirectory) && Directory.GetFiles(targetDirectory).Length == 0 && Directory.GetDirectories(targetDirectory).Length == 0)
            {
                Directory.Delete(targetDirectory, false);
            }
        }

        public void DeleteLatestFile(string project, string code, string period, int year, string directoryType)
        {
            string baseDirectory = Path.Combine(Directory.GetCurrentDirectory(), directoryType, $"{code}_{deleteSpaces(period)}_{year}");
            if (!Directory.Exists(baseDirectory)) return;

            string fileNameBase = $"Indication_{project}_{code}_{deleteSpaces(period)}_{year}";
            string[] matchingFiles = Directory.GetFiles(baseDirectory, $"{fileNameBase}*.*");

            if (matchingFiles.Length == 0) return;

            // Sort files by suffix in descending order
            var sortedFiles = matchingFiles
                .Select(f => new { Path = f, Suffix = GetFileSuffix(f, fileNameBase) })
                .OrderByDescending(f => f.Suffix)
                .ToList();

            // Delete the file with the highest suffix (or base file if no suffix)
            string fileToDelete = sortedFiles.First().Path;
            if (File.Exists(fileToDelete))
            {
                FileSystem.DeleteFile(fileToDelete, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
            }

            // Remove empty directory
            if (Directory.GetFiles(baseDirectory).Length == 0 && Directory.GetDirectories(baseDirectory).Length == 0)
            {
                Directory.Delete(baseDirectory, false);
            }
        }

        public void DeleteSpecificFile(string filePath)
        {
            string baseDir = Directory.GetCurrentDirectory();
            string tempDir = Path.GetTempPath();
            if (File.Exists(filePath))
            {
                // Solo eliminar si el archivo está en los directorios "Project", "Indication" o temporal
                if (filePath.StartsWith(Path.Combine(baseDir, "Project")) ||
                    filePath.StartsWith(Path.Combine(baseDir, "Indication")) ||
                    filePath.StartsWith(tempDir))
                {
                    FileSystem.DeleteFile(filePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"No se eliminó {filePath}: no está en un directorio permitido.");
                }
            }

            // Esperar a que el archivo realmente se elimine
            int retries = 5;
            while (File.Exists(filePath) && retries-- > 0)
            {
                System.Threading.Thread.Sleep(100);
            }

            // Eliminar directorio si está vacío y no tiene atributos de solo lectura
            string directory = Path.GetDirectoryName(filePath);
            if (Directory.Exists(directory) &&
                Directory.GetFiles(directory).Length == 0 &&
                Directory.GetDirectories(directory).Length == 0)
            {
                // Quitar atributo de solo lectura si existe
                var dirInfo = new DirectoryInfo(directory);
                if ((dirInfo.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    dirInfo.Attributes &= ~FileAttributes.ReadOnly;
                }
                try
                {
                    Directory.Delete(directory, false);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"No se pudo eliminar el directorio {directory}: {ex.Message}");
                }
            }
        }

        public int GetFileSuffix(string filePath, string fileNameBase)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);

            // Check if fileName starts with fileNameBase
            if (!fileName.StartsWith(fileNameBase, StringComparison.OrdinalIgnoreCase))
                return 0;

            // Extract suffix if fileName is long enough
            if (fileName.Length > fileNameBase.Length)
            {
                string suffix = fileName.Substring(fileNameBase.Length).TrimStart('_');
                if (int.TryParse(suffix, out int number))
                    return number;
            }
            return 0;
        }

        public bool ValidNotNull(string p)
        {
            if (string.IsNullOrEmpty(p)) return false;

            return true;
        }

        public bool ValidFloat(string p)
        {
            try
            {
                if (string.IsNullOrEmpty(p))
                {
                    return true;
                }
                float value = float.Parse(p);
                if (value > 10)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public float MakeItReal(float obtain, float total, float maxValue)
        {
            float percentage = obtain / maxValue;

            float realValue = percentage * total;

            realValue = (float)Math.Round(realValue, 2);

            return realValue;
        }
    }
}