using Xunit;

public class SoundexTests
{
    [Theory]
[InlineData("", "0000")]
[InlineData("   ", "0000")]
[InlineData(null, "0000")]
public void HandlesEmptyString_NullString_WhitespaceString(string name,string expectedValue)
{

    //Act
    string actual = Soundex.GenerateSoundex(name);
    

    //Assert
    Assert.Equal(expectedValue, actual);
}

[Theory]
[InlineData("A", "A000")]
[InlineData("BF", "B100")]
[InlineData("CPG", "C120")]
public void HandlesCharacterLessThanFour(string input, string expected)
{
    // Act
    string actual = Soundex.GenerateSoundex(input);

    // Assert
    Assert.Equal(expected, actual);
}

[Theory]
[InlineData("Robert", "R163")]
[InlineData("robeRT", "R163")]
public void HandlesCaseSensitiveCharacters(string name, string expectedSoundex)
{
    // Act
    string actualSoundex = Soundex.GenerateSoundex(name);

    // Assert
    Assert.Equal(expectedSoundex, actualSoundex);
}

[Theory]
[InlineData("1234", "0000")]
[InlineData("#$% ^&", "0000")]
public void HandlesOnlyNonAlphabeticCharacters(string name, string expectedSoundex)
{
    // Act
    string actualSoundex = Soundex.GenerateSoundex(name);

    // Assert
    Assert.Equal(expectedSoundex, actualSoundex);
}

[Theory]
[InlineData("J@hn", "J500")]
[InlineData("Alex1nderSmith", "A425")]
public void HandlesNameWithSpecialCharacters(string name, string expectedSoundex)
{
    // Act
    string actualSoundex = Soundex.GenerateSoundex(name);

    // Assert
    Assert.Equal(expectedSoundex, actualSoundex);
}

[Theory]
[InlineData("Aaaa", "A000")]
[InlineData("Danna", "D500")]
public void HandlesNamesWithRepeatedCharacters(string name, string expectedSoundex)
{
    // Act
    string actualSoundex = Soundex.GenerateSoundex(name);

    // Assert
    Assert.Equal(expectedSoundex, actualSoundex);
}

[InlineData("AEIOU", "0000")]
[InlineData("I", "I000")]
[InlineData("EAOUI", "I000")]
public void HandlesNamesWithAllVowels(string name, string expectedSoundex)
{
    // Act
    string actualSoundex = Soundex.GenerateSoundex(name);

    // Assert
    Assert.Equal(expectedSoundex, actualSoundex);
}

[Theory]
[InlineData("Oli", "O400")]      
[InlineData("Uri", "U650")]      
[InlineData("Oce", "O020")]
[InlineData("ABACAB", "A120")]
public void HandlesNamesWithConsonantAndVowels(string name, string expectedSoundex)
{
    // Act
    string actualSoundex = Soundex.GenerateSoundex(name);

    // Assert
    Assert.Equal(expectedSoundex, actualSoundex);
}
[Theory]
[InlineData(" Samuel", "S540")]
[InlineData("Samuel ", "S540")]
[InlineData("Sam uel", "S540")]
public void HandlesSpacesBetweenString(string name, string expectedSoundex)
{
    // Act
    string actualSoundex = Soundex.GenerateSoundex(name);

    // Assert
    Assert.Equal(expectedSoundex, actualSoundex);
}




[Theory]
[InlineData("1234", "0000")]

[Theory]
[InlineData("Robert", "R163")]
[InlineData("Alex", "A302")]
public void HandlesCorrectEntry(string name, string expectedSoundex)
{
    // Act
    string actualSoundex = Soundex.GenerateSoundex(name);

    // Assert
    Assert.Equal(expectedSoundex, actualSoundex);
}

   
}
