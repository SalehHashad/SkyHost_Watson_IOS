using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class CustomTextFunctions
{
    public static TextGenerator GetTextGenerator(Text textUI, string text)
    {
        textUI.text = text; // set the text for the text element  
                            // Define an object of type TextGenerator, which will contain the information
        TextGenerator textGenerator = new TextGenerator();
        // we know another object that will contain the dimensions of the text element in the interface
        // The reason is that the number of new lines required depends on the available space
        TextGenerationSettings generationSettings =
      textUI.GetGenerationSettings(textUI.rectTransform.rect.size);
        // We provide text and settings for textGenerator, //
        // to count the number of lines and so on,
        // by the Populate function
        textGenerator.Populate(text, generationSettings);
        // Returns the object containing the requested information
        return textGenerator;
    }

    public static string FixArabicUITextLines(this Text textUIItem, bool useTashkeel, bool hinduNumbers,
      string text)
    {
        textUIItem.text = text;
        TextGenerator textGenerator = GetTextGenerator(textUIItem, text);

        string reversedText = "";
        string tempLine;
        // Loop, as many lines as there are
        for (int i = 0; i < textGenerator.lineCount; i++)
        {
            // Unfortunately, the text for each line is not directly provided
            // We must extract it by ourselves ^ _ ^
            // we'll get the starting and ending position for each line, and then subtract it from the original text
            // The starting location for the line is simply:
            int startIndex = textGenerator.lines[i].startCharIdx;
            // As for the end location: 
            // if we haven't reached the last line yet
            int endIndex = i < textGenerator.lines.Count - 1 ?
              // we get the end-of-line location from the start-of-line location:
              textGenerator.lines[i + 1].startCharIdx :
              // But on the last line, we'll get it from the length of the full text:
              textUIItem.text.Length;
            // get the text of the current line, which is defined by the start and end locations
            // Substring truncates a piece of text 
            // based on starting location and height
            tempLine = textUIItem.text.Substring(startIndex, endIndex - startIndex);
            // we fix this line and then add it to the final mirrored text
            reversedText += ArabicSupport.ArabicFixer.Fix(tempLine, useTashkeel, hinduNumbers).Trim('\n');
            reversedText += Environment.NewLine; // We separate each line with an enter
        }

        return reversedText;
    }
}
