#include "stdafx.h"
#ifndef __UPDATELIST_H
#define __UPDATELIST_H

//List Of Key
uint keyIdnesiff[4] = { 23334327, 21322395, 41884343, 93424468 };


//List of Func
void xtea_encipher(unsigned int num_rounds, uint data[2], uint key[4]);
void xtea_decipher(unsigned int num_rounds, uint data[2], uint key[4]);
int FileCryptDecrypt(string filename, uint key[4]);

#endif