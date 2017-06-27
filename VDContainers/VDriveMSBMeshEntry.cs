using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using VDriveFiles.VertexData;
namespace VDriveFiles
{
    public class VDriveMSBMeshEntry : VDriveEntry
    {
        public Vec4 LeftTopBounds { get; set; }
        public Vec4 BottomRightBounds { get; set; }
        public Vec4 Color { get; set; }
        public int Unk1 { get; set; }
        public float Unk2 { get; set; }
        public short StreamCount { get; set; }

        public short FaceCount { get; set; }
        public int Size { get; set; }
        public short Unk3 { get; set; }
        public short Unk4 { get; set; }
        public short Unk5 { get; set; }
        public short Unk6 { get; set; }
        public int Unk7 { get; set; }
        public int Unk8 { get; set; }
        public string name;
        public override void LoadData(BinaryReader br)
        {
            base.LoadData(br);
        }

    } 
}
