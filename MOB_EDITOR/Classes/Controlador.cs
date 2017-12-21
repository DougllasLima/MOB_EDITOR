using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

public static class Editor
{
    public static List<STRUCT_MOB> NPCs = new List<STRUCT_MOB>();
    public static sITEMLIST ItemList = new sITEMLIST();

    public static void ReadNpc()
    {
        try
        {
            string DirNPC = Directory.GetCurrentDirectory() + @"\npc";

            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(DirNPC);
            foreach (string fileName in fileEntries)
            {
                Byte[] data = File.ReadAllBytes(fileName);
                STRUCT_MOB pMob = (STRUCT_MOB)Marshal.PtrToStructure(Marshal.UnsafeAddrOfPinnedArrayElement(data, 0), typeof(STRUCT_MOB));
                Editor.NPCs.Add(pMob);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
    public static void SaveNPC(STRUCT_MOB NPC)
    {
        try
        {
            string DirNPC = Directory.GetCurrentDirectory() + @"\npc\";

            byte[] arr = new byte[Marshal.SizeOf(NPC)];

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(NPC));
            Marshal.StructureToPtr(NPC, ptr, false);
            Marshal.Copy(ptr, arr, 0, Marshal.SizeOf(NPC));
            Marshal.FreeHGlobal(ptr);

            File.WriteAllBytes(DirNPC + NPC.name, arr);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    public static void ReadItemList()
    {
        try
        {
            Byte[] data = File.ReadAllBytes("Itemlist.bin");
            for (int i = 0; i < data.Length; i++)
            {
                data[i] ^= 0x5A;
            }

            ItemList = (sITEMLIST)Marshal.PtrToStructure(Marshal.UnsafeAddrOfPinnedArrayElement(data, 0), typeof(sITEMLIST));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}