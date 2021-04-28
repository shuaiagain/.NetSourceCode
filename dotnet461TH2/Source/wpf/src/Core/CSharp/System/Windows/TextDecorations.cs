//---------------------------------------------------------------------------
//
// <copyright file=GlyphInfoList.cs company=Microsoft>
//    Copyright (C) Microsoft Corporation.  All rights reserved.
// </copyright>
// 
//
// Description: TextDecorations class
//
// History:
//   11/18/2003 garyyang   Created
//   10/14/2004 garyyang   Refactored: The class becomes static and contains
//                         only well-known text decoration definitions
//
//---------------------------------------------------------------------------

namespace System.Windows 
{
    /// <summary>
    /// TextDecorations class contains a set of commonly used text decorations such as underline, 
    /// strikethrough, baseline and over-line.
    /// </summary>

    public static class TextDecorations
    {     

        static TextDecorations()
        {
            // Init Underline            
            TextDecoration td = new TextDecoration();
            td.Location       = TextDecorationLocation.Underline;
            underline         = new TextDecorationCollection();
            underline.Add(td);
            underline.Freeze();

            // Init strikethrough
            td = new TextDecoration();
            td.Location       = TextDecorationLocation.Strikethrough;
            strikethrough     = new TextDecorationCollection();
            strikethrough.Add(td);
            strikethrough.Freeze();
            
            // Init overline
            td = new TextDecoration();
            td.Location       = TextDecorationLocation.OverLine;
            overLine          = new TextDecorationCollection();
            overLine.Add(td);
            overLine.Freeze();

            // Init baseline
            td = new TextDecoration();
            td.Location       = TextDecorationLocation.Baseline;
            baseline          = new TextDecorationCollection();
            baseline.Add(td);
            baseline.Freeze();            
        }
        
        //---------------------------------
        // Public properties
        //---------------------------------
      
        /// <summary>
        /// returns a frozen collection containing an underline
        /// </summary>
        public static TextDecorationCollection Underline
        {
            get 
            {
                return underline;
            }
        }
        

        /// <summary>
        /// returns a frozen collection containing a strikethrough
        /// </summary>
        public static TextDecorationCollection Strikethrough
        {
            get
            {
                return strikethrough;
            }
        }

        /// <summary>
        /// returns a frozen collection containing an overline
        /// </summary>
        public static TextDecorationCollection OverLine
        {
            get
            {
                return overLine;
            }
        }
        
        /// <summary>
        /// returns a frozen collection containing a baseline
        /// </summary>
        public static TextDecorationCollection Baseline
        {
            get
            {
                return baseline;
            }
        }

        //--------------------------------
        // Private members
        //--------------------------------

        private static readonly TextDecorationCollection underline;
        private static readonly TextDecorationCollection strikethrough;
        private static readonly TextDecorationCollection overLine;
        private static readonly TextDecorationCollection baseline;
    }
}
