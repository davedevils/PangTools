// UpdateList_DE-Crypt.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "Updatelist.h"    

int main(int argc, char* argv[])
{
	int result;
	string sFileName = "updatelist";
	uint * keyselected;

	printf("-----------------------------------------------\n");
	printf("|        Pangya UpdateList Encrypt/Decrypt    |\n");
	printf("|                   Version 2.0               |\n");
	printf("-----------------------------------------------\n");
	printf("Created by DaveDevil's - Special thanks to HSReina\n");
	printf("-----------------------------------------------\n");
	if (argc == 1)
	{
		printf("No input file, Try in same folder ...\n");

	}
	else
	{

		sFileName = argv[1];
	}

	for (int i = 1; i < 4; i++)
	{
		switch (i)
		{
			case 1: keyselected = keyusa; break;
			case 2: keyselected = keythai; break;
			case 3: keyselected = keyjapan; break;
			default: keyselected = keyusa;
		}


		result = FileCryptDecrypt(sFileName, keyselected);
		if (result == -1)
		{
			printf("The file has been encrypted !\n");
			break;
		}
		else if (result == 0)
		{
			printf("The file has been Decrypted !\n");
			break;
		}
		else if (result == 1)
		{
			printf("Try other Key ...\n");
			
		}
		else if (result == 2)
		{
			printf("Sorry i don't know how encrypt this file !\n");
			break;
		}
		else if (result == 3)
		{
			break;
		}

		if (i == 3)
		{
			printf("Sorry i don't know how decrypt this file !\n");
		}
	}


	printf("\n");
	system("pause");
	return 1;
}

int FileCryptDecrypt(string filename, uint key[4])
{
	bool encrypt = false;
	int ret;
	ifstream fOriginalFile(filename.c_str(), ios::binary | ios::ate);
	ifstream::pos_type pos = fOriginalFile.tellg();

	int size = (int)pos;

	if (size < 0)
	{
		printf("File not found : %s \n", filename.c_str());
		fOriginalFile.close();
		return 3;
	}

	char * Data = new char[size];
	char * DataFinal = new char[size];

	fOriginalFile.seekg(0, ios::beg);

	fOriginalFile.read(Data, size);

	// If data is decrypted -> check what crypt i need
	if (Data[0] == '<' && Data[1] == '?')
	{
		printf("Trying to Encrypt ... \n");
		encrypt = true;
		if (Data[0x4B] == 'T' && Data[0x4C] == 'H')
		{
			printf("Encrypt Key found : Thai ... \n");
			key = keythai;
		}
		else if (Data[0x4B] == 'J' && Data[0x4C] == 'P')
		{
			printf("Encrypt Key found : Japan ... \n");
			key = keyjapan;
		}
		else if (Data[0x4B] == 'G' && Data[0x4C] == 'B')
		{
			printf("Encrypt Key found : English ... \n");
			key = keyusa;
		}
		else
		{
			//no have key :'(
			printf("No Key found - Maybe Bad Decrypt :/ ... \n");
			fOriginalFile.close();
			return 2;
		}
	}

	for (int i = 0; i < size; i = i + 8)
	{
		uint DataCut[8];

		memcpy(&DataCut[0], &Data[i], 8);

		if (encrypt)
		{
			xtea_encipher(16, (uint*)DataCut, key);
		}
		else
		{
			xtea_decipher(16, (uint*)DataCut, key);
		}

		memcpy(&DataFinal[i], &DataCut[0], 8);


		//If Decrypt fail ...
		if (i == 0 && DataFinal[0] != '<' && DataFinal[1] != '?' && encrypt == false)
		{
			if (key == keyusa)
			{
				printf("Not English Updatelist... \n");
			}
			else if (key == keyjapan)
			{
				printf("Not Japan Updatelist... \n");
			}
			else if (key == keythai)
			{
				printf("Not Thai Updatelist... \n");
			}

			fOriginalFile.close();
			return 1;
		}
	}


	if (encrypt)
	{
		std::fstream SaveFile;
		string savefilename = filename + "_encrypt";
		SaveFile.open(savefilename.c_str(), std::fstream::in | std::fstream::out | fstream::binary | std::fstream::app);
		SaveFile.write(DataFinal, size);
		SaveFile.close();
		ret = -1;
	}
	else
	{
		std::fstream SaveFile;
		string savefilename = filename + ".xml";
		SaveFile.open(savefilename.c_str(), std::fstream::in | std::fstream::out | fstream::binary | std::fstream::app);
		SaveFile.write(DataFinal, size);
		SaveFile.close();
		ret = 0;

		if (key == keyusa)
		{
			printf("Is English Updatelist !\n");
		}
		else if (key == keyjapan)
		{
			printf("Is Japan Updatelist !\n");
		}
		else if (key == keythai)
		{
			printf("Is Thai Updatelist !\n");
		}
	}


	fOriginalFile.close();
	return ret;
}

void xtea_encipher(unsigned int num_rounds, uint data[2], uint key[4]) 
{
	uint i;
	uint data0 = data[0];
	uint data1 = data[1];
	uint delta = 0x61c88647, sum = 0;
	for (i = 0; i < num_rounds; i++)
	{
		data0 += (((data1 << 4) ^ (data1 >> 5)) + data1) ^ (sum + key[sum & 3]);
		sum -= delta;
		data1 += (((data0 << 4) ^ (data0 >> 5)) + data0) ^ (sum + key[(sum >> 11) & 3]);
	}
	data[0] = data0;
	data[1] = data1;
}

void xtea_decipher(unsigned int num_rounds, uint data[2], uint key[4]) 
{
	uint i;
	uint data0 = data[0];
	uint data1 = data[1];
	uint delta = 0x61C88647, sum = 0xE3779B90;
	for (i = 0; i < num_rounds; i++)
	{
		data1 -= (((data0 << 4) ^ (data0 >> 5)) + data0) ^ (sum + key[(sum >> 11) & 3]);
		sum += delta;
		data0 -= (((data1 << 4) ^ (data1 >> 5)) + data1) ^ (sum + key[sum & 3]);
	}
	data[0] = data0;
	data[1] = data1;
}

