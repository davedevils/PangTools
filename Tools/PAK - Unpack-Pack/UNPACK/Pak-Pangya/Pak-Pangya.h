#include "stdafx.h"
#ifndef __PAK_PANGYA_H
#define __PAK_PANGYA_H

typedef unsigned char BYTE;
typedef unsigned long DWORD;

//List Of Key
unsigned short lz77_masks[] = { 65313, 33615, 26463, 52, 62007, 33119, 18277, 563}; 

// 16 ROUND
uint xtea_US_key[4] = { 66455465, 57629246, 17826484, 78315754 }; // 0x3F607A9, 0x36F5A3E, 0x11002B4, 0x4AB00EA
uint xtea_JP_key[4] = { 34234324, 32423423, 45336224, 83272673 }; // 0x20A5FD4, 0x1EEBDFF, 0x2B3C6A0, 0x4F6A3E1
uint xtea_TH_key[4] = { 84595515, 12254985, 72548314, 46875682 }; // 0x50AD33B, 0x0BAFF09, 0x452FFDA, 0x2CB4422
uint xtea_EU_key[4] = { 32081624, 92374137, 64139451, 46772272 }; // 0x1E986D8, 0x5818479, 0x3D2B0BB, 0x2C9B030
uint xtea_ID_key[4] = { 23334327, 21322395, 41884343, 93424468 }; // 0x1640DB7, 0x1455A9B, 0x27F1AB7, 0x5918B54

uint xtea_all[5][4] = {
	{ 66455465, 57629246, 17826484, 78315754 },
	{ 34234324, 32423423, 45336224, 83272673 },
	{ 84595515, 12254985, 72548314, 46875682 },
	{ 32081624, 92374137, 64139451, 46772272 },
	{ 23334327, 21322395, 41884343, 93424468 }
};

struct HeaderFile // footer but ok
{
	unsigned int	ListOffset;
	unsigned int	NumFiles;
	char			Sign;
};


struct StructFile 
{
	unsigned char   LenFileName;
	unsigned char	ModeCompression;
	unsigned int	Offset;
	unsigned int	FileSize;
	unsigned int	RealFileSize;
	string			FileName;
	char			Unknow5;
};

//List of Func
int OpenPak(string filename);
int FindLangPak(uint Data0, uint Data1);
string XOR_data(char * Data, int DataSize, int Type);
int Lz77_Decompress(char * Data, int DataSize, char * DataDst,  int Type);
void xtea_encipher(unsigned int num_rounds, uint data[2], uint key[4]);
void xtea_decipher(unsigned int num_rounds, uint data[2], uint key[4]);

#endif