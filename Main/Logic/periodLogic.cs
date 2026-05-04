using Dysfunction.Data;
using Dysfunction.Model;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;

namespace Dysfunction.Logic
{
    public class periodLogic
    {
        periodData periodData = new periodData();
        asignatureLogic asignatureLogic = new asignatureLogic();
        projectLogic projectLogic = new projectLogic();

        public void NewObject(periodModel objectperiodModel)
        {
            periodData.AddNew(objectperiodModel);
        }

        public List<periodModel> Consult()
        {
            List<periodModel> periodModels = periodData.ConsultBD();
            periodModels.Reverse();
            return periodModels;
        }

        public void EditObject(periodModel objectperiodModel)
        {
            periodData.Edit(objectperiodModel);
        }

        public void DeleteObject(periodModel objectperiodModel)
        {
            // Eliminar proyectos asociados a cada asignatura del periodo
            if (objectperiodModel.Asignatures != null)
            {
                foreach (var code in objectperiodModel.Asignatures)
                {
                    // Elimina proyectos, archivos y carpetas asociadas a la asignatura en este periodo
                    projectLogic.DeleteSpecs(objectperiodModel.Year, objectperiodModel.Period, code);
                    projectLogic.DeletePros(code, objectperiodModel.Period, objectperiodModel.Year);
                    projectLogic.DeleteInds(code, objectperiodModel.Period, objectperiodModel.Year);
                    DeleteOriFile(code, objectperiodModel.Period, objectperiodModel.Year);
                    DeleteMatFile(code, objectperiodModel.Period, objectperiodModel.Year);
                }
                // Elimina todos los proyectos e indicaciones del periodo (por si acaso)
                projectLogic.DeleteAllProsForPeriod(objectperiodModel.Period, objectperiodModel.Year);
                projectLogic.DeleteAllIndsForPeriod(objectperiodModel.Period, objectperiodModel.Year);
            }

            // Finalmente elimina el periodo de la base de datos
            periodData.Delete(objectperiodModel);
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

        public bool oriExist(string code, string period, int year)
        {
            string fileNameBase = $"Orientation_{code}_{projectLogic.deleteSpaces(period)}_{year}";
            string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Orientation", $"{code}_{deleteSpaces(period)}_{year}");

            if (!Directory.Exists(targetDirectory))
                return false;

            string[] matchingFiles = Directory.GetFiles(targetDirectory, $"{fileNameBase}*.*");
            return matchingFiles.Length > 0;
        }

        public bool matExist(string code, string period, int year)
        {
            string fileNameBase = $"Material_{code}_{projectLogic.deleteSpaces(period)}_{year}";
            string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Material", $"{code}_{projectLogic.deleteSpaces(period)}_{year}");

            if (!Directory.Exists(targetDirectory))
                return false;

            string[] matchingFiles = Directory.GetFiles(targetDirectory, $"{fileNameBase}*.*");
            return matchingFiles.Length > 0;
        }

        public void SaveOri(string code, string period, int year, List<string> tempFilePaths)
        {
            string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Orientation", $"{code}_{projectLogic.deleteSpaces(period)}_{year}");
            Directory.CreateDirectory(targetDirectory);

            string fileNameBase = $"Orientation_{code}_{projectLogic.deleteSpaces(period)}_{year}";

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

        public void DeleteOriFile(string code, string period, int year)
        {
            string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Orientation", $"{code}_{projectLogic.deleteSpaces(period)}_{year}");

            if (!Directory.Exists(targetDirectory))
                return;

            string searchPattern = $"Orientation_{code}_{projectLogic.deleteSpaces(period)}_{year}*.*";
            string[] files = Directory.GetFiles(targetDirectory, searchPattern);

            foreach (string file in files)
            {
                if (File.Exists(file))
                {
                    FileSystem.DeleteFile(file, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                }
            }

            if (Directory.Exists(targetDirectory) && Directory.GetFiles(targetDirectory).Length == 0 && Directory.GetDirectories(targetDirectory).Length == 0)
            {
                Directory.Delete(targetDirectory, false);
            }
        }

        

        public void SaveMat(string code, string period, int year, List<string> tempFilePaths)
        {
            string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Material", $"{code}_{projectLogic.deleteSpaces(period)}_{year}");
            Directory.CreateDirectory(targetDirectory);

            string fileNameBase = $"Material_{code}_{projectLogic.deleteSpaces(period)}_{year}";

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

        public void DeleteMatFile(string code, string period, int year)
        {
            string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Material", $"{code}_{projectLogic.deleteSpaces(period)}_{year}");

            if (!Directory.Exists(targetDirectory))
                return;

            string searchPattern = $"Material_{code}_{projectLogic.deleteSpaces(period)}_{year}*.*";
            string[] files = Directory.GetFiles(targetDirectory, searchPattern);

            foreach (string file in files)
            {
                if (File.Exists(file))
                {
                    FileSystem.DeleteFile(file, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                }
            }

            if (Directory.Exists(targetDirectory) && Directory.GetFiles(targetDirectory).Length == 0 && Directory.GetDirectories(targetDirectory).Length == 0)
            {
                Directory.Delete(targetDirectory, false);
            }
        }


        public List<string> GetExistingOriFiles(string code, string period, int year)
        {
            string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Orientation", $"{code}_{deleteSpaces(period)}_{year}");
            if (!Directory.Exists(targetDirectory)) return new List<string>();

            string fileNameBase = $"Orientation_{code}_{deleteSpaces(period)}_{year}";
            var files = Directory.GetFiles(targetDirectory, $"{fileNameBase}*.*")
                .OrderBy(f => GetFileSuffix(f, fileNameBase))
                .ToList();
            return files;
        }

        public List<string> GetExistingMatFiles(string code, string period, int year)
        {
            string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Material", $"{code}_{deleteSpaces(period)}_{year}");
            if (!Directory.Exists(targetDirectory)) return new List<string>();

            string fileNameBase = $"Material_{code}_{deleteSpaces(period)}_{year}";
            var files = Directory.GetFiles(targetDirectory, $"{fileNameBase}*.*")
                .OrderBy(f => GetFileSuffix(f, fileNameBase))
                .ToList();
            return files;
        }

        public void DeleteLatestOri(string code, string period, int year)
        {
            string baseDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Orientation", $"{code}_{deleteSpaces(period)}_{year}");
            if (!Directory.Exists(baseDirectory)) return;

            string fileNameBase = $"Orientation_{code}_{deleteSpaces(period)}_{year}";
            string[] matchingFiles = Directory.GetFiles(baseDirectory, $"{fileNameBase}*.*");

            if (matchingFiles.Length == 0) return;

            var sortedFiles = matchingFiles
                .Select(f => new { Path = f, Suffix = GetFileSuffix(f, fileNameBase) })
                .OrderByDescending(f => f.Suffix)
                .ToList();

            string fileToDelete = sortedFiles.First().Path;
            if (File.Exists(fileToDelete))
            {
                FileSystem.DeleteFile(fileToDelete, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
            }

            if (Directory.GetFiles(baseDirectory).Length == 0 && Directory.GetDirectories(baseDirectory).Length == 0)
            {
                Directory.Delete(baseDirectory, false);
            }
        }

        public void DeleteLatestMat(string code, string period, int year)
        {
            string baseDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Material", $"{code}_{deleteSpaces(period)}_{year}");
            if (!Directory.Exists(baseDirectory)) return;

            string fileNameBase = $"Material_{code}_{deleteSpaces(period)}_{year}";
            string[] matchingFiles = Directory.GetFiles(baseDirectory, $"{fileNameBase}*.*");

            if (matchingFiles.Length == 0) return;

            var sortedFiles = matchingFiles
                .Select(f => new { Path = f, Suffix = GetFileSuffix(f, fileNameBase) })
                .OrderByDescending(f => f.Suffix)
                .ToList();

            string fileToDelete = sortedFiles.First().Path;
            if (File.Exists(fileToDelete))
            {
                FileSystem.DeleteFile(fileToDelete, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
            }

            if (Directory.GetFiles(baseDirectory).Length == 0 && Directory.GetDirectories(baseDirectory).Length == 0)
            {
                Directory.Delete(baseDirectory, false);
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

        public bool ValidNotNull(string p)
        {
            if (string.IsNullOrEmpty(p)) return false;

            return true;
        }
    }
}