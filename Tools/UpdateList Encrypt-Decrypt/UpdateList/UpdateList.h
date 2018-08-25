#include "stdafx.h"
#ifndef __UPDATELIST_H
#define __UPDATELIST_H


//List Of Key
// 16 ROUND
uint xtea_US_key[4] = { 66455465, 57629246, 17826484, 78315754 }; // 0x3F607A9, 0x36F5A3E, 0x11002B4, 0x4AB00EA
uint xtea_JP_key[4] = { 34234324, 32423423, 45336224, 83272673 }; // 0x20A5FD4, 0x1EEBDFF, 0x2B3C6A0, 0x4F6A3E1
uint xtea_TH_key[4] = { 84595515, 12254985, 72548314, 46875682 }; // 0x50AD33B, 0x0BAFF09, 0x452FFDA, 0x2CB4422
uint xtea_EU_key[4] = { 32081624, 92374137, 64139451, 46772272 }; // 0x1E986D8, 0x5818479, 0x3D2B0BB, 0x2C9B030
uint xtea_ID_key[4] = { 23334327, 21322395, 41884343, 93424468 }; // 0x1640DB7, 0x1455A9B, 0x27F1AB7, 0x5918B54
uint xtea_KR_key[4] = { 75871606, 85233154, 85204374, 42969558 }; // 0x485B576, 0x5148E02, 0x5141D96, 0x28FA9D6

//List of Func
void xtea_encipher(unsigned int num_rounds, uint data[2], uint key[4]);
void xtea_decipher(unsigned int num_rounds, uint data[2], uint key[4]);
int FileCryptDecrypt(string filename, uint key[4]);

#endif