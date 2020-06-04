using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace RPGWO_Client
{
    public class Utils
    {
        public static byte CalcCheckSum(byte[] data)
        {
            bool sw = false;
            Int16 num1 = 0;
            Int16 num2 = 0;

            for (int i = 0; i < data.Length; i++)
            {
                char value = Convert.ToString(data[i]).ElementAt<char>(0);

                if (sw == false)
                {
                    num1 += Convert.ToByte(value);
                    sw = true;
                }
                else
                {
                    num2 += Convert.ToByte(value);
                    sw = false;
                }
            }

            return (byte)((num1 + (num2 * 3)) % 255);
        }

        // Example from https://codesnippets.fesslersoft.de/how-to-get-a-drive-serial-number-in-c-and-vb-net/
        public static string GetDriveSerialNumber(string drive)
        {
            try
            {
                var driveSerialnumber = string.Empty;
                var pathRoot = Path.GetPathRoot(drive);
                if (pathRoot == null)
                {
                    return driveSerialnumber;
                }
                var driveFixed = pathRoot.Replace("\\", "");
                if (driveFixed.Length == 1)
                {
                    driveFixed = driveFixed + ":";
                }
                var wmiQuery = string.Format("SELECT VolumeSerialNumber FROM Win32_LogicalDisk Where Name = '{0}'", driveFixed);
                using (var driveSearcher = new ManagementObjectSearcher(wmiQuery))
                {
                    using (var driveCollection = driveSearcher.Get())
                    {
                        foreach (var moItem in driveCollection.Cast<ManagementObject>())
                        {
                            // driveSerialnumber = ConvertHelper.ToString(moItem["VolumeSerialNumber"]);
                            Console.WriteLine(moItem);
                        }
                    }
                }
                return driveSerialnumber;
            }
            catch (Exception ex)
            {
                //handle the error your way
                return string.Empty;
            }
        }
    }
}
