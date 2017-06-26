using System;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Linq;
using System.Collections.Generic;
using VDriveFiles;

namespace MIBUtil
{
    class Program
    {
        static void dump(string fileName)
        {
            VDriveMibFile file = new VDriveMibFile(fileName);
            int i = 0;
            string dir = fileName.Substring(0, fileName.Length - 4);
            Directory.CreateDirectory(dir);
            using (var mapping = new StreamWriter(dir + "\\mapping.txt"))
            {
                foreach (var item in file.Entries)
                {

                    if (item.isDDS)
                    {

                        var ddsHeader = item.GetDDSFile();
                        ddsHeader.WriteData(string.Format("{0}\\{1}.dds", dir, item.InternalID));

                    }
                    i++;

                }
            }

        }
        static void Update(string fileName)
        {
            string dir = fileName.Substring(0, fileName.Length - 4);
            if (Directory.Exists(dir))
            {
                VDriveMibFile outfile = new VDriveMibFile(fileName);
                foreach (var item in outfile.Entries)
                {
                    if (item.isDDS)
                    {
                        DDSFile dds = new DDSFile();
                        if (dds.ReadData(string.Format("{0}/{1}.dds", dir, item.InternalID)))
                            item.UpdateFromDDS(dds);
                    }

                }
                outfile.UpdateOffsets();
                outfile.WriteFile(fileName);
            }
            else
            {
                Console.WriteLine("Dump the file first");
            }
        }
        static void OutputHelp()
        {
            //Console.WriteLine("Put this in you fuckhead before shipping");
            Console.WriteLine("usage: \n MIBUtil -d filename to dump\n MIBUtil -U filename to update from dump");
        }
        static void Main(string[] args)
        {
            if (args.Length > 1)
            {
                if (args[0] == "-d")
                {
                    dump(args[1]);
                }
                if (args[0] == "-u")
                {
                    Update(args[1]);
                }

            }
            else
            {
                OutputHelp();
            }

        }
    }
}
