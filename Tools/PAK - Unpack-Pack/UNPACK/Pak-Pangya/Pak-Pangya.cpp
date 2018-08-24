// UpdateList_DE-Crypt.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "Pak-Pangya.h"    

int main(int argc, char* argv[])
{
	int result;
	string sFileName = "../Pangya-TH-OLD.pak";

	printf("-----------------------------------------------\n");
	printf("|            Pangya Pak Extract/Create        |\n");
	printf("|                   Version 1.0               |\n");
	printf("-----------------------------------------------\n");
	printf("Created by DaveDevil's - Special thanks to Seddi\n");
	printf("-----------------------------------------------\n");
	if (argc == 1)
	{
		printf("No input file, Try in same folder ...\n");

	}
	else
	{

		sFileName = argv[1];
	}


		result = OpenPak(sFileName);
		if (result == 0)
		{
			printf("The file has been Decrypted !\n");
		}
		else if (result == 1)
		{
			printf("Try other Key ...\n");
			
		}
		else if (result == 2)
		{
			printf("Sorry i don't know how Unpack this file !\n");
		}


	printf("\n");
	system("pause");
	return 1;
}


/*
//Structure

-> begin file
//ALL DATA
{
	ALL Data File(encrypt or not)
}

//TABLE of content
{
	char			LenFileName;
	char			ModeCompression; // 0 - No compress , 2 Folder , 3 - Lz77 compress
	unsigned int	Offset;
	unsigned int	FileSize;
	unsigned int	RealFileSize;
	string			FileName; // size of LenFileName
	if(OLD pack)
	{
		char			Unknow5; 
	}
}

//Footer Files - 9 Byte
	unsigned int	ListOffset;
	unsigned int	NumFiles;
	char			Sign;

-> end file


*/



int OpenPak(string filename)
{
	HeaderFile Header;
	StructFile * FileInfo;
	int pos;
	FILE * fOriginalFile = fopen(filename.c_str(), "rb");

	if (!fOriginalFile)
	{
		printf("File not found : %s \n", filename.c_str());
		fclose(fOriginalFile);
		return 3;
	}

	fseek(fOriginalFile, 0L, SEEK_END);

	int size = ftell(fOriginalFile);

	if (size < 0)
	{
		printf("File is Empty : %s \n", filename.c_str());
		fclose(fOriginalFile);
		return 3;
	}


	//Begin to the end (-9 byte value)!
	fseek(fOriginalFile, -9, SEEK_END);

	//Read All
	fread(&Header.ListOffset, 4, 1, fOriginalFile);
	fread(&Header.NumFiles	, 4, 1, fOriginalFile);
	fread(&Header.Sign		, 1, 1, fOriginalFile);

	if (Header.Sign != 0x12)
	{
		fclose(fOriginalFile);
		return 2;
	}

	//Go to Offset
	fseek(fOriginalFile, Header.ListOffset, 0);

	if (Header.NumFiles > 0)
	{
		FileInfo = new StructFile[Header.NumFiles];

		char * DataTmp;
		char * Data;
		char * DataFinal;
		int	   LangPak = -1;
		uint   XTeaInfo[2];

		for (unsigned int i = 0; i < Header.NumFiles; i++)
		{

			//Read Table info
			fread(&FileInfo[i].LenFileName		, 1, 1, fOriginalFile);
			fread(&FileInfo[i].ModeCompression	, 1, 1, fOriginalFile);
			fread(&FileInfo[i].Offset			, 4, 1, fOriginalFile);
			fread(&FileInfo[i].FileSize			, 4, 1, fOriginalFile);
			fread(&FileInfo[i].RealFileSize		, 4, 1, fOriginalFile);

			DataTmp = new char[FileInfo[i].LenFileName + 1];
			fread(DataTmp, FileInfo[i].LenFileName, 1, fOriginalFile);

			if (FileInfo[i].ModeCompression < 4 && FileInfo[i].ModeCompression > 0) // If OLD PAK (XOR)
			{
				FileInfo[i].FileName = XOR_data(DataTmp, FileInfo[i].LenFileName, 1);
				fread(&FileInfo[i].Unknow5, 1, 1, fOriginalFile);
				LangPak = 10;
			}
			else // New pack (XTEA PAK)
			{
				if (LangPak == -1)
				{
					//try to found what lang is
					LangPak = FindLangPak(FileInfo[i].Offset, FileInfo[i].RealFileSize);
					if (LangPak == -1)
						return 2;
				}

				for (int y = 0; y < FileInfo[i].LenFileName; y = y + 8)
				{
					uint DataCut[8];

					memcpy(&DataCut[0], &DataTmp[y], 8);

					xtea_decipher(16, (uint*)DataCut, xtea_all[LangPak]);

					memcpy(&DataTmp[y], &DataCut[0], 8);
				}
				
				FileInfo[i].FileName = DataTmp;
				FileInfo[i].FileName = FileInfo[i].FileName.substr(0, FileInfo[i].LenFileName);

				//Now decrypt Mode
				FileInfo[i].ModeCompression ^= 0x20;

				//Now Decrypt Offset AND FinalSize
				XTeaInfo[0] = FileInfo[i].Offset;
				XTeaInfo[1] = FileInfo[i].RealFileSize;
				xtea_decipher(16, XTeaInfo, xtea_all[LangPak]);
				FileInfo[i].Offset = XTeaInfo[0];
				FileInfo[i].RealFileSize = XTeaInfo[1];

			}

			delete DataTmp;
			

			if (FileInfo[i].ModeCompression == 1)
			{
				printf("Compress Unknow 1");
			}


			pos = ftell(fOriginalFile);

			if (FileInfo[i].ModeCompression == 2)
			{
				printf("Folder Found: %s ", FileInfo[i].FileName.c_str());

				std::wstring stemp = std::wstring(FileInfo[i].FileName.begin(), FileInfo[i].FileName.end());
				
				if (!CreateDirectory((LPCWSTR)stemp.c_str(), NULL))
				{
					printf("- ERROR \n");
				}
				else
				{
					printf("- Created \n");
				}	
				
			}
			else if (FileInfo[i].ModeCompression == 3 )
			{
				printf("File Found: %s", FileInfo[i].FileName.c_str());


				fseek(fOriginalFile, FileInfo[i].Offset, 0);

				Data = new char[FileInfo[i].FileSize + 1];
				DataFinal = new  char[FileInfo[i].RealFileSize + 200 ];


				fread(Data, FileInfo[i].FileSize, 1, fOriginalFile);


				unsigned int NewSize = Lz77_Decompress(Data, FileInfo[i].FileSize, DataFinal,  FileInfo[i].ModeCompression);

				if (NewSize > FileInfo[i].RealFileSize || FileInfo[i].RealFileSize > NewSize)
				{
					//printf(" - Size problem -");
				}

				FILE * SaveFile;
				SaveFile = fopen(FileInfo[i].FileName.c_str(), "wb");
				fwrite(DataFinal, FileInfo[i].RealFileSize, 1, SaveFile);
				fclose(SaveFile);
				SaveFile = 0;

				delete DataFinal;
				delete Data;

				fseek(fOriginalFile, pos, 0);

				printf(" - Extracted\n");
			}
			

		}
		
	}



	return 0;
}

int FindLangPak(uint Data0, uint Data1)
{
	uint   XTeaInfo[2];

	XTeaInfo[0] = Data0;
	XTeaInfo[1] = Data1;
	xtea_decipher(16, XTeaInfo, xtea_all[0]);

	if (XTeaInfo[0] == 0)
		return 0; // US KEY

	XTeaInfo[0] = Data0;
	XTeaInfo[1] = Data1;
	xtea_decipher(16, XTeaInfo, xtea_all[1]);

	if (XTeaInfo[0] == 0)
		return 1; // JAPAN KEY


	XTeaInfo[0] = Data0;
	XTeaInfo[1] = Data1;
	xtea_decipher(16, XTeaInfo, xtea_all[2]);

	if (XTeaInfo[0] == 0)
		return 2; // THAI KEY

	XTeaInfo[0] = Data0;
	XTeaInfo[1] = Data1;
	xtea_decipher(16, XTeaInfo, xtea_all[3]);

	if (XTeaInfo[0] == 0)
		return 3; // Europe KEY

	XTeaInfo[0] = Data0;
	XTeaInfo[1] = Data1;
	xtea_decipher(16, XTeaInfo, xtea_all[4]);

	if (XTeaInfo[0] == 0)
		return 4; // INDONESIA KEY

	//i don't know the key :(
	return -1;
}

int Lz77_Decompress(char * Data, int DataSize, char * DataDst, int Type)
{

	if (Type == 0)
	{
		//Clean Data (no compress)
		DataDst = Data;

		return DataSize;
	}
	else
	{
		// Compresion Type 3
		int OriginalMask, Mask = 0;
		int CountByte = 0;
		int Size = 0;
		int Offset, OffsetSize;
		unsigned short ByteTmp;

		for (int j = 0; j < DataSize; )
		{
			if (!CountByte)
			{
				Mask = Data[j++];
				OriginalMask = Mask;

				if (Type == 3)
					Mask ^= 0xC8;
			}
			else
				Mask >>= 1;

			if (Mask & 1)
			{
				ByteTmp = *(unsigned short *)&Data[j];
				j += 2;

				if (Type == 3)
					ByteTmp ^= lz77_masks[(OriginalMask >> 3) & 7];

				Offset = ByteTmp & 0x0FFF;
				OffsetSize = (ByteTmp >> 12) + 2;
				memcpy(&DataDst[Size], &DataDst[Size - Offset], OffsetSize);
				Size += OffsetSize;
			}
			else
			{
				DataDst[Size++] = Data[j++];
			}
			CountByte = (CountByte + 1) & 7;
		}

		return Size;
	}
}


string XOR_data(char * Data, int DataSize, int Type)
{
	if (Type == 1)
	{
		for (int i = 0; i < DataSize; i++)
		{
			Data[i] ^= 0x71u;
		}
	}

	string Return = Data;
	Return = Return.substr(0, DataSize);
	return Return;
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

