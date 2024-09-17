using System;
using System.Text;
public class Soundex
{
    public static string GenerateSoundex(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty;
        }
        StringBuilder soundex = new StringBuilder();
        soundex.Append(char.ToUpper(name[0]));
        char prevCode = GetSoundexCode(name[0]);
        AppendSoundexCodes(name, soundex, ref prevCode);
        PadSoundexString(soundex);
        return soundex.ToString();
    }

    private static void AppendSoundexCodes(string name, StringBuilder soundex, ref char prevCode)
    {
       for (int i = 1; NameAndSoundexValidator(name,soundex); i++)
       {
         char code = GetSoundexCode(name[i]);
         if (ShouldAppendCode(code, prevCode))
         {
            soundex.Append(code);
            prevCode = code;
         }
      }
    }
    
   private static bool NameAndSoundexValidator(string name,StringBuilder soundex)
   {
       return name.Length && soundex.Length<4;
   }
   private static bool ShouldAppendCode(char code, char prevCode)
   {
       return code != '0' && code != prevCode;
   }

   private static void PadSoundexString(StringBuilder soundex)
   {
      while (soundex.Length < 4)
      {
        soundex.Append('0');
      }
   }
   
    private static readonly (string Characters,char Code)[] SoundexGroups = 
    {
       ("BFPV", '1'),
       ("CGJKQSXZ", '2'),
       ("DT", '3'),
       ("L", '4'),
       ("MN", '5'),
       ("R", '6')
    };
    private static char GetSoundexCode(char c)
    {
        c = char.ToUpper(c);
        foreach (var group in SoundexGroups)
        {
           if (group.Characters.Contains(c))
           {
             return group.Code;
           }
        }
        return '0';
    }
}
