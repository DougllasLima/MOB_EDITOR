using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct sITEMLIST
{
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6500)]
    public STRUCT_ITEMLIST[] item;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct sItemADD//2
{
    public Byte cEfeito;
    public Byte cValue;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ItemEffect
{
     public short sEffect;
     public short sValue;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
public struct STRUCT_AFFECT
{
    public byte Type;
    public byte Value;
    public short Level;
    public int Time;
};

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
public struct STRUCT_ITEM
{
    public short sIndex;//2
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public sItemADD[] sEffect;//8
};

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct STRUCT_SCORE
{
    public Int32 Level;
    public Int32 Defesa;
    public Int32 Ataque;

    public byte Merchante;
    public byte Speed;
    public byte Direcao;
    public byte ChaosRate;

    public Int32 MaxHP;
    public Int32 MaxMP;
    public Int32 HP;
    public Int32 MP;
    
    public short Str;
    public short Int;
    public short Dex;
    public short Con;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
     public short[] Special;        

};

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct STRUCT_MOB
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
    public string name; // 0 ~ 15  = 16
    public byte Clan; // 16 = 1
    public byte Merchant; // 17 = 1
    public short Guild; // 18 a 19 = 2
    public byte Class; // 20 = 1
    public byte Rsv; // 21 = 1
    public short Quest; // 22 a 23 = 2 

    public int unk1; // 24 a 27 = 4

    public int Coin; // 28 a 31 = 4

    public long Exp; // 32 a 39 = 8

    public short SPX; // 40 = 1
    public short SPY; // 41 = 2

    public STRUCT_SCORE BaseScore; // 42 a 89 = 48
    public STRUCT_SCORE CurrentScore; // 90 a 137 = 48

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public STRUCT_ITEM[] Equip; // 138 a 265 = 128
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
    public STRUCT_ITEM[] Carry; // 266 a 777 = 512

    public ulong LearnedSkill; // 778 a 785 = 8

    public short ScoreBonus; // 788 a 789 = 2
    public short SpecialBonus; // 790 a 791 = 2
    public short SkillBonus; // 792 a 793 = 2

    public byte Critical; // 786 = 1
    public byte SaveMana; // 787 = 1

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public byte[] SkillBar; // 794 a 797

    public byte GuildLevel; // 798 = 1

    public int Magic; // 799 a 802 = 4
    public short RegenHP; // 803 a 804 = 2
    public short RegenMP; // 805 a 806 = 2

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public byte[] Resist; // 806 a 809 = 4
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct STRUCT_ITEMLIST
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    public string Name;
    public short IndexMesh;
    public short IndexTexture;
    public short IndexVisualEffect;
    public short ReqLvl;
    public short ReqStr;
    public short ReqInt;
    public short ReqDex;
    public short ReqCon;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
    public ItemEffect[] stEffect;

    public int Price;
    public short nUnique;
    public short nPos;
    public short Extra;
    public short Grade;
}

