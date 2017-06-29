#include "stdafx.h"
#ifndef __UPDATELIST_H
#define __UPDATELIST_H


//List Of Key
uint keyusa[4] = { 66455465, 57629246, 17826484, 78315754 };
uint keythai[4] = { 0x50AD33B, 0x0BAFF09, 0x452FFDA, 0x2CB4422 };
uint keyjapan[4] = { 0x20A5FD4, 0x1EEBDFF, 0x2B3C6A0, 0x4F6A3E1 };

//List of Func
void xtea_encipher(unsigned int num_rounds, uint data[2], uint key[4]);
void xtea_decipher(unsigned int num_rounds, uint data[2], uint key[4]);
int FileCryptDecrypt(string filename, uint key[4]);

#endif