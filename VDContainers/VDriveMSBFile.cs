using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace VDriveFiles
{
    public class VDriveMSBFile
    {
        public VDriveHeader Header { get; set; }
        public List<VDriveMSBMeshEntry> Meshes { get; set; }

        public VDriveMSBFile()
        {
            Header = new VDriveHeader();
            Meshes = new List<VDriveMSBMeshEntry>();
        }
        public void ReadData(string FileName)
        {
            using (var br = new BinaryReader(File.OpenRead(FileName)))
            {
                Header.LoadData(br);
                foreach (var item in Header.Offsets)
                {
                    br.BaseStream.Seek(item, SeekOrigin.Begin);
                    VDriveMSBMeshEntry temp = new VDriveMSBMeshEntry();
                    temp.LoadData(br);
                    Meshes.Add(temp);
                }
            }
        }
        public VDriveMSBFile(string fileName)
        {
            Header = new VDriveHeader();
            Meshes = new List<VDriveMSBMeshEntry>();
            ReadData(fileName);

        }
    }
}
