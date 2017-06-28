In some file you no see len, you see only ushort , byte and other ...

REMEMBER   -> We speak in Hexadecimal
-> Exemple -> "50 46 00 00 00 00 00 00 00 00 00 00 24 00 00 00 6D 5F 64 65 66 00 00 00"
           -> 24 Octets

So this is the explain :

byte     - 1 Octets -> Exemple (FF)
ushort   - 2 Octets -> Exemple (00 01)
uint     - 4 Octets -> Exemple (00 11 11 22)
double   - 8 Octets -> Exemple (00 11 11 22 50 11 11 22)
string   - X Octets -> all time i set len in commentary