// Pangya Pak Extract.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "Pak-Pangya.h"    

int main(int argc, char* argv[])
{
	int result;
	string sFileName = "../Pangya-TH-OLD.pak";
	uint encrypttype;

	printf("-----------------------------------------------\n");
	printf("|            Pangya Pak Extract/Create        |\n");
	printf("|                   Version 1.3               |\n");
	printf("-----------------------------------------------\n");
	printf("Created by DaveDevil's - Special thanks to Seddi\n");
	printf("-----------------------------------------------\n");
	if (argc == 1)
	{
		printf("No input file, Create PAK ...\n");
		if (!CreateDirectory(L"NEWPAK", NULL))
		{
			printf("Folder NEWPAK found \n");
			do
			{
				printf("--------------\n");
				printf("Write the number of what you want\n");
				printf("0 - XTEA - US\n");
				printf("1 - XTEA - JP\n");
				printf("2 - XTEA - TH\n");
				printf("3 - XTEA - EU\n");
				printf("4 - XTEA - ID\n");
				printf("5 - XTEA - KR\n");
				printf("6 - XOR  - (old format)\n");
				std::cin >> encrypttype;

				if (encrypttype > 6)
				{
					printf("Bad Number - try again\n");
				}

			} while (encrypttype > 6);

			result = CreatePak(encrypttype);
			if (result == 0)
			{
				printf("The Pak Have been MAKE!\n");
			}
		}
		else
		{
			printf("Folder NEWPAK not found - Created \n");
			printf("Put your data into the folder next time !\n");
		}

	}
	else
	{
		printf("File added, Extract PAK ...\n");
		sFileName = argv[1];

		result = OpenPak(sFileName);
		if (result == 0)
		{
			printf("The file has been unpacked !\n");
		}
		else if (result == 1)
		{
			printf("This is not a valid pak file !\n");

		}
		else if (result == 2)
		{
			printf("Sorry i don't know how Unpack this file !\n");
		}
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
	char			ModeCompression; // 0 - No compress , 1 - Lz77 compress,  2 - Folder , 3 - Lz77 compress Custom
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

// UNPAK PART

int OpenPak(string filename)
{
	HeaderFile Header;
	StructFile * FileInfo;
	int pos;
	FILE * fOriginalFile;

	if (fopen_s(&fOriginalFile, filename.c_str(), "rb") != 0)
	{
		printf("File not found : %s \n", filename.c_str());
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
		return 1;
	}

	//Go to Offset
	fseek(fOriginalFile, Header.ListOffset, 0);

	if (Header.NumFiles > 0)
	{
		FileInfo = new StructFile[Header.NumFiles + 1];


		int	   LangPak = -1;
		uint   XTeaInfo[2];

		for (uint i = 0; i < Header.NumFiles; i++)
		{

			char * DataTmp;
			unsigned char * Data;
			unsigned char * DataFinal;

			//Read Table info
			fread(&FileInfo[i].LenFileName		, 1, 1, fOriginalFile);
			fread(&FileInfo[i].ModeCompression	, 1, 1, fOriginalFile);
			fread(&FileInfo[i].Offset			, 4, 1, fOriginalFile);
			fread(&FileInfo[i].FileSize			, 4, 1, fOriginalFile);
			fread(&FileInfo[i].RealFileSize		, 4, 1, fOriginalFile);

			DataTmp = new char[FileInfo[i].LenFileName + 1];
			fread(DataTmp, FileInfo[i].LenFileName, 1, fOriginalFile);

			if (FileInfo[i].ModeCompression < 4 && FileInfo[i].ModeCompression > -1) // If OLD PAK (XOR)
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
				
				FileInfo[i].FileName = (char *)DataTmp;
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

			delete[] DataTmp;
			
			pos = ftell(fOriginalFile);

			if (FileInfo[i].ModeCompression == 0) // No Compress
			{
				printf("File Found: %s", FileInfo[i].FileName.c_str());


				fseek(fOriginalFile, FileInfo[i].Offset, 0);

				Data = new unsigned char[FileInfo[i].FileSize + 1];

				fread(Data, FileInfo[i].FileSize, 1, fOriginalFile);
				fseek(fOriginalFile, pos, 0);

				SaveToFile(FileInfo[i].FileName.c_str(), Data, FileInfo[i].RealFileSize);
				printf(" - Extracted \n");

				delete[] Data;
			}
			else if (FileInfo[i].ModeCompression == 2) // Folder
			{
				printf("Folder Found: %s ", FileInfo[i].FileName.c_str());
				
				if (!CreateDirectoryA(FileInfo[i].FileName.c_str(), NULL))
				{
					printf("- ERROR \n");
				}
				else
				{
					printf("- Created \n");
				}	
				
			}
			else if (FileInfo[i].ModeCompression == 1 || FileInfo[i].ModeCompression == 3) // LZ77 & LZ77 Custom
			{
				printf("File Found: %s", FileInfo[i].FileName.c_str());


				fseek(fOriginalFile, FileInfo[i].Offset, 0);

				Data = new unsigned char[FileInfo[i].FileSize + 1];
				DataFinal = new  unsigned char[FileInfo[i].RealFileSize + 128];


				fread(Data, FileInfo[i].FileSize, 1, fOriginalFile);
				fseek(fOriginalFile, pos, 0);

#if DEBUG_MODE >= 1
				/*
				FILE * TmpSaveFile;
				string TmpName = FileInfo[i].FileName + ".compressDATA";
				TmpSaveFile = fopen(TmpName.c_str(), "wb");
				fwrite(Data, FileInfo[i].FileSize, 1, TmpSaveFile);
				fclose(TmpSaveFile);
				*/
#endif

				uint NewSize = Lz77_Decompress(Data, FileInfo[i].FileSize, DataFinal,  FileInfo[i].ModeCompression);

				delete[] Data;

				if (NewSize > FileInfo[i].RealFileSize || FileInfo[i].RealFileSize > NewSize)
				{
#if DEBUG_MODE >= 1
					printf(" - Size problem ");
#endif
				}

				SaveToFile(FileInfo[i].FileName.c_str(), DataFinal, FileInfo[i].RealFileSize);
				printf(" - Extracted \n");

				delete[] DataFinal;
			}
		}

		
	}



	return 0;
}


int SaveToFile(const char * Filename , unsigned char * Data , uint DataSize) 
{
	ofstream file;
	file.open(Filename, std::ofstream::out | std::ofstream::trunc | std::ofstream::binary);
	file.write((char *)Data, DataSize);
	file.close();
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

	XTeaInfo[0] = Data0;
	XTeaInfo[1] = Data1;
	xtea_decipher(16, XTeaInfo, xtea_all[5]);

	if (XTeaInfo[0] == 0)
		return 5; // KOREAN KEY

	//i don't know the key :(
	return -1;
}

int Lz77_Decompress(unsigned char * Data, int DataSize, unsigned char * DataDst, int Type)
{

	if (Type == 0)
	{
		//Clean Data (no compress)
		DataDst = Data;

		return DataSize;
	}
	else
	{
		// Décompresion Type 3
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
				ByteTmp = *(unsigned short *)&Data[j],
				j += 2;

				if (Type == 3)
					ByteTmp ^= lz77_masks[(OriginalMask >> 3) & 7];

				Offset = ByteTmp & 0x0FFF;
				OffsetSize = (ByteTmp >> 0x0C) + 2;
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


void xtea_decipher(uint num_rounds, uint data[2], uint key[4]) 
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

// PAK MAKER PART

int CreatePak(uint EncryptType)
{
	vector<wstring> ListOfFile, ListOfFolder;
	int CurPos = 0;


	ListFile(ListOfFile, ListOfFolder);
	printf("Number of File found : %u \n", ListOfFile.size());

	// PART 1 - Put ALL data in the file ... And save Offset and all 
	uint NumFiles = ListOfFile.size() + ListOfFolder.size();
	char Sign = 0x12;
	int FakeSize = 0;
	uint XTeaInfo[2];

	FILE * OutPak;
	string SaveFileName = "projectg999";
	switch (EncryptType)
	{
		case 0: SaveFileName += "gb.pak"; break;
		case 1: SaveFileName += "jp.pak"; break;
		case 2: SaveFileName += "th.pak"; break;
		case 3: SaveFileName += "eu.pak"; break;
		case 4: SaveFileName += "id.pak"; break;
		case 5: SaveFileName += "kr.pak"; break;
		case 6: SaveFileName += "th.pak"; break;
	}

	OutPak = fopen(SaveFileName.c_str(), "wb");

	StructFile * FileInfo = new StructFile[ListOfFile.size() + 1];
	
	for(uint i = 0; i < ListOfFile.size(); i++)
	{
		string Filename = ws2s(ListOfFile[i]);

		string RealFileName = "NEWPAK\\";
		RealFileName += Filename;

		FILE * FileData = fopen(RealFileName.c_str(), "rb");

		if (!FileData)
		{
			printf("File not found : %s \n", RealFileName.c_str());
			continue;
		}

		fseek(FileData, 0L, SEEK_END);

		// Save info For table
		FileInfo[i].FileName			= Filename;
		FileInfo[i].LenFileName			= ListOfFile[i].size();
		FileInfo[i].ModeCompression		= 3;
		FileInfo[i].Offset				= ftell(OutPak);
		FileInfo[i].RealFileSize		= ftell(FileData);

		unsigned char * DATAin = new unsigned char[FileInfo[i].RealFileSize + 1];
		unsigned char * DATAout = new unsigned char[1024 * 4096];

		//Now Read File
		fseek(FileData, 0L, SEEK_SET);
		fread(DATAin, FileInfo[i].RealFileSize, 1, FileData);

		//Now need to Compress for know the new size
		uint newsize = Lz77_Compress(DATAin, FileInfo[i].RealFileSize, DATAout);
		FileInfo[i].FileSize			= newsize;

		fwrite(DATAout, newsize, 1, OutPak);

		printf("File Compressed : %s \n", RealFileName.c_str());
		
		delete[] DATAin;
		delete[] DATAout;
	}

	unsigned int OffsetList = ftell(OutPak);

	char FolderMode = 0x02;

	if (EncryptType != 6)
		FolderMode ^= 0x20;

	// PART 2 - DO THE TABLE-ROLL
	printf("Create table ... ");
	//Folder !
	for (uint i = 0; i < ListOfFolder.size(); i++)
	{
		string sFolderName = ws2s(ListOfFolder[i]);
		char * FolderName = new char[ListOfFolder[i].size() + 9];
		strcpy(FolderName, sFolderName.c_str());

		uint size = ListOfFolder[i].size();
		uint Offset = 0, RealFileSize = 0;
		if (EncryptType != 6)
		{
			if (size < 8)
			{
				xtea_encipher(16, (uint*)FolderName, xtea_all[EncryptType]);
			}
			else
			{
				for (int y = 0; y < ListOfFolder[i].size(); y = y + 8)
				{
					uint DataCut[8];

					memcpy(&DataCut[0], &FolderName[y], 8);

					xtea_encipher(16, (uint*)DataCut, xtea_all[EncryptType]);

					memcpy(&FolderName[y], &DataCut[0], 8);

					size = y;
				}
			}

			sFolderName = FolderName;

			XTeaInfo[0] = Offset;
			XTeaInfo[1] = RealFileSize;
			xtea_encipher(16, XTeaInfo, xtea_all[EncryptType]);
			Offset = XTeaInfo[0];
			RealFileSize = XTeaInfo[1];
		}
		else
		{
			sFolderName = XOR_data(FolderName, size, 1);
		}

		size = sFolderName.size();

 		fwrite(&size, 1, 1, OutPak);
		fwrite(&FolderMode, 1, 1, OutPak);
		fwrite(&Offset, 4, 1, OutPak);
		fwrite(&FakeSize, 4, 1, OutPak);
		fwrite(&RealFileSize, 4, 1, OutPak);
		fwrite(sFolderName.c_str(), size, 1, OutPak);

		if (EncryptType == 6)
		{
			fwrite(&FakeSize, 1, 1, OutPak);
		}
	}
	//File !
	for (uint i = 0; i < ListOfFile.size(); i++)
	{
		
		string sFilename = ws2s(ListOfFile[i]);
		char * FileName = new char[ListOfFile[i].size() + 9];
		strcpy(FileName, sFilename.c_str());

		uint size = ListOfFile[i].size();

		if (EncryptType != 6)
		{
			for (int y = 0; y < FileInfo[i].LenFileName; y = y + 8)
			{
				uint DataCut[8];

				memcpy(&DataCut[0], &FileName[y], 8);

				xtea_encipher(16, (uint*)DataCut, xtea_all[EncryptType]);

				memcpy(&FileName[y], &DataCut[0], 8);

				size = y;
			}

			FileInfo[i].ModeCompression ^= 0x20;
			XTeaInfo[0] = FileInfo[i].Offset;
			XTeaInfo[1] = FileInfo[i].RealFileSize;
			xtea_encipher(16, XTeaInfo, xtea_all[EncryptType]);
			FileInfo[i].Offset = XTeaInfo[0];
			FileInfo[i].RealFileSize = XTeaInfo[1];

			sFilename = FileName;
		}
		else
		{
			sFilename = XOR_data(FileName, size, 1);
		}

		size = sFilename.size();

		fwrite(&size, 1, 1, OutPak);
		fwrite(&FileInfo[i].ModeCompression, 1, 1, OutPak);
		fwrite(&FileInfo[i].Offset, 4, 1, OutPak);
		fwrite(&FileInfo[i].FileSize, 4, 1, OutPak);
		fwrite(&FileInfo[i].RealFileSize, 4, 1, OutPak);
		fwrite(sFilename.c_str(), size, 1, OutPak);

		if (EncryptType == 6)
		{
			fwrite(&FakeSize, 1, 1, OutPak);
		}

		delete[] FileName;
	}
	printf(" DONE \n");

	// PART 3 - The "header" of the footer ?
	fwrite(&OffsetList	, 4, 1, OutPak);
	fwrite(&NumFiles	, 4, 1, OutPak);
	fwrite(&Sign, 1, 1, OutPak);

	//DONE

	fclose(OutPak);
	OutPak = 0;
	return 0;
}

void ListFile(vector<wstring> &FileList, vector<wstring> &FolderList)
{
	FileList.clear();

	WIN32_FIND_DATA File;
	HANDLE hSearch;

	wstring OriginalDir = L"NEWPAK";
	wstring Mask = L"\\*";
	wstring ActualFolder = OriginalDir + Mask;

	uint i = -1;
	do
	{
		
		if ( i != -1)
			ActualFolder = OriginalDir + L"/" + FolderList[i] + Mask;

		hSearch = FindFirstFile(ActualFolder.c_str(), &File);

		if (hSearch != INVALID_HANDLE_VALUE)
		{
			do
			{
				if (wcscmp(File.cFileName, L".") && wcscmp(File.cFileName, L"..") && wcscmp(File.cFileName, L""))
				{
					if (File.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY && i == -1)
					{
						FolderList.push_back(File.cFileName);
					}
					else if (File.dwFileAttributes != FILE_ATTRIBUTE_DIRECTORY && i == -1)
					{
						FileList.push_back(File.cFileName);
					}
					else if (File.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
					{
						FolderList.push_back(FolderList[i] + L"/" + File.cFileName);
					}
					else
					{
						FileList.push_back(FolderList[i] + L"/" + File.cFileName);
					}
				}
			} while (FindNextFile(hSearch, &File));

			FindClose(hSearch);
		}
		i++;
	} while (i < FolderList.size());

}


int Lz77_Compress(unsigned char * Data, int DataSize, unsigned char * DataDst)
{

	
	int OriginalMask, Mask = 0;
	int CountByte = 0;
	int Size = 0;
	int Offset, OffsetSize;
	unsigned short ByteTmp;


	for (int j = 0; j < DataSize;)
	{

		if (!CountByte)
		{
			DataDst[Size++] = 0xC8;
			DataDst[Size++] = Data[j++];

			//TODO - COMPRESS
		}
		else
		{
			DataDst[Size++] = Data[j++];
		}
		CountByte = (CountByte + 1) & 7;
	}

	/*
	while (1)
	{
		//secure les data
		if (Size % 8)
		{
			break;
		}
		DataDst[Size++] = 0x00;
	}
	*/

	return Size;


	return 0;

}

void xtea_encipher(uint num_rounds, uint data[2], uint key[4])
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

wstring s2ws(const std::string& str)
{
	using convert_typeX = std::codecvt_utf8<wchar_t>;
	std::wstring_convert<convert_typeX, wchar_t> converterX;

	return converterX.from_bytes(str);
}

string ws2s(const std::wstring& wstr)
{
	using convert_typeX = std::codecvt_utf8<wchar_t>;
	std::wstring_convert<convert_typeX, wchar_t> converterX;

	return converterX.to_bytes(wstr);
}
