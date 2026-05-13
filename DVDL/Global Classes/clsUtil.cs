using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL.Global_Classes
{
    internal class clsUtil
    {

        public static string GenerateGUID()
        {

            // Generate a new GUID
            Guid newGuid = Guid.NewGuid();

            // convert the GUID to a string
            return newGuid.ToString();

        }
        public static bool CreateFolderIfDoesNotExist(string FolderName)
        {
            // if Folder Not Exist
            if (!Directory.Exists(FolderName))
            {

                try
                {
                    Directory.CreateDirectory(FolderName);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }

            }
           
            return true;
        }

        public static string ReplaceFileNAmeWithGUID(string SourceFile)
        {
            string fileName = SourceFile;
            FileInfo fi = new FileInfo(fileName);
            string ex = fi.Extension;
            return GenerateGUID() + ex;
        }
        public static bool CopyImageToProjectImagesFolder(ref string SourceFile)
        {
            string DestinationFolder = @"C:\DVLD-People-Image\";
            if (!CreateFolderIfDoesNotExist(DestinationFolder)) { 
                return false;
            }
            string DestinationFile = DestinationFolder + ReplaceFileNAmeWithGUID(SourceFile);
            try
            {
                File.Copy(SourceFile,DestinationFile,true);

            }catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            SourceFile = DestinationFile;
            return true;

        }


    }
}
