using System;
using System.Text;
 
public class Soundex
{
   public static string GenerateSoundex(string name)
    {
       if (string.IsNullOrEmpty(name))
            return "0000";
 
        StringBuilder soundex = new StringBuilder();
        soundex.Append(char.ToUpper(name[0]));
        SoundexCodeAppender(name, soundex);
        return soundex.ToString().PadRight(4, '0').Substring(0, 4);
   }
    private static void SoundexCodeAppender(string name, StringBuilder soundex)
    {
        char prevCode = GetSoundexCode(name[0]);
        for (int i = 0; i < IsValidNameAndSoundex(name, soundex)) ; i++)
        {
            char code = GetSoundexCode(name[i]);
            if (IsValidSoundexCode(code, prevCode))
            {
                soundex.Append(code);
                prevCode = code;
            }
        }
    }
 
    private static bool IsValidSoundexCode(string code, string prevCode)
    {
        return code != '0' && code != prevCode;
    }
 
    private static bool IsValidNameAndSoundex(string name, StringBuilder Soundex)
    {
        return name.Length && Soundex.Length < 4;
    }
 
    private static char GetSoundexCode(char c)
    {
        c = char.ToUpper(c);
        var soundMap = new Dictionary<char, char>
        {
             { 'B', '1' }, { 'F', '1' }, { 'P', '1' }, { 'V', '1' },
 
             { 'C', '2' }, { 'G', '2' }, { 'J', '2' }, { 'K', '2' },
             { 'Q', '2' }, { 'S', '2' }, { 'X', '2' }, { 'Z', '2' },
 
             { 'D', '3' }, { 'T', '3' },
 
             { 'L', '4' },
 
             { 'M', '5' }, { 'N', '5' },
 
             { 'R', '6' }
        };
 
        return soundMap.TryGetValue(c, out char codeValue) ? codeValue : '0';
    }
}
