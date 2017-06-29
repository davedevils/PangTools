#include "stdafx.h"
#ifndef __UPDATELIST_H
#define __UPDATELIST_H


//List Of Key
uint keythaiiff[4] = { 75946027, 21546795, 41872123, 94517268 };


//List of Func
void xtea_encipher(unsigned int num_rounds, uint data[2], uint key[4]);
void xtea_decipher(unsigned int num_rounds, uint data[2], uint key[4]);
int FileCryptDecrypt(string filename, uint key[4]);

#endif