    //------------------------------------------------------------------------------ 
    // <copyright file="FieldCreator.cs" company="Florian Wolters"> 
    //     Copyright (c) Florian Wolters. All rights reserved. 
    // </copyright> 
    // <author>Florian Wolters &lt;wolters.fl@gmail.com&gt;</author> 
    //------------------------------------------------------------------------------ 
    namespace FlorianWolters.Office.Word.Fields 
    { 
      using System; 
      using System.Collections; 
      using System.Runtime.InteropServices; 
      using Word = Microsoft.Office.Interop.Word; 
  
      /// <summary> 
      /// The class <see cref="FieldCreator"/> simplifies the creation of <see cref="Word.Field"/>s. 
      /// </summary> 
      public class FieldCreator 
      { 
         /// <summary> 
         /// Adds one or more new <see cref="Word.Field"/> to the specified <see cref="Word.Range"/>. 
         /// <para> 
         /// This method allows to insert nested fields at the specified range. 
         /// </para> 
         /// <example> 
         /// <c>InsertField(Application.Selection.Range, {{= {{PAGE}} - 1}};</c> 
         /// will produce 
         /// { = { PAGE } - 1 } 
         /// </example> 
         /// </summary> 
         /// <param name="range">The <see cref="Word.Range"/> where to add the <see cref="Word.Field"/>.</param> 
         /// <param name="theString">The string to convert to one or more <see cref="Word.Field"/> objects.</param> 
         /// <param name="fieldOpen">The special code to mark the start of a <see cref="Word.Field"/>.</param> 
         /// <param name="fieldClose">The special code to mark the end of a <see cref="Word.Field"/>.</param> 
         /// <returns>The newly created <see cref="Word.Field"/></returns> 
         /// <remarks> 
         /// A solution for VBA has been taken from <a href="http://stoptyping.co.uk/word/nested-fields-in-vba">this</a> 
         /// article and adopted for C# by the author. 
         /// </remarks> 
         public Word.Field InsertField( 
             Word.Range range, 
             string theString = "{{}}", 
             string fieldOpen = "{{", 
             string fieldClose = "}}") 
         { 
             if (null == range) 
             { 
                 throw new ArgumentNullException("range"); 
             } 
 
             if (string.IsNullOrEmpty(fieldOpen)) 
             { 
                 throw new ArgumentException("fieldOpen"); 
             }  
 
             if (string.IsNullOrEmpty(fieldClose)) 
             { 
                 throw new ArgumentException("fieldClose"); 
             } 
 
             if (!theString.Contains(fieldOpen) || !theString.Contains(fieldClose)) 
             { 
                 throw new ArgumentException("theString"); 
             } 
 
             // Special case. If we do not check this, the algorithm breaks. 
             if (theString == fieldOpen + fieldClose) 
             { 
                 return this.InsertEmpty(range); 
             } 
 
             // TODO Implement additional error handling. 
             // TODO Possible to remove the dependency to state capture? 
             using (new StateCapture(range.Application.ActiveDocument)) 
             { 
                 Word.Field result = null; 
                 Stack fieldStack = new Stack(); 
 
                 range.Text = theString; 
                 fieldStack.Push(range); 
 
                 Word.Range searchRange = range.Duplicate; 
                 Word.Range nextOpen = null; 
                 Word.Range nextClose = null; 
                 Word.Range fieldRange = null; 
 
                 while (searchRange.Start != searchRange.End) 
                 { 
                     nextOpen = this.FindNextOpen(searchRange.Duplicate, fieldOpen); 
                     nextClose = this.FindNextClose(searchRange.Duplicate, fieldClose); 
 
                     if (null == nextClose) 
                     { 
                         break; 
                     } 
 
                     // See which marker comes first. 
                     if (nextOpen.Start < nextClose.Start) 
                     { 
                         nextOpen.Text = string.Empty; 
                         searchRange.Start = nextOpen.End; 
 
                         // Field open, so push a new range to the stack. 
                         fieldStack.Push(nextOpen.Duplicate); 
                     } 
                     else 
                     { 
                         nextClose.Text = string.Empty; 
 
                         // Move start of main search region onwards past the end marker. 
                         searchRange.Start = nextClose.End; 
 
                         // Field close, so pop the last range from the stack and insert the field. 
                         fieldRange = (Word.Range)fieldStack.Pop(); 
                         fieldRange.End = nextClose.End; 
                         result = this.InsertEmpty(fieldRange); 
                     } 
                 } 
 
                 // Move the current selection after all inserted fields. 
                 // TODO Improvement possible, e.g. by using another range object? 
                 int newPos = fieldRange.End + fieldRange.Fields.Count + 1; 
                 fieldRange.SetRange(newPos, newPos); 
                 fieldRange.Select(); 
                 // Update the result of the outer field object. 
                 result.Update(); 
 
 
                 return result; 
             } 
         } 
 
         /// <summary> 
         /// Adds a new empty <see cref="Word.Field"/> to the specified <see cref="Word.Range"/>. 
         /// </summary> 
         /// <param name="range">The <see cref="Word.Range"/> where to add the <see cref="Word.Field"/>.</param> 
         /// <param name="preserveFormatting"> 
         /// Whether to apply the formatting of the previous <see cref="Word.Field"/> result to the new result. 
         /// </param> 
         /// <returns>The newly created <see cref="Word.Field"/>.</returns> 
         public Word.Field InsertEmpty(Word.Range range, bool preserveFormatting = false) 
         { 
             Word.Field result = this.AddFieldToRange(range, Word.WdFieldType.wdFieldEmpty, preserveFormatting); 
 
             // Show the field codes of an empty field, because otherwise we can't be sure that it is visible. 
             result.ShowCodes = true; 
 
             return result; 
         } 
 
         /// <summary> 
         /// Creates a <see cref="Word.Field"/> and adds it to the specified <see cref="Word.Range"/> 
         /// </summary> 
         /// <remarks> 
         /// The <see cref="Word.Field"/> is added to the <see cref="Word.Fields"/> collection of the specified <see 
         /// cref="Word.Range"/>. 
         /// </remarks> 
         /// <param name="range">The <see cref="Word.Range"/> where to add the <see cref="Word.Field"/>.</param> 
         /// <param name="type">The type of <see cref="Word.Field"/> to create.</param> 
         /// <param name="preserveFormatting"> 
         /// Whether to apply the formatting of the previous field result to the new result. 
         /// </param> 
         /// <param name="text">Additional text needed for the <see cref="Word.Field"/>.</param> 
         /// <returns>The newly created <see cref="Word.Field"/>.</returns> 
         private Word.Field AddFieldToRange( 
             Word.Range range, 
             Word.WdFieldType type, 
             bool preserveFormatting = false, 
             string text = null) 
         { 
             return range.Fields.Add( 
                 range, 
                 type, 
                 (null == text) ? Type.Missing : text, 
                 preserveFormatting); 
         } 
 
         private Word.Range FindNextOpen(Word.Range range, string text) 
         { 
             Word.Find find = this.CreateFind(range, text); 
             Word.Range result = range.Duplicate; 
 
             if (!find.Found) 
             { 
                 // Make sure that the next closing field will be found first. 
                 result.Collapse(Word.WdCollapseDirection.wdCollapseEnd); 
             } 
 
             return result; 
         } 
 
         private Word.Range FindNextClose(Word.Range range, string text) 
         { 
             return this.CreateFind(range, text).Found ? range.Duplicate : null; 
         } 
 
         private Word.Find CreateFind(Word.Range range, string text) 
         { 
             Word.Find result = range.Find; 
             result.Execute(FindText: text, Forward: true, Wrap: Word.WdFindWrap.wdFindStop); 
 
             return result; 
         } 
      } 
    } 
